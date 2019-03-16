namespace desay
{
    partial class frmParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParameter));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbxAssemblyPlateID = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAssemblyCalib = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSelectProductType = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.lbxProductType = new System.Windows.Forms.ListBox();
            this.lblCurrentProductType = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpAxisSpeed = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPlatePosition = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox8.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbxAssemblyPlateID);
            this.groupBox8.Controls.Add(this.btnRefresh);
            this.groupBox8.Controls.Add(this.btnAssemblyCalib);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Controls.Add(this.btnNew);
            this.groupBox8.Controls.Add(this.btnSelectProductType);
            this.groupBox8.Controls.Add(this.btnDelete);
            this.groupBox8.Controls.Add(this.txtProductType);
            this.groupBox8.Controls.Add(this.lbxProductType);
            this.groupBox8.Controls.Add(this.lblCurrentProductType);
            this.groupBox8.Controls.Add(this.label60);
            this.groupBox8.Controls.Add(this.label57);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox8.Location = new System.Drawing.Point(0, 27);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(291, 526);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "型号参数";
            // 
            // cbxAssemblyPlateID
            // 
            this.cbxAssemblyPlateID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAssemblyPlateID.FormattingEnabled = true;
            this.cbxAssemblyPlateID.Location = new System.Drawing.Point(69, 239);
            this.cbxAssemblyPlateID.Name = "cbxAssemblyPlateID";
            this.cbxAssemblyPlateID.Size = new System.Drawing.Size(91, 20);
            this.cbxAssemblyPlateID.TabIndex = 39;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(237, 239);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5, 15, 5, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(48, 24);
            this.btnRefresh.TabIndex = 37;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAssemblyCalib
            // 
            this.btnAssemblyCalib.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAssemblyCalib.Location = new System.Drawing.Point(164, 239);
            this.btnAssemblyCalib.Margin = new System.Windows.Forms.Padding(5, 15, 5, 15);
            this.btnAssemblyCalib.Name = "btnAssemblyCalib";
            this.btnAssemblyCalib.Size = new System.Drawing.Size(67, 24);
            this.btnAssemblyCalib.TabIndex = 38;
            this.btnAssemblyCalib.Text = "标定";
            this.btnAssemblyCalib.UseVisualStyleBackColor = true;
            this.btnAssemblyCalib.Click += new System.EventHandler(this.btnAssemblyCalib_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 241);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 12);
            this.label20.TabIndex = 36;
            this.label20.Text = "托盘型号:";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(148, 97);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(138, 36);
            this.btnNew.TabIndex = 28;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSelectProductType
            // 
            this.btnSelectProductType.Location = new System.Drawing.Point(148, 181);
            this.btnSelectProductType.Name = "btnSelectProductType";
            this.btnSelectProductType.Size = new System.Drawing.Size(138, 36);
            this.btnSelectProductType.TabIndex = 29;
            this.btnSelectProductType.Text = "切换型号";
            this.btnSelectProductType.UseVisualStyleBackColor = true;
            this.btnSelectProductType.Click += new System.EventHandler(this.btnSelectProductType_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(148, 139);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 36);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(148, 65);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(138, 21);
            this.txtProductType.TabIndex = 27;
            // 
            // lbxProductType
            // 
            this.lbxProductType.FormattingEnabled = true;
            this.lbxProductType.ItemHeight = 12;
            this.lbxProductType.Location = new System.Drawing.Point(11, 65);
            this.lbxProductType.Name = "lbxProductType";
            this.lbxProductType.Size = new System.Drawing.Size(131, 148);
            this.lbxProductType.TabIndex = 26;
            // 
            // lblCurrentProductType
            // 
            this.lblCurrentProductType.AutoSize = true;
            this.lblCurrentProductType.Location = new System.Drawing.Point(101, 22);
            this.lblCurrentProductType.Name = "lblCurrentProductType";
            this.lblCurrentProductType.Size = new System.Drawing.Size(41, 12);
            this.lblCurrentProductType.TabIndex = 23;
            this.lblCurrentProductType.Text = "ABC123";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(10, 45);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(77, 12);
            this.label60.TabIndex = 24;
            this.label60.Text = "产品型号列表";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(10, 22);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(83, 12);
            this.label57.TabIndex = 25;
            this.label57.Text = "当前产品型号:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1249, 27);
            this.toolStrip1.TabIndex = 35;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 24);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpAxisSpeed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(726, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 526);
            this.panel1.TabIndex = 34;
            // 
            // flpAxisSpeed
            // 
            this.flpAxisSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAxisSpeed.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAxisSpeed.Location = new System.Drawing.Point(0, 0);
            this.flpAxisSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.flpAxisSpeed.Name = "flpAxisSpeed";
            this.flpAxisSpeed.Size = new System.Drawing.Size(523, 526);
            this.flpAxisSpeed.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.dgvPlatePosition);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(291, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 526);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // dgvPlatePosition
            // 
            this.dgvPlatePosition.AllowUserToAddRows = false;
            this.dgvPlatePosition.AllowUserToDeleteRows = false;
            this.dgvPlatePosition.AllowUserToResizeRows = false;
            this.dgvPlatePosition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlatePosition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPlatePosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPlatePosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column1,
            this.Column6});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlatePosition.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPlatePosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPlatePosition.EnableHeadersVisualStyles = false;
            this.dgvPlatePosition.Location = new System.Drawing.Point(3, 17);
            this.dgvPlatePosition.Name = "dgvPlatePosition";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlatePosition.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPlatePosition.RowHeadersVisible = false;
            this.dgvPlatePosition.RowTemplate.Height = 23;
            this.dgvPlatePosition.Size = new System.Drawing.Size(429, 186);
            this.dgvPlatePosition.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewLinkColumn1,
            this.dataGridViewLinkColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 201);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(429, 322);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "轴号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "穴数";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "待料角度";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "是否屏蔽";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "定位";
            this.Column1.Name = "Column1";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "保存";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "穴号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "角度";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "轴数";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.HeaderText = "定位";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewLinkColumn2.HeaderText = "保存";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmParameter";
            this.Text = "frmParameter";
            this.Load += new System.EventHandler(this.frmParameter_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSelectProductType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.ListBox lbxProductType;
        private System.Windows.Forms.Label lblCurrentProductType;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ComboBox cbxAssemblyPlateID;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAssemblyCalib;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpAxisSpeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPlatePosition;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
    }
}