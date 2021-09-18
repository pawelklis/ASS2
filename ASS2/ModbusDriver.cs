
using EasyModbus;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASS2
{
    public class ModbusDriver
    {

        ModbusIpMaster master;

        public event EventHandler<ModbusValueEventArgs> CoilValueChanged;
        public event EventHandler ModbusConnected;
        public event EventHandler ModbusDisconnected;
        private Timer timer { get; set; }
        private Timer ReconnectTimer { get; set; }
        private string clientip { get; set; }
        private int clientport { get; set; }
        private Dictionary<int, bool> Coils { get; set; }

        public bool Connected;

        public SensorStartDetectionType StartDetectionSensor;
        public SensorStartParcelType StartParcelSensor;
        public StopSensorType StopSensor;
        public TactSensorType TactSensor;
        public ModbusDriver()
        {


        }




        public void ConnectClient(string ip, int port)
        {
            clientip = ip;
            clientport = port;

            try
            {
                TcpClient client = new TcpClient(ip, port);
                master = ModbusIpMaster.CreateIp(client);
                ReconnectTimer?.Stop();
                ConnectionChange(true);
            }

            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }



        private void StartReconnectTimer()
        {
            Connected = false;
            ReconnectTimer?.Stop();
            ReconnectTimer = new Timer();
            ReconnectTimer.Interval = 5000;
            ReconnectTimer.Elapsed += ReconnectTimer_Elapsed;
            ReconnectTimer.Start();
        }

        private void ReconnectTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ConnectClient(clientip, clientport);
        }
        


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ReadDigitalInputsAsync();
        }

        private async void ReadDigitalInputsAsync()
        {


            try
            {
                await Task.Run(new Action(() =>
                {

                    bool[] rr = master.ReadInputsAsync(0, 4).Result;

                    if (StartDetectionSensor != null)
                        StartDetectionSensor.Value = rr[0];
                    if (StartParcelSensor != null)
                        StartParcelSensor.Value = rr[1];
                    if (TactSensor != null)
                        TactSensor.Value = rr[2];
                    if (StopSensor != null)
                        StopSensor.Value = rr[3];

                }));
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233088)
                    ConnectionChange(false);

                ErrorLog.SaveError(ex);
            }

        }



        public void WriteCoils(int startingAddress, bool[] values)
        {
            Task.Run(new Action(() =>
            {
                try
                {
                    if (startingAddress + values.Length < 65)
                        master.WriteMultipleCoils((ushort)startingAddress, values);
                }

                catch (Exception ex)
                {
                    ErrorLog.SaveError(ex);
                }
            }));
        }


        private void ConnectionChange(bool connected)
        {
            try
            {
                if (connected)
                {
                    timer?.Stop();
                    timer = new Timer();
                    timer.Interval = 100;
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();


                    Connected = true;
                }
                else
                {
                    timer.Stop();

                    StartReconnectTimer();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }
        private void Client_ConnectedChanged(object sender)
        {
            try
            {
                ModbusClient cl = (ModbusClient)sender;
                if (cl.Connected == true)
                {
                    timer?.Stop();
                    timer = new Timer();
                    timer.Interval = 200;
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();

                    ////Console.WriteLine("Modbus connected");
                    ///
                    EventHandler handler = ModbusConnected;
                    handler?.Invoke(this, null);
                    Connected = true;
                }
                else
                {

                    timer.Stop();
                    //.WriteLine("Modbus connection lost");
                    EventHandler handler = ModbusDisconnected;
                    handler?.Invoke(this, null);
                    StartReconnectTimer();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.SaveError(ex);
            }

        }


        public class ModbusValueEventArgs
        {
            public int Address { get; set; }
            public bool OldValue { get; set; }
            public bool NewValue { get; set; }
            public string Name { get; set; }
        }
    }
}
