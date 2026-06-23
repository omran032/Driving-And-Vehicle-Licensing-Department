
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
