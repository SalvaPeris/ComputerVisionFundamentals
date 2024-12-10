using OpenCvSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"..\..\..\..\..\images\lena.jpg";
        Mat image = Cv2.ImRead(path, ImreadModes.Color);
        Cv2.ImShow("original", image);

        // 6.2 Part 1
        //GetBinaryThreshold(image);

        // 6.2 Part 2
        //GetGrayscaledThreshold(image);

        // 6.3 Otsu
        GetOtsuThreshold(image);

        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }

    private static Mat GetBinaryThreshold(Mat image)
    {
        Mat threshold = new Mat(new Size(image.Width, image.Height), MatType.CV_8UC3, new Scalar(0));
        Cv2.Threshold(image, threshold, 15, 255, ThresholdTypes.Binary);

        Cv2.ImShow("threshold", threshold);

        return threshold;
    }

    private static void GetGrayscaledThreshold(Mat image)
    {
        Mat threshold = GetBinaryThreshold(image);

        Mat grayscaled = new Mat();
        Cv2.CvtColor(image, grayscaled, ColorConversionCodes.BGR2GRAY);
        Cv2.Threshold(grayscaled, threshold, 30, 255, ThresholdTypes.Binary);
        Cv2.ImShow("threshold Grayscaled", threshold);
        
        Mat adaptive = new Mat();
        Cv2.AdaptiveThreshold(grayscaled, adaptive, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 31, 1.0);
        Cv2.ImShow("adaptive", adaptive);

        Mat grayscaledImage = new Mat();
        Cv2.GaussianBlur(image, grayscaledImage, new Size(9, 9),0);
        Cv2.ImShow("image denoised", grayscaledImage);
        Cv2.ImWrite("denoised.jpg", grayscaledImage);
        Cv2.CvtColor(image, grayscaledImage, ColorConversionCodes.BGR2GRAY);
        Cv2.ImShow("gray image", grayscaledImage);
    }

    private static void GetOtsuThreshold(Mat image)
    {
        Mat grayscaledLeaf = new Mat();
        Cv2.CvtColor(image, grayscaledLeaf, ColorConversionCodes.BGR2GRAY);
        Cv2.ImShow("gray image", grayscaledLeaf);
        Mat otsu = new Mat();
        Cv2.Threshold(grayscaledLeaf, otsu, 0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
        Cv2.ImShow("otsu", otsu);
        Cv2.ImWrite("otsu.jpg", otsu);
    }
}