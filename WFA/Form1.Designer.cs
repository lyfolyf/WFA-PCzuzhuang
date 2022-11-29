using System;
using System.Runtime.InteropServices;

namespace WFA
{
    partial class MainForm
    {

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_ConnectNet",
       CallingConvention = CallingConvention.Cdecl)]
        extern static uint RseeController_ConnectNet(string address, int port);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_CloseNet",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_CloseNet(uint socket);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_OpenCom",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_OpenCom(string com, int baud, bool overloop);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_CloseCom",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_CloseCom(string com, int com_handle);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_BRTSetChannel",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_BRTSetChannel(int com, uint socket, int channel, int range);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_PLSSetChannel",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_PLSSetChannel(int com, uint socket, int channel, int time);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_BRTReadChannel",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_BRTReadChannel(int com, uint socket, int channel);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_PLSReadChannel",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_PLSReadChannel(int com, uint socket, int channel);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_SetIP",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_SetIP(int com, uint socket, int add_1, int add_2, int add_3, int add_4, IntPtr arr);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_SetPort",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_SetPort(int com, uint socket, int port, IntPtr arr);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_ChangeMode",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_ChangeMode(int com, uint socket, int mode);

        [DllImport(@"RseeController.dll", EntryPoint = "RseeController_PM_D_8TE_ReadInfo",
               CallingConvention = CallingConvention.Cdecl)]
        extern static int RseeController_PM_D_8TE_ReadInfo(int com, uint socket, IntPtr arr);


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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCam1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCam2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCam3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCam4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCam5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSocket = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.hW1 = new HalconDotNet.HWindowControl();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.hW2 = new HalconDotNet.HWindowControl();
            this.hW3 = new HalconDotNet.HWindowControl();
            this.hW4 = new HalconDotNet.HWindowControl();
            this.hW5 = new HalconDotNet.HWindowControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hW_debug = new HalconDotNet.HWindowControl();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvNine = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvCicle = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnSoftTrig = new System.Windows.Forms.Button();
            this.btnLoadLocalImage = new System.Windows.Forms.Button();
            this.btnRealVedio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numExpose = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numGain = new System.Windows.Forms.NumericUpDown();
            this.cbCamIndex = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNine)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCicle)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExpose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGain)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCam1,
            this.tsslCam2,
            this.tsslCam3,
            this.tsslCam4,
            this.tsslCam5,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4,
            this.tsslSocket,
            this.toolStripStatusLabel1,
            this.tsslTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslCam1
            // 
            this.tsslCam1.Name = "tsslCam1";
            this.tsslCam1.Size = new System.Drawing.Size(68, 17);
            this.tsslCam1.Text = "左上角相机";
            // 
            // tsslCam2
            // 
            this.tsslCam2.Name = "tsslCam2";
            this.tsslCam2.Size = new System.Drawing.Size(68, 17);
            this.tsslCam2.Text = "右上角相机";
            // 
            // tsslCam3
            // 
            this.tsslCam3.Name = "tsslCam3";
            this.tsslCam3.Size = new System.Drawing.Size(68, 17);
            this.tsslCam3.Text = "左下角相机";
            // 
            // tsslCam4
            // 
            this.tsslCam4.Name = "tsslCam4";
            this.tsslCam4.Size = new System.Drawing.Size(68, 17);
            this.tsslCam4.Text = "右下角相机";
            // 
            // tsslCam5
            // 
            this.tsslCam5.Name = "tsslCam5";
            this.tsslCam5.Size = new System.Drawing.Size(68, 17);
            this.tsslCam5.Text = "摄像孔相机";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // tsslSocket
            // 
            this.tsslSocket.Name = "tsslSocket";
            this.tsslSocket.Size = new System.Drawing.Size(68, 17);
            this.tsslSocket.Text = "上位机通信";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(839, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsslTime
            // 
            this.tsslTime.Name = "tsslTime";
            this.tsslTime.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1274, 713);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 707);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.hW1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtbLog, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.hW2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.hW3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.hW4, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.hW5, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1268, 707);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // hW1
            // 
            this.hW1.BackColor = System.Drawing.Color.Black;
            this.hW1.BorderColor = System.Drawing.Color.Black;
            this.hW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hW1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hW1.Location = new System.Drawing.Point(3, 3);
            this.hW1.Name = "hW1";
            this.hW1.Size = new System.Drawing.Size(628, 229);
            this.hW1.TabIndex = 0;
            this.hW1.WindowSize = new System.Drawing.Size(628, 229);
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(40)))));
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbLog.ForeColor = System.Drawing.SystemColors.Control;
            this.rtbLog.Location = new System.Drawing.Point(635, 471);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(1);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.Size = new System.Drawing.Size(632, 235);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // hW2
            // 
            this.hW2.BackColor = System.Drawing.Color.Black;
            this.hW2.BorderColor = System.Drawing.Color.Black;
            this.hW2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hW2.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hW2.Location = new System.Drawing.Point(637, 3);
            this.hW2.Name = "hW2";
            this.hW2.Size = new System.Drawing.Size(628, 229);
            this.hW2.TabIndex = 0;
            this.hW2.WindowSize = new System.Drawing.Size(628, 229);
            // 
            // hW3
            // 
            this.hW3.BackColor = System.Drawing.Color.Black;
            this.hW3.BorderColor = System.Drawing.Color.Black;
            this.hW3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hW3.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hW3.Location = new System.Drawing.Point(3, 238);
            this.hW3.Name = "hW3";
            this.hW3.Size = new System.Drawing.Size(628, 229);
            this.hW3.TabIndex = 0;
            this.hW3.WindowSize = new System.Drawing.Size(628, 229);
            // 
            // hW4
            // 
            this.hW4.BackColor = System.Drawing.Color.Black;
            this.hW4.BorderColor = System.Drawing.Color.Black;
            this.hW4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hW4.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hW4.Location = new System.Drawing.Point(637, 238);
            this.hW4.Name = "hW4";
            this.hW4.Size = new System.Drawing.Size(628, 229);
            this.hW4.TabIndex = 0;
            this.hW4.WindowSize = new System.Drawing.Size(628, 229);
            // 
            // hW5
            // 
            this.hW5.BackColor = System.Drawing.Color.Black;
            this.hW5.BorderColor = System.Drawing.Color.Black;
            this.hW5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hW5.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hW5.Location = new System.Drawing.Point(3, 473);
            this.hW5.Name = "hW5";
            this.hW5.Size = new System.Drawing.Size(628, 231);
            this.hW5.TabIndex = 0;
            this.hW5.WindowSize = new System.Drawing.Size(628, 231);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(1, 1);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 739);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(50)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 20);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(1);
            this.tabPage1.Size = new System.Drawing.Size(1276, 715);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "检测";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(50)))));
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 20);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1276, 715);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "调试";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hW_debug);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1270, 709);
            this.splitContainer1.SplitterDistance = 889;
            this.splitContainer1.TabIndex = 0;
            // 
            // hW_debug
            // 
            this.hW_debug.BackColor = System.Drawing.Color.Black;
            this.hW_debug.BorderColor = System.Drawing.Color.Black;
            this.hW_debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hW_debug.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hW_debug.Location = new System.Drawing.Point(0, 0);
            this.hW_debug.Name = "hW_debug";
            this.hW_debug.Size = new System.Drawing.Size(889, 709);
            this.hW_debug.TabIndex = 1;
            this.hW_debug.WindowSize = new System.Drawing.Size(889, 709);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(369, 458);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 3;
            this.tabControl2.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(50)))));
            this.tabPage3.Controls.Add(this.dgvNine);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(361, 432);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "九点标定";
            // 
            // dgvNine
            // 
            this.dgvNine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvNine.Location = new System.Drawing.Point(6, 6);
            this.dgvNine.Name = "dgvNine";
            this.dgvNine.RowHeadersVisible = false;
            this.dgvNine.RowTemplate.Height = 23;
            this.dgvNine.Size = new System.Drawing.Size(391, 316);
            this.dgvNine.TabIndex = 0;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "序号";
            this.Column9.Name = "Column9";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "像素X";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "像素Y";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "物理X";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "物理Y";
            this.Column8.Name = "Column8";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(50)))));
            this.tabPage4.Controls.Add(this.dgvCicle);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(361, 432);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "旋转中心标定";
            // 
            // dgvCicle
            // 
            this.dgvCicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCicle.Location = new System.Drawing.Point(6, 6);
            this.dgvCicle.Name = "dgvCicle";
            this.dgvCicle.RowTemplate.Height = 23;
            this.dgvCicle.Size = new System.Drawing.Size(391, 303);
            this.dgvCicle.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnConfig, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnSoftTrig, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnLoadLocalImage, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnRealVedio, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.button1, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.numExpose, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.numGain, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbCamIndex, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 467);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(356, 242);
            this.tableLayoutPanel2.TabIndex = 2;
            this.tableLayoutPanel2.Visible = false;
            // 
            // btnConfig
            // 
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfig.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfig.Location = new System.Drawing.Point(181, 174);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(171, 27);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "配置";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnSoftTrig
            // 
            this.btnSoftTrig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSoftTrig.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSoftTrig.Location = new System.Drawing.Point(4, 140);
            this.btnSoftTrig.Name = "btnSoftTrig";
            this.btnSoftTrig.Size = new System.Drawing.Size(170, 27);
            this.btnSoftTrig.TabIndex = 3;
            this.btnSoftTrig.Text = "软触发一次";
            this.btnSoftTrig.UseVisualStyleBackColor = true;
            this.btnSoftTrig.Click += new System.EventHandler(this.btnSoftTrig_Click);
            // 
            // btnLoadLocalImage
            // 
            this.btnLoadLocalImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadLocalImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadLocalImage.Location = new System.Drawing.Point(4, 174);
            this.btnLoadLocalImage.Name = "btnLoadLocalImage";
            this.btnLoadLocalImage.Size = new System.Drawing.Size(170, 27);
            this.btnLoadLocalImage.TabIndex = 0;
            this.btnLoadLocalImage.Text = "载入图片";
            this.btnLoadLocalImage.UseVisualStyleBackColor = true;
            this.btnLoadLocalImage.Click += new System.EventHandler(this.btnLoadLocalImage_Click);
            // 
            // btnRealVedio
            // 
            this.btnRealVedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRealVedio.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRealVedio.Location = new System.Drawing.Point(181, 140);
            this.btnRealVedio.Name = "btnRealVedio";
            this.btnRealVedio.Size = new System.Drawing.Size(171, 27);
            this.btnRealVedio.TabIndex = 0;
            this.btnRealVedio.Text = "视频模式";
            this.btnRealVedio.UseVisualStyleBackColor = true;
            this.btnRealVedio.Click += new System.EventHandler(this.btnRealVedio_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(181, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "曝光";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numExpose
            // 
            this.numExpose.DecimalPlaces = 1;
            this.numExpose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numExpose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numExpose.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numExpose.Location = new System.Drawing.Point(181, 38);
            this.numExpose.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numExpose.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numExpose.Name = "numExpose";
            this.numExpose.Size = new System.Drawing.Size(171, 29);
            this.numExpose.TabIndex = 1;
            this.numExpose.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numExpose.ValueChanged += new System.EventHandler(this.numExpose_ValueChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "增益";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numGain
            // 
            this.numGain.DecimalPlaces = 2;
            this.numGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numGain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numGain.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numGain.Location = new System.Drawing.Point(181, 72);
            this.numGain.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numGain.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGain.Name = "numGain";
            this.numGain.Size = new System.Drawing.Size(171, 29);
            this.numGain.TabIndex = 1;
            this.numGain.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGain.ValueChanged += new System.EventHandler(this.numGain_ValueChanged);
            // 
            // cbCamIndex
            // 
            this.cbCamIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCamIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamIndex.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCamIndex.FormattingEnabled = true;
            this.cbCamIndex.Items.AddRange(new object[] {
            "左上角相机",
            "右上角相机",
            "左下角相机",
            "右下角相机",
            "摄像孔相机"});
            this.cbCamIndex.Location = new System.Drawing.Point(181, 4);
            this.cbCamIndex.Name = "cbCamIndex";
            this.cbCamIndex.Size = new System.Drawing.Size(171, 27);
            this.cbCamIndex.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "相机";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "TP_PC组装";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNine)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCicle)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numExpose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HalconDotNet.HWindowControl hW1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ToolStripStatusLabel tsslCam1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslCam2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslSocket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private HalconDotNet.HWindowControl hW2;
        private HalconDotNet.HWindowControl hW3;
        private HalconDotNet.HWindowControl hW4;
        private HalconDotNet.HWindowControl hW5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private HalconDotNet.HWindowControl hW_debug;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnSoftTrig;
        private System.Windows.Forms.ComboBox cbCamIndex;
        private System.Windows.Forms.Button btnLoadLocalImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRealVedio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numExpose;
        private System.Windows.Forms.NumericUpDown numGain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvNine;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvCicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ToolStripStatusLabel tsslCam3;
        private System.Windows.Forms.ToolStripStatusLabel tsslCam4;
        private System.Windows.Forms.ToolStripStatusLabel tsslCam5;
    }
}

