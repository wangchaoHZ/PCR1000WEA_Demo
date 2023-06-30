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
            textBox1.Text = string.Empty;
        }

        string serverIP = "192.168.1.127";
        int serverPort = 5024;
        TcpClient client;
        NetworkStream networkStream;

        string LAST_VALUE = string.Empty;


        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text.Contains("连接"))
            {
                button1.Text = "断开设备";
                richTextBox1.Clear();
                client = new TcpClient();
                client.Connect(serverIP, serverPort);

                networkStream = client.GetStream();
                string message = "VOLT:RANG 322\n";
                byte[] data = Encoding.ASCII.GetBytes(message);
                // 发送消息到服务器
                networkStream.Write(data, 0, data.Length);

                byte[] buffer = new byte[256];
                int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                response =  response.Replace("SCPI>", "SCPI> OK");
                richTextBox1.Text = richTextBox1.Text + response;
                Thread.Sleep(300);

                message = "OUTP OFF\n";
                data = Encoding.ASCII.GetBytes(message);
                // 发送消息到服务器
                networkStream.Write(data, 0, data.Length);
                Thread.Sleep(300);

                message = "VOLT:OFFS 0\n";
                data = Encoding.ASCII.GetBytes(message);
                // 发送消息到服务器
                networkStream.Write(data, 0, data.Length);
                //buffer = new byte[256];
                //bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                //response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                //richTextBox1.Text = richTextBox1.Text + response;
                Thread.Sleep(500);

                message = "OUTP ON\n";
                data = Encoding.ASCII.GetBytes(message);
                // 发送消息到服务器
                networkStream.Write(data, 0, data.Length);

                //buffer = new byte[256];
                //bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                //response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                //richTextBox1.Text = richTextBox1.Text + response;
                richTextBox1.Text = richTextBox1.Text + "\n电源已连接\n";
            }
            else if (button1.Text.Contains("断开"))
            {
                button1.Text = "连接设备";
                string message = "OUTP OFF\n";
                byte[] data = Encoding.ASCII.GetBytes(message);
                // 发送消息到服务器
                networkStream.Write(data, 0, data.Length);
                Thread.Sleep(300);
                byte[] buffer = new byte[256];
                int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                response = response.Replace("SCPI>", "SCPI> OK");
                richTextBox1.Text = richTextBox1.Text + response;
                Thread.Sleep(300);
                client.Close();
                richTextBox1.Text = richTextBox1.Text + "\n电源已断开\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "通信协议：SCPI协议  IP地址: 192.168.1.127  端口: 5024";
            textBox2.Text = "24";
        }


        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        float maxOut;
        float value;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (float.TryParse(textBox2.Text, out maxOut))
            {
                if (maxOut > 450.0)
                {
                    maxOut = (float)450.0;
                }
            }
            else
            {
                MessageBox.Show("设置输出限值错误, 是不是有效数字");
                return;
            }
            textBox1.Text = textBox1.Text.Replace("。", ".");
            if (float.TryParse(textBox1.Text, out value))
            {
                if (button1.Text.Contains("连接"))
                {
                    MessageBox.Show("请先连接设备!!!");
                    textBox1.Text = string.Empty;
                    return;
                }

                if (value > maxOut)
                {
                    MessageBox.Show("输入超限制，最大输出：" + maxOut.ToString());
                    //return;//
                    textBox1.Text = maxOut.ToString();
                }

                if (LAST_VALUE != textBox1.Text)
                {
                    LAST_VALUE = textBox1.Text;
                    richTextBox1.Text = richTextBox1.Text + "\n设置电压:" + value.ToString() + "V";
                    string message = "VOLT:OFFS " + textBox1.Text + "\n";
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    // 发送消息到服务器
                    networkStream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[256];
                    int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    response = response.Replace("SCPI>", "SCPI> OK");
                    richTextBox1.Text = richTextBox1.Text + response;
                }
            }

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
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


        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            string helpInfo = "1. 网线连接电源后LAN口\r\n\r\n2. 网线另一端连接电脑网口\r\n\r\n3. 设置电脑IPv4地址:192.168.1.123\r\n\r\n4. 子网掩码:255.255.255.0\r\n\r\n5. 点击连接设备\r\n\r\n6. 设置输出电压";
            richTextBox1.Text = helpInfo;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out maxOut))
            {
                if (maxOut > 450.0)
                {
                    maxOut = (float)450.0;
                    return;
                }

                if (value > maxOut)
                {
                    textBox1.Text = "0.0";

                    if (button1.Text.Contains("断开"))
                    {
                        string message = "VOLT:OFFS 0\n";
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        // 发送消息到服务器
                        networkStream.Write(data, 0, data.Length);

                        byte[] buffer = new byte[256];
                        int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        response = response.Replace("SCPI>", "SCPI> OK");
                        richTextBox1.Text = richTextBox1.Text + response;
                    }
                }
            }
        }
    }
}
