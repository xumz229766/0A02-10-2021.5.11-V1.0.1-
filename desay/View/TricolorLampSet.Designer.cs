namespace desay
{
    partial class TricolorLampSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TricolorLampSet));
            this.btnRunStursGreen = new System.Windows.Forms.Button();
            this.btnRunStursYellow = new System.Windows.Forms.Button();
            this.btnRunStursRed = new System.Windows.Forms.Button();
            this.ckbbtnRunSturs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnErrStursRed = new System.Windows.Forms.Button();
            this.btnErrStursYellow = new System.Windows.Forms.Button();
            this.btnErrStursGreen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPuseStursRed = new System.Windows.Forms.Button();
            this.btnPuseStursYellow = new System.Windows.Forms.Button();
            this.btnPuseStursGreen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStopStursRed = new System.Windows.Forms.Button();
            this.btnStopStursYellow = new System.Windows.Forms.Button();
            this.btnStopStursGreen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnWarningStursRed = new System.Windows.Forms.Button();
            this.btnWarningStursYellow = new System.Windows.Forms.Button();
            this.btnWarningStursGreen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnResetStursRed = new System.Windows.Forms.Button();
            this.btnResetStursYellow = new System.Windows.Forms.Button();
            this.btnResetStursGreen = new System.Windows.Forms.Button();
            this.ckbErrSturs = new System.Windows.Forms.ComboBox();
            this.ckbPuseSturs = new System.Windows.Forms.ComboBox();
            this.ckbStopSturs = new System.Windows.Forms.ComboBox();
            this.ckbWarningSturs = new System.Windows.Forms.ComboBox();
            this.ckbResetSturs = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRunStursGreen
            // 
            this.btnRunStursGreen.Image = global::desay.Properties.Resources.LedGreen;
            this.btnRunStursGreen.Location = new System.Drawing.Point(247, 71);
            this.btnRunStursGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRunStursGreen.Name = "btnRunStursGreen";
            this.btnRunStursGreen.Size = new System.Drawing.Size(35, 27);
            this.btnRunStursGreen.TabIndex = 39;
            this.btnRunStursGreen.UseVisualStyleBackColor = true;
            this.btnRunStursGreen.Click += new System.EventHandler(this.BtnRunStursGreen_Click);
            // 
            // btnRunStursYellow
            // 
            this.btnRunStursYellow.Image = ((System.Drawing.Image)(resources.GetObject("btnRunStursYellow.Image")));
            this.btnRunStursYellow.Location = new System.Drawing.Point(289, 71);
            this.btnRunStursYellow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRunStursYellow.Name = "btnRunStursYellow";
            this.btnRunStursYellow.Size = new System.Drawing.Size(35, 27);
            this.btnRunStursYellow.TabIndex = 40;
            this.btnRunStursYellow.UseVisualStyleBackColor = true;
            this.btnRunStursYellow.Click += new System.EventHandler(this.BtnRunStursYellow_Click);
            // 
            // btnRunStursRed
            // 
            this.btnRunStursRed.Image = global::desay.Properties.Resources.LedRed;
            this.btnRunStursRed.Location = new System.Drawing.Point(332, 71);
            this.btnRunStursRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRunStursRed.Name = "btnRunStursRed";
            this.btnRunStursRed.Size = new System.Drawing.Size(35, 27);
            this.btnRunStursRed.TabIndex = 41;
            this.btnRunStursRed.UseVisualStyleBackColor = true;
            this.btnRunStursRed.Click += new System.EventHandler(this.BtnRunStursRed_Click);
            // 
            // ckbbtnRunSturs
            // 
            this.ckbbtnRunSturs.FormattingEnabled = true;
            this.ckbbtnRunSturs.Items.AddRange(new object[] {
            "静音",
            "长音",
            "间隔音"});
            this.ckbbtnRunSturs.Location = new System.Drawing.Point(375, 71);
            this.ckbbtnRunSturs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbbtnRunSturs.Name = "ckbbtnRunSturs";
            this.ckbbtnRunSturs.Size = new System.Drawing.Size(107, 22);
            this.ckbbtnRunSturs.TabIndex = 42;
            this.ckbbtnRunSturs.SelectedIndexChanged += new System.EventHandler(this.CkbbtnRunSturs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(137, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 43;
            this.label1.Text = "运转中";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(137, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "异常";
            // 
            // btnErrStursRed
            // 
            this.btnErrStursRed.Image = global::desay.Properties.Resources.LedRed;
            this.btnErrStursRed.Location = new System.Drawing.Point(332, 110);
            this.btnErrStursRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnErrStursRed.Name = "btnErrStursRed";
            this.btnErrStursRed.Size = new System.Drawing.Size(35, 27);
            this.btnErrStursRed.TabIndex = 46;
            this.btnErrStursRed.UseVisualStyleBackColor = true;
            this.btnErrStursRed.Click += new System.EventHandler(this.BtnErrStursRed_Click);
            // 
            // btnErrStursYellow
            // 
            this.btnErrStursYellow.Image = ((System.Drawing.Image)(resources.GetObject("btnErrStursYellow.Image")));
            this.btnErrStursYellow.Location = new System.Drawing.Point(289, 110);
            this.btnErrStursYellow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnErrStursYellow.Name = "btnErrStursYellow";
            this.btnErrStursYellow.Size = new System.Drawing.Size(35, 27);
            this.btnErrStursYellow.TabIndex = 45;
            this.btnErrStursYellow.UseVisualStyleBackColor = true;
            this.btnErrStursYellow.Click += new System.EventHandler(this.BtnErrStursYellow_Click);
            // 
            // btnErrStursGreen
            // 
            this.btnErrStursGreen.Image = global::desay.Properties.Resources.LedGreen;
            this.btnErrStursGreen.Location = new System.Drawing.Point(247, 110);
            this.btnErrStursGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnErrStursGreen.Name = "btnErrStursGreen";
            this.btnErrStursGreen.Size = new System.Drawing.Size(35, 27);
            this.btnErrStursGreen.TabIndex = 44;
            this.btnErrStursGreen.UseVisualStyleBackColor = true;
            this.btnErrStursGreen.Click += new System.EventHandler(this.BtnErrStursGreen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(137, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 53;
            this.label3.Text = "暂停";
            // 
            // btnPuseStursRed
            // 
            this.btnPuseStursRed.Image = global::desay.Properties.Resources.LedRed;
            this.btnPuseStursRed.Location = new System.Drawing.Point(332, 147);
            this.btnPuseStursRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPuseStursRed.Name = "btnPuseStursRed";
            this.btnPuseStursRed.Size = new System.Drawing.Size(35, 27);
            this.btnPuseStursRed.TabIndex = 51;
            this.btnPuseStursRed.UseVisualStyleBackColor = true;
            this.btnPuseStursRed.Click += new System.EventHandler(this.BtnPuseStursRed_Click);
            // 
            // btnPuseStursYellow
            // 
            this.btnPuseStursYellow.Image = ((System.Drawing.Image)(resources.GetObject("btnPuseStursYellow.Image")));
            this.btnPuseStursYellow.Location = new System.Drawing.Point(289, 147);
            this.btnPuseStursYellow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPuseStursYellow.Name = "btnPuseStursYellow";
            this.btnPuseStursYellow.Size = new System.Drawing.Size(35, 27);
            this.btnPuseStursYellow.TabIndex = 50;
            this.btnPuseStursYellow.UseVisualStyleBackColor = true;
            this.btnPuseStursYellow.Click += new System.EventHandler(this.BtnPuseStursYellow_Click);
            // 
            // btnPuseStursGreen
            // 
            this.btnPuseStursGreen.Image = global::desay.Properties.Resources.LedGreen;
            this.btnPuseStursGreen.Location = new System.Drawing.Point(247, 147);
            this.btnPuseStursGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPuseStursGreen.Name = "btnPuseStursGreen";
            this.btnPuseStursGreen.Size = new System.Drawing.Size(35, 27);
            this.btnPuseStursGreen.TabIndex = 49;
            this.btnPuseStursGreen.UseVisualStyleBackColor = true;
            this.btnPuseStursGreen.Click += new System.EventHandler(this.BtnPuseStursGreen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(137, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 14);
            this.label4.TabIndex = 58;
            this.label4.Text = "停止";
            // 
            // btnStopStursRed
            // 
            this.btnStopStursRed.Image = global::desay.Properties.Resources.LedRed;
            this.btnStopStursRed.Location = new System.Drawing.Point(332, 181);
            this.btnStopStursRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStopStursRed.Name = "btnStopStursRed";
            this.btnStopStursRed.Size = new System.Drawing.Size(35, 27);
            this.btnStopStursRed.TabIndex = 56;
            this.btnStopStursRed.UseVisualStyleBackColor = true;
            this.btnStopStursRed.Click += new System.EventHandler(this.BtnStopStursRed_Click);
            // 
            // btnStopStursYellow
            // 
            this.btnStopStursYellow.Image = ((System.Drawing.Image)(resources.GetObject("btnStopStursYellow.Image")));
            this.btnStopStursYellow.Location = new System.Drawing.Point(289, 181);
            this.btnStopStursYellow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStopStursYellow.Name = "btnStopStursYellow";
            this.btnStopStursYellow.Size = new System.Drawing.Size(35, 27);
            this.btnStopStursYellow.TabIndex = 55;
            this.btnStopStursYellow.UseVisualStyleBackColor = true;
            this.btnStopStursYellow.Click += new System.EventHandler(this.BtnStopStursYellow_Click);
            // 
            // btnStopStursGreen
            // 
            this.btnStopStursGreen.Image = global::desay.Properties.Resources.LedGreen;
            this.btnStopStursGreen.Location = new System.Drawing.Point(247, 181);
            this.btnStopStursGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStopStursGreen.Name = "btnStopStursGreen";
            this.btnStopStursGreen.Size = new System.Drawing.Size(35, 27);
            this.btnStopStursGreen.TabIndex = 54;
            this.btnStopStursGreen.UseVisualStyleBackColor = true;
            this.btnStopStursGreen.Click += new System.EventHandler(this.BtnStopStursGreen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(137, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 63;
            this.label5.Text = "有警示消息";
            // 
            // btnWarningStursRed
            // 
            this.btnWarningStursRed.Image = global::desay.Properties.Resources.LedRed;
            this.btnWarningStursRed.Location = new System.Drawing.Point(332, 215);
            this.btnWarningStursRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWarningStursRed.Name = "btnWarningStursRed";
            this.btnWarningStursRed.Size = new System.Drawing.Size(35, 27);
            this.btnWarningStursRed.TabIndex = 61;
            this.btnWarningStursRed.UseVisualStyleBackColor = true;
            this.btnWarningStursRed.Click += new System.EventHandler(this.BtnWarningStursRed_Click);
            // 
            // btnWarningStursYellow
            // 
            this.btnWarningStursYellow.Image = ((System.Drawing.Image)(resources.GetObject("btnWarningStursYellow.Image")));
            this.btnWarningStursYellow.Location = new System.Drawing.Point(289, 215);
            this.btnWarningStursYellow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWarningStursYellow.Name = "btnWarningStursYellow";
            this.btnWarningStursYellow.Size = new System.Drawing.Size(35, 27);
            this.btnWarningStursYellow.TabIndex = 60;
            this.btnWarningStursYellow.UseVisualStyleBackColor = true;
            this.btnWarningStursYellow.Click += new System.EventHandler(this.BtnWarningStursYellow_Click);
            // 
            // btnWarningStursGreen
            // 
            this.btnWarningStursGreen.Image = global::desay.Properties.Resources.LedGreen;
            this.btnWarningStursGreen.Location = new System.Drawing.Point(247, 215);
            this.btnWarningStursGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWarningStursGreen.Name = "btnWarningStursGreen";
            this.btnWarningStursGreen.Size = new System.Drawing.Size(35, 27);
            this.btnWarningStursGreen.TabIndex = 59;
            this.btnWarningStursGreen.UseVisualStyleBackColor = true;
            this.btnWarningStursGreen.Click += new System.EventHandler(this.BtnWarningStursGreen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(137, 257);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 68;
            this.label6.Text = "原点复位";
            // 
            // btnResetStursRed
            // 
            this.btnResetStursRed.Image = global::desay.Properties.Resources.LedRed;
            this.btnResetStursRed.Location = new System.Drawing.Point(332, 248);
            this.btnResetStursRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnResetStursRed.Name = "btnResetStursRed";
            this.btnResetStursRed.Size = new System.Drawing.Size(35, 27);
            this.btnResetStursRed.TabIndex = 66;
            this.btnResetStursRed.UseVisualStyleBackColor = true;
            this.btnResetStursRed.Click += new System.EventHandler(this.BtnResetStursRed_Click);
            // 
            // btnResetStursYellow
            // 
            this.btnResetStursYellow.Image = ((System.Drawing.Image)(resources.GetObject("btnResetStursYellow.Image")));
            this.btnResetStursYellow.Location = new System.Drawing.Point(289, 248);
            this.btnResetStursYellow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnResetStursYellow.Name = "btnResetStursYellow";
            this.btnResetStursYellow.Size = new System.Drawing.Size(35, 27);
            this.btnResetStursYellow.TabIndex = 65;
            this.btnResetStursYellow.UseVisualStyleBackColor = true;
            this.btnResetStursYellow.Click += new System.EventHandler(this.BtnResetStursYellow_Click);
            // 
            // btnResetStursGreen
            // 
            this.btnResetStursGreen.Image = global::desay.Properties.Resources.LedGreen;
            this.btnResetStursGreen.Location = new System.Drawing.Point(247, 248);
            this.btnResetStursGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnResetStursGreen.Name = "btnResetStursGreen";
            this.btnResetStursGreen.Size = new System.Drawing.Size(35, 27);
            this.btnResetStursGreen.TabIndex = 64;
            this.btnResetStursGreen.UseVisualStyleBackColor = true;
            this.btnResetStursGreen.Click += new System.EventHandler(this.BtnResetStursGreen_Click);
            // 
            // ckbErrSturs
            // 
            this.ckbErrSturs.FormattingEnabled = true;
            this.ckbErrSturs.Items.AddRange(new object[] {
            "静音",
            "长音",
            "间隔音"});
            this.ckbErrSturs.Location = new System.Drawing.Point(375, 110);
            this.ckbErrSturs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbErrSturs.Name = "ckbErrSturs";
            this.ckbErrSturs.Size = new System.Drawing.Size(107, 22);
            this.ckbErrSturs.TabIndex = 69;
            this.ckbErrSturs.SelectedIndexChanged += new System.EventHandler(this.CkbErrSturs_SelectedIndexChanged);
            // 
            // ckbPuseSturs
            // 
            this.ckbPuseSturs.FormattingEnabled = true;
            this.ckbPuseSturs.Items.AddRange(new object[] {
            "静音",
            "长音",
            "间隔音"});
            this.ckbPuseSturs.Location = new System.Drawing.Point(375, 149);
            this.ckbPuseSturs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbPuseSturs.Name = "ckbPuseSturs";
            this.ckbPuseSturs.Size = new System.Drawing.Size(107, 22);
            this.ckbPuseSturs.TabIndex = 70;
            this.ckbPuseSturs.SelectedIndexChanged += new System.EventHandler(this.CkbPuseSturs_SelectedIndexChanged);
            // 
            // ckbStopSturs
            // 
            this.ckbStopSturs.FormattingEnabled = true;
            this.ckbStopSturs.Items.AddRange(new object[] {
            "静音",
            "长音",
            "间隔音"});
            this.ckbStopSturs.Location = new System.Drawing.Point(375, 183);
            this.ckbStopSturs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbStopSturs.Name = "ckbStopSturs";
            this.ckbStopSturs.Size = new System.Drawing.Size(107, 22);
            this.ckbStopSturs.TabIndex = 71;
            this.ckbStopSturs.SelectedIndexChanged += new System.EventHandler(this.CkbStopSturs_SelectedIndexChanged);
            // 
            // ckbWarningSturs
            // 
            this.ckbWarningSturs.FormattingEnabled = true;
            this.ckbWarningSturs.Items.AddRange(new object[] {
            "静音",
            "长音",
            "间隔音"});
            this.ckbWarningSturs.Location = new System.Drawing.Point(375, 219);
            this.ckbWarningSturs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbWarningSturs.Name = "ckbWarningSturs";
            this.ckbWarningSturs.Size = new System.Drawing.Size(107, 22);
            this.ckbWarningSturs.TabIndex = 72;
            this.ckbWarningSturs.SelectedIndexChanged += new System.EventHandler(this.CkbWarningSturs_SelectedIndexChanged);
            // 
            // ckbResetSturs
            // 
            this.ckbResetSturs.FormattingEnabled = true;
            this.ckbResetSturs.Items.AddRange(new object[] {
            "静音",
            "长音",
            "间隔音"});
            this.ckbResetSturs.Location = new System.Drawing.Point(375, 253);
            this.ckbResetSturs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbResetSturs.Name = "ckbResetSturs";
            this.ckbResetSturs.Size = new System.Drawing.Size(107, 22);
            this.ckbResetSturs.TabIndex = 73;
            this.ckbResetSturs.SelectedIndexChanged += new System.EventHandler(this.CkbResetSturs_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(253, 301);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 14);
            this.label7.TabIndex = 74;
            this.label7.Text = "点击可改变状态";
            // 
            // TricolorLampSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ckbResetSturs);
            this.Controls.Add(this.ckbWarningSturs);
            this.Controls.Add(this.ckbStopSturs);
            this.Controls.Add(this.ckbPuseSturs);
            this.Controls.Add(this.ckbErrSturs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnResetStursRed);
            this.Controls.Add(this.btnResetStursYellow);
            this.Controls.Add(this.btnResetStursGreen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnWarningStursRed);
            this.Controls.Add(this.btnWarningStursYellow);
            this.Controls.Add(this.btnWarningStursGreen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStopStursRed);
            this.Controls.Add(this.btnStopStursYellow);
            this.Controls.Add(this.btnStopStursGreen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPuseStursRed);
            this.Controls.Add(this.btnPuseStursYellow);
            this.Controls.Add(this.btnPuseStursGreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnErrStursRed);
            this.Controls.Add(this.btnErrStursYellow);
            this.Controls.Add(this.btnErrStursGreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbbtnRunSturs);
            this.Controls.Add(this.btnRunStursRed);
            this.Controls.Add(this.btnRunStursYellow);
            this.Controls.Add(this.btnRunStursGreen);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TricolorLampSet";
            this.Size = new System.Drawing.Size(896, 503);
            this.Load += new System.EventHandler(this.TricolorLampSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRunStursGreen;
        private System.Windows.Forms.Button btnRunStursYellow;
        private System.Windows.Forms.Button btnRunStursRed;
        private System.Windows.Forms.ComboBox ckbbtnRunSturs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnErrStursRed;
        private System.Windows.Forms.Button btnErrStursYellow;
        private System.Windows.Forms.Button btnErrStursGreen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPuseStursRed;
        private System.Windows.Forms.Button btnPuseStursYellow;
        private System.Windows.Forms.Button btnPuseStursGreen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStopStursRed;
        private System.Windows.Forms.Button btnStopStursYellow;
        private System.Windows.Forms.Button btnStopStursGreen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnWarningStursRed;
        private System.Windows.Forms.Button btnWarningStursYellow;
        private System.Windows.Forms.Button btnWarningStursGreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnResetStursRed;
        private System.Windows.Forms.Button btnResetStursYellow;
        private System.Windows.Forms.Button btnResetStursGreen;
        private System.Windows.Forms.ComboBox ckbErrSturs;
        private System.Windows.Forms.ComboBox ckbPuseSturs;
        private System.Windows.Forms.ComboBox ckbStopSturs;
        private System.Windows.Forms.ComboBox ckbWarningSturs;
        private System.Windows.Forms.ComboBox ckbResetSturs;
        private System.Windows.Forms.Label label7;
    }
}
