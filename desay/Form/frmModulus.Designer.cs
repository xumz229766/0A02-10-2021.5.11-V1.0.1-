namespace desay
{
    partial class frmModulus
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
            this.nudSelectCheckModulus = new System.Windows.Forms.NumericUpDown();
            this.labSelectCheckModulus = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectCheckModulus)).BeginInit();
            this.SuspendLayout();
            // 
            // nudSelectCheckModulus
            // 
            this.nudSelectCheckModulus.Location = new System.Drawing.Point(131, 32);
            this.nudSelectCheckModulus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nudSelectCheckModulus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSelectCheckModulus.Name = "nudSelectCheckModulus";
            this.nudSelectCheckModulus.Size = new System.Drawing.Size(96, 25);
            this.nudSelectCheckModulus.TabIndex = 94;
            this.nudSelectCheckModulus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSelectCheckModulus.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labSelectCheckModulus
            // 
            this.labSelectCheckModulus.AutoSize = true;
            this.labSelectCheckModulus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labSelectCheckModulus.Location = new System.Drawing.Point(31, 36);
            this.labSelectCheckModulus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labSelectCheckModulus.Name = "labSelectCheckModulus";
            this.labSelectCheckModulus.Size = new System.Drawing.Size(84, 18);
            this.labSelectCheckModulus.TabIndex = 93;
            this.labSelectCheckModulus.Text = "抽检模数";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(75, 90);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 95;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmModulus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 145);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudSelectCheckModulus);
            this.Controls.Add(this.labSelectCheckModulus);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModulus";
            this.Text = "设置模数";
            this.Load += new System.EventHandler(this.frmModulus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectCheckModulus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudSelectCheckModulus;
        private System.Windows.Forms.Label labSelectCheckModulus;
        private System.Windows.Forms.Button btnOK;
    }
}