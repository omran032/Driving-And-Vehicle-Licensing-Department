using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;

namespace DVLD_Management_System.AI
{
    internal class cls_InspectImage
    {

        public static bool DetectFace(string imagePath)
        {
            // تحميل الصورة
            Image<Bgr, byte> img = new Image<Bgr, byte>(imagePath);

            // تحويل الصورة إلى تدرج رمادي (أفضل لكشف الوجه)
            Image<Gray, byte> gray = img.Convert<Gray, byte>();

            // تحميل نموذج كشف الوجه
            CascadeClassifier faceDetector = new CascadeClassifier(@"AI/haarcascade_frontalface_default.xml");

            // كشف الوجوه داخل الصورة
            Rectangle[] faces = faceDetector.DetectMultiScale(
                gray,
                1.1,     // scale factor
                4,       // min neighbors
                Size.Empty
            );

            // إذا تم العثور على وجه واحد أو أكثر
            if (faces.Length > 0)
            {
                return true; // يوجد وجه
            }
            else
            {
                return false; // لا يوجد وجه
            }
        }







public static bool HasFace(string imagePath)
    {
        var cascade = new FaceHaarCascade();
        var detector = new HaarObjectDetector(cascade, 30);
        detector.SearchMode = ObjectDetectorSearchMode.Average;
        detector.ScalingMode = ObjectDetectorScalingMode.GreaterToSmaller;
        detector.ScalingFactor = 1.5f;
        detector.UseParallelProcessing = true;

        Bitmap bmp = (Bitmap)Image.FromFile(imagePath);
        var faces = detector.ProcessFrame(bmp);

        return faces.Length > 0;
    }








}

   


}
