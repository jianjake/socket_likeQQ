namespace Client
{
    partial class Client
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
            if (disposing && (components != null))
            {
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToSer = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCloseSer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFriends = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnShake = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSelFile = new System.Windows.Forms.Button();
            this.richText = new System.Windows.Forms.RichTextBox();
            this.richShow = new System.Windows.Forms.RichTextBox();
            this.btnPic = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "好友列表：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "端口:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "服务器IP:";
            // 
            // btnToSer
            // 
            this.btnToSer.Location = new System.Drawing.Point(6, 129);
            this.btnToSer.Name = "btnToSer";
            this.btnToSer.Size = new System.Drawing.Size(76, 23);
            this.btnToSer.TabIndex = 11;
            this.btnToSer.Text = "连接服务器";
            this.btnToSer.UseVisualStyleBackColor = true;
            this.btnToSer.Click += new System.EventHandler(this.btnToServer_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(122, 96);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "51112";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(122, 64);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 8;
            this.txtIP.Text = "10.15.132.206";
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五",
            "赵六"});
            this.cmbUser.Location = new System.Drawing.Point(122, 32);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(121, 20);
            this.cmbUser.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "选择用户名：";
            // 
            // btnCloseSer
            // 
            this.btnCloseSer.Location = new System.Drawing.Point(166, 129);
            this.btnCloseSer.Name = "btnCloseSer";
            this.btnCloseSer.Size = new System.Drawing.Size(75, 23);
            this.btnCloseSer.TabIndex = 17;
            this.btnCloseSer.Text = "断开服务器";
            this.btnCloseSer.UseVisualStyleBackColor = true;
            this.btnCloseSer.Click += new System.EventHandler(this.btnCloseSer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbUser);
            this.groupBox1.Controls.Add(this.btnCloseSer);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnToSer);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 158);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户设置";
            // 
            // lbFriends
            // 
            this.lbFriends.FormattingEnabled = true;
            this.lbFriends.ItemHeight = 12;
            this.lbFriends.Location = new System.Drawing.Point(6, 204);
            this.lbFriends.Name = "lbFriends";
            this.lbFriends.Size = new System.Drawing.Size(247, 316);
            this.lbFriends.TabIndex = 19;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(372, 457);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnShake
            // 
            this.btnShake.Location = new System.Drawing.Point(470, 457);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(75, 23);
            this.btnShake.TabIndex = 23;
            this.btnShake.Text = "震动";
            this.btnShake.UseVisualStyleBackColor = true;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(573, 501);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 24;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSelFile
            // 
            this.btnSelFile.Location = new System.Drawing.Point(470, 501);
            this.btnSelFile.Name = "btnSelFile";
            this.btnSelFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelFile.TabIndex = 25;
            this.btnSelFile.Text = "浏览";
            this.btnSelFile.UseVisualStyleBackColor = true;
            this.btnSelFile.Click += new System.EventHandler(this.btnSelFile_Click);
            // 
            // richText
            // 
            this.richText.Location = new System.Drawing.Point(256, 277);
            this.richText.Name = "richText";
            this.richText.Size = new System.Drawing.Size(419, 174);
            this.richText.TabIndex = 26;
            this.richText.Text = "";
            this.richText.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // richShow
            // 
            this.richShow.Location = new System.Drawing.Point(265, 12);
            this.richShow.Name = "richShow";
            this.richShow.Size = new System.Drawing.Size(410, 237);
            this.richShow.TabIndex = 27;
            this.richShow.Text = "";
            // 
            // btnPic
            // 
            this.btnPic.Location = new System.Drawing.Point(259, 457);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(75, 23);
            this.btnPic.TabIndex = 28;
            this.btnPic.Text = "图片插入";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 536);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.richShow);
            this.Controls.Add(this.richText);
            this.Controls.Add(this.btnSelFile);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnShake);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbFriends);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "Client";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToSer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCloseSer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbFriends;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSelFile;
        private System.Windows.Forms.RichTextBox richText;
        private System.Windows.Forms.RichTextBox richShow;
        private System.Windows.Forms.Button btnPic;
    }
}