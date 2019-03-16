namespace desay
{
    partial class frmRunSetting
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ndnMLayerCurrentIndex = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ndnCurrentTrayPosition = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chxHaveInPlate = new System.Windows.Forms.CheckBox();
            this.chkZPutBuffer = new System.Windows.Forms.CheckBox();
            this.chkZGetBuffer = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chxUpCameraSheild = new System.Windows.Forms.CheckBox();
            this.chxFrameSensorSheild = new System.Windows.Forms.CheckBox();
            this.chxIncomingSensorSheild = new System.Windows.Forms.CheckBox();
            this.chxPlateSensorSheild = new System.Windows.Forms.CheckBox();
            this.chxDownCameraSheild = new System.Windows.Forms.CheckBox();
            this.chxInhaleSignalSheild = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndnMLayerCurrentIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndnCurrentTrayPosition)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ndnMLayerCurrentIndex);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ndnCurrentTrayPosition);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "索引设置";
            // 
            // ndnMLayerCurrentIndex
            // 
            this.ndnMLayerCurrentIndex.Location = new System.Drawing.Point(254, 17);
            this.ndnMLayerCurrentIndex.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.ndnMLayerCurrentIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndnMLayerCurrentIndex.Name = "ndnMLayerCurrentIndex";
            this.ndnMLayerCurrentIndex.Size = new System.Drawing.Size(48, 21);
            this.ndnMLayerCurrentIndex.TabIndex = 76;
            this.ndnMLayerCurrentIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndnMLayerCurrentIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndnMLayerCurrentIndex.Validating += new System.ComponentModel.CancelEventHandler(this.ndnMLayerCurrentIndex_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(162, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "当前料仓盘索引";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ndnCurrentTrayPosition
            // 
            this.ndnCurrentTrayPosition.Location = new System.Drawing.Point(102, 17);
            this.ndnCurrentTrayPosition.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.ndnCurrentTrayPosition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndnCurrentTrayPosition.Name = "ndnCurrentTrayPosition";
            this.ndnCurrentTrayPosition.Size = new System.Drawing.Size(48, 21);
            this.ndnCurrentTrayPosition.TabIndex = 74;
            this.ndnCurrentTrayPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndnCurrentTrayPosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndnCurrentTrayPosition.Validating += new System.ComponentModel.CancelEventHandler(this.ndnCurrentTrayPosition_Validating);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 73;
            this.label8.Text = "当前Tray盘索引";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 200);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(190, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chxHaveInPlate);
            this.groupBox1.Controls.Add(this.chkZPutBuffer);
            this.groupBox1.Controls.Add(this.chkZGetBuffer);
            this.groupBox1.Location = new System.Drawing.Point(6, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 50);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "动作设置";
            // 
            // chxHaveInPlate
            // 
            this.chxHaveInPlate.AutoSize = true;
            this.chxHaveInPlate.Location = new System.Drawing.Point(202, 22);
            this.chxHaveInPlate.Name = "chxHaveInPlate";
            this.chxHaveInPlate.Size = new System.Drawing.Size(114, 16);
            this.chxHaveInPlate.TabIndex = 10;
            this.chxHaveInPlate.Text = "Y轴上有无盘设置";
            this.chxHaveInPlate.UseVisualStyleBackColor = true;
            // 
            // chkZPutBuffer
            // 
            this.chkZPutBuffer.AutoSize = true;
            this.chkZPutBuffer.Location = new System.Drawing.Point(107, 22);
            this.chkZPutBuffer.Name = "chkZPutBuffer";
            this.chkZPutBuffer.Size = new System.Drawing.Size(96, 16);
            this.chkZPutBuffer.TabIndex = 10;
            this.chkZPutBuffer.Text = "启用下料缓冲";
            this.chkZPutBuffer.UseVisualStyleBackColor = true;
            // 
            // chkZGetBuffer
            // 
            this.chkZGetBuffer.AutoSize = true;
            this.chkZGetBuffer.Location = new System.Drawing.Point(12, 22);
            this.chkZGetBuffer.Name = "chkZGetBuffer";
            this.chkZGetBuffer.Size = new System.Drawing.Size(96, 16);
            this.chkZGetBuffer.TabIndex = 9;
            this.chkZGetBuffer.Text = "启用吸料缓冲";
            this.chkZGetBuffer.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chxInhaleSignalSheild);
            this.groupBox3.Controls.Add(this.chxDownCameraSheild);
            this.groupBox3.Controls.Add(this.chxUpCameraSheild);
            this.groupBox3.Controls.Add(this.chxPlateSensorSheild);
            this.groupBox3.Controls.Add(this.chxFrameSensorSheild);
            this.groupBox3.Controls.Add(this.chxIncomingSensorSheild);
            this.groupBox3.Location = new System.Drawing.Point(6, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 71);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "屏蔽设置";
            // 
            // chxUpCameraSheild
            // 
            this.chxUpCameraSheild.AutoSize = true;
            this.chxUpCameraSheild.Location = new System.Drawing.Point(12, 49);
            this.chxUpCameraSheild.Name = "chxUpCameraSheild";
            this.chxUpCameraSheild.Size = new System.Drawing.Size(84, 16);
            this.chxUpCameraSheild.TabIndex = 10;
            this.chxUpCameraSheild.Text = "上相机屏蔽";
            this.chxUpCameraSheild.UseVisualStyleBackColor = true;
            // 
            // chxFrameSensorSheild
            // 
            this.chxFrameSensorSheild.AutoSize = true;
            this.chxFrameSensorSheild.Location = new System.Drawing.Point(150, 22);
            this.chxFrameSensorSheild.Name = "chxFrameSensorSheild";
            this.chxFrameSensorSheild.Size = new System.Drawing.Size(96, 16);
            this.chxFrameSensorSheild.TabIndex = 10;
            this.chxFrameSensorSheild.Text = "料仓感应屏蔽";
            this.chxFrameSensorSheild.UseVisualStyleBackColor = true;
            // 
            // chxIncomingSensorSheild
            // 
            this.chxIncomingSensorSheild.AutoSize = true;
            this.chxIncomingSensorSheild.Location = new System.Drawing.Point(12, 22);
            this.chxIncomingSensorSheild.Name = "chxIncomingSensorSheild";
            this.chxIncomingSensorSheild.Size = new System.Drawing.Size(132, 16);
            this.chxIncomingSensorSheild.TabIndex = 9;
            this.chxIncomingSensorSheild.Text = "O-Ring进料光电屏蔽";
            this.chxIncomingSensorSheild.UseVisualStyleBackColor = true;
            // 
            // chxPlateSensorSheild
            // 
            this.chxPlateSensorSheild.AutoSize = true;
            this.chxPlateSensorSheild.Location = new System.Drawing.Point(246, 20);
            this.chxPlateSensorSheild.Name = "chxPlateSensorSheild";
            this.chxPlateSensorSheild.Size = new System.Drawing.Size(96, 16);
            this.chxPlateSensorSheild.TabIndex = 10;
            this.chxPlateSensorSheild.Text = "料盘感应屏蔽";
            this.chxPlateSensorSheild.UseVisualStyleBackColor = true;
            // 
            // chxDownCameraSheild
            // 
            this.chxDownCameraSheild.AutoSize = true;
            this.chxDownCameraSheild.Location = new System.Drawing.Point(150, 49);
            this.chxDownCameraSheild.Name = "chxDownCameraSheild";
            this.chxDownCameraSheild.Size = new System.Drawing.Size(84, 16);
            this.chxDownCameraSheild.TabIndex = 10;
            this.chxDownCameraSheild.Text = "下相机屏蔽";
            this.chxDownCameraSheild.UseVisualStyleBackColor = true;
            // 
            // chxInhaleSignalSheild
            // 
            this.chxInhaleSignalSheild.AutoSize = true;
            this.chxInhaleSignalSheild.Location = new System.Drawing.Point(246, 48);
            this.chxInhaleSignalSheild.Name = "chxInhaleSignalSheild";
            this.chxInhaleSignalSheild.Size = new System.Drawing.Size(96, 16);
            this.chxInhaleSignalSheild.TabIndex = 10;
            this.chxInhaleSignalSheild.Text = "吸笔信号屏蔽";
            this.chxInhaleSignalSheild.UseVisualStyleBackColor = true;
            // 
            // frmRunSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 235);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRunSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "运行设置";
            this.Load += new System.EventHandler(this.frmRunSetting_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndnMLayerCurrentIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndnCurrentTrayPosition)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown ndnCurrentTrayPosition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown ndnMLayerCurrentIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkZPutBuffer;
        private System.Windows.Forms.CheckBox chkZGetBuffer;
        private System.Windows.Forms.CheckBox chxHaveInPlate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chxUpCameraSheild;
        private System.Windows.Forms.CheckBox chxFrameSensorSheild;
        private System.Windows.Forms.CheckBox chxIncomingSensorSheild;
        private System.Windows.Forms.CheckBox chxPlateSensorSheild;
        private System.Windows.Forms.CheckBox chxInhaleSignalSheild;
        private System.Windows.Forms.CheckBox chxDownCameraSheild;
    }
}