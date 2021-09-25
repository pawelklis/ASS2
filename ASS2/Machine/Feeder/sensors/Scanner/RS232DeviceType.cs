using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class RS232DeviceType
    {

        SerialPort _serialPort { get; set; }
    private int delay { get; set; }
    public string Name { get; set; }

        public event EventHandler<SkanerEventArgs> OnDataReceived;
        public class SkanerEventArgs
        {
            public string DataReceived { get; set; }


        }
        public void Disconnect()
        {
            try
            {
                _serialPort.Close();
            }
            catch (Exception)
            {

            }
        }
        public void Connect(string PortName,string name,int speed=9600, int delay=0,bool tact=false)
        {
        this.Name = name;
        this.delay = delay;
            try
            {
              
                    _serialPort = new SerialPort();
                    _serialPort.PortName = PortName;
                    _serialPort.BaudRate = speed;
                    _serialPort.Parity = Parity.None;
                    _serialPort.DataBits = 8;
                    _serialPort.StopBits = StopBits.One;
                    _serialPort.Handshake = Handshake.None;


                    _serialPort.ReadTimeout = 500;
                    _serialPort.WriteTimeout = 500;

            //  _serialPort.DtrEnable = true;
            //  _serialPort.RtsEnable = true;

            if (tact == true)
            {
                _serialPort.DataReceived+= TactDataReceived;
            }
            else
            {
                    _serialPort.DataReceived += DataReceived;
            }

                _serialPort.ErrorReceived += errorrreceived;
                _serialPort.PinChanged += pinchanged;

                    _serialPort.Open();
               
                               
                

            }
            catch (Exception ex)
            {


            }
        }
        public void errorrreceived(object sender, EventArgs e)
        {

        }
        public void pinchanged(object sender, EventArgs e)
        {

        }

    public void TactDataReceived(object sender, EventArgs e)
    {
        string x = _serialPort.ReadExisting();
        if (!string.IsNullOrEmpty(x))
        {
            if (x.Contains("J"))
            {
                SkanerEventArgs args = new SkanerEventArgs();
                args.DataReceived = x;


                EventHandler<SkanerEventArgs> handler = OnDataReceived;
                handler.Invoke(this, args);
            }
        }
    }

    public void DataReceived(object sender, EventArgs e)
    {

        Task.Run(new Action(() =>
        {
            if(delay>0)
                System.Threading.Thread.Sleep(this.delay);

            string message = "";
            string x = _serialPort.ReadExisting();
            if (!string.IsNullOrEmpty(x))
            {
                message = x.Replace("\r", "").Replace("]C1", "").Replace("\n", "");
                if (message != "")
                {
                    if (message.Length < 2)
                        return;

                    message = message.Replace("\r", "").Replace("]C1", "").Replace("\n", "");


                    if (message.Length == 19)
                        message = "0" + message;

                    if (message.Length == 12)
                    {
                        if (message.ToLower().StartsWith("e"))
                            message = "E" + message;
                        if (message.ToLower().StartsWith("p"))
                            message = "C" + message;

                    }


                    SkanerEventArgs args = new SkanerEventArgs();
                    args.DataReceived = message;


                    EventHandler<SkanerEventArgs> handler = OnDataReceived;
                    handler.Invoke(this, args);

                }

            }
        }));




    }


}

