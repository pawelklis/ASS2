
using EasyModbus;
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

        EasyModbus.ModbusClient Client;
        EasyModbus.ModbusServer Server;
        public event EventHandler<ModbusValueEventArgs> CoilValueChanged;
        public event EventHandler<ModbusValueEventArgs> DigitalInputValueChanged;
        private Timer timer { get; set; }
        private Timer ReconnectTimer { get; set; }
        private string clientip { get; set; }
        private int clientport { get; set; }
        private Dictionary<int,bool> Coils { get; set; }

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
            Client = new ModbusClient();
            try
            {
                ////Console.Clear();

                Client.ConnectedChanged += Client_ConnectedChanged;
                Client.ReceiveDataChanged += Client_ReceiveDataChanged;
                Client.SendDataChanged += Client_SendDataChanged;
                Client.Connect(clientip, clientport);

                ReconnectTimer?.Stop();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Modbus connection error " + ex.Message);
                StartReconnectTimer();
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
                    await Task.Run(new Action(() => {
                        System.Threading.Thread.Sleep(11);
                        Client.ConnectionTimeout = 100;
                        bool[] rr = Client.ReadDiscreteInputs(8, 4);

                        int i = 0;
                        foreach (var c in rr)
                        {
                            if (i == 0)
                                if (StartDetectionSensor != null)
                                    StartDetectionSensor.Value = c;
                            if (i == 1)
                                if (StartParcelSensor != null)
                                    StartParcelSensor.Value = c;
                            if (i == 2)
                                if (TactSensor != null)
                                    TactSensor.Value = c;
                            if (i == 3)
                                if (StopSensor != null)
                                    StopSensor.Value = c;
                            i++;
                        }


                        //if (StartDetectionSensor != null)
                        //    StartDetectionSensor.Value = Client.ReadDiscreteInputs(8, 1)[0];

                        //if (StartParcelSensor != null)
                        //    StartParcelSensor.Value = Client.ReadDiscreteInputs(9, 1)[0];

                        //if (TactSensor != null)
                        //    TactSensor.Value = Client.ReadDiscreteInputs(10, 1)[0];

                        //if (StopSensor != null)
                        //    StopSensor.Value = Client.ReadDiscreteInputs(11, 1)[0];

                    }));
            }
            catch (Exception ex)
            {
                if(ex.HResult!= -2146232800)
                    Client.Disconnect();                
            }
            //Client.WriteMultipleCoils(0, new bool[] { true, true, true, true });
        }

        private async void ReadCoilsAsync()
        {
            try
            {
                await Task.Run(new Action(() =>
                {
                    bool[] cl = Client.ReadCoils(0, 64);



                    int i = 0;
                    foreach (var c in cl)
                    {
                        var x = Coils[i];
                        if (x != c)
                        {
                            ModbusValueEventArgs me = new ModbusValueEventArgs();
                            me.Address = i;
                            me.OldValue = x;
                            me.NewValue = c;
                            EventHandler<ModbusValueEventArgs> handler = CoilValueChanged;
                            handler.Invoke(this, me);
                        }

                        Coils[i] = c;
                        i++;
                    }
                }));
            }
            catch (Exception)
            {
                Client.Disconnect();
            }

        }

        //public void ServerConnect()
        //{
        //    System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");

        //    Server = new ModbusServer();
        //    Server.HoldingRegistersChanged += Server_HoldingRegistersChanged;
        //    Server.LogDataChanged += Server_LogDataChanged;
        //    Server.NumberOfConnectedClientsChanged += Server_NumberOfConnectedClientsChanged;
        //    Server.CoilsChanged += Server_CoilsChanged;
        //    Server.Port = 501;
        //    Server.LocalIPAddress = ip;
        //    Server.Listen();


        //}

        public void WriteCoils(int startingAddress, bool[] values)
        {
            Task.Run(new Action(() => {
                try
                {
                    if (startingAddress + values.Length < 65)
                        Client.WriteMultipleCoils(startingAddress, values);
                }
                catch (Exception ex)
                {
                }
            }));
        }

        #region "ServerEvents"
        

        private void Server_CoilsChanged(int coil, int numberOfCoils)
        {
            
        }

        private void Server_NumberOfConnectedClientsChanged()
        {
            
        }

        private void Server_LogDataChanged()
        {
            
        }

        private void Server_HoldingRegistersChanged(int register, int numberOfRegisters)
        {
            
        }
        #endregion

        private void Client_SendDataChanged(object sender)
        {
           
        }

        private void Client_ReceiveDataChanged(object sender)
        {
            
        }

        private void Client_ConnectedChanged(object sender)
        {
            ModbusClient cl = (ModbusClient)sender;
            if (cl.Connected == true)
            {
                timer?.Stop();
                timer = new Timer();
                timer.Interval = 100;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                ////Console.WriteLine("Modbus connected");
                Connected = true;
            }
            else
            {

                timer.Stop();
                //.WriteLine("Modbus connection lost");
                StartReconnectTimer();
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
