namespace desay
{
    partial class frmManualOperate
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelVeiw = new System.Windows.Forms.TableLayoutPanel();
            this.panelOperator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(158, 600);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelVeiw
            // 
            this.panelVeiw.ColumnCount = 1;
            this.panelVeiw.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelVeiw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVeiw.Location = new System.Drawing.Point(158, 0);
            this.panelVeiw.Name = "panelVeiw";
            this.panelVeiw.RowCount = 3;
            this.panelVeiw.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.panelVeiw.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.panelVeiw.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelVeiw.Size = new System.Drawing.Size(805, 600);
            this.panelVeiw.TabIndex = 2;
            // 
            // panelOperator
            // 
            this.panelOperator.BackColor = System.Drawing.SystemColors.Control;
            this.panelOperator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOperator.Location = new System.Drawing.Point(158, 500);
            this.panelOperator.Name = "panelOperator";
            this.panelOperator.Size = new System.Drawing.Size(805, 100);
            this.panelOperator.TabIndex = 3;
            // 
            // frmManualOperate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 600);
            this.Controls.Add(this.panelOperator);
            this.Controls.Add(this.panelVeiw);
            this.Controls.Add(this.treeView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManualOperate";
            this.Text = "frmTeach";
            this.Load += new System.EventHandler(this.frmTeach_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel panelVeiw;
        private System.Windows.Forms.Panel panelOperator;
    }
}