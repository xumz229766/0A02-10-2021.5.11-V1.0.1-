namespace System.MES
{
    partial class FrmMesSet
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
            this.btnSavePath = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.txtShowMe = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblShowEv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMesExample = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtShowFile = new System.Windows.Forms.TextBox();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(341, 257);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(98, 23);
            this.btnSavePath.TabIndex = 19;
            this.btnSavePath.Text = "MES保存路径(&F)";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(14, 259);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(305, 21);
            this.txtSavePath.TabIndex = 18;
            // 
            // txtShowMe
            // 
            this.txtShowMe.Location = new System.Drawing.Point(13, 141);
            this.txtShowMe.Multiline = true;
            this.txtShowMe.Name = "txtShowMe";
            this.txtShowMe.ReadOnly = true;
            this.txtShowMe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShowMe.Size = new System.Drawing.Size(694, 106);
            this.txtShowMe.TabIndex = 17;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(12, 126);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(71, 12);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = "ME_MSTR参数";
            // 
            // lblShowEv
            // 
            this.lblShowEv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShowEv.Location = new System.Drawing.Point(12, 72);
            this.lblShowEv.Name = "lblShowEv";
            this.lblShowEv.Size = new System.Drawing.Size(695, 46);
            this.lblShowEv.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "EV_MSTR参数：";
            // 
            // btnMesExample
            // 
            this.btnMesExample.Location = new System.Drawing.Point(56, 292);
            this.btnMesExample.Name = "btnMesExample";
            this.btnMesExample.Size = new System.Drawing.Size(75, 39);
            this.btnMesExample.TabIndex = 11;
            this.btnMesExample.Text = "Mes示例(&M)";
            this.btnMesExample.UseVisualStyleBackColor = true;
            this.btnMesExample.Click += new System.EventHandler(this.btnMesExample_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(540, 292);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 39);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(294, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存配置(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtShowFile
            // 
            this.txtShowFile.Location = new System.Drawing.Point(12, 10);
            this.txtShowFile.Name = "txtShowFile";
            this.txtShowFile.ReadOnly = true;
            this.txtShowFile.Size = new System.Drawing.Size(307, 21);
            this.txtShowFile.TabIndex = 10;
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(325, 10);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(105, 23);
            this.btnLoadConfig.TabIndex = 9;
            this.btnLoadConfig.Text = "导入配置文件(&L)";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // FrmMesSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 340);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.txtShowMe);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lblShowEv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMesExample);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtShowFile);
            this.Controls.Add(this.btnLoadConfig);
            this.Name = "FrmMesSet";
            this.Text = "MES设置";
            this.Load += new System.EventHandler(this.FrmMesSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.Button btnSavePath;
        private Windows.Forms.TextBox txtSavePath;
        private Windows.Forms.TextBox txtShowMe;
        private Windows.Forms.Label lbl2;
        private Windows.Forms.Label lblShowEv;
        private Windows.Forms.Label label1;
        private Windows.Forms.Button btnMesExample;
        private Windows.Forms.Button btnExit;
        private Windows.Forms.Button btnSave;
        private Windows.Forms.TextBox txtShowFile;
        private Windows.Forms.Button btnLoadConfig;
    }
}