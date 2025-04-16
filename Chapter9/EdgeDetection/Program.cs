using EdgeDetection;
using OpenCvSharp;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Mat image = Cv2.ImRead(@"..\..\..\..\..\images\road.jpg", ImreadModes.Color);

        //ThresholdTrackBarDemo t = new ThresholdTrackBarDemo(@"../../../images/road.jpg");
        //t.Function();

        CannyTrackBarDemo t = new CannyTrackBarDemo(@"..\..\..\..\..\images\road.jpg", 100);
        t.TrackBar();

        /*Cv2.CvtColor(image, image, ColorConversionCodes.BGR2GRAY);
        Mat edgesL2 = new Mat();

        Mat edgesL1 = new Mat();
        //// Get Canny contours
        Cv2.Canny(image, edgesL2, 125, 350, 3, true);

        Cv2.Canny(image, edgesL1, 125, 350, 3, false);

        Cv2.ImShow("Original", image);

        Cv2.ImShow("edgesL1", edgesL1);

        Cv2.ImShow("edgesL2gradient", edgesL2);*/

        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }
}