namespace desay
{
    partial class Position4DEditView<T>
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
            this.flpView = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxPosition = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnGotoSafetyZ = new System.Windows.Forms.Button();
            this.btnSaveSafetyZ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbManualInput = new System.Windows.Forms.CheckBox();
            this.tbPointX = new System.Windows.Forms.TextBox();
            this.tbPointY = new System.Windows.Forms.TextBox();
            this.tbPointZ = new System.Windows.Forms.TextBox();
            this.tbSafetyZ = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbxPosition.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpView
            // 
            this.flpView.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpView.Location = new System.Drawing.Point(0, 0);
            this.flpView.Margin = new System.Windows.Forms.Padding(2);
            this.flpView.Name = "flpView";
            this.flpView.Size = new System.Drawing.Size(736, 296);
            this.flpView.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(290, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(1);
            this.btnSave.Name = "btnSave";
            this.tableLayoutPanel2.SetRowSpan(this.btnSave, 3);
            this.btnSave.Size = new System.Drawing.Size(94, 63);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 447);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 68);
            this.panel1.TabIndex = 1;
            // 
            // gbxPosition
            // 
            this.gbxPosition.Controls.Add(this.tableLayoutPanel2);
            this.gbxPosition.Location = new System.Drawing.Point(2, 2);
            this.gbxPosition.Margin = new System.Windows.Forms.Padding(2);
            this.gbxPosition.Name = "gbxPosition";
            this.gbxPosition.Padding = new System.Windows.Forms.Padding(2);
            this.gbxPosition.Size = new System.Drawing.Size(390, 133);
            this.gbxPosition.TabIndex = 0;
            this.gbxPosition.TabStop = false;
            this.gbxPosition.Text = "位置";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.82835F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.10663F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.03251F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.03251F));
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblName1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblName2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblName3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnGoto, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGotoSafetyZ, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnSaveSafetyZ, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbManualInput, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tbPointX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbPointY, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbPointZ, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbSafetyZ, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.92982F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.17544F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 115);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName1.Location = new System.Drawing.Point(4, 1);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(100, 21);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "X轴";
            this.lblName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName2.Location = new System.Drawing.Point(4, 23);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(100, 21);
            this.lblName2.TabIndex = 1;
            this.lblName2.Text = "Y轴";
            this.lblName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName3.Location = new System.Drawing.Point(4, 45);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(100, 21);
            this.lblName3.TabIndex = 1;
            this.lblName3.Text = "Z轴";
            this.lblName3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Z轴安全高度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGoto
            // 
            this.btnGoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGoto.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGoto.Location = new System.Drawing.Point(194, 2);
            this.btnGoto.Margin = new System.Windows.Forms.Padding(1);
            this.btnGoto.Name = "btnGoto";
            this.tableLayoutPanel2.SetRowSpan(this.btnGoto, 3);
            this.btnGoto.Size = new System.Drawing.Size(93, 63);
            this.btnGoto.TabIndex = 2;
            this.btnGoto.Text = "定位";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnGotoSafetyZ
            // 
            this.btnGotoSafetyZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGotoSafetyZ.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGotoSafetyZ.Location = new System.Drawing.Point(193, 67);
            this.btnGotoSafetyZ.Margin = new System.Windows.Forms.Padding(0);
            this.btnGotoSafetyZ.Name = "btnGotoSafetyZ";
            this.btnGotoSafetyZ.Size = new System.Drawing.Size(95, 23);
            this.btnGotoSafetyZ.TabIndex = 1;
            this.btnGotoSafetyZ.Text = "定位";
            this.btnGotoSafetyZ.UseVisualStyleBackColor = true;
            this.btnGotoSafetyZ.Click += new System.EventHandler(this.btnGotoSafetyZ_Click);
            // 
            // btnSaveSafetyZ
            // 
            this.btnSaveSafetyZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveSafetyZ.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveSafetyZ.Location = new System.Drawing.Point(289, 67);
            this.btnSaveSafetyZ.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveSafetyZ.Name = "btnSaveSafetyZ";
            this.btnSaveSafetyZ.Size = new System.Drawing.Size(96, 23);
            this.btnSaveSafetyZ.TabIndex = 1;
            this.btnSaveSafetyZ.Text = "保存";
            this.btnSaveSafetyZ.UseVisualStyleBackColor = true;
            this.btnSaveSafetyZ.Click += new System.EventHandler(this.btnSaveSafetyZ_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "手动输入";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbManualInput
            // 
            this.cbManualInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbManualInput.AutoSize = true;
            this.cbManualInput.Location = new System.Drawing.Point(142, 95);
            this.cbManualInput.Name = "cbManualInput";
            this.cbManualInput.Size = new System.Drawing.Size(15, 14);
            this.cbManualInput.TabIndex = 5;
            this.cbManualInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbManualInput.UseVisualStyleBackColor = true;
            this.cbManualInput.CheckedChanged += new System.EventHandler(this.cbManualInput_CheckedChanged);
            // 
            // tbPointX
            // 
            this.tbPointX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPointX.Enabled = false;
            this.tbPointX.Location = new System.Drawing.Point(108, 1);
            this.tbPointX.Margin = new System.Windows.Forms.Padding(0);
            this.tbPointX.Name = "tbPointX";
            this.tbPointX.Size = new System.Drawing.Size(84, 21);
            this.tbPointX.TabIndex = 6;
            this.tbPointX.Text = "0.000";
            this.tbPointX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPointY
            // 
            this.tbPointY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPointY.Enabled = false;
            this.tbPointY.Location = new System.Drawing.Point(108, 23);
            this.tbPointY.Margin = new System.Windows.Forms.Padding(0);
            this.tbPointY.Name = "tbPointY";
            this.tbPointY.Size = new System.Drawing.Size(84, 21);
            this.tbPointY.TabIndex = 7;
            this.tbPointY.Text = "0.000";
            this.tbPointY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPointZ
            // 
            this.tbPointZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPointZ.Enabled = false;
            this.tbPointZ.Location = new System.Drawing.Point(108, 45);
            this.tbPointZ.Margin = new System.Windows.Forms.Padding(0);
            this.tbPointZ.Name = "tbPointZ";
            this.tbPointZ.Size = new System.Drawing.Size(84, 21);
            this.tbPointZ.TabIndex = 8;
            this.tbPointZ.Text = "0.000";
            this.tbPointZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSafetyZ
            // 
            this.tbSafetyZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSafetyZ.Enabled = false;
            this.tbSafetyZ.Location = new System.Drawing.Point(108, 67);
            this.tbSafetyZ.Margin = new System.Windows.Forms.Padding(0);
            this.tbSafetyZ.Name = "tbSafetyZ";
            this.tbSafetyZ.Size = new System.Drawing.Size(84, 21);
            this.tbSafetyZ.TabIndex = 9;
            this.tbSafetyZ.Text = "0.000";
            this.tbSafetyZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.57065F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.42935F));
            this.tableLayoutPanel1.Controls.Add(this.gbxPosition, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 296);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 146);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(411, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(322, 140);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Position4DEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Position4DEditView";
            this.Size = new System.Drawing.Size(736, 515);
            this.Load += new System.EventHandler(this.uc4DPointView_Load);
            this.gbxPosition.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbxPosition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGotoSafetyZ;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnSaveSafetyZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbManualInput;
        private System.Windows.Forms.TextBox tbPointX;
        private System.Windows.Forms.TextBox tbPointY;
        private System.Windows.Forms.TextBox tbPointZ;
        private System.Windows.Forms.TextBox tbSafetyZ;
    }
}
