using OpenCvSharp;

internal class Program
{
    private void Main(string[] args)
    {
        string path = @"..\..\..\..\..\images\lena.jpg";
        Mat image = Cv2.ImRead(path, ImreadModes.Color);
        Cv2.ImShow("original", image);

        GetBinaryThreshold(image);

        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }

    private void GetBinaryThreshold(Mat image)
    {
        Mat threshold = new Mat(new Size(image.Width, image.Height), MatType.CV_8UC3, new Scalar(0));
        Cv2.Threshold(image, threshold, 15, 255, ThresholdTypes.Binary);

        Cv2.ImShow("threshold", threshold);
    }
}