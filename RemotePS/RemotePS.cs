using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using PowerSupply;
using PowerSupply.xantrax_response;
using Ivi.Visa.Interop;

namespace RemotePS
{
    public partial class RemotePS : Form
    {
        #region members
        private xantrax powerSupply;
        private keithley powerSupplyKeithley;
        private float voltage;
        private float current;
        private string file_log;
        private FileStream file_stream_log;
        private BinaryWriter binary_writer_log;
        #endregion
        public RemotePS()
        {
            InitializeComponent();

            this.GetSerialPorts();
            this.GetIVIDevices();
            this.SetConnectProperty(false);
            this.powerSupply = new xantrax(this);
            this.powerSupply.ResponseID += this.ID_RespHander;
            this.powerSupply.ResponseVoltage += this.Voltage_RespHandler;
            this.powerSupply.ResponseCurrent += this.Current_RespHandler;

            this.powerSupplyKeithley = new keithley(this);
        }

        #region Helpers
        private void GetSerialPorts()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            cboPorts.Items.Clear();
            cboPorts.Text = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            if (ArrayComPortsNames.GetUpperBound(0) >= 0) {
                do {
                    index += 1;
                    cboPorts.Items.Add(ArrayComPortsNames[index]);
                }
                while (!( ( ArrayComPortsNames[index] == ComPortName ) ||
                      ( index == ArrayComPortsNames.GetUpperBound(0) ) ));
                Array.Sort(ArrayComPortsNames);
                if (index == ArrayComPortsNames.GetUpperBound(0)) {
                    ComPortName = ArrayComPortsNames[0];
                }
                cboPorts.Text = ArrayComPortsNames[0];
            }
        }

        private void GetIVIDevices()
        {
            string[] ArrayIVIDevices = null;
            int index = -1;
            string IVI_deviceName = null;
            ResourceManager resourceManager = new ResourceManager();
            ArrayIVIDevices = resourceManager.FindRsrc("(USB)?*");

            cbo_IVI_devices.Items.Clear();
            cbo_IVI_devices.Text = null;
            if(ArrayIVIDevices.GetUpperBound(0) >= 0) {
                do {
                    index += 1;
                    cbo_IVI_devices.Items.Add(ArrayIVIDevices[index]);
                }
                while (!( ( ArrayIVIDevices[index] == IVI_deviceName ) ||
                     ( index == ArrayIVIDevices.GetUpperBound(0) ) ));

                if (index == ArrayIVIDevices.GetUpperBound(0)) {
                    IVI_deviceName = ArrayIVIDevices[0];
                }
                cbo_IVI_devices.Text = ArrayIVIDevices[0];
            }
        }

        private void SetConnectProperty(bool isConnected)
        {
            this.cboPorts.Enabled = !isConnected;
            this.btnGetSerialPorts.Enabled = !isConnected;
            this.timer_poll.Enabled = isConnected;
            this.groupBox_main.Enabled = isConnected;
            this.timer_log.Enabled = isConnected;
            this.OpenLogStream();
            this.label_logFilename.Text = "Log File: " + Path.GetFileName(this.file_log);
        }

        private void SetKeithleyConnectProperty(bool isConnected)
        {
            this.timer_keithley_poll.Enabled = isConnected;
            this.groupBox_keithley.Enabled = isConnected;
            this.cbo_IVI_devices.Enabled = !isConnected;
            this.btnGetIVIdevices.Enabled = !isConnected;
        }

        #endregion

        #region Event Handlers
        #region Xantrax Event Handlers
        private void ID_RespHander(object sender, ID_RespArgs e)
        {
            this.Text = e.id + " v0.02";
        }

        private void Voltage_RespHandler(object sender, Voltage_RespArgs e)
        {
            this.voltage = e.voltage;
            this.label_voltage.Text = "voltage: " + e.voltage.ToString("#.000") + " V";
        }

        private void Current_RespHandler(object sender, Current_RespArgs e)
        {
            this.current = e.current;
            this.label_current.Text = "current: " + e.current.ToString("#.000") + " A";
        }
        #endregion
        #region Button Event Handlers
        private void btnGetSerialPorts_Click(object sender, EventArgs e)
        {
            this.GetSerialPorts();
        }

        private void btnGetIVIdevices_Click(object sender, EventArgs e)
        {
            this.GetIVIDevices();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect") {
                try {
                    this.powerSupply.Connect(this.cboPorts.Text);
                    this.powerSupply.GetID();
                    this.powerSupply.GetID();
                    this.powerSupply.GetErr();
                    this.powerSupply.SetOutput(false);
                    btnConnect.Text = "Disconnect";
                    this.SetConnectProperty(true);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else if (btnConnect.Text == "Disconnect") {
                try {
                    btnConnect.Text = "Connect";

                    this.SetConnectProperty(false);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnKeithleyConnect_Click(object sender, EventArgs e)
        {
            if (btnKeithleyConnect.Text == "Connect") {
                try {
                    this.powerSupplyKeithley.Connect(cbo_IVI_devices.Text);
                    this.lbl_KeithleyDevice.Text = "IDN: " + this.powerSupplyKeithley.GetID();
                    this.btn_set_ch1_Click(sender, e);
                    this.btn_set_ch2_Click(sender, e);
                    this.btn_set_ch3_Click(sender, e);
                    this.powerSupplyKeithley.OutputEnable(false);
                    btnKeithleyConnect.Text = "Disconnect";
                    this.SetKeithleyConnectProperty(true);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else {
                try {
                    this.powerSupplyKeithley.Disconnect();
                    btnKeithleyConnect.Text = "Connect";
                    this.powerSupplyKeithley.OutputEnable(false); 
                    this.SetKeithleyConnectProperty(false);
                    this.lbl_KeithleyDevice.Text = "IDN: ----";
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #endregion


        private void timer_poll_Tick(object sender, EventArgs e)
        {
            this.powerSupply.GetVoltage();
            this.powerSupply.GetCurrent();
        }

        private void timer_keithley_poll_Tick(object sender, EventArgs e)
        {
            float tmpValf32;

            tmpValf32 = this.powerSupplyKeithley.GetVoltage(0);
            lbl_voltage_ch1.Text = "voltage: " + tmpValf32.ToString("0.00") + " V";
            tmpValf32 = this.powerSupplyKeithley.GetCurrent(0);
            lbl_current_ch1.Text = "current: " + tmpValf32.ToString("0.00") + " A";

            tmpValf32 = this.powerSupplyKeithley.GetVoltage(1);
            lbl_voltage_ch2.Text = "voltage: " + tmpValf32.ToString("0.00") + " V";
            tmpValf32 = this.powerSupplyKeithley.GetCurrent(1);
            lbl_current_ch2.Text = "current: " + tmpValf32.ToString("0.00") + " A";

            tmpValf32 = this.powerSupplyKeithley.GetVoltage(2);
            lbl_voltage_ch3.Text = "voltage: " + tmpValf32.ToString("0.00") + " V";
            tmpValf32 = this.powerSupplyKeithley.GetCurrent(2);
            lbl_current_ch3.Text = "current: " + tmpValf32.ToString("0.00") + " A";
        }


        private void button_setVoltage_Click(object sender, EventArgs e)
        {
            try {
                float voltage = Convert.ToSingle(textBox_voltage.Text);
                this.powerSupply.SetVoltage(voltage);
                float current = Convert.ToSingle(textBox_current.Text);
                this.powerSupply.SetCurrent(current);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_on_off_Click(object sender, EventArgs e)
        {
            if(button_on_off.Text == "ON") {
                this.powerSupply.SetOutput(true);
                button_on_off.Text = "OFF";
                int interval = Convert.ToInt32(textBox_logInterval.Text) * 1000;
                if (interval < 300) {
                    interval = 300;
                }
                this.timer_log.Interval = interval;
            } else {
                this.powerSupply.SetOutput(false);
                button_on_off.Text = "ON";
            }
        }

        #region Logging
        private void OpenLogStream()
        {
            // Close and create new stream
            this.CloseLogStream();
            this.file_log = this.GenerateFileName("PowerSupply");
            this.file_stream_log = new FileStream(this.file_log, FileMode.Append, FileAccess.Write, FileShare.Read);
            this.binary_writer_log = new BinaryWriter(this.file_stream_log);
        }

        private void CloseLogStream()
        {
            if (null != this.binary_writer_log) {
                this.binary_writer_log.Flush();
                this.binary_writer_log.Close();
                this.binary_writer_log = null;
            }

            if (null != this.file_stream_log) {
                this.file_stream_log.Close();
                this.file_stream_log = null;
            }
        }
        private string GenerateFileName(string name)
        {
            // Filename: MotorX_YYYYMMDD_HHMMSS.csv
            DateTime dateTimeStamp = DateTime.Now;
            string streamFileName = Path.Combine(Environment.CurrentDirectory, name + "_" +
                            dateTimeStamp.Year.ToString("D4") +
                            dateTimeStamp.Month.ToString("D2") +
                            dateTimeStamp.Day.ToString("D2") + "_" +
                            dateTimeStamp.Hour.ToString("D2") +
                            dateTimeStamp.Minute.ToString("D2") +
                            dateTimeStamp.Second.ToString("D2") + ".csv");
            return streamFileName;

        }
        #endregion

        private void timer_log_Tick(object sender, EventArgs e)
        {
            if (this.binary_writer_log != null) {
                DateTime timestamp = DateTime.Now;
                var msTimestamp = ( ( ( ( ( timestamp.Hour * 60 ) + timestamp.Minute ) * 60 ) + timestamp.Second ) * 1000 ) + timestamp.Millisecond;
                string logString = DateTime.Now.ToString() + ", ";
                logString += this.voltage.ToString("#.000") + ", ";
                logString += this.current.ToString("#.000") + ", ";
                logString += Environment.NewLine;
                this.binary_writer_log.Write(Encoding.Default.GetBytes(logString));
            }
        }

        private void btn_Keithley_output_Click(object sender, EventArgs e)
        {
            if(btn_Keithley_output.Text == "ON") {
                this.powerSupplyKeithley.OutputEnable(true);
                btn_Keithley_output.Text = "OFF";
            } else {
                this.powerSupplyKeithley.OutputEnable(false);
                btn_Keithley_output.Text = "ON";
            }
        }

        private void ConfigChannel(byte channel, float voltage, float current)
        {
            if(channel < 3) {
                this.powerSupplyKeithley.SetVoltage(channel, voltage);
                this.powerSupplyKeithley.SetCurrent(channel, current);
            }
        }
        private void btn_set_ch1_Click(object sender, EventArgs e)
        {
            float voltage;
            float current;
            try {
                voltage = Convert.ToSingle(textBox_voltage_ch1.Text);
                current = Convert.ToSingle(textBox_current_ch1.Text);
                this.ConfigChannel(0, voltage, current);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_set_ch2_Click(object sender, EventArgs e)
        {
            float voltage;
            float current;
            try {
                voltage = Convert.ToSingle(textBox_voltage_ch2.Text);
                current = Convert.ToSingle(textBox_current_ch2.Text);
                this.ConfigChannel(1, voltage, current);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_set_ch3_Click(object sender, EventArgs e)
        {
            float voltage;
            float current;
            try {
                voltage = Convert.ToSingle(textBox_voltage_ch3.Text);
                current = Convert.ToSingle(textBox_current_ch3.Text);
                this.ConfigChannel(2, voltage, current);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKeithleyReset_Click(object sender, EventArgs e)
        {
            this.powerSupplyKeithley.Reset();
        }
    }
}
