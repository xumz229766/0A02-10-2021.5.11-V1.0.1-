namespace desay
{
    partial class frmSpeedSet
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
            this.components = new System.ComponentModel.Container();
            this.btnsave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAcc = new System.Windows.Forms.Button();
            this.flpAxisSpeed = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsave
            // 
            this.btnsave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnsave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnsave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnsave.Location = new System.Drawing.Point(6, 11);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 32;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.Btnsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAcc);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 40);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // buttonAcc
            // 
            this.buttonAcc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAcc.Location = new System.Drawing.Point(157, 11);
            this.buttonAcc.Name = "buttonAcc";
            this.buttonAcc.Size = new System.Drawing.Size(112, 23);
            this.buttonAcc.TabIndex = 33;
            this.buttonAcc.Text = "加减速设定";
            this.buttonAcc.UseVisualStyleBackColor = true;
            this.buttonAcc.Click += new System.EventHandler(this.buttonAcc_Click);
            // 
            // flpAxisSpeed
            // 
            this.flpAxisSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAxisSpeed.Location = new System.Drawing.Point(0, 40);
            this.flpAxisSpeed.Name = "flpAxisSpeed";
            this.flpAxisSpeed.Size = new System.Drawing.Size(1020, 554);
            this.flpAxisSpeed.TabIndex = 34;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSpeedSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 594);
            this.Controls.Add(this.flpAxisSpeed);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSpeedSet";
            this.Text = "速度参数设定";
            this.Load += new System.EventHandler(this.frmTeach_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flpAxisSpeed;
        private System.Windows.Forms.Button buttonAcc;
        private System.Windows.Forms.Timer timer1;
    }
}