using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace WFA
{
    public class ImageDealProcess
    {
        //静态实例初始化
        public static ImageDealProcess I_P = new ImageDealProcess();

        HDevEngine hengine;  //定义调用hdev程序的引擎       
        public static HDevProcedureCall hprocall_LU ; //左上角相机A壳 引擎文件
        public static HDevProcedureCall hprocall_LD; //左下角相机A壳 引擎文件
        public static HDevProcedureCall hprocall_RU; //右上角相机A壳 引擎文件
        public static HDevProcedureCall hprocall_RD; //右下角相机A壳 引擎文件
        public static HDevProcedureCall hprocall_Cam; //摄像孔相机 引擎文件
        public static HDevProcedureCall hprocall_Lcd_Cam; //摄像孔相机 引擎文件


        public static HDevProcedureCall hprocall_LU_LCD; //左上角相机 引擎文件
        public static HDevProcedureCall hprocall_LD_LCD; //左下角相机 引擎文件
        public static HDevProcedureCall hprocall_RU_LCD; //右上角相机 引擎文件
        public static HDevProcedureCall hprocall_RD_LCD; //右下角相机 引擎文件

        public static HDevProcedureCall hprocall_LU_DIS; //左上角相机A壳 引擎文件
        public static HDevProcedureCall hprocall_LD_DIS; //左下角相机A壳 引擎文件
        public static HDevProcedureCall hprocall_RU_DIS; //右上角相机A壳 引擎文件
        public static HDevProcedureCall hprocall_RD_DIS; //右下角相机A壳 引擎文件



        public void LoadHdevFile()
        {
            try
            {
                string exePath = string.Format(AppDomain.CurrentDomain.BaseDirectory + "HDEV\\{0}",SysConfig.DefaultJob);
                //string exePath = AppDomain.CurrentDomain.BaseDirectory + "HDEV\\"; 


                //设置hdev程序所在路径
                hengine = new HDevEngine();    //新建对应实例
                hengine.SetProcedurePath(exePath);
                var Program = new HDevProcedure("Inspect_LU");
                hprocall_LU = new HDevProcedureCall(Program);

                var Program_LULCD = new HDevProcedure("Inspect_LCD_LU");
                hprocall_LU_LCD = new HDevProcedureCall(Program_LULCD);


                var Programb = new HDevProcedure("Inspect_LD");
                hprocall_LD = new HDevProcedureCall(Programb);

                var ProgrambLCD = new HDevProcedure("Inspect_LCD_LD");
                hprocall_LD_LCD = new HDevProcedureCall(ProgrambLCD);


                var ProgramL = new HDevProcedure("Inspect_RU");
                hprocall_RU = new HDevProcedureCall(ProgramL);

                var ProgramLLCD = new HDevProcedure("Inspect_LCD_RU");
                hprocall_RU_LCD = new HDevProcedureCall(ProgramLLCD);


                var ProgramR = new HDevProcedure("Inspect_RD");
                hprocall_RD = new HDevProcedureCall(ProgramR);

                var ProgramRLCD = new HDevProcedure("Inspect_LCD_RD");
                hprocall_RD_LCD = new HDevProcedureCall(ProgramRLCD);


                var Program1 = new HDevProcedure("Inspect_LU_DIS");
                hprocall_LU_DIS = new HDevProcedureCall(Program1);

                var Program2 = new HDevProcedure("Inspect_LD_DIS");
                hprocall_LD_DIS = new HDevProcedureCall(Program2);


                var Program3 = new HDevProcedure("Inspect_RU_DIS");
                hprocall_RU_DIS = new HDevProcedureCall(Program3);

                var Program4 = new HDevProcedure("Inspect_RD_DIS");
                hprocall_RD_DIS = new HDevProcedureCall(Program4);

                var ProgramCam = new HDevProcedure("Inspect_Cam");
                hprocall_Cam = new HDevProcedureCall(ProgramCam);

                var ProgramlcdCam = new HDevProcedure("Inspect_LCD_Cam");
                hprocall_Lcd_Cam = new HDevProcedureCall(ProgramlcdCam);

            }
            catch (Exception ex)
            {
                ErrLog.WriteLogEx(ex.ToString());
            }
        }


        public bool Run_LU_DIS(HObject ImageAll)
        {

            try
            {
                hprocall_LU_DIS.SetInputIconicParamObject("InputImage", ImageAll);
                hprocall_LU_DIS.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }


        public bool Run_LD_DIS(HObject ImageAll)
        {

            try
            {
                hprocall_LD_DIS.SetInputIconicParamObject("InputImage", ImageAll);
                hprocall_LD_DIS.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }


        public bool Run_RU_DIS(HObject ImageAll)
        {

            try
            {
                hprocall_RU_DIS.SetInputIconicParamObject("InputImage", ImageAll);
                hprocall_RU_DIS.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }


        public bool Run_RD_DIS(HObject ImageAll)
        {

            try
            {
                hprocall_RD_DIS.SetInputIconicParamObject("InputImage", ImageAll);
                hprocall_RD_DIS.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }


        public bool Run_LU(HObject ImageAll)
        {
       
            try
            {               
                hprocall_LU.SetInputIconicParamObject("InputImage", ImageAll);
                hprocall_LU.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {
               
                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }
          
        }

        public bool Run_LU_LCD(HObject ImageAll)
        {

            try
            {
                hprocall_LU_LCD.SetInputIconicParamObject("InputImage", ImageAll);
         
                hprocall_LU_LCD.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }

        public bool Run_LD(HObject ImageAll)
        {

            try
            {
                hprocall_LD.SetInputIconicParamObject("InputImage", ImageAll);
                //hprocall_LD.SetInputCtrlParamTuple("minArea", SysConfig.BlobMin);
                //hprocall_LD.SetInputCtrlParamTuple("maxArea", SysConfig.BlobMax);
                hprocall_LD.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }

        public bool Run_LD_LCD(HObject ImageAll)
        {

            try
            {
                hprocall_LD_LCD.SetInputIconicParamObject("InputImage", ImageAll);
                //hprocall_LD_LCD.SetInputCtrlParamTuple("minArea", SysConfig.BlobMin);
                //hprocall_LD_LCD.SetInputCtrlParamTuple("maxArea", SysConfig.BlobMax);
                hprocall_LD_LCD.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }

        public bool Run_RU(HObject ImageAll)
        {

            try
            {
                hprocall_RU.SetInputIconicParamObject("InputImage", ImageAll);
                //hprocall_RU.SetInputCtrlParamTuple("minArea", SysConfig.BlobMin);
                //hprocall_RU.SetInputCtrlParamTuple("maxArea", SysConfig.BlobMax);
                hprocall_RU.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }

        public bool Run_RU_LCD(HObject ImageAll)
        {

            try
            {
                hprocall_RU_LCD.SetInputIconicParamObject("InputImage", ImageAll);
                //hprocall_RU_LCD.SetInputCtrlParamTuple("minArea", SysConfig.BlobMin);
                //hprocall_RU_LCD.SetInputCtrlParamTuple("maxArea", SysConfig.BlobMax);
                hprocall_RU_LCD.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }


        public bool Run_RD(HObject ImageAll)
        {

            try
            {
                hprocall_RD.SetInputIconicParamObject("InputImage", ImageAll);
                //hprocall_RD.SetInputCtrlParamTuple("minArea", SysConfig.BlobMin);
                //hprocall_RD.SetInputCtrlParamTuple("maxArea", SysConfig.BlobMax);
                hprocall_RD.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }

        public bool Run_RD_LCD(HObject ImageAll)
        {

            try
            {
                hprocall_RD_LCD.SetInputIconicParamObject("InputImage", ImageAll);
                //hprocall_RD_LCD.SetInputCtrlParamTuple("minArea", SysConfig.BlobMin);
                //hprocall_RD_LCD.SetInputCtrlParamTuple("maxArea", SysConfig.BlobMax);
                hprocall_RD_LCD.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }

        public bool Run_Cam(HObject ImageAll)
        {

            try
            {
                hprocall_Cam.SetInputIconicParamObject("InputImage", ImageAll);
                hprocall_Cam.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }


        public bool Run_LCD_Cam(HObject ImageAll)
        {

            try
            {
                hprocall_Lcd_Cam.SetInputIconicParamObject("InputImage", ImageAll);
                hprocall_Lcd_Cam.Execute();
                return true;
            }
            catch (HDevEngineException ex)
            {

                ErrLog.WriteLogEx(ex.ToString());
                return false;
            }

        }

        public double KDeg(double x1,double y1,double x2,double y2)
        {
            y2 = y2 - 200;
            double k = (x1-x2) / (y1-y2);
            double rad = Math.Atan(k);

            return RadToDeg(rad);
        }



        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="Degree"></param>
        /// <returns></returns>
        public  Double DegToRad(Double Degree)
        {
            Double rad;
            rad = Math.PI / 180 * Degree;
            return rad;
        }
        /// <summary>
        ///弧度转换成角度
        /// </summary>
        /// <param name="Radian"></param>
        /// <returns></returns>

        public Double RadToDeg(Double Radian)
        {
            Double deg;
            deg = 180 / Math.PI * Radian;
            return deg;
        }
        /// <summary>
        /// 旋转中心计算
        /// </summary>
        /// <param name="BeforeX"></param>
        /// <param name="BeforeY"></param>
        /// <param name="CenterX"></param>
        /// <param name="CenterY"></param>
        /// <param name="angle"></param>
        /// <param name="AfterX"></param>
        /// <param name="AfterY"></param>
        /// <returns></returns>
        public  bool  RotationCalculation(double BeforeX, double BeforeY, double CenterX, double CenterY, double angle, out double AfterX, out double AfterY)
        {
            AfterX = 0;
            AfterY = 0;
            try
            {
                AfterX = Math.Round(CenterX + (BeforeX - CenterX) * Math.Cos(DegToRad(angle)) - (BeforeY - CenterY) * Math.Sin(DegToRad(angle)), 3);
                AfterY = Math.Round(CenterY + (BeforeX - CenterX) * Math.Sin(DegToRad(angle)) + (BeforeY - CenterY) * Math.Cos(DegToRad(angle)), 3);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //saveErrLog("旋转中心计算出错：" + ex.Message + "_" + ex.StackTrace.Substring(ex.StackTrace.IndexOf("行号"), ex.StackTrace.Length - ex.StackTrace.IndexOf("行号")));
            }
        }

        /// <summary>
        /// 拟合圆  
        /// </summary>
        /// <param name="X"> 拟合点X坐标集合</param>
        /// <param name="Y">拟合点Y坐标集合</param>
        /// <param name="RcX">拟合圆心X</param>
        /// <param name="RcY">拟合圆心Y</param>
        /// <param name="R">拟合圆半径</param>
        /// <returns></returns>
        public bool FitCircle(double[] X, double[] Y, out double RcX, out double RcY, out double R)
        {
            try
            {
                HTuple hTuple = new HTuple();
                HTuple hTuple2 = new HTuple();
                int num = 0;
                for (num = 0; num < X.Length; num++)
                {
                    if ((X[num] > 0.0) & (Y[num] > 0.0))//获得寻找到的模板中心装入hTuple2与hTuple
                    {
                        hTuple2.TupleConcat(X[num]);
                        hTuple.TupleConcat(Y[num]);
                    }
                }
                HObject contour;
                HOperatorSet.GenContourPolygonXld(out contour, hTuple, hTuple2);//使用模板中心生成多边形XLD轮廓
                HTuple row, column, radius, StartPhi, EndPhi, pointOrder;
                HOperatorSet.FitCircleContourXld(contour, "algebraic", -1, 0, 0, 3, 2, out row, out column, out radius, out StartPhi, out EndPhi, out pointOrder);//拟合圆形
                                                                                                                                                                  //得出结果
                RcY = row;
                RcX = column;
                R = radius;

                contour.Dispose();
                return true;
            }
            catch
            {
                RcY = -1.0;
                RcX = -1.0;
                R = -1.0;
                return false;
            }
        }


    }
}
