using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using TcpSocket;
using System.Net;
using System.Timers;
using DataGridViewTools;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using Mark.CommonFile;
namespace WFA
{
    public partial class MainForm : Form
    {


        private AcqFIFOManager mAcqFIFOManager = null;
        private RecordDisplay mRecordDisplay_LU = null;
        private RecordDisplay mRecordDisplay_LD = null;
        private RecordDisplay mRecordDisplay_RU = null;
        private RecordDisplay mRecordDisplay_RD = null;
        private RecordDisplay mRecordDisplay_Cam = null;

        private RecordDisplay mRecordDisplay_Debug = null;
        //private HObject img;

        private bool IsVedio = false;

        bool r1 = false;
        bool r2 = false;
        bool r3 = false;
        bool r4 = false;
        bool Cam_hole = false;
        bool secTrig = false;
        int Com7_Handle = 0;//网口通信句柄
        int Com3_Handle = 0;//串口通信句柄
        int Com5_Handle = 0;//串口通信句柄

        private Server server = null;//视觉作为服务端 
        private Client socketClient = null;
        private Action actLoadHdev = null;

        private TcpClient mTcpClient = null; //我作为服务器时  连上的客户端信息
        private int nSum = 0;
        private int nOK = 0;
        private string strRece = "";

        private double degLcd = 0;
        private double degAAA = 0;

        private HTuple LU_LCD_X;
        private HTuple LU_LCD_Y;
        private HTuple LU_LCD_Result;

        //private HRegion LU_LCD_Line1;
        //private HRegion LU_LCD_Line2;

        private HTuple LD_LCD_X;
        private HTuple LD_LCD_Y;
        private HTuple LD_LCD_Result;
        //private HRegion LD_LCD_Line1;
        //private HRegion LD_LCD_Line2;


        private HTuple RU_LCD_X;
        private HTuple RU_LCD_Y;
        private HTuple RU_LCD_Result;
        //private HRegion RU_LCD_Line1;
        //private HRegion RU_LCD_Line2;

        private HTuple RD_LCD_X;
        private HTuple RD_LCD_Y;
        private HTuple RD_LCD_Result;
        //private HRegion RD_LCD_Line1;
        //private HRegion RD_LCD_Line2;


        private HTuple LU_A_X;
        private HTuple LU_A_Y;
        private HTuple LU_A_Result;
        //private HRegion LU_A_Line1;
        //private HRegion LU_A_Line2;


        private HTuple LD_A_X;
        private HTuple LD_A_Y;
        private HTuple LD_A_Result;
        //private HRegion LD_A_Line1;
        //private HRegion LD_A_Line2;

        private HTuple RU_A_X;
        private HTuple RU_A_Y;
        private HTuple RU_A_Result;
        //private HRegion RU_A_Line1;
        //private HRegion RU_A_Line2;

        private HTuple RD_A_X;
        private HTuple RD_A_Y;
        private HTuple RD_A_Result;



        private HTuple LU_DIS_X;
        private HTuple LU_DIS_Y;

        private HTuple LD_DIS_X;
        private HTuple LD_DIS_Y;

        private HTuple RU_DIS_X;
        private HTuple RU_DIS_Y;

        private HTuple RD_DIS_X;
        private HTuple RD_DIS_Y;

        private string dataFilePaht = "";

        private string strCommand = "";
        private System.Timers.Timer tme = new System.Timers.Timer();

        private HTuple LD_LCD_R;
        private HTuple LD_AAA_R;



        public MainForm()
        {
            InitializeComponent();
            DataGridViewToolsClass dgt = new DataGridViewToolsClass();
            //dgt.NoShanSHuo(dgv);

            InitAcqFIFOManager();
   
            actLoadHdev = ImageDealProcess.I_P.LoadHdevFile;
            InitTcp();

            LU_LCD_X = new HTuple();
            LU_LCD_Y = new HTuple();
            LU_LCD_Result = new HTuple();



        LD_LCD_X = new HTuple();
         LD_LCD_Y = new HTuple();
        LD_LCD_Result = new HTuple();



       RU_LCD_X = new HTuple();
        RU_LCD_Y = new HTuple();
        RU_LCD_Result = new HTuple();


         RD_LCD_X = new HTuple();
         RD_LCD_Y = new HTuple();
         RD_LCD_Result = new HTuple();



          LU_A_X = new HTuple();
          LU_A_Y = new HTuple();
          LU_A_Result = new HTuple();



          LD_A_X = new HTuple();
          LD_A_Y = new HTuple();
          LD_A_Result = new HTuple();


          RU_A_X = new HTuple();
          RU_A_Y = new HTuple();
          RU_A_Result = new HTuple();


          RD_A_X = new HTuple();
          RD_A_Y = new HTuple();
          RD_A_Result = new HTuple();


            LU_DIS_X = new HTuple();
            LU_DIS_Y = new HTuple();

            LD_DIS_X = new HTuple();
            LD_DIS_Y = new HTuple();

            RU_DIS_X = new HTuple();
            RU_DIS_Y = new HTuple();

            RD_DIS_X = new HTuple();
            RD_DIS_Y = new HTuple();

            LD_LCD_R = new HTuple();
            LD_AAA_R = new HTuple();
        }

        private void InitLight()
        {
            try
            {
                Com3_Handle = RseeController_OpenCom(SysConfig.PortName.Split(',')[0], 19200, true);
                Com5_Handle = RseeController_OpenCom(SysConfig.PortName.Split(',')[1], 19200, true);
                Com7_Handle = RseeController_OpenCom(SysConfig.PortName.Split(',')[2], 19200, true);
                //设置所有通道 亮度为0
                for (int i = 1; i < 9; i++)
                {
                    RseeController_PM_D_8TE_BRTSetChannel(Com3_Handle, 0, i, 0);
                    RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, i, 0);
                    RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, i, 0);
                }
                string errmsg = "";
                errmsg += Com3_Handle == 0 ? "左边光源控制器开启失败!": "左边光源控制器开启成功!"+Environment.NewLine;
                errmsg += Com5_Handle == 0 ? "中间光源控制器开启失败!" : "中间光源控制器开启成功!" + Environment.NewLine;
                errmsg += Com7_Handle == 0 ? "右边光源控制器开启失败!" : "右边光源控制器开启成功!" + Environment.NewLine;
                UpdateLog("发送通信指令:" + errmsg, Color.Lime);
            }
            catch (Exception ex)
            {

               
            }
        }
 

        private void InitTime()
        {

            tme.AutoReset = true;
            tme.Interval = 500;
            tme.Elapsed += Tme_Elapsed;
            tme.Enabled = true;
        }

        private void Tme_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ElapsedEventHandler(Tme_Elapsed), sender, e);
                return;
            }
            try
            {
                tsslTime.Text = DateTime.Now.ToString("MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {

            
            }
        }

        #region  TCP通信与注册事件

        private void InitTcp()
        {
            try
            {

                //socketClient = new Client(SysConfig.mHostIP, Convert.ToInt32(SysConfig.mPort));
                //socketClient.TcpConnected += SocketClient_TcpConnected;
                //socketClient.TcpDateReceived += SocketClient_TcpDateReceived;
                //socketClient.TcpDateSend += SocketClient_TcpDateSend;
                //socketClient.TcpDisConnected += SocketClient_TcpDisConnected;
                //socketClient.Connect();


                server = new Server(SysConfig.mHostIP, Convert.ToInt32(SysConfig.mPort));
                server.TcpConnected += Server_TcpConnected;
                server.TcpDateReceived += Server_TcpDateReceived;
                server.TcpDateSend += Server_TcpDateSend;
                server.TcpDisConnected += Server_TcpDisConnected;
                server.Start();
            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }
        }

        private void Server_TcpDisConnected(object sender, TcpDateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TcpDisConnectedEventHandler(Server_TcpDisConnected), sender, e);
                return;
            }
            tsslSocket.BackColor = Color.Red;
            UpdateLog("客户端已断开!", Color.Lime);
        }

        private void Server_TcpDateSend(object sender, TcpDateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TcpDateSendEventHandler(Server_TcpDateSend), sender, e);
                return;
            }
            UpdateLog("发送通信指令:" + e.Message, Color.Lime);
        }

        private void Server_TcpDateReceived(object sender, TcpDateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TcpDateReceivedEventHandler(Server_TcpDateReceived), sender, e);
                return;
            }
            //Catch;LCD;ToolNO   拍摄LCD
            //Catch;AAA;ToolNO   拍摄A壳
            strCommand = e.Message;
            UpdateLog("接收通信指令:" + e.Message, Color.Lime);
            if (strCommand.Contains("AAA") || strCommand.Contains("LCD") || strCommand.Contains("CHE"))
            {
                UpdateLog("触发拍照", Color.Lime);

                Task task = Task.Run(() =>
                {


                    TrigCam(strCommand.Substring(6,3));
                });
                //线程触发相机拍照. 3S后取结果
                task.ContinueWith((o) =>
                {
                    GetResult();
                });
            }
        }

        private void Server_TcpConnected(object sender, TcpDateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TcpConnectedEventHandler(Server_TcpConnected), sender, e);
                return;
            }

            mTcpClient = e.Client;
            tsslSocket.BackColor = Color.Lime;
            UpdateLog("客户端已连上!", Color.Lime);
          

        }



        //private void SocketClient_TcpDisConnected(object sender, TcpDateEventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new TcpDisConnectedEventHandler(SocketClient_TcpDisConnected), sender, e);
        //        return;
        //    }
        //    tsslSocket.BackColor = Color.Red;
        //}

        //private void SocketClient_TcpDateSend(object sender, TcpDateEventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new TcpDateSendEventHandler(SocketClient_TcpDateSend), sender, e);
        //        return;
        //    }

        //    UpdateLog("发送通信指令:" + e.Message, Color.Lime);

        //}

        //private void SocketClient_TcpDateReceived(object sender, TcpDateEventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new TcpDateReceivedEventHandler(SocketClient_TcpDateReceived), sender, e);
        //        return;
        //    }
        //    // 判断是拍A壳 还是 LCD
        //    strCommand = e.Message;


        //    //Catch;LCD;ToolNO   拍摄LCD
        //    //Catch;AAA;ToolNO   拍摄A壳
        //    UpdateLog("接收通信指令:" + e.Message, Color.Lime);
        //    if (strCommand.Contains("AAA") || strCommand.Contains("LCD"))
        //    {
        //        UpdateLog("触发拍照", Color.Lime);

        //        Task task = Task.Run(() => {
        //            TrigCam(strCommand.Contains("AAA"));
        //        });
        //        //线程触发相机拍照. 3S后取结果
        //        task.ContinueWith((o) => {
        //            GetResult();
        //        });
        //    }

        //}

        //private void SocketClient_TcpConnected(object sender, TcpDateEventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new TcpConnectedEventHandler(SocketClient_TcpConnected), sender, e);
        //        return;
        //    }
        //    tsslSocket.BackColor = Color.Lime;

        //}


        //private void Server_TcpDateSend(object sender, TcpDateEventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new TcpDateSendEventHandler(Server_TcpDateSend), sender, e);
        //        return;
        //    }
        //    UpdateLog("发送通信指令:"+e.Message,Color.Lime);
        //}

        //private void Server_TcpDisConnected(object sender, TcpDateEventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new TcpDisConnectedEventHandler(Server_TcpDisConnected), sender, e);
        //        return;
        //    }
        //    tsslSocket.BackColor = Color.Red;
        //}

        //private void Server_TcpDateReceived(object sender, TcpDateEventArgs e)
        //{
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new TcpDateReceivedEventHandler(Server_TcpDateReceived), sender, e);
        //        return;
        //    }
        //    try
        //    {
        //        strRece = e.Message;
        //        UpdateLog("收到通信指令:"+strRece,Color.Lime);

        //    }
        //    catch (Exception ex)
        //    {

        //        ErrLog.WriteLogEx(ex.ToString());
        //    }
        //}

        //private void Server_TcpConnected(object sender, TcpDateEventArgs e)
        //{
        //    //if (InvokeRequired)
        //    //{
        //    //    BeginInvoke(new TcpConnectedEventHandler(Server_TcpConnected),sender,e);
        //    //    return;
        //    //}

        //    mTcpClient = e.Client;
        //    tsslSocket.BackColor = Color.Lime;
        //    UpdateLog("客户端已连上!",Color.Lime);
        //}

        #endregion

        #region 相机初始化与 图片获取事件

        private void InitAcqFIFOManager()
        {
            try
            {
                mAcqFIFOManager = new AcqFIFOManager();
                mAcqFIFOManager.InitAcqFIFOManager();  // 初始化相机
                mAcqFIFOManager.OnImageReady += MAcqFIFOManager_OnImageReady;

                if (mAcqFIFOManager.AcqFifo1 != null)
                {
                    mAcqFIFOManager.AcqFifo1.TriggerSource(7); //设置触发方式为软件触发
                    mAcqFIFOManager.SetTriggerModel(1, true);
                    mAcqFIFOManager.SetExposure(1, SysConfig.ExposureLU_A);
                    mAcqFIFOManager.SetGain(1, Convert.ToSingle(SysConfig.Gain1));
                   // mAcqFIFOManager.StartAcquire(1);
                }
                if (mAcqFIFOManager.AcqFifo2 != null)
                {
                    mAcqFIFOManager.AcqFifo2.TriggerSource(7); //设置触发方式为软件触发
                    mAcqFIFOManager.SetTriggerModel(2, true);
                    mAcqFIFOManager.SetExposure(2, SysConfig.ExposureRU_A);
                    mAcqFIFOManager.SetGain(2, Convert.ToSingle(SysConfig.Gain2));
                   // mAcqFIFOManager.StartAcquire(2);
                }
                if (mAcqFIFOManager.AcqFifo3 != null)
                {
                    mAcqFIFOManager.AcqFifo3.TriggerSource(7); //设置触发方式为软件触发
                    mAcqFIFOManager.SetTriggerModel(3, true);
                    mAcqFIFOManager.SetExposure(3, SysConfig.ExposureLD_A);
                    mAcqFIFOManager.SetGain(3, Convert.ToSingle(SysConfig.Gain3));
                  //  mAcqFIFOManager.StartAcquire(3);
                }
                if (mAcqFIFOManager.AcqFifo4 != null)
                {
                    mAcqFIFOManager.AcqFifo4.TriggerSource(7); //设置触发方式为软件触发
                    mAcqFIFOManager.SetTriggerModel(4, true);
                    mAcqFIFOManager.SetExposure(4, SysConfig.ExposureRD_A);
                    mAcqFIFOManager.SetGain(4, Convert.ToSingle(SysConfig.Gain4));
                    //mAcqFIFOManager.StartAcquire(4);
                }
                if (mAcqFIFOManager.AcqFifo5 != null)
                {
                    mAcqFIFOManager.AcqFifo5.TriggerSource(7); //设置触发方式为软件触发
                    mAcqFIFOManager.SetTriggerModel(5, true);
                    mAcqFIFOManager.SetExposure(5, SysConfig.Exposure_ACam);
                    mAcqFIFOManager.SetGain(5, Convert.ToSingle(SysConfig.Gain5));
                   // mAcqFIFOManager.StartAcquire(5);
                }

                mAcqFIFOManager.StartAcquire(1);
                mAcqFIFOManager.StartAcquire(2);
                mAcqFIFOManager.StartAcquire(3);
                mAcqFIFOManager.StartAcquire(4);
                mAcqFIFOManager.StartAcquire(5);

            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }
        }

        private void MAcqFIFOManager_OnImageReady(uint camNo, HObject  _Image)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ImageReadyHandler(MAcqFIFOManager_OnImageReady), camNo, _Image);
                return;
            }
            try
            {
                if (IsVedio)
                {
                    //mRecordDisplay_Debug.Image = _Image;
                  

                }
                else
                {
                    switch (camNo)
                    {

                        case 1:
                            mRecordDisplay_LU.Clear();
                            mRecordDisplay_LU.Image = _Image;
                            ImageSave("左上_",_Image);
                            if (strCommand.Contains("LCD"))
                            {

                                if (ImageDealProcess.I_P.Run_LU_LCD(_Image))
                                {
                                    LU_LCD_Result = ImageDealProcess.hprocall_LU_LCD.GetOutputCtrlParamTuple("Result");
                                    LU_LCD_X.Dispose();
                                    LU_LCD_Y.Dispose();
                                    GC.Collect();
                                    LU_LCD_X = ImageDealProcess.hprocall_LU_LCD.GetOutputCtrlParamTuple("Xcol");
                                    LU_LCD_Y = ImageDealProcess.hprocall_LU_LCD.GetOutputCtrlParamTuple("Yrow");
                                    r1 = true;
                                    HObject LU_LCD_Line1 = ImageDealProcess.hprocall_LU_LCD.GetOutputIconicParamObject("Line1");
                                    HObject LU_LCD_Line2 = ImageDealProcess.hprocall_LU_LCD.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_LU.DisplayRegion(LU_LCD_Line1, FontColor.red);
                                    mRecordDisplay_LU.DisplayRegion(LU_LCD_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    LU_LCD_Line1.Dispose();
                                    LU_LCD_Line2.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r1 = true;
                                }
                            }
                            else if (strCommand.Contains("AAA"))
                            {
                                if (ImageDealProcess.I_P.Run_LU(_Image))
                                {
                                    LU_A_Result = ImageDealProcess.hprocall_LU.GetOutputCtrlParamTuple("Result");
                                    LU_A_X.Dispose();
                                    LU_A_Y.Dispose();
                                    GC.Collect();
                                    LU_A_X = ImageDealProcess.hprocall_LU.GetOutputCtrlParamTuple("Xcol");
                                    LU_A_Y = ImageDealProcess.hprocall_LU.GetOutputCtrlParamTuple("Yrow");
                                    r1 = true;
                                    
                                    HObject LU_A_Line1 = ImageDealProcess.hprocall_LU.GetOutputIconicParamObject("Line1");
                                    HObject LU_A_Line2 = ImageDealProcess.hprocall_LU.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_LU.DisplayRegion(LU_A_Line1, FontColor.red);
                                    mRecordDisplay_LU.DisplayRegion(LU_A_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    LU_A_Line1.Dispose();
                                    LU_A_Line2.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r1 = true;
                                }
                            }
                            else if(strCommand.Contains("CHE"))
                            {
                                if (ImageDealProcess.I_P.Run_LU_DIS(_Image))
                                {
                                    LU_A_Result = ImageDealProcess.hprocall_LU_DIS.GetOutputCtrlParamTuple("Result");
                                    LU_DIS_X.Dispose();
                                    LU_DIS_Y.Dispose();
                                    GC.Collect();
                                    LU_DIS_X = ImageDealProcess.hprocall_LU_DIS.GetOutputCtrlParamTuple("Xcol");
                                    LU_DIS_Y = ImageDealProcess.hprocall_LU_DIS.GetOutputCtrlParamTuple("Yrow");
                                    r1 = true;
                                }
                                else
                                {
                                    r1 = true;
                                }
                            }
                            break;

                        case 2:
                            mRecordDisplay_RU.Clear();
                            mRecordDisplay_RU.Image = _Image;
                            ImageSave("右上_", _Image);
                            if (strCommand.Contains("LCD"))
                            {


                                if (ImageDealProcess.I_P.Run_RU_LCD(_Image))
                                {
                                    RU_LCD_Result = ImageDealProcess.hprocall_RU_LCD.GetOutputCtrlParamTuple("Result");
                                    RU_LCD_X.Dispose();
                                    RU_LCD_Y.Dispose();
                                    GC.Collect();
                                    RU_LCD_X = ImageDealProcess.hprocall_RU_LCD.GetOutputCtrlParamTuple("Xcol");
                                    RU_LCD_Y = ImageDealProcess.hprocall_RU_LCD.GetOutputCtrlParamTuple("Yrow");
                                    r2 = true;
                                    HObject RU_LCD_Line1 = ImageDealProcess.hprocall_RU_LCD.GetOutputIconicParamObject("Line1");
                                    HObject RU_LCD_Line2 = ImageDealProcess.hprocall_RU_LCD.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_RU.DisplayRegion(RU_LCD_Line1, FontColor.red);
                                    mRecordDisplay_RU.DisplayRegion(RU_LCD_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    RU_LCD_Line2.Dispose();
                                    RU_LCD_Line1.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r2 = true;
                                }

                            }
                            else if (strCommand.Contains("AAA"))
                            {

                                if (ImageDealProcess.I_P.Run_RU(_Image))
                                {
                                    RU_A_Result = ImageDealProcess.hprocall_RU.GetOutputCtrlParamTuple("Result");
                                    RU_A_X.Dispose();
                                    RU_A_Y.Dispose();
                                    GC.Collect();
                                    RU_A_X = ImageDealProcess.hprocall_RU.GetOutputCtrlParamTuple("Xcol");
                                    RU_A_Y = ImageDealProcess.hprocall_RU.GetOutputCtrlParamTuple("Yrow");
                                    r2 = true;
                                    HObject RU_A_Line1 = ImageDealProcess.hprocall_RU.GetOutputIconicParamObject("Line1");
                                    HObject RU_A_Line2 = ImageDealProcess.hprocall_RU.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_RU.DisplayRegion(RU_A_Line1, FontColor.red);
                                    mRecordDisplay_RU.DisplayRegion(RU_A_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    RU_A_Line1.Dispose();
                                    RU_A_Line2.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r2 = true;
                                }

                            }
                            else if (strCommand.Contains("CHE"))
                            {
                                if (ImageDealProcess.I_P.Run_RU_DIS(_Image))
                                {
                                    RU_A_Result = ImageDealProcess.hprocall_RU_DIS.GetOutputCtrlParamTuple("Result");
                                    RU_DIS_X.Dispose();
                                    RU_DIS_Y.Dispose();
                                    RU_DIS_X = ImageDealProcess.hprocall_RU_DIS.GetOutputCtrlParamTuple("Xcol");
                                    RU_DIS_Y = ImageDealProcess.hprocall_RU_DIS.GetOutputCtrlParamTuple("Yrow");
                                    r2 = true;
                                }
                                else
                                {
                                    r2 = true;
                                }
                            }
                            break;

                        case 3:
                            mRecordDisplay_LD.Clear();
                            mRecordDisplay_LD.Image = _Image;
                            ImageSave("左下_", _Image);
                            if (strCommand.Contains("LCD"))
                            {

                                if (ImageDealProcess.I_P.Run_LD_LCD(_Image))
                                {
                                    LD_LCD_Result = ImageDealProcess.hprocall_LD_LCD.GetOutputCtrlParamTuple("Result");
                                    LD_LCD_X.Dispose();
                                    LD_LCD_Y.Dispose();
                                    GC.Collect();
                                    LD_LCD_X = ImageDealProcess.hprocall_LD_LCD.GetOutputCtrlParamTuple("Xcol");
                                    LD_LCD_Y = ImageDealProcess.hprocall_LD_LCD.GetOutputCtrlParamTuple("Yrow");
                                    //degLcd = ImageDealProcess.hprocall_LD_LCD.GetOutputCtrlParamTuple("Deg").D;
                                    r3 = true;
                                    HObject RU_LCD_Line1 = ImageDealProcess.hprocall_LD_LCD.GetOutputIconicParamObject("Line1");
                                    HObject RU_LCD_Line2 = ImageDealProcess.hprocall_LD_LCD.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_LD.DisplayRegion(RU_LCD_Line1, FontColor.red);
                                    mRecordDisplay_LD.DisplayRegion(RU_LCD_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    RU_LCD_Line1.Dispose();
                                    RU_LCD_Line2.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r3 = true;
                                }

                            }
                            else if (strCommand.Contains("AAA"))
                            {

                                if (ImageDealProcess.I_P.Run_LD(_Image))
                                {
                                    LD_A_Result = ImageDealProcess.hprocall_LD.GetOutputCtrlParamTuple("Result");
                                    LD_A_X.Dispose();
                                    LD_A_Y.Dispose();
                                    GC.Collect();
                                    LD_A_X = ImageDealProcess.hprocall_LD.GetOutputCtrlParamTuple("Xcol");
                                    LD_A_Y = ImageDealProcess.hprocall_LD.GetOutputCtrlParamTuple("Yrow");
                                    //degAAA   = ImageDealProcess.hprocall_LD.GetOutputCtrlParamTuple("Deg").D;
                                    r3 = true;
                                    HObject LD_A_Line1 = ImageDealProcess.hprocall_LD.GetOutputIconicParamObject("Line1");
                                    HObject LD_A_Line2 = ImageDealProcess.hprocall_LD.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_LD.DisplayRegion(LD_A_Line1, FontColor.red);
                                    mRecordDisplay_LD.DisplayRegion(LD_A_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    LD_A_Line1.Dispose();
                                    LD_A_Line2.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r3 = true;
                                }
                            }
                            else if (strCommand.Contains("CHE"))
                            {
                                if (ImageDealProcess.I_P.Run_LD_DIS(_Image))
                                {
                                    LD_A_Result = ImageDealProcess.hprocall_LD_DIS.GetOutputCtrlParamTuple("Result");
                                    LD_DIS_X.Dispose();
                                    LD_DIS_Y.Dispose();
                                    LD_DIS_X = ImageDealProcess.hprocall_LD_DIS.GetOutputCtrlParamTuple("Xcol");
                                    LD_DIS_Y = ImageDealProcess.hprocall_LD_DIS.GetOutputCtrlParamTuple("Yrow");
                                    r3 = true;
                                }
                                else
                                {
                                    r3 = true;
                                }
                            }
                            break;

                        case 4:
                            mRecordDisplay_RD.Clear();
                            mRecordDisplay_RD.Image = _Image;
                            ImageSave("右下_", _Image);
                            if (strCommand.Contains("LCD"))
                            {

                                if (ImageDealProcess.I_P.Run_RD_LCD(_Image))
                                {

                                    RD_LCD_Result = ImageDealProcess.hprocall_RD_LCD.GetOutputCtrlParamTuple("Result");
                                    RD_LCD_X.Dispose();
                                    RD_LCD_Y.Dispose();
                                    RD_LCD_X = ImageDealProcess.hprocall_RD_LCD.GetOutputCtrlParamTuple("Xcol");
                                    RD_LCD_Y = ImageDealProcess.hprocall_RD_LCD.GetOutputCtrlParamTuple("Yrow");
                                    r4 = true;
                                    HObject RD_LCD_Line1 = ImageDealProcess.hprocall_RD_LCD.GetOutputIconicParamObject("Line1");
                                    HObject RD_LCD_Line2 = ImageDealProcess.hprocall_RD_LCD.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_RD.DisplayRegion(RD_LCD_Line1, FontColor.red);
                                    mRecordDisplay_RD.DisplayRegion(RD_LCD_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    RD_LCD_Line1.Dispose();
                                    RD_LCD_Line2.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r4 = true;
                                }
                            }
                            else if(strCommand.Contains("AAA"))
                            {


                                if (ImageDealProcess.I_P.Run_RD(_Image))
                                {
                                    RD_A_Result = ImageDealProcess.hprocall_RD.GetOutputCtrlParamTuple("Result");
                                    RD_A_X.Dispose();
                                    RD_A_Y.Dispose();
                                    RD_A_X = ImageDealProcess.hprocall_RD.GetOutputCtrlParamTuple("Xcol");
                                    RD_A_Y = ImageDealProcess.hprocall_RD.GetOutputCtrlParamTuple("Yrow");
                                    r4 = true;
                                     
                                    HObject RD_A_Line1 = ImageDealProcess.hprocall_RD.GetOutputIconicParamObject("Line1");
                                    HObject RD_A_Line2 = ImageDealProcess.hprocall_RD.GetOutputIconicParamObject("Line2");
                                    mRecordDisplay_RD.DisplayRegion(RD_A_Line1, FontColor.red);
                                    mRecordDisplay_RD.DisplayRegion(RD_A_Line2, FontColor.red);
                                    Thread.Sleep(100);
                                    RD_A_Line1.Dispose();
                                    RD_A_Line2.Dispose();
                                    GC.Collect();
                                }
                                else
                                {
                                    r4 = true;
                                }
                            }
                            else if (strCommand.Contains("CHE"))
                            {
                                if (ImageDealProcess.I_P.Run_RD_DIS(_Image))
                                {
                                    RD_A_Result = ImageDealProcess.hprocall_RD_DIS.GetOutputCtrlParamTuple("Result");
                                    RD_DIS_X.Dispose();
                                    RD_DIS_Y.Dispose();
                                    RD_DIS_X = ImageDealProcess.hprocall_RD_DIS.GetOutputCtrlParamTuple("Xcol");
                                    RD_DIS_Y = ImageDealProcess.hprocall_RD_DIS.GetOutputCtrlParamTuple("Yrow");
                                    r4 = true;
                                }
                                else
                                {
                                    r4 = true;
                                }
                            }
                            break;

                        case 5:
                            mRecordDisplay_Cam.Clear();
                            mRecordDisplay_Cam.Image = _Image;
                            ImageSave("孔_", _Image);
                            if (!SysConfig.CamHoleUse)
                            {
                                return;
                            }
                            if (strCommand.Contains("LCD"))
                            {
                                if (ImageDealProcess.I_P.Run_LCD_Cam(_Image))
                                {
                                    HTuple T1 = new HTuple();
                                    T1 = ImageDealProcess.hprocall_Lcd_Cam.GetOutputCtrlParamTuple("Result");
                                    if (T1.D >= 1)
                                    {
                                        HTuple X = ImageDealProcess.hprocall_Lcd_Cam.GetOutputCtrlParamTuple("Xcol");
                                        HTuple Y = ImageDealProcess.hprocall_Lcd_Cam.GetOutputCtrlParamTuple("Yrow");
                                        HTuple R = ImageDealProcess.hprocall_Lcd_Cam.GetOutputCtrlParamTuple("Radius");
                                        HObject RD_A_Line1 = ImageDealProcess.hprocall_Lcd_Cam.GetOutputIconicParamObject("Line1");
                                        Cam_hole = true;
                                        mRecordDisplay_Cam.DisplayRegion(RD_A_Line1, FontColor.red);
                                        Thread.Sleep(100);
                                        RD_A_Line1.Dispose();
                                        string sa = "Radius" + "," + X.D.ToString("F3") + "," + Y.D.ToString("F3") + "," + R.D.ToString("F3");

                                        if (!CsvHepler.IsEmpty(dataFilePaht))
                                        {
                                            UpdateLog("数据保存成功!", Color.LightBlue);
                                            CsvHepler.WriteCSV(dataFilePaht, sa);
                                        }
                                    }
                                    else
                                    {
                                        Cam_hole = true;
                                    }
                                    T1.Dispose();
                                    GC.Collect();
                                }
                            }
                            else if(strCommand.Contains("AAA"))
                            {
                                if (ImageDealProcess.I_P.Run_Cam(_Image))
                                {
                                    HTuple T1 = new HTuple();
                                    T1 = ImageDealProcess.hprocall_Cam.GetOutputCtrlParamTuple("Result");
                                    if (T1.D >=1)
                                    {
                                        HTuple X = ImageDealProcess.hprocall_Cam.GetOutputCtrlParamTuple("Xcol");
                                        HTuple Y = ImageDealProcess.hprocall_Cam.GetOutputCtrlParamTuple("Yrow");
                                        HTuple R = ImageDealProcess.hprocall_Cam.GetOutputCtrlParamTuple("Radius");
                                        HObject RD_A_Line1 = ImageDealProcess.hprocall_Cam.GetOutputIconicParamObject("Line1");

                                        mRecordDisplay_Cam.DisplayRegion(RD_A_Line1, FontColor.red);
                                        Thread.Sleep(100);
                                        RD_A_Line1.Dispose();
                                        string sa = "Radius" + "," + X.D.ToString("F3") + "," + Y.D.ToString("F3") + "," + R.D.ToString("F3");

                                        if (!CsvHepler.IsEmpty(dataFilePaht))
                                        {
                                            UpdateLog("数据保存成功!", Color.LightBlue);
                                            CsvHepler.WriteCSV(dataFilePaht, sa);
                                        }
                                    }
                                    T1.Dispose();
                                    GC.Collect();
                                }
                            }
                            else if (strCommand.Contains("CHE"))
                            {

                            }
                            break;

                        default:
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }
        }

        private void TrigCam(string Trig_A)
        {
            try
            {
                switch (Trig_A)
                {
                    case "AAA":
                        LU_A_Result.Dispose();
                        LD_A_Result.Dispose();
                        RU_A_Result.Dispose();
                        RD_A_Result.Dispose();
                        GC.Collect();

                        //for (int i = 1; i < 9; i++)
                        //{
                        //    RseeController_PM_D_8TE_BRTSetChannel(Com3_Handle, 0, i, 255);
                        //}

                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 4, 250);
                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 3, 250);
                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 2, 250);
                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 1, 250);

                        RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, 3, 250);

                        mAcqFIFOManager.SetExposure(1,  SysConfig.ExposureLU_A );
                        mAcqFIFOManager.SetExposure(2,  SysConfig.ExposureRU_A );
                        mAcqFIFOManager.SetExposure(3,  SysConfig.ExposureLD_A );
                        mAcqFIFOManager.SetExposure(4,  SysConfig.ExposureRD_A );
                        mAcqFIFOManager.SetExposure(5,  SysConfig.Exposure_ACam);
                        break;

                    case "LCD":
                        LU_LCD_Result.Dispose();
                        LD_LCD_Result.Dispose();
                        RU_LCD_Result.Dispose();
                        RD_LCD_Result.Dispose();
                        GC.Collect();

                        RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, 4, 100);
                        RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, 5, 100);
                        RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, 7, 100);
                        RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, 8, 100);
                        RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, 6, 250);

                        mAcqFIFOManager.SetExposure(1,  SysConfig.ExposureLU_L);
                        mAcqFIFOManager.SetExposure(2,  SysConfig.ExposureRU_L);
                        mAcqFIFOManager.SetExposure(3,  SysConfig.ExposureLD_L);
                        mAcqFIFOManager.SetExposure(4,  SysConfig.ExposureRD_L);
                        mAcqFIFOManager.SetExposure(5,  SysConfig.Exposure_LCam);
                        break;

                    case "CHE":
                        LU_A_Result.Dispose();
                        LD_A_Result.Dispose();
                        RU_A_Result.Dispose();
                        RD_A_Result.Dispose();

                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 4, 250);
                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 3, 250);
                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 2, 250);
                        RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, 1, 250);

                        mAcqFIFOManager.SetExposure(1, SysConfig.ExposureLU_C);
                        mAcqFIFOManager.SetExposure(2, SysConfig.ExposureRU_C);
                        mAcqFIFOManager.SetExposure(3, SysConfig.ExposureLD_C);
                        mAcqFIFOManager.SetExposure(4, SysConfig.ExposureRD_C);
                        mAcqFIFOManager.SetExposure(5, SysConfig.Exposure_CCam);

                        break;


                    default:
                        break;
                }
 
                //设置曝光参数


                //软触发五次
                mAcqFIFOManager.AcqFifo1.OneShot();
                Thread.Sleep(50);
                mAcqFIFOManager.AcqFifo2.OneShot();
                Thread.Sleep(50);
                mAcqFIFOManager.AcqFifo3.OneShot();
                Thread.Sleep(50);
                mAcqFIFOManager.AcqFifo4.OneShot();
                Thread.Sleep(50);
                mAcqFIFOManager.AcqFifo5.OneShot();
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                //500后结束 关掉所有光源
                for (int i = 1; i < 9; i++)
                {
                    RseeController_PM_D_8TE_BRTSetChannel(Com3_Handle, 0, i, 0);
                    RseeController_PM_D_8TE_BRTSetChannel(Com7_Handle, 0, i, 0);
                    RseeController_PM_D_8TE_BRTSetChannel(Com5_Handle, 0, i, 0);
                }
                //引擎文件调用给与2S缓冲
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            catch (Exception ex)
            {

                
            }
        }


        private void GetResult()
        {
            try
            {
                    if (r1 && r2 && r3 && r4)
                    {

                        r1 = r2 = r3 = r4 = false;
                        if (strCommand.Contains("LCD"))
                        {
                            r1 = r2 = r3 = r4 = false;

                            if (SysConfig.CamHoleUse)
                            {
                                if (!Cam_hole)
                                {
                                    string strCom = string.Format("Catch;LCD;NG;{0};{1};{2}", 0, 0, 0);
                                    if (server != null && mTcpClient != null)
                                    {
                                        server.Send(mTcpClient, strCom);
                                    }
                                    UpdateLog("LCD摄像孔NG!", Color.LightBlue);
                                     return;
                                }
                                else
                                {
                                  Cam_hole = false;
                                }
                            }

                            if (LD_LCD_Result.D >= 1 && LD_LCD_Result.D == RD_LCD_Result.D && LD_LCD_Result.D == LU_LCD_Result.D && RD_LCD_Result.D == RU_LCD_Result.D)
                            {
                                
                                degLcd = ImageDealProcess.I_P.KDeg(LU_LCD_X.D, LU_LCD_Y.D, LD_LCD_X.D, LD_LCD_Y.D);
                            //this.Invoke(new MethodInvoker(delegate {

                            //    dgv.Rows.Add(new object[] { "LCD", degLcd.ToString("F3"), ((LD_LCD_X.D + RD_LCD_X.D) / 2).ToString("F3"), ((LD_LCD_Y.D + RD_LCD_Y.D) / 2).ToString("F3") });

                            //}));
                            //发送结果
                            //
                            UpdateLog("LCD角度:"+ degLcd.ToString("F3"), Color.Lime);
                            UpdateLog("发送结果", Color.Lime);
                                string strCom = string.Format("Catch;LCD;OK;{0};{1};{2}", ((LD_LCD_X.D + RD_LCD_X.D) / 2).ToString("F3"), ((LD_LCD_Y.D + RD_LCD_Y.D) / 2).ToString("F3"), degLcd.ToString("F3"));
                                if (server !=null && mTcpClient != null)
                                {

                                   string sa = "LCD" + "," + LU_LCD_X.D.ToString("F3") +","+ LU_LCD_Y.D.ToString("F3") + "," + LD_LCD_X.D.ToString("F3") + "," + LD_LCD_Y.D.ToString("F3") + ","+ RU_LCD_X.D.ToString("F3") + "," + RU_LCD_Y.D.ToString("F3") + "," + RD_LCD_X.D.ToString("F3") + "," + RD_LCD_Y.D.ToString("F3");

                                if (!CsvHepler.IsEmpty(dataFilePaht))
                                {
                                    UpdateLog("数据保存成功!", Color.LightBlue);
                                    CsvHepler.WriteCSV(dataFilePaht, sa);
                                }

                                server.Send(mTcpClient, strCom);
                                    ErrLog.WriteLogData(strCom);
                                }
                                //if (socketClient !=null)
                                //{
                                   
                                //    socketClient.Send(strCom);
                                //    ErrLog.WriteLogData(strCom);
                                //}
                            
                            }
                             else if(strCommand.Contains("LCD"))
                            {
                                //NG  发送重复再次拍照请求
                                UpdateLog("发送结果", Color.Lime);
                                string strCom = string.Format("Catch;LCD;NG;{0};{1};{2}", 0, 0, 0);
                                if (server != null && mTcpClient != null)
                                {
                                    server.Send(mTcpClient, strCom);
                                    
                                }
                                //if (socketClient != null)
                                //{
                                //    socketClient.Send(strCom);
                                //}
                             }
                        }
                       else if (strCommand.Contains("AAA"))
                        {
                            r1 = r2 = r3 = r4 = false;
                        if (SysConfig.CamHoleUse)
                        {
                            if (!Cam_hole)
                            {
                                string strCom = string.Format("Catch;LCD;NG;{0};{1};{2}", 0, 0, 0);
                                if (server != null && mTcpClient != null)
                                {
                                    server.Send(mTcpClient, strCom);
                                }
                                UpdateLog("LCD摄像孔NG!", Color.LightBlue);
                                return;
                            }
                            else
                            {
                                Cam_hole = false;
                            }
                        }
                        if (LD_A_Result.D >= 1 && LD_A_Result.D == RD_A_Result.D && LD_A_Result.D == LU_A_Result.D && RD_A_Result.D == RU_A_Result.D)
                            {
                                degAAA = ImageDealProcess.I_P.KDeg(LU_A_X.D, LU_A_Y.D, LD_A_X.D, LD_A_Y.D);
                            UpdateLog("A壳角度:" + degAAA.ToString("F3"), Color.Lime);
                            //this.Invoke( new MethodInvoker(delegate {

                            //        dgv.Rows.Add(new object[] { "AAA", degAAA.ToString("F3"), ((LD_A_X.D + RD_A_X.D) / 2).ToString("F3"), ((LD_A_Y.D + RD_A_Y.D) / 2).ToString("F3") });

                            //    }));


                            string sa1 = "AAA" + "," + LU_A_X.D.ToString("F3") + "," + LU_A_Y.D.ToString("F3") + "," + LD_A_X.D.ToString("F3") + "," + LD_A_Y.D.ToString("F3") + "," + RU_A_X.D.ToString("F3") + "," + RU_A_Y.D.ToString("F3") + "," + RD_A_X.D.ToString("F3") + "," + RD_A_Y.D.ToString("F3");

                            if (!CsvHepler.IsEmpty(dataFilePaht))
                            {
                                UpdateLog("数据保存成功!", Color.LightBlue);
                                CsvHepler.WriteCSV(dataFilePaht, sa1);
                            }

                            if (SysConfig.IsDebug)
                            {
                               string strCom11 = string.Format("Catch;AAA;OK;{0};{1};{2}", 0, 0, 0);
                                server.Send(mTcpClient, strCom11);
                                return;
                            }
                            //发送结果
                            //double _shiftX = ((LD_LCD_X.D + RD_LCD_X.D) / 2) - ((LD_A_X.D + RD_A_X.D) / 2) + SysConfig.AssembleX;
                            //double _shiftY = ((LD_LCD_Y.D + RD_LCD_Y.D) / 2) - ((LD_A_Y.D + RD_A_Y.D) / 2) + SysConfig.AssembleY;
                            //double _shiftR = Math.Abs(degLcd) - Math.Abs(deg) + SysConfig.AssembleR;
                            //  double offset = _shiftR;
                            //  if (Math.Abs(offset)>1.5)
                            //  {
                            //      _shiftR = _shiftR / 3;
                            //  }
                            //  string sa = "LCD" + "," + LD_LCD_X.D.ToString("F3") +","+ LD_LCD_Y.D.ToString("F3") + "," + RD_LCD_X.D.ToString("F3") + "," + RD_LCD_Y.D.ToString("F3");

                            double _shiftX = (LD_A_X.D - LD_LCD_X.D);
                            double _shiftY = (LD_LCD_Y.D - LD_A_Y.D);
                            double _shiftR = degAAA  - degLcd;

                            //double _shiftX = 0;
                            //double _shiftY = 0;
                            //double _shiftR = 90.1 - degAAA;

                            UpdateLog("发送结果", Color.Lime);
                                string strCom = "";
                              
                                if (!secTrig)
                                {
                                    if (Math.Abs(_shiftR)<0.05)
                                    {
                                        strCom = string.Format("Catch;AAA;NG2;{0};{1};{2}", 0, 0, 0);
                                        secTrig = true;
               
                                    }
                                    else
                                    {
                                        strCom = string.Format("Catch;AAA;NG2;{0};{1};{2}", 0, 0, _shiftR.ToString("f3"));
                                        secTrig = false;
                                    }

                                }
                                else
                                {
                                        if (LD_LCD_X.D > LD_A_X.D)
                                        {
                                            _shiftX = (LD_LCD_X.D -LD_A_X.D ) - SysConfig.AssembleX;
                                        }
                                        else
                                        {
                                             _shiftX = (LD_LCD_X.D - LD_A_X.D) - SysConfig.AssembleX;
                                        }

                                        if (LD_LCD_Y.D > LD_A_Y.D)
                                        {
                                            _shiftY = (LD_LCD_Y.D - LD_A_Y.D) - SysConfig.AssembleY;
                                        }
                                        else
                                        {
                                            _shiftY = (LD_LCD_Y.D - LD_A_Y.D) - SysConfig.AssembleY;
                                        }


                                        strCom = string.Format("Catch;AAA;OK;{0};{1};{2}", (_shiftX).ToString("F3"), (_shiftY).ToString("F3"),0);
                                        secTrig = false;
                                 }
                                    //strCom = string.Format("Catch;AAA;NG2;{0};{1};{2}", (_shiftX).ToString("F3"), (_shiftY).ToString("F3"), _shiftR);
                                  
                                    if (server != null && mTcpClient != null)
                                    {

                                        string sa = "AAA" + "," + LU_A_X.D.ToString("F3") + "," + LU_A_Y.D.ToString("F3") + "," + LD_A_X.D.ToString("F3") + "," + LD_A_Y.D.ToString("F3") + RU_A_X.D.ToString("F3") + "," + RU_A_Y.D.ToString("F3") + "," + RD_A_X.D.ToString("F3") + "," + RD_A_Y.D.ToString("F3");

                                        if (!CsvHepler.IsEmpty(dataFilePaht))
                                        {
                                            UpdateLog("数据保存成功!", Color.LightBlue);
                                            CsvHepler.WriteCSV(dataFilePaht, sa);
                                        }

                                        server.Send(mTcpClient, strCom);
                                        ErrLog.WriteLogData(strCom);
                                    }
                                    //if (socketClient != null)
                                    //{
                                    //    socketClient.Send(strCom);
                                    //    ErrLog.WriteLogData(strCom);
                                    //}
                             }
                            else
                            {
                                //NG  发送重复再次拍照请求
                                string strCom = string.Format("Catch;AAA;NG;{0};{1};{2}",0, 0, 0);
                                if (server != null && mTcpClient != null)
                                {
                                    server.Send(mTcpClient, strCom);
                                   // ErrLog.WriteLogData(strCom);
                                }
                 
                            }
                        }
                        else if (strCommand.Contains("CHE"))
                        {
                            string  strCom = string.Format("Catch;CHE;OK;{0};{1};{2}", 0, 0, 0);
                            if (server != null && mTcpClient != null)
                            {
                                server.Send(mTcpClient, strCom);
                                // ErrLog.WriteLogData(strCom);
                            }
                            r1 = r2 = r3 = r4 = false;
                            if (LD_A_Result.D >= 1 && LD_A_Result.D == RD_A_Result.D && LD_A_Result.D == LU_A_Result.D && RD_A_Result.D == RU_A_Result.D)
                            {
                                string strCom1 = string.Format("DIS,{0},{1},{2},{3},{4},{5},{6},{7}", LU_DIS_X.D.ToString("F3"), LU_DIS_Y.D.ToString("F3"), LD_DIS_X.D.ToString("F3"), LD_DIS_Y.D.ToString("F3"), RU_DIS_X.D.ToString("F3"), RU_DIS_Y.D.ToString("F3"), RD_DIS_X.D.ToString("F3"), RD_DIS_Y.D.ToString("F3"));
                                if (!CsvHepler.IsEmpty(dataFilePaht))
                                {
                                  UpdateLog("数据保存成功!",Color.LightBlue);
                                    CsvHepler.WriteCSV(dataFilePaht, strCom1);
                                }
                            }
                        }
                    }
     
                //}
            }
            catch (Exception ex)
            {
                if (server != null && mTcpClient != null)
                {
                    if (strCommand.Contains("AAA"))
                    {
                        string strCom = string.Format("Catch;AAA;NG;{0};{1};{2}", 0, 0, 0);
                        server.Send(mTcpClient, strCom);
                    }
                    else
                    {
                        string strCom = string.Format("Catch;LCD;NG;{0};{1};{2}", 0, 0, 0);
                        server.Send(mTcpClient, strCom);
                    }
                  
               
                }

            }
        }

        #endregion

        /// <summary>
        /// 运行日志实时显示
        /// </summary>
        /// <param name="log"></param>
        /// <param name="color"></param>
        public void UpdateLog(string log, Color color)
        {
            rtbLog.BeginInvoke(new Action(delegate {
                log = DateTime.Now.ToString("HH-mm-ss-fff") + " : " + log + "\n";
                rtbLog.AppendText(log);
                //rtbLog.SelectionStart = rtbLog.TextLength - log.Length;
                //rtbLog.SelectionLength = log.Length;
                //rtbLog.SelectionColor = color;
                //rtbLog.SelectionStart = rtbLog.TextLength - 1;
                //rtbLog.SelectionLength = 0;
                //rtbLog.ScrollToCaret();
                if (rtbLog.TextLength > 3000)
                {
                    rtbLog.Clear();
                }
            }));
        }

        #region 控件相关

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ErrLog.WriteLogEx("软件退出!");
                RseeController_CloseCom("COM3", Com3_Handle);
                RseeController_CloseCom("COM5", Com5_Handle);
                RseeController_CloseCom("COM7", Com7_Handle);
                if (mAcqFIFOManager !=null)
                {
                    mAcqFIFOManager.StopAcquire(1);
                    mAcqFIFOManager.StopAcquire(2);
                    mAcqFIFOManager.StopAcquire(3);
                    mAcqFIFOManager.StopAcquire(4);
                    mAcqFIFOManager.StopAcquire(5);
                    mAcqFIFOManager.OnImageReady -= MAcqFIFOManager_OnImageReady;
                    mAcqFIFOManager.AcqFIFOManagerFree();
                }



                //socketClient.TcpConnected -= SocketClient_TcpConnected;
                //socketClient.TcpDateReceived -= SocketClient_TcpDateReceived;
                //socketClient.TcpDateSend -= SocketClient_TcpDateSend;
                //socketClient.TcpDisConnected -= SocketClient_TcpDisConnected;
                //socketClient.Stop();

                server.TcpConnected -= Server_TcpConnected;
                server.TcpDateReceived -= Server_TcpDateReceived;
                server.TcpDateSend -= Server_TcpDateSend;
                server.TcpDisConnected -= Server_TcpDisConnected;
                server.Stop();

            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());

            }
        }

         private void ImageSave(string _path,HObject _Image)
        {
            if (SysConfig.ImageSave && !IsVedio)
            {
                string ss = SysConfig.ImageSavePath + "//" + DateTime.Now.ToString("yyyy-MM-dd");
                if (!Directory.Exists(ss))
                {
                    Directory.CreateDirectory(ss);
                }


                HObject img_save;
                HOperatorSet.GenEmptyObj(out img_save);
                img_save = _Image.Clone();
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) => {
                    HOperatorSet.WriteImage(img_save, "bmp", 0, ss + "//" + _path + DateTime.Now.ToString("HH-mm-sss-fff") + ".bmp");
                    img_save.Dispose();
                }));

            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateLog("软件启动!", Color.Red);
                ErrLog.WriteLogEx("软件启动!");
                InitLight();

                string path = SysConfig.ImageSavePath;

           
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                dataFilePaht = $@"{path}\{DateTime.Now.ToString("yyyyMMdd")}.csv";
                if (!File.Exists(dataFilePaht))
                {
                    File.Create(dataFilePaht).Close();
                }

                string strCom = "行名,左上X,左上Y,左下X,左下Y,右上X,右上Y,右下X,右下Y,";
                if (CsvHepler.IsEmpty(dataFilePaht))
                {
                    CsvHepler.WriteCSV(dataFilePaht, strCom);
                }


                mRecordDisplay_LU = new RecordDisplay(hW1);
                mRecordDisplay_RU = new RecordDisplay(hW2);
                mRecordDisplay_LD = new RecordDisplay(hW3);
                mRecordDisplay_RD = new RecordDisplay(hW4);
                mRecordDisplay_Cam = new RecordDisplay(hW5);

                mRecordDisplay_Debug = new RecordDisplay(hW_debug);
             
                InitTime();
                if (mAcqFIFOManager != null)
                {
                    tsslCam1.BackColor = mAcqFIFOManager.Connection1 ? Color.Lime : Color.Red ;
                    tsslCam2.BackColor = mAcqFIFOManager.Connection2 ? Color.Lime : Color.Red;
                    tsslCam3.BackColor = mAcqFIFOManager.Connection3 ? Color.Lime : Color.Red;
                    tsslCam4.BackColor = mAcqFIFOManager.Connection4 ? Color.Lime : Color.Red;
                    tsslCam5.BackColor = mAcqFIFOManager.Connection5 ? Color.Lime : Color.Red;
                    if (!mAcqFIFOManager.Connection1 && mAcqFIFOManager.Connection2 && mAcqFIFOManager.Connection3 && mAcqFIFOManager.Connection4 && mAcqFIFOManager.Connection5)
                    {
                        UpdateLog("相机链接失败!", Color.Red);
                    }
                    else
                    {
                        UpdateLog("相机初始化成功!", Color.Red);
                    }
                }
                else
                {
                    UpdateLog("相机未初始化!", Color.Red);
                }

                actLoadHdev.BeginInvoke(( o)=> {
                
                    UpdateLog("算法加载完成!",Color.Lime);


                },null);

                //if (mAcqFIFOManager.Connection1)
                //{
                //    numExpose.Value = Convert.ToDecimal(SysConfig.ExposureLU_A);
                //    numGain.Value = Convert.ToDecimal(SysConfig.Gain1);
                //}
                //tableLayoutPanel2.Enabled = false;
                tabControl1.TabPages.RemoveAt(1);
            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }

        }

        private void numExpose_ValueChanged(object sender, EventArgs e)
        {
            if (mAcqFIFOManager != null)
            {
                //左上角   Config文件按照   左上 右上 左下 右下  摄像孔顺序排列相机
                mAcqFIFOManager.SetExposure(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1), Convert.ToDouble(numExpose .Value));
                SysConfig.INIJobConfig.IniWriteValue("Cam" + (cbCamIndex.SelectedIndex + 1).ToString(), "Exposure", numExpose.Value.ToString());
            }
        }

        private void numGain_ValueChanged(object sender, EventArgs e)
        {
            if (mAcqFIFOManager != null)
            {
                //左上角   Config文件按照   左上 右上 左下 右下  摄像孔顺序排列相机
                mAcqFIFOManager.SetGain(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1), Convert.ToSingle(numGain.Value));
                SysConfig.INIJobConfig.IniWriteValue("Cam" + (cbCamIndex.SelectedIndex + 1).ToString(), "Gain", numGain.Value.ToString());
            }
        }

        private void btnLoadLocalImage_Click(object sender, EventArgs e)
        {
            try
            {

                //HOperatorSet.GenEmptyObj(out img);
                //OpenFileDialog openFile = new OpenFileDialog();
                //    openFile.Filter = "图片|*.jpg;*.png;*.jpeg;*.bmp";
                //    openFile.Multiselect = true;
                //    if (openFile.ShowDialog() == DialogResult.OK)
                //    {
                //        string[] file = openFile.FileNames;
                //        HOperatorSet.ReadImage(out img, file[0]);
                //        mRecordDisplay_Debug.Image = img;
                //        mRecordDisplay_Debug.ZoomFit();

                //}

            }
            catch (Exception ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
            }
        }

        private void btnRealVedio_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRealVedio.Text == "视频模式")
                {
                    btnRealVedio.Text = "视频中";
                    mAcqFIFOManager.StopAcquire(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1));
                    Thread.Sleep(100);
                    mAcqFIFOManager.SetTriggerModel(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1), false);
                    Thread.Sleep(100);
                    mAcqFIFOManager.StartAcquire(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1));
                    IsVedio = true;

                }
                else
                {
                    btnRealVedio.Text = "视频模式";
                    mAcqFIFOManager.StopAcquire(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1));
                    Thread.Sleep(100);
                    mAcqFIFOManager.SetTriggerModel(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1), true);
                    Thread.Sleep(100);
                    mAcqFIFOManager.StartAcquire(Convert.ToUInt32(cbCamIndex.SelectedIndex + 1));
                    IsVedio = false;
                    //IsVedio = mAcqFIFOManager.AcqFifo1.GetTrigger();
                }
            }
            catch (Exception ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmProperty frm = new FrmProperty();
            frm.ShowDialog();
        }
        /// <summary>
        /// 相机软触发一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSoftTrig_Click(object sender, EventArgs e)
        {
            try
            {
                if (mAcqFIFOManager != null && mAcqFIFOManager.Connection1)
                {
                    switch (cbCamIndex.SelectedIndex)
                    {
                        case 0:
                            mAcqFIFOManager.AcqFifo1.OneShot();
                            break;
                        case 1:
                            mAcqFIFOManager.AcqFifo2.OneShot();
                            break;
                        case 2:
                            mAcqFIFOManager.AcqFifo3.OneShot();
                            break;
                        case 3:
                            mAcqFIFOManager.AcqFifo4.OneShot();
                            break;
                        case 4:
                            mAcqFIFOManager.AcqFifo5.OneShot();
                            break;

                        default:
                            break;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }
        }

        #endregion

        private void labTitle_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Enabled = !tableLayoutPanel2.Enabled;
        }
    }
}
