
namespace RemotePS
{
    partial class RemotePS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetSerialPorts = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.timer_poll = new System.Windows.Forms.Timer(this.components);
            this.textBox_voltage = new System.Windows.Forms.TextBox();
            this.textBox_current = new System.Windows.Forms.TextBox();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_voltage = new System.Windows.Forms.Label();
            this.label_current = new System.Windows.Forms.Label();
            this.button_setVoltage = new System.Windows.Forms.Button();
            this.button_setCurrent = new System.Windows.Forms.Button();
            this.button_on_off = new System.Windows.Forms.Button();
            this.timer_log = new System.Windows.Forms.Timer(this.components);
            this.label_logFilename = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetSerialPorts);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cboPorts);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication";
            // 
            // btnGetSerialPorts
            // 
            this.btnGetSerialPorts.Location = new System.Drawing.Point(118, 19);
            this.btnGetSerialPorts.Name = "btnGetSerialPorts";
            this.btnGetSerialPorts.Size = new System.Drawing.Size(78, 21);
            this.btnGetSerialPorts.TabIndex = 4;
            this.btnGetSerialPorts.Text = "Refresh";
            this.btnGetSerialPorts.UseVisualStyleBackColor = true;
            this.btnGetSerialPorts.Click += new System.EventHandler(this.btnGetSerialPorts_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(16, 46);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(180, 38);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboPorts
            // 
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(16, 19);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(96, 21);
            this.cboPorts.TabIndex = 5;
            // 
            // timer_poll
            // 
            this.timer_poll.Interval = 300;
            this.timer_poll.Tick += new System.EventHandler(this.timer_poll_Tick);
            // 
            // textBox_voltage
            // 
            this.textBox_voltage.Location = new System.Drawing.Point(82, 23);
            this.textBox_voltage.Name = "textBox_voltage";
            this.textBox_voltage.Size = new System.Drawing.Size(79, 20);
            this.textBox_voltage.TabIndex = 9;
            this.textBox_voltage.Text = "200";
            // 
            // textBox_current
            // 
            this.textBox_current.Location = new System.Drawing.Point(82, 51);
            this.textBox_current.Name = "textBox_current";
            this.textBox_current.Size = new System.Drawing.Size(79, 20);
            this.textBox_current.TabIndex = 9;
            this.textBox_current.Text = "0.50";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.button_on_off);
            this.groupBox_main.Controls.Add(this.button_setCurrent);
            this.groupBox_main.Controls.Add(this.button_setVoltage);
            this.groupBox_main.Controls.Add(this.label_current);
            this.groupBox_main.Controls.Add(this.label2);
            this.groupBox_main.Controls.Add(this.label_voltage);
            this.groupBox_main.Controls.Add(this.label1);
            this.groupBox_main.Controls.Add(this.textBox_current);
            this.groupBox_main.Controls.Add(this.textBox_voltage);
            this.groupBox_main.Location = new System.Drawing.Point(247, 12);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(467, 118);
            this.groupBox_main.TabIndex = 10;
            this.groupBox_main.TabStop = false;
            this.groupBox_main.Text = "Xantrax";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "voltage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "current:";
            // 
            // label_voltage
            // 
            this.label_voltage.AutoSize = true;
            this.label_voltage.Location = new System.Drawing.Point(281, 22);
            this.label_voltage.Name = "label_voltage";
            this.label_voltage.Size = new System.Drawing.Size(57, 13);
            this.label_voltage.TabIndex = 10;
            this.label_voltage.Text = "voltage: ---";
            // 
            // label_current
            // 
            this.label_current.AutoSize = true;
            this.label_current.Location = new System.Drawing.Point(283, 50);
            this.label_current.Name = "label_current";
            this.label_current.Size = new System.Drawing.Size(55, 13);
            this.label_current.TabIndex = 10;
            this.label_current.Text = "current: ---";
            // 
            // button_setVoltage
            // 
            this.button_setVoltage.Location = new System.Drawing.Point(167, 21);
            this.button_setVoltage.Name = "button_setVoltage";
            this.button_setVoltage.Size = new System.Drawing.Size(75, 23);
            this.button_setVoltage.TabIndex = 11;
            this.button_setVoltage.Text = "Set";
            this.button_setVoltage.UseVisualStyleBackColor = true;
            this.button_setVoltage.Click += new System.EventHandler(this.button_setVoltage_Click);
            // 
            // button_setCurrent
            // 
            this.button_setCurrent.Location = new System.Drawing.Point(167, 48);
            this.button_setCurrent.Name = "button_setCurrent";
            this.button_setCurrent.Size = new System.Drawing.Size(75, 23);
            this.button_setCurrent.TabIndex = 11;
            this.button_setCurrent.Text = "Set";
            this.button_setCurrent.UseVisualStyleBackColor = true;
            this.button_setCurrent.Click += new System.EventHandler(this.button_setCurrent_Click);
            // 
            // button_on_off
            // 
            this.button_on_off.Location = new System.Drawing.Point(130, 78);
            this.button_on_off.Name = "button_on_off";
            this.button_on_off.Size = new System.Drawing.Size(193, 31);
            this.button_on_off.TabIndex = 12;
            this.button_on_off.Text = "ON";
            this.button_on_off.UseVisualStyleBackColor = true;
            this.button_on_off.Click += new System.EventHandler(this.button_on_off_Click);
            // 
            // timer_log
            // 
            this.timer_log.Interval = 60000;
            this.timer_log.Tick += new System.EventHandler(this.timer_log_Tick);
            // 
            // label_logFilename
            // 
            this.label_logFilename.AutoSize = true;
            this.label_logFilename.Location = new System.Drawing.Point(76, 139);
            this.label_logFilename.Name = "label_logFilename";
            this.label_logFilename.Size = new System.Drawing.Size(62, 13);
            this.label_logFilename.TabIndex = 11;
            this.label_logFilename.Text = "Log File: ----";
            // 
            // RemotePS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 161);
            this.Controls.Add(this.label_logFilename);
            this.Controls.Add(this.groupBox_main);
            this.Controls.Add(this.groupBox1);
            this.Name = "RemotePS";
            this.Text = "Unknown";
            this.groupBox1.ResumeLayout(false);
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetSerialPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.Timer timer_poll;
        private System.Windows.Forms.TextBox textBox_voltage;
        private System.Windows.Forms.TextBox textBox_current;
        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.Label label_current;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_voltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_setVoltage;
        private System.Windows.Forms.Button button_on_off;
        private System.Windows.Forms.Button button_setCurrent;
        private System.Windows.Forms.Timer timer_log;
        private System.Windows.Forms.Label label_logFilename;
    }
}

