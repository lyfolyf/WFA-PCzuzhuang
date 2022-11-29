using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
    class SysConfig
    {

        /// <summary>
        /// 文件配置
        /// </summary>
        public static INI INIConfig = null;
        public static INI INIJobConfig = null;
        /// <summary>
        /// 通信ip地址 与端口
        /// </summary>
        public static string mPort = ""; //主机IP
        public static string mHostIP = "";

        /// <summary>
        /// 相机序列号   曝光    增益
        /// </summary>
        public static string mCam1SerNum = ""; //相机序列号
        public static string mCam2SerNum = ""; //相机序列号
        public static string mCam3SerNum = ""; //相机序列号
        public static string mCam4SerNum = ""; //相机序列号
        public static string mCam5SerNum = ""; //相机序列号

        public static double ExposureLU_A = 0;
        public static double ExposureLD_A = 0;
        public static double ExposureRU_A = 0;
        public static double ExposureRD_A = 0;
        public static double Exposure_ACam = 0;

        public static double ExposureLU_L = 0;
        public static double ExposureLD_L = 0;
        public static double ExposureRU_L = 0;
        public static double ExposureRD_L = 0;
        public static double Exposure_LCam = 0;


        public static double ExposureLU_C = 0;
        public static double ExposureLD_C = 0;
        public static double ExposureRU_C = 0;
        public static double ExposureRD_C = 0;
        public static double Exposure_CCam = 0;

        public static double Gain1 = 0;
        public static double Gain2 = 0;
        public static double Gain3 = 0;
        public static double Gain4 = 0;
        public static double Gain5 = 0;
        /// <summary>
        /// 摄像孔是否引用
        /// </summary>
        public static bool CamHoleUse = false;
        public static string comClass = ""; //光源型号

        public static string PortName = "COM1";
        public static int BaudRate = 9600;
        public static int DataBits = 8;


        public static bool ImageSave = false; //图片保存
        public static string ImageSavePath = ""; //图片保存

        public static int BlobMin = 30;
        public static int BlobMax = 30;
        public static bool IsDebug = false;
        public static string DefaultJob = "JOB1";

        public static double AssembleX = 0;
        public static double AssembleY = 0;
        public static double AssembleR = 0;

        public static void SysLoadConfig()
        {
            try
            {
                INIConfig = new INI(AppDomain.CurrentDomain.BaseDirectory + "Config\\Config.ini");


                mHostIP = INIConfig.IniReadValue("System", "HostIP");
                mPort = INIConfig.IniReadValue("System", "HPort");

                comClass = INIConfig.IniReadValue("System", "ComClass");

                ImageSave = Convert.ToBoolean(INIConfig.IniReadValue("System", "ImageSave"));

                ImageSavePath = INIConfig.IniReadValue("System", "ImageSavePath");

                IsDebug = Convert.ToBoolean(INIConfig.IniReadValue("System", "Debug"));


                DefaultJob = INIConfig.IniReadValue("System", "DefaultJob");

                PortName = INIConfig.IniReadValue("SerPort", "PortName");
                int.TryParse(INIConfig.IniReadValue("SerPort", "BaudRate"),out BaudRate);
                int.TryParse(INIConfig.IniReadValue("SerPort", "DataBits"), out DataBits);

                mCam1SerNum = INIConfig.IniReadValue("Cam", "CamSerNum1");
                mCam2SerNum = INIConfig.IniReadValue("Cam", "CamSerNum2");
                mCam3SerNum = INIConfig.IniReadValue("Cam", "CamSerNum3");
                mCam4SerNum = INIConfig.IniReadValue("Cam", "CamSerNum4");
                mCam5SerNum = INIConfig.IniReadValue("Cam", "CamSerNum5");



                int.TryParse(INIConfig.IniReadValue("Calc", "BlobMin"), out BlobMin);
                int.TryParse(INIConfig.IniReadValue("Calc", "BlobMax"), out BlobMax);


                //bool.TryParse(INIConfig.IniReadValue("System", "Debug"),out IsDebug);

            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }

        }

        public static void LoadCamParam()
        {
            //左上  右上 左下 右下
            INIJobConfig = new INI(AppDomain.CurrentDomain.BaseDirectory +"HDEV\\"+ SysConfig.DefaultJob + "\\JobConfig.ini");
            double.TryParse(INIJobConfig.IniReadValue("Cam1", "ExposureA"), out ExposureLU_A);
            double.TryParse(INIJobConfig.IniReadValue("Cam2", "ExposureA"), out ExposureRU_A);
            double.TryParse(INIJobConfig.IniReadValue("Cam3", "ExposureA"), out ExposureLD_A);
            double.TryParse(INIJobConfig.IniReadValue("Cam4", "ExposureA"), out ExposureRD_A);
            double.TryParse(INIJobConfig.IniReadValue("Cam5", "ExposureA"), out Exposure_ACam);

            double.TryParse(INIJobConfig.IniReadValue("Cam1", "ExposureL"), out ExposureLU_L);
            double.TryParse(INIJobConfig.IniReadValue("Cam2", "ExposureL"), out ExposureRU_L);
            double.TryParse(INIJobConfig.IniReadValue("Cam3", "ExposureL"), out ExposureLD_L);
            double.TryParse(INIJobConfig.IniReadValue("Cam4", "ExposureL"), out ExposureRD_L);
            double.TryParse(INIJobConfig.IniReadValue("Cam5", "ExposureL"), out Exposure_LCam);



            double.TryParse(INIJobConfig.IniReadValue("Cam1", "ExposureC"), out ExposureLU_C);
            double.TryParse(INIJobConfig.IniReadValue("Cam2", "ExposureC"), out ExposureRU_C);
            double.TryParse(INIJobConfig.IniReadValue("Cam3", "ExposureC"), out ExposureLD_C);
            double.TryParse(INIJobConfig.IniReadValue("Cam4", "ExposureC"), out ExposureRD_C);
            double.TryParse(INIJobConfig.IniReadValue("Cam5", "ExposureC"), out Exposure_CCam);


            double.TryParse(INIJobConfig.IniReadValue("Cam1", "Gain"), out Gain1);
            double.TryParse(INIJobConfig.IniReadValue("Cam2", "Gain"), out Gain2);
            double.TryParse(INIJobConfig.IniReadValue("Cam3", "Gain"), out Gain3);
            double.TryParse(INIJobConfig.IniReadValue("Cam4", "Gain"), out Gain4);
            double.TryParse(INIJobConfig.IniReadValue("Cam5", "Gain"), out Gain5);

            double.TryParse(INIJobConfig.IniReadValue("Calc", "AssembleX"), out AssembleX);
            double.TryParse(INIJobConfig.IniReadValue("Calc", "AssembleY"), out AssembleY);
            double.TryParse(INIJobConfig.IniReadValue("Calc", "AssembleR"), out AssembleR);
 

            CamHoleUse = Convert.ToBoolean(INIJobConfig.IniReadValue("Calc", "CamHoleUse"));
        }
    }
}
