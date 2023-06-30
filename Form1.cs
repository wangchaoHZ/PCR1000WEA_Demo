using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KiKuSuiPowerSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient KiKuSuiTcpClient = null;
        NetworkStream KiKuSuiNetStream;
        private string KiKuSuiWebServerAddress = "192.168.1.127";
        private int KiKuSuiWebServerPort = 5024;

        private string HistoryCmdValue = string.Empty;
        private float PowerMaxOutLimitValue;
        private float PowerCurrentSetValue;

        /**
         *  CMD List
         */
        private const string VOLT_RANGE = "VOLT:RANG 322\n";
        private const string OUTP_CLOSE = "OUTP OFF\n";
        private const string OUTP_START = "OUTP ON\n";
        private const string VOLT_DC_SET = "VOLT:OFFS ";


        private string SetVoltSendValue(string value)
        {
            return VOLT_DC_SET + value + "\n";
        }
        private bool SendSCPICommand(string cmd)
        {
            string message = cmd + "\n";
            byte[] data = Encoding.ASCII.GetBytes(message);
            KiKuSuiNetStream.Write(data, 0, data.Length);
            Thread.Sleep(300);
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ConnHandle.Text.Contains("连接"))
            {
                ConnHandle.Text = "断开设备";
                LogTextBox.Clear();

                KiKuSuiTcpClient = new TcpClient();
                KiKuSuiTcpClient.Connect(KiKuSuiWebServerAddress, KiKuSuiWebServerPort);
                KiKuSuiNetStream = KiKuSuiTcpClient.GetStream();

                // Set Volt Range
                SendSCPICommand(VOLT_RANGE);
                LogTextBox.Text = LogTextBox.Text + "电源输出能力: 0-450V\n";

                // Set close output
                SendSCPICommand(OUTP_CLOSE);
                LogTextBox.Text = LogTextBox.Text + "电源输出关闭\n";

                // Set Volt 0
                SendSCPICommand(SetVoltSendValue("0"));
                LogTextBox.Text = LogTextBox.Text + "电源输出设置：0V\n";
                // Wait 0.3s
                Thread.Sleep(300);

                // Set close output
                SendSCPICommand(OUTP_START);
                LogTextBox.Text = LogTextBox.Text + "电源输出开启\n";

                LogTextBox.Text = LogTextBox.Text + "电源连接成功\n";
            }
            else if (ConnHandle.Text.Contains("断开"))
            {
                ConnHandle.Text = "连接设备";
                // Set close output
                SendSCPICommand(OUTP_CLOSE);
                LogTextBox.Text = LogTextBox.Text + "电源输出关闭\n";
                KiKuSuiTcpClient.Close();
                LogTextBox.Text = LogTextBox.Text + "\n电源已断开\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "通信协议：SCPI协议  IP地址: 192.168.1.127  端口: 5024";
            MaxOutTextBox.Text = "24";
            PowerSetTextBox.Text = string.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (float.TryParse(MaxOutTextBox.Text, out PowerMaxOutLimitValue))
            {
                if (PowerMaxOutLimitValue > 450.0)
                {
                    PowerMaxOutLimitValue = (float)450.0;
                }
            }
            else
            {
                MessageBox.Show("设置输出限值错误, 是不是有效数字");
                return;
            }
            PowerSetTextBox.Text = PowerSetTextBox.Text.Replace("。", ".");
            if (float.TryParse(PowerSetTextBox.Text, out PowerCurrentSetValue))
            {
                if (ConnHandle.Text.Contains("连接"))
                {
                    MessageBox.Show("请先连接设备.");
                    PowerSetTextBox.Text = string.Empty;
                    return;
                }

                if (PowerCurrentSetValue > PowerMaxOutLimitValue)
                {
                    MessageBox.Show("输入超限制，最大输出：" + PowerMaxOutLimitValue.ToString());
                    //return;//
                    PowerSetTextBox.Text = PowerMaxOutLimitValue.ToString();
                }

                if (HistoryCmdValue != PowerSetTextBox.Text)
                {
                    HistoryCmdValue = PowerSetTextBox.Text;
                    SendSCPICommand(SetVoltSendValue(PowerCurrentSetValue.ToString()));
                    LogTextBox.Text = LogTextBox.Text + "电源输出设置：" + PowerCurrentSetValue.ToString() + "V";
                }
            }
            // 
            LogTextBox.SelectionStart = LogTextBox.Text.Length;
            LogTextBox.ScrollToCaret();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LogTextBox.Text = string.Empty;
            string helpInfo = "1. 网线连接电源后LAN口\r\n\r\n2. 网线另一端连接电脑网口\r\n\r\n3. 设置电脑IPv4地址:192.168.1.123\r\n\r\n4. 子网掩码:255.255.255.0\r\n\r\n5. 点击连接设备\r\n\r\n6. 设置输出电压";
            LogTextBox.Text = helpInfo;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(MaxOutTextBox.Text, out PowerMaxOutLimitValue))
            {
                if (PowerMaxOutLimitValue > 450.0)
                {
                    PowerMaxOutLimitValue = (float)450.0;
                    return;
                }

                if (PowerCurrentSetValue > PowerMaxOutLimitValue)
                {
                    PowerSetTextBox.Text = "0.0";
                    if (ConnHandle.Text.Contains("断开"))
                    {
                        // Set Volt 0
                        SendSCPICommand(SetVoltSendValue("0"));
                        LogTextBox.Text = LogTextBox.Text + "电源输出设置：0V\n";
                    }
                }
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
