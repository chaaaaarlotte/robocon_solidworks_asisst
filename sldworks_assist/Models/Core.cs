using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

using System.Diagnostics;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using sldworks_assist.Views;

namespace sldworks_assist.Models
{
    public class Core : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        SldWorks SwApp;
        IModelDoc2 swModel;

        public bool CreatePipe(string FileName, int kei, string destance)
        {
            Process[] processes = Process.GetProcessesByName("SLDWOROKS");
            foreach (Process process in processes)
            {
                process.CloseMainWindow();
                process.Kill();
            }
            Type swType = Type.GetTypeFromProgID("SldWorks.Application.22");
            ISldWorks processSW = (ISldWorks)System.Activator.CreateInstance(swType);
            SwApp = (SldWorks)processSW;
            processSW.Visible = true;
            SwApp.Visible = true;

            SwApp.NewPart();
            swModel = SwApp.IActiveDoc2;

            int sign = -1;

            swModel.Extension.SelectByID2("正面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            double il = (double)kei;
            swModel.SketchManager.CreateCenterRectangle(0, 0, 0, il / 2000, il / 2000, 0);
            swModel.ClearSelection2(true);

            swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, true, 1, null, 0);
            swModel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 1, null, 0);
            swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 1, null, 0);
            swModel.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 1, null, 0);

            swModel.SketchManager.SketchOffset(-0.001, false, true, false, false, true);
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("ｽｹｯﾁ1", "SKETCH", 0, 0, 0, false, 4, null, 0);

            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, double.Parse(destance) / 1000, 0.01, false, false, false, false,
                0.017453292519943334, 0.017453292519943334, false, false, false, false, true, true, true, 0, 0, false);
            swModel.ISelectionManager.EnableContourSelection = false;

            switch (kei)
            {
                case 9:
                    break;
                case 10:
                    //swModel.Extension.SelectByID2("", "FACE", 0.0041595505632017193, 0.0099999999998772182, 0.005742651313312308, false, 0, null, 0); //恐らくもう一つの面
                    swModel.Extension.SelectByID2("", "FACE", 0.0099999999998772182, 0.0067603663156319271, 0.0057709521539095476, false, 0, null, 0);
                    break;
                case 12:
                    swModel.Extension.SelectByID2("", "FACE", 0.011999999999886768, 0.0088564999179538972, 0.0099292730428715, false, 0, null, 0);
                    break;
                case 15:
                    break;
                case 20:
                    break;
            }
            swModel.SketchManager.InsertSketch(true);
            for (int i = 0; pipeText.demention1Main.Length > i; i++)
            {
                if (pipeText.demention1Main[i].distance.Text == "")
                {
                    break;
                }
                swModel.SketchManager.CreateCircle(double.Parse(pipeText.demention1Main[i].distance.Text) * sign / 1000, 0, 0,
                    (double.Parse(pipeText.demention1Main[i].distance.Text) / 1000 - double.Parse(pipeText.demention1Main[i].fai.Text) / 2000) * sign, 0, 0);
            }
            swModel.ClearSelection2(true);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("ｽｹｯﾁ2", "SKETCH", 0, 0, 0, false, 4, null, 0);
            swModel.FeatureManager.FeatureCut3(true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334
                , false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            swModel.ISelectionManager.EnableSelection = false;


            switch (kei)
            {
                case 9:
                    break;
                case 10:
                    swModel.Extension.SelectByID2("", "FACE", 0.0041595505632017193, 0.0099999999998772182, 0.005742651313312308, false, 0, null, 0); //恐らくもう一つの面
                    //swModel.Extension.SelectByID2("", "FACE", 0.0099999999998772182, 0.0067603663156319271, 0.0057709521539095476, false, 0, null, 0);
                    break;
                case 12:
                    swModel.Extension.SelectByID2("", "FACE", 0.011999999999886768, 0.0088564999179538972, 0.0099292730428715, false, 0, null, 0);
                    break;
                case 15:
                    break;
                case 20:
                    break;
            }
            swModel.SketchManager.InsertSketch(true);
            for (int i = 0; pipeText.demention2Main.Length > i; i++)
            {
                if (pipeText.demention2Main[i].distance.Text == "")
                {
                    break;
                }
                swModel.SketchManager.CreateCircle(double.Parse(pipeText.demention2Main[i].distance.Text) * sign / 1000, 0, 0,
                    (double.Parse(pipeText.demention2Main[i].distance.Text) / 1000 - double.Parse(pipeText.demention2Main[i].fai.Text) / 2000) * sign, 0, 0);
            }
            swModel.ClearSelection2(true);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.Extension.SelectByID2("ｽｹｯﾁ2", "SKETCH", 0, 0, 0, false, 4, null, 0);
            swModel.FeatureManager.FeatureCut3(true, false, false, 1, 0, 0.01, 0.01, false, false, false, false, 0.017453292519943334, 0.017453292519943334
                , false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            swModel.ISelectionManager.EnableSelection = false;

            //swModel.SaveAs3(FileName, 0, 2);            

            /*0@
             * SwApp.ExitApp(); 
             * SwApp = null;
             */
            return Checker(FileName);
        }

        private bool Checker(string fileName)
        {
            return true;
        }
    }
}

