namespace System.Device
{
    partial class frmSimensPLC
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
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConnectStatus = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(64, 14);
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(123, 21);
            this.txtIPAddr.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 59;
            this.label2.Text = "IP地址";
            // 
            // txtPortNumber
            // 
            this.txtPortNumber.Location = new System.Drawing.Point(64, 48);
            this.txtPortNumber.Name = "txtPortNumber";
            this.txtPortNumber.Size = new System.Drawing.Size(123, 21);
            this.txtPortNumber.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "端口号";
            // 
            // txtSlot
            // 
            this.txtSlot.Location = new System.Drawing.Point(64, 116);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.Size = new System.Drawing.Size(123, 21);
            this.txtSlot.TabIndex = 56;
            // 
            // txtRack
            // 
            this.txtRack.Location = new System.Drawing.Point(64, 82);
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(123, 21);
            this.txtRack.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 54;
            this.label7.Text = "插槽号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "机架号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "连接状态：";
            // 
            // lblConnectStatus
            // 
            this.lblConnectStatus.AutoSize = true;
            this.lblConnectStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectStatus.Location = new System.Drawing.Point(278, 9);
            this.lblConnectStatus.Name = "lblConnectStatus";
            this.lblConnectStatus.Size = new System.Drawing.Size(41, 12);
            this.lblConnectStatus.TabIndex = 62;
            this.lblConnectStatus.Text = "已断开";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(221, 83);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 65;
            this.button_Close.Text = "断开";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(221, 46);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 63;
            this.button_Connect.Text = "连接";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(221, 120);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 64;
            this.button_Save.Text = "保存参数";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // frmSimensPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 156);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.lblConnectStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIPAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPortNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSlot);
            this.Controls.Add(this.txtRack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "frmSimensPLC";
            this.Text = "frmSimensPLC";
            this.Load += new System.EventHandler(this.frmSimensPLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.TextBox txtIPAddr;
        private Windows.Forms.Label label2;
        private Windows.Forms.TextBox txtPortNumber;
        private Windows.Forms.Label label1;
        private Windows.Forms.TextBox txtSlot;
        private Windows.Forms.TextBox txtRack;
        private Windows.Forms.Label label7;
        private Windows.Forms.Label label6;
        private Windows.Forms.Label label3;
        private Windows.Forms.Label lblConnectStatus;
        protected Windows.Forms.Button button_Close;
        protected Windows.Forms.Button button_Connect;
        protected Windows.Forms.Button button_Save;

    }
}