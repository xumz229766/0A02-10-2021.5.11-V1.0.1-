namespace desay
{
    partial class CutControlView<T>
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
            this.gbxPosition = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTestCut = new System.Windows.Forms.Button();
            this.BtnSaveCloseCut = new System.Windows.Forms.Button();
            this.BtnGotoCloseCut = new System.Windows.Forms.Button();
            this.BtnSaveBufCut = new System.Windows.Forms.Button();
            this.BtnGotoBufCut = new System.Windows.Forms.Button();
            this.BtnSaveOpenCut = new System.Windows.Forms.Button();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.lblPointX = new System.Windows.Forms.Label();
            this.lblPointY = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.lblPointZ = new System.Windows.Forms.Label();
            this.BtnGotoOpenCut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnCRotate = new System.Windows.Forms.Button();
            this.btnPMove = new System.Windows.Forms.Button();
            this.flpView = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbxPosition.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxPosition
            // 
            this.gbxPosition.Controls.Add(this.tableLayoutPanel2);
            this.gbxPosition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxPosition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxPosition.Location = new System.Drawing.Point(0, 320);
            this.gbxPosition.Margin = new System.Windows.Forms.Padding(2);
            this.gbxPosition.Name = "gbxPosition";
            this.gbxPosition.Padding = new System.Windows.Forms.Padding(2);
            this.gbxPosition.Size = new System.Drawing.Size(620, 115);
            this.gbxPosition.TabIndex = 0;
            this.gbxPosition.TabStop = false;
            this.gbxPosition.Text = "位置";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.9992F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.9992F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.9992F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.9992F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0032F));
            this.tableLayoutPanel2.Controls.Add(this.btnTestCut, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnSaveCloseCut, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.BtnGotoCloseCut, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.BtnSaveBufCut, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnGotoBufCut, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnSaveOpenCut, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblName1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblName2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPointX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPointY, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblName3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblPointZ, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.BtnGotoOpenCut, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(616, 97);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnTestCut
            // 
            this.btnTestCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTestCut.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestCut.Location = new System.Drawing.Point(492, 4);
            this.btnTestCut.Name = "btnTestCut";
            this.tableLayoutPanel2.SetRowSpan(this.btnTestCut, 3);
            this.btnTestCut.Size = new System.Drawing.Size(120, 89);
            this.btnTestCut.TabIndex = 10;
            this.btnTestCut.Text = "测试剪产品";
            this.btnTestCut.UseVisualStyleBackColor = true;
            this.btnTestCut.Click += new System.EventHandler(this.btnTestCut_Click);
            // 
            // BtnSaveCloseCut
            // 
            this.BtnSaveCloseCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveCloseCut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSaveCloseCut.Location = new System.Drawing.Point(370, 67);
            this.BtnSaveCloseCut.Name = "BtnSaveCloseCut";
            this.BtnSaveCloseCut.Size = new System.Drawing.Size(115, 26);
            this.BtnSaveCloseCut.TabIndex = 9;
            this.BtnSaveCloseCut.Text = "保存";
            this.BtnSaveCloseCut.UseVisualStyleBackColor = true;
            this.BtnSaveCloseCut.Click += new System.EventHandler(this.BtnSaveCloseCut_Click);
            // 
            // BtnGotoCloseCut
            // 
            this.BtnGotoCloseCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGotoCloseCut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGotoCloseCut.Location = new System.Drawing.Point(248, 67);
            this.BtnGotoCloseCut.Name = "BtnGotoCloseCut";
            this.BtnGotoCloseCut.Size = new System.Drawing.Size(115, 26);
            this.BtnGotoCloseCut.TabIndex = 8;
            this.BtnGotoCloseCut.Text = "定位";
            this.BtnGotoCloseCut.UseVisualStyleBackColor = true;
            this.BtnGotoCloseCut.Click += new System.EventHandler(this.BtnGotoCloseCut_Click);
            // 
            // BtnSaveBufCut
            // 
            this.BtnSaveBufCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveBufCut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSaveBufCut.Location = new System.Drawing.Point(370, 35);
            this.BtnSaveBufCut.Name = "BtnSaveBufCut";
            this.BtnSaveBufCut.Size = new System.Drawing.Size(115, 25);
            this.BtnSaveBufCut.TabIndex = 7;
            this.BtnSaveBufCut.Text = "保存";
            this.BtnSaveBufCut.UseVisualStyleBackColor = true;
            this.BtnSaveBufCut.Click += new System.EventHandler(this.BtnSaveBufCut_Click);
            // 
            // BtnGotoBufCut
            // 
            this.BtnGotoBufCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGotoBufCut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGotoBufCut.Location = new System.Drawing.Point(248, 35);
            this.BtnGotoBufCut.Name = "BtnGotoBufCut";
            this.BtnGotoBufCut.Size = new System.Drawing.Size(115, 25);
            this.BtnGotoBufCut.TabIndex = 6;
            this.BtnGotoBufCut.Text = "定位";
            this.BtnGotoBufCut.UseVisualStyleBackColor = true;
            this.BtnGotoBufCut.Click += new System.EventHandler(this.BtnGotoBufCut_Click);
            // 
            // BtnSaveOpenCut
            // 
            this.BtnSaveOpenCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveOpenCut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSaveOpenCut.Location = new System.Drawing.Point(370, 4);
            this.BtnSaveOpenCut.Name = "BtnSaveOpenCut";
            this.BtnSaveOpenCut.Size = new System.Drawing.Size(115, 24);
            this.BtnSaveOpenCut.TabIndex = 5;
            this.BtnSaveOpenCut.Text = "保存";
            this.BtnSaveOpenCut.UseVisualStyleBackColor = true;
            this.BtnSaveOpenCut.Click += new System.EventHandler(this.BtnSaveOpenCut_Click);
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName1.Location = new System.Drawing.Point(4, 1);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(115, 30);
            this.lblName1.TabIndex = 0;
            this.lblName1.Text = "刀口打开位";
            this.lblName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName2.Location = new System.Drawing.Point(4, 32);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(115, 31);
            this.lblName2.TabIndex = 1;
            this.lblName2.Text = "刀口缓冲位";
            this.lblName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointX
            // 
            this.lblPointX.AutoSize = true;
            this.lblPointX.BackColor = System.Drawing.Color.Transparent;
            this.lblPointX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPointX.ForeColor = System.Drawing.Color.Black;
            this.lblPointX.Location = new System.Drawing.Point(126, 1);
            this.lblPointX.Name = "lblPointX";
            this.lblPointX.Size = new System.Drawing.Size(115, 30);
            this.lblPointX.TabIndex = 2;
            this.lblPointX.Text = "0000.000";
            this.lblPointX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointY
            // 
            this.lblPointY.AutoSize = true;
            this.lblPointY.BackColor = System.Drawing.Color.Transparent;
            this.lblPointY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointY.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPointY.ForeColor = System.Drawing.Color.Black;
            this.lblPointY.Location = new System.Drawing.Point(126, 32);
            this.lblPointY.Name = "lblPointY";
            this.lblPointY.Size = new System.Drawing.Size(115, 31);
            this.lblPointY.TabIndex = 3;
            this.lblPointY.Text = "0000.000";
            this.lblPointY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName3.Location = new System.Drawing.Point(4, 64);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(115, 32);
            this.lblName3.TabIndex = 1;
            this.lblName3.Text = "刀口关闭位";
            this.lblName3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointZ
            // 
            this.lblPointZ.AutoSize = true;
            this.lblPointZ.BackColor = System.Drawing.Color.Transparent;
            this.lblPointZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPointZ.ForeColor = System.Drawing.Color.Black;
            this.lblPointZ.Location = new System.Drawing.Point(126, 64);
            this.lblPointZ.Name = "lblPointZ";
            this.lblPointZ.Size = new System.Drawing.Size(115, 32);
            this.lblPointZ.TabIndex = 3;
            this.lblPointZ.Text = "0000.000";
            this.lblPointZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnGotoOpenCut
            // 
            this.BtnGotoOpenCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnGotoOpenCut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGotoOpenCut.Location = new System.Drawing.Point(248, 4);
            this.BtnGotoOpenCut.Name = "BtnGotoOpenCut";
            this.BtnGotoOpenCut.Size = new System.Drawing.Size(115, 24);
            this.BtnGotoOpenCut.TabIndex = 4;
            this.BtnGotoOpenCut.Text = "定位";
            this.BtnGotoOpenCut.UseVisualStyleBackColor = true;
            this.BtnGotoOpenCut.Click += new System.EventHandler(this.BtnGotoOpenCut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 227);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(620, 93);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手动";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.BtnCRotate);
            this.flowLayoutPanel2.Controls.Add(this.btnPMove);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(616, 75);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // BtnCRotate
            // 
            this.BtnCRotate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCRotate.Location = new System.Drawing.Point(3, 3);
            this.BtnCRotate.Name = "BtnCRotate";
            this.BtnCRotate.Size = new System.Drawing.Size(136, 45);
            this.BtnCRotate.TabIndex = 0;
            this.BtnCRotate.Text = "C轴旋转";
            this.BtnCRotate.UseVisualStyleBackColor = true;
            this.BtnCRotate.Click += new System.EventHandler(this.BtnCRotate_Click);
            // 
            // btnPMove
            // 
            this.btnPMove.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPMove.Location = new System.Drawing.Point(145, 3);
            this.btnPMove.Name = "btnPMove";
            this.btnPMove.Size = new System.Drawing.Size(136, 45);
            this.btnPMove.TabIndex = 0;
            this.btnPMove.Text = "P轴前后";
            this.btnPMove.UseVisualStyleBackColor = true;
            this.btnPMove.Click += new System.EventHandler(this.btnPMove_Click);
            // 
            // flpView
            // 
            this.flpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpView.Location = new System.Drawing.Point(0, 0);
            this.flpView.Name = "flpView";
            this.flpView.Size = new System.Drawing.Size(620, 227);
            this.flpView.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CutControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxPosition);
            this.Name = "CutControlView";
            this.Size = new System.Drawing.Size(620, 435);
            this.Load += new System.EventHandler(this.CutControlView_Load);
            this.gbxPosition.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPosition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnSaveCloseCut;
        private System.Windows.Forms.Button BtnGotoCloseCut;
        private System.Windows.Forms.Button BtnSaveBufCut;
        private System.Windows.Forms.Button BtnGotoBufCut;
        private System.Windows.Forms.Button BtnSaveOpenCut;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Label lblPointX;
        private System.Windows.Forms.Label lblPointY;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.Label lblPointZ;
        private System.Windows.Forms.Button BtnGotoOpenCut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestCut;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flpView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnCRotate;
        private System.Windows.Forms.Button btnPMove;
    }
}
