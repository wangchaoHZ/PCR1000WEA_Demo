namespace KiKuSuiPowerSet
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnHandle = new System.Windows.Forms.Button();
            this.PowerSetTextBox = new System.Windows.Forms.TextBox();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxOutTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConnHandle
            // 
            this.ConnHandle.Font = new System.Drawing.Font("等线", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConnHandle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ConnHandle.Location = new System.Drawing.Point(40, 151);
            this.ConnHandle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnHandle.Name = "ConnHandle";
            this.ConnHandle.Size = new System.Drawing.Size(263, 59);
            this.ConnHandle.TabIndex = 0;
            this.ConnHandle.Text = "连接设备";
            this.ConnHandle.UseVisualStyleBackColor = true;
            this.ConnHandle.Click += new System.EventHandler(this.button1_Click);
            // 
            // PowerSetTextBox
            // 
            this.PowerSetTextBox.Font = new System.Drawing.Font("等线", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PowerSetTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PowerSetTextBox.Location = new System.Drawing.Point(529, 180);
            this.PowerSetTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PowerSetTextBox.Multiline = true;
            this.PowerSetTextBox.Name = "PowerSetTextBox";
            this.PowerSetTextBox.Size = new System.Drawing.Size(168, 54);
            this.PowerSetTextBox.TabIndex = 2;
            this.PowerSetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PowerSetTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.PowerSetTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogTextBox.ForeColor = System.Drawing.Color.Navy;
            this.LogTextBox.Location = new System.Drawing.Point(16, 251);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(761, 295);
            this.LogTextBox.TabIndex = 3;
            this.LogTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("等线", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(35, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "通信协议：SCPI协议  IP地址:192.168.1.127 端口:5024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("等线", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(381, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "电压设置:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("等线", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(707, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "V";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(529, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(249, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "点我查看如何使用";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("等线", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(381, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "输出限值:";
            // 
            // MaxOutTextBox
            // 
            this.MaxOutTextBox.Font = new System.Drawing.Font("等线", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaxOutTextBox.ForeColor = System.Drawing.Color.Red;
            this.MaxOutTextBox.Location = new System.Drawing.Point(529, 115);
            this.MaxOutTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaxOutTextBox.Multiline = true;
            this.MaxOutTextBox.Name = "MaxOutTextBox";
            this.MaxOutTextBox.Size = new System.Drawing.Size(168, 54);
            this.MaxOutTextBox.TabIndex = 10;
            this.MaxOutTextBox.Text = "24";
            this.MaxOutTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxOutTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.MaxOutTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("等线", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(707, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 39);
            this.label5.TabIndex = 11;
            this.label5.Text = "V";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 562);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MaxOutTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.PowerSetTextBox);
            this.Controls.Add(this.ConnHandle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智控实验室菊水电源操作工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnHandle;
        private System.Windows.Forms.TextBox PowerSetTextBox;
        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MaxOutTextBox;
        private System.Windows.Forms.Label label5;
    }
}

