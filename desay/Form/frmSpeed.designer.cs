namespace desay
{
    partial class frmSpeed
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSpeed = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSpeed
            // 
            this.dgvSpeed.AllowDrop = true;
            this.dgvSpeed.AllowUserToAddRows = false;
            this.dgvSpeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpeed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Column1,
            this.Column2,
            this.Column8,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column9,
            this.Column6,
            this.Column7});
            this.dgvSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpeed.Location = new System.Drawing.Point(0, 0);
            this.dgvSpeed.Name = "dgvSpeed";
            this.dgvSpeed.RowTemplate.Height = 23;
            this.dgvSpeed.Size = new System.Drawing.Size(906, 567);
            this.dgvSpeed.TabIndex = 0;
            this.dgvSpeed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name.FillWeight = 53.29949F;
            this.Name.HeaderText = "轴名";
            this.Name.Name = "Name";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 107.7834F;
            this.Column1.HeaderText = "回原点启动速度(pulse/s)";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 107.7834F;
            this.Column2.HeaderText = "回原点加速时间(ms)";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "回原点减速时间(ms)";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 107.7834F;
            this.Column3.HeaderText = "回原点速度(mm/s)";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 107.7834F;
            this.Column4.HeaderText = "运行启动速度(pulse/s)";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.FillWeight = 107.7834F;
            this.Column5.HeaderText = "运行加速时间(ms)";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "运行减速时间(ms)";
            this.Column9.Name = "Column9";
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.FillWeight = 107.7834F;
            this.Column6.HeaderText = "运行最大速度(mm/s)";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column7.HeaderText = "保存";
            this.Column7.Name = "Column7";
            // 
            // Speed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 567);
            this.Controls.Add(this.dgvSpeed);
            this.Text = "Speed";
            this.Load += new System.EventHandler(this.Speed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSpeed;
        private System.Windows.Forms.DataGridViewLinkColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
    }
}