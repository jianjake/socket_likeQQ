namespace MySocket
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSerIP = new System.Windows.Forms.TextBox();
            this.txtSerPort = new System.Windows.Forms.TextBox();
            this.txtSetting = new System.Windows.Forms.TextBox();
            this.btnSerStar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetSave = new System.Windows.Forms.Button();
            this.Ser_mainBox = new System.Windows.Forms.GroupBox();
            this.txtOnlineCount = new System.Windows.Forms.TextBox();
            this.txtSerMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerState = new System.Windows.Forms.TextBox();
            this.btnSerClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listChat = new System.Windows.Forms.ListBox();
            this.btnSetClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Ser_mainBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSerIP
            // 
            this.txtSerIP.Location = new System.Drawing.Point(8, 84);
            this.txtSerIP.Name = "txtSerIP";
            this.txtSerIP.Size = new System.Drawing.Size(115, 21);
            this.txtSerIP.TabIndex = 0;
            this.txtSerIP.Text = "10.15.132.206";
            // 
            // txtSerPort
            // 
            this.txtSerPort.Location = new System.Drawing.Point(8, 137);
            this.txtSerPort.Name = "txtSerPort";
            this.txtSerPort.Size = new System.Drawing.Size(115, 21);
            this.txtSerPort.TabIndex = 1;
            this.txtSerPort.Text = "51112";
            // 
            // txtSetting
            // 
            this.txtSetting.Location = new System.Drawing.Point(6, 12);
            this.txtSetting.Multiline = true;
            this.txtSetting.Name = "txtSetting";
            this.txtSetting.Size = new System.Drawing.Size(467, 116);
            this.txtSetting.TabIndex = 3;
            // 
            // btnSerStar
            // 
            this.btnSerStar.Location = new System.Drawing.Point(12, 316);
            this.btnSerStar.Name = "btnSerStar";
            this.btnSerStar.Size = new System.Drawing.Size(75, 23);
            this.btnSerStar.TabIndex = 4;
            this.btnSerStar.Text = "开启服务器";
            this.btnSerStar.UseVisualStyleBackColor = true;
            this.btnSerStar.Click += new System.EventHandler(this.btnSerStar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "服务器IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "端口:";
            // 
            // btnSetSave
            // 
            this.btnSetSave.Location = new System.Drawing.Point(561, 156);
            this.btnSetSave.Name = "btnSetSave";
            this.btnSetSave.Size = new System.Drawing.Size(75, 23);
            this.btnSetSave.TabIndex = 9;
            this.btnSetSave.Text = "清屏";
            this.btnSetSave.UseVisualStyleBackColor = true;
            this.btnSetSave.Click += new System.EventHandler(this.btnSetSave_Click);
            // 
            // Ser_mainBox
            // 
            this.Ser_mainBox.Controls.Add(this.txtOnlineCount);
            this.Ser_mainBox.Controls.Add(this.txtSerMax);
            this.Ser_mainBox.Controls.Add(this.label5);
            this.Ser_mainBox.Controls.Add(this.label6);
            this.Ser_mainBox.Controls.Add(this.label4);
            this.Ser_mainBox.Controls.Add(this.txtSerState);
            this.Ser_mainBox.Controls.Add(this.txtSerIP);
            this.Ser_mainBox.Controls.Add(this.txtSerPort);
            this.Ser_mainBox.Controls.Add(this.label1);
            this.Ser_mainBox.Controls.Add(this.label2);
            this.Ser_mainBox.Location = new System.Drawing.Point(12, 12);
            this.Ser_mainBox.Name = "Ser_mainBox";
            this.Ser_mainBox.Size = new System.Drawing.Size(200, 291);
            this.Ser_mainBox.TabIndex = 10;
            this.Ser_mainBox.TabStop = false;
            this.Ser_mainBox.Text = "服务器信息";
            // 
            // txtOnlineCount
            // 
            this.txtOnlineCount.Location = new System.Drawing.Point(8, 191);
            this.txtOnlineCount.Name = "txtOnlineCount";
            this.txtOnlineCount.Size = new System.Drawing.Size(115, 21);
            this.txtOnlineCount.TabIndex = 9;
            this.txtOnlineCount.Text = "0";
            // 
            // txtSerMax
            // 
            this.txtSerMax.Location = new System.Drawing.Point(8, 244);
            this.txtSerMax.Name = "txtSerMax";
            this.txtSerMax.Size = new System.Drawing.Size(115, 21);
            this.txtSerMax.TabIndex = 10;
            this.txtSerMax.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "在线人数:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "系统负荷:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "服务器状态:";
            // 
            // txtSerState
            // 
            this.txtSerState.Location = new System.Drawing.Point(8, 32);
            this.txtSerState.Name = "txtSerState";
            this.txtSerState.Size = new System.Drawing.Size(115, 21);
            this.txtSerState.TabIndex = 7;
            this.txtSerState.Text = "关闭";
            // 
            // btnSerClose
            // 
            this.btnSerClose.Location = new System.Drawing.Point(137, 316);
            this.btnSerClose.Name = "btnSerClose";
            this.btnSerClose.Size = new System.Drawing.Size(75, 23);
            this.btnSerClose.TabIndex = 11;
            this.btnSerClose.Text = "关闭服务器";
            this.btnSerClose.UseVisualStyleBackColor = true;
            this.btnSerClose.Click += new System.EventHandler(this.btnSerClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSetting);
            this.groupBox1.Location = new System.Drawing.Point(218, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 138);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器日志";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listChat);
            this.groupBox2.Location = new System.Drawing.Point(224, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 159);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "在线用户管理";
            // 
            // listChat
            // 
            this.listChat.FormattingEnabled = true;
            this.listChat.ItemHeight = 12;
            this.listChat.Location = new System.Drawing.Point(0, 15);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(467, 136);
            this.listChat.TabIndex = 0;
            // 
            // btnSetClear
            // 
            this.btnSetClear.Location = new System.Drawing.Point(249, 156);
            this.btnSetClear.Name = "btnSetClear";
            this.btnSetClear.Size = new System.Drawing.Size(75, 23);
            this.btnSetClear.TabIndex = 14;
            this.btnSetClear.Text = "保存日志";
            this.btnSetClear.UseVisualStyleBackColor = true;
            this.btnSetClear.Click += new System.EventHandler(this.btnSetClear_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 350);
            this.Controls.Add(this.btnSetClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSerClose);
            this.Controls.Add(this.Ser_mainBox);
            this.Controls.Add(this.btnSetSave);
            this.Controls.Add(this.btnSerStar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Ser_mainBox.ResumeLayout(false);
            this.Ser_mainBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSerIP;
        private System.Windows.Forms.TextBox txtSerPort;
        private System.Windows.Forms.TextBox txtSetting;
        private System.Windows.Forms.Button btnSerStar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetSave;
        private System.Windows.Forms.GroupBox Ser_mainBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerState;
        private System.Windows.Forms.TextBox txtOnlineCount;
        private System.Windows.Forms.TextBox txtSerMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSerClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSetClear;
        private System.Windows.Forms.ListBox listChat;
        private System.Windows.Forms.Timer timer1;
    }
}

