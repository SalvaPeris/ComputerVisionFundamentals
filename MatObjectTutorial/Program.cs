using OpenCvSharp;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        //CreateMatObject();
        CopyMatObject();

        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }

    private static void CreateMatObject()
    {
        Mat mat = new Mat(30, 40, MatType.CV_8UC3, new Scalar(0, 0, 255));
        Mat mat2 = new Mat(new Size(140, 130), MatType.CV_8UC3, new Scalar(0, 255, 0));

        Cv2.ImShow("m", mat);
        Cv2.ImShow("m2", mat2);
    }

    private static void CopyMatObject()
    {
        string path = @"..\..\..\..\images\lena.jpg";
        Mat colorImage = Cv2.ImRead(path, ImreadModes.Color);
        Cv2.ImShow("original", colorImage);

        Mat clonedImage = colorImage.Clone();
        Cv2.ImShow("cloned", clonedImage);

        Mat anotherClonedImage = new Mat();
        colorImage.CopyTo(anotherClonedImage);
        Cv2.ImShow("anotherCloned", anotherClonedImage);
    }
}