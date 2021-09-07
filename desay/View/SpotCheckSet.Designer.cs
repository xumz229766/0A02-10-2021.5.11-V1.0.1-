namespace desay
{
    partial class SpotCheckSet
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AxisSet = new System.Windows.Forms.GroupBox();
            this.InputLimitValue = new System.Windows.Forms.CheckBox();
            this.AxisID = new System.Windows.Forms.ComboBox();
            this.SetSoftLimit = new System.Windows.Forms.Button();
            this.GetSoftPLimit = new System.Windows.Forms.Button();
            this.GetSoftNLimit = new System.Windows.Forms.Button();
            this.AxisName = new System.Windows.Forms.Label();
            this.SetORG = new System.Windows.Forms.Button();
            this.SoftPlimit = new System.Windows.Forms.TextBox();
            this.SoftNlimit = new System.Windows.Forms.TextBox();
            this.CurrentPos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WriteServo = new System.Windows.Forms.Button();
            this.ReadServo = new System.Windows.Forms.Button();
            this.AllCheck = new System.Windows.Forms.CheckBox();
            this.InitServo = new System.Windows.Forms.CheckBox();
            this.btnCoolReset = new System.Windows.Forms.Button();
            this.btnSoftReset = new System.Windows.Forms.Button();
            this.ServoParam = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StepParam = new System.Windows.Forms.DataGridView();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column35 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column37 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column39 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AxisSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServoParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepParam)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // AxisSet
            // 
            this.AxisSet.Controls.Add(this.InputLimitValue);
            this.AxisSet.Controls.Add(this.AxisID);
            this.AxisSet.Controls.Add(this.SetSoftLimit);
            this.AxisSet.Controls.Add(this.GetSoftPLimit);
            this.AxisSet.Controls.Add(this.GetSoftNLimit);
            this.AxisSet.Controls.Add(this.AxisName);
            this.AxisSet.Controls.Add(this.SetORG);
            this.AxisSet.Controls.Add(this.SoftPlimit);
            this.AxisSet.Controls.Add(this.SoftNlimit);
            this.AxisSet.Controls.Add(this.CurrentPos);
            this.AxisSet.Controls.Add(this.label3);
            this.AxisSet.Controls.Add(this.label2);
            this.AxisSet.Controls.Add(this.label1);
            this.AxisSet.Location = new System.Drawing.Point(843, 388);
            this.AxisSet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AxisSet.Name = "AxisSet";
            this.AxisSet.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AxisSet.Size = new System.Drawing.Size(415, 201);
            this.AxisSet.TabIndex = 79;
            this.AxisSet.TabStop = false;
            this.AxisSet.Text = "轴设置";
            // 
            // InputLimitValue
            // 
            this.InputLimitValue.AutoSize = true;
            this.InputLimitValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputLimitValue.Location = new System.Drawing.Point(54, 164);
            this.InputLimitValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InputLimitValue.Name = "InputLimitValue";
            this.InputLimitValue.Size = new System.Drawing.Size(101, 18);
            this.InputLimitValue.TabIndex = 85;
            this.InputLimitValue.Text = "输入限位值";
            this.InputLimitValue.UseVisualStyleBackColor = true;
            this.InputLimitValue.CheckedChanged += new System.EventHandler(this.InputLimitValue_CheckedChanged);
            // 
            // AxisID
            // 
            this.AxisID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AxisID.FormattingEnabled = true;
            this.AxisID.Location = new System.Drawing.Point(145, 22);
            this.AxisID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AxisID.Name = "AxisID";
            this.AxisID.Size = new System.Drawing.Size(121, 20);
            this.AxisID.TabIndex = 85;
            this.AxisID.SelectedIndexChanged += new System.EventHandler(this.AxisID_SelectedIndexChanged);
            // 
            // SetSoftLimit
            // 
            this.SetSoftLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetSoftLimit.Location = new System.Drawing.Point(295, 159);
            this.SetSoftLimit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SetSoftLimit.Name = "SetSoftLimit";
            this.SetSoftLimit.Size = new System.Drawing.Size(100, 27);
            this.SetSoftLimit.TabIndex = 84;
            this.SetSoftLimit.Text = "设置软限位";
            this.SetSoftLimit.UseVisualStyleBackColor = true;
            this.SetSoftLimit.Click += new System.EventHandler(this.SetSoftLimit_Click);
            // 
            // GetSoftPLimit
            // 
            this.GetSoftPLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetSoftPLimit.Location = new System.Drawing.Point(295, 122);
            this.GetSoftPLimit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GetSoftPLimit.Name = "GetSoftPLimit";
            this.GetSoftPLimit.Size = new System.Drawing.Size(100, 27);
            this.GetSoftPLimit.TabIndex = 83;
            this.GetSoftPLimit.Text = "获取位置";
            this.GetSoftPLimit.UseVisualStyleBackColor = true;
            this.GetSoftPLimit.Click += new System.EventHandler(this.GetSoftPLimit_Click);
            // 
            // GetSoftNLimit
            // 
            this.GetSoftNLimit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetSoftNLimit.Location = new System.Drawing.Point(295, 88);
            this.GetSoftNLimit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GetSoftNLimit.Name = "GetSoftNLimit";
            this.GetSoftNLimit.Size = new System.Drawing.Size(100, 27);
            this.GetSoftNLimit.TabIndex = 83;
            this.GetSoftNLimit.Text = "获取位置";
            this.GetSoftNLimit.UseVisualStyleBackColor = true;
            this.GetSoftNLimit.Click += new System.EventHandler(this.GetSoftNLimit_Click);
            // 
            // AxisName
            // 
            this.AxisName.AutoSize = true;
            this.AxisName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AxisName.Location = new System.Drawing.Point(66, 25);
            this.AxisName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AxisName.Name = "AxisName";
            this.AxisName.Size = new System.Drawing.Size(60, 14);
            this.AxisName.TabIndex = 79;
            this.AxisName.Text = "轴名称:";
            // 
            // SetORG
            // 
            this.SetORG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetORG.Location = new System.Drawing.Point(295, 51);
            this.SetORG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SetORG.Name = "SetORG";
            this.SetORG.Size = new System.Drawing.Size(100, 27);
            this.SetORG.TabIndex = 83;
            this.SetORG.Text = "设置原点";
            this.SetORG.UseVisualStyleBackColor = true;
            this.SetORG.Click += new System.EventHandler(this.SetORG_Click);
            // 
            // SoftPlimit
            // 
            this.SoftPlimit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SoftPlimit.Location = new System.Drawing.Point(145, 125);
            this.SoftPlimit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SoftPlimit.Name = "SoftPlimit";
            this.SoftPlimit.ReadOnly = true;
            this.SoftPlimit.Size = new System.Drawing.Size(122, 21);
            this.SoftPlimit.TabIndex = 82;
            this.SoftPlimit.Text = "0";
            // 
            // SoftNlimit
            // 
            this.SoftNlimit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SoftNlimit.Location = new System.Drawing.Point(145, 90);
            this.SoftNlimit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SoftNlimit.Name = "SoftNlimit";
            this.SoftNlimit.ReadOnly = true;
            this.SoftNlimit.Size = new System.Drawing.Size(122, 21);
            this.SoftNlimit.TabIndex = 82;
            this.SoftNlimit.Text = "0";
            // 
            // CurrentPos
            // 
            this.CurrentPos.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentPos.Location = new System.Drawing.Point(145, 55);
            this.CurrentPos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CurrentPos.Name = "CurrentPos";
            this.CurrentPos.ReadOnly = true;
            this.CurrentPos.Size = new System.Drawing.Size(122, 21);
            this.CurrentPos.TabIndex = 82;
            this.CurrentPos.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(51, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 79;
            this.label3.Text = "当前位置:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(51, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 79;
            this.label2.Text = "软限位 +:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(51, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 79;
            this.label1.Text = "软限位 -:";
            // 
            // WriteServo
            // 
            this.WriteServo.BackColor = System.Drawing.Color.Red;
            this.WriteServo.Location = new System.Drawing.Point(678, 436);
            this.WriteServo.Name = "WriteServo";
            this.WriteServo.Size = new System.Drawing.Size(92, 43);
            this.WriteServo.TabIndex = 89;
            this.WriteServo.Text = "写入伺服";
            this.WriteServo.UseVisualStyleBackColor = false;
            this.WriteServo.Click += new System.EventHandler(this.WriteServo_Click);
            // 
            // ReadServo
            // 
            this.ReadServo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ReadServo.Location = new System.Drawing.Point(678, 484);
            this.ReadServo.Name = "ReadServo";
            this.ReadServo.Size = new System.Drawing.Size(92, 38);
            this.ReadServo.TabIndex = 90;
            this.ReadServo.Text = "读取伺服";
            this.ReadServo.UseVisualStyleBackColor = false;
            this.ReadServo.Click += new System.EventHandler(this.ReadServo_Click);
            // 
            // AllCheck
            // 
            this.AllCheck.AutoSize = true;
            this.AllCheck.Location = new System.Drawing.Point(678, 388);
            this.AllCheck.Name = "AllCheck";
            this.AllCheck.Size = new System.Drawing.Size(71, 18);
            this.AllCheck.TabIndex = 91;
            this.AllCheck.Text = "全启用";
            this.AllCheck.UseVisualStyleBackColor = true;
            this.AllCheck.CheckedChanged += new System.EventHandler(this.AllCheck_CheckedChanged);
            // 
            // InitServo
            // 
            this.InitServo.AutoSize = true;
            this.InitServo.Location = new System.Drawing.Point(678, 412);
            this.InitServo.Name = "InitServo";
            this.InitServo.Size = new System.Drawing.Size(131, 18);
            this.InitServo.TabIndex = 91;
            this.InitServo.Text = "初始化伺服参数";
            this.InitServo.UseVisualStyleBackColor = true;
            this.InitServo.CheckedChanged += new System.EventHandler(this.InitServo_CheckedChanged);
            // 
            // btnCoolReset
            // 
            this.btnCoolReset.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCoolReset.Location = new System.Drawing.Point(678, 529);
            this.btnCoolReset.Name = "btnCoolReset";
            this.btnCoolReset.Size = new System.Drawing.Size(92, 27);
            this.btnCoolReset.TabIndex = 90;
            this.btnCoolReset.Text = "热复位";
            this.btnCoolReset.UseVisualStyleBackColor = false;
            this.btnCoolReset.Click += new System.EventHandler(this.btnCoolReset_Click);
            // 
            // btnSoftReset
            // 
            this.btnSoftReset.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSoftReset.Location = new System.Drawing.Point(678, 562);
            this.btnSoftReset.Name = "btnSoftReset";
            this.btnSoftReset.Size = new System.Drawing.Size(92, 27);
            this.btnSoftReset.TabIndex = 90;
            this.btnSoftReset.Text = "冷复位";
            this.btnSoftReset.UseVisualStyleBackColor = false;
            this.btnSoftReset.Click += new System.EventHandler(this.btnSoftReset_Click);
            // 
            // ServoParam
            // 
            this.ServoParam.AllowUserToAddRows = false;
            this.ServoParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServoParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27});
            this.ServoParam.Location = new System.Drawing.Point(10, 17);
            this.ServoParam.Name = "ServoParam";
            this.ServoParam.RowHeadersVisible = false;
            this.ServoParam.RowTemplate.Height = 23;
            this.ServoParam.Size = new System.Drawing.Size(1249, 346);
            this.ServoParam.TabIndex = 92;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "主索引";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "子索引 ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "参数定义";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "X轴";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "启用";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Y轴";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "启用";
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Z轴";
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 50;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "启用";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.Width = 50;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "C1轴";
            this.Column12.Name = "Column12";
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 50;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "启用";
            this.Column13.Name = "Column13";
            this.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column13.Width = 50;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "C2轴";
            this.Column14.Name = "Column14";
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column14.Width = 50;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "启用";
            this.Column15.Name = "Column15";
            this.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column15.Width = 50;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "C3轴";
            this.Column16.Name = "Column16";
            this.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column16.Width = 50;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "启用";
            this.Column17.Name = "Column17";
            this.Column17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column17.Width = 50;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "C4轴";
            this.Column18.Name = "Column18";
            this.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column18.Width = 50;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "启用";
            this.Column19.Name = "Column19";
            this.Column19.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column19.Width = 50;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "P1轴";
            this.Column20.Name = "Column20";
            this.Column20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column20.Width = 50;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "启用";
            this.Column21.Name = "Column21";
            this.Column21.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column21.Width = 50;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "P2轴";
            this.Column22.Name = "Column22";
            this.Column22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column22.Width = 50;
            // 
            // Column23
            // 
            this.Column23.HeaderText = "启用";
            this.Column23.Name = "Column23";
            this.Column23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column23.Width = 50;
            // 
            // Column24
            // 
            this.Column24.HeaderText = "P3轴";
            this.Column24.Name = "Column24";
            this.Column24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column24.Width = 50;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "启用";
            this.Column25.Name = "Column25";
            this.Column25.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column25.Width = 50;
            // 
            // Column26
            // 
            this.Column26.HeaderText = "P4轴";
            this.Column26.Name = "Column26";
            this.Column26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column26.Width = 50;
            // 
            // Column27
            // 
            this.Column27.HeaderText = "启用";
            this.Column27.Name = "Column27";
            this.Column27.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column27.Width = 50;
            // 
            // StepParam
            // 
            this.StepParam.AllowUserToAddRows = false;
            this.StepParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StepParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column28,
            this.Column29,
            this.Column30,
            this.Column31,
            this.Column32,
            this.Column33,
            this.Column34,
            this.Column35,
            this.Column36,
            this.Column37,
            this.Column38,
            this.Column39,
            this.Column40,
            this.Column41});
            this.StepParam.Location = new System.Drawing.Point(10, 388);
            this.StepParam.Name = "StepParam";
            this.StepParam.RowHeadersVisible = false;
            this.StepParam.RowTemplate.Height = 23;
            this.StepParam.Size = new System.Drawing.Size(657, 201);
            this.StepParam.TabIndex = 93;
            // 
            // Column28
            // 
            this.Column28.HeaderText = "类型";
            this.Column28.Name = "Column28";
            this.Column28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column29
            // 
            this.Column29.HeaderText = "主索引";
            this.Column29.Name = "Column29";
            this.Column29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column30
            // 
            this.Column30.HeaderText = "子索引";
            this.Column30.Name = "Column30";
            this.Column30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column31
            // 
            this.Column31.HeaderText = "参数定义";
            this.Column31.Name = "Column31";
            this.Column31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column31.Width = 150;
            // 
            // Column32
            // 
            this.Column32.HeaderText = "Z1轴";
            this.Column32.Name = "Column32";
            this.Column32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column32.Width = 50;
            // 
            // Column33
            // 
            this.Column33.HeaderText = "启动";
            this.Column33.Name = "Column33";
            this.Column33.Width = 50;
            // 
            // Column34
            // 
            this.Column34.HeaderText = "Z2轴";
            this.Column34.Name = "Column34";
            this.Column34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column34.Width = 50;
            // 
            // Column35
            // 
            this.Column35.HeaderText = "启动";
            this.Column35.Name = "Column35";
            this.Column35.Width = 50;
            // 
            // Column36
            // 
            this.Column36.HeaderText = "Z3轴";
            this.Column36.Name = "Column36";
            this.Column36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column36.Width = 50;
            // 
            // Column37
            // 
            this.Column37.HeaderText = "启动";
            this.Column37.Name = "Column37";
            this.Column37.Width = 50;
            // 
            // Column38
            // 
            this.Column38.HeaderText = "Z4轴";
            this.Column38.Name = "Column38";
            this.Column38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column38.Width = 50;
            // 
            // Column39
            // 
            this.Column39.HeaderText = "启动";
            this.Column39.Name = "Column39";
            this.Column39.Width = 50;
            // 
            // Column40
            // 
            this.Column40.HeaderText = "M轴";
            this.Column40.Name = "Column40";
            this.Column40.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column40.Width = 50;
            // 
            // Column41
            // 
            this.Column41.HeaderText = "启用";
            this.Column41.Name = "Column41";
            this.Column41.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column41.Width = 50;
            // 
            // SpotCheckSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StepParam);
            this.Controls.Add(this.ServoParam);
            this.Controls.Add(this.InitServo);
            this.Controls.Add(this.AllCheck);
            this.Controls.Add(this.btnSoftReset);
            this.Controls.Add(this.btnCoolReset);
            this.Controls.Add(this.ReadServo);
            this.Controls.Add(this.WriteServo);
            this.Controls.Add(this.AxisSet);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SpotCheckSet";
            this.Size = new System.Drawing.Size(1262, 614);
            this.Load += new System.EventHandler(this.SpotCheckSet_Load);
            this.AxisSet.ResumeLayout(false);
            this.AxisSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServoParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepParam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox AxisSet;
        private System.Windows.Forms.Label AxisName;
        private System.Windows.Forms.Button SetORG;
        private System.Windows.Forms.TextBox CurrentPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SetSoftLimit;
        private System.Windows.Forms.TextBox SoftPlimit;
        private System.Windows.Forms.TextBox SoftNlimit;
        private System.Windows.Forms.Button GetSoftPLimit;
        private System.Windows.Forms.Button GetSoftNLimit;
        private System.Windows.Forms.ComboBox AxisID;
        private System.Windows.Forms.CheckBox InputLimitValue;
        private System.Windows.Forms.Button WriteServo;
        private System.Windows.Forms.Button ReadServo;
        private System.Windows.Forms.CheckBox AllCheck;
        private System.Windows.Forms.CheckBox InitServo;
        private System.Windows.Forms.Button btnCoolReset;
        private System.Windows.Forms.Button btnSoftReset;
        private System.Windows.Forms.DataGridView ServoParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column27;
        private System.Windows.Forms.DataGridView StepParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column34;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column35;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column36;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column37;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column38;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column39;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column40;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column41;
    }
}
