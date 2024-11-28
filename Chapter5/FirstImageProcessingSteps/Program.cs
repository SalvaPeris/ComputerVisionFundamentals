using OpenCvSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        Mat image = Cv2.ImRead(@"..\..\..\..\..\images\lena.jpg", ImreadModes.Color);

        //5.2 - Image shifting
        //Translation Matrix
        //[1,0,tx]
        //[0,1,ty]
        //ShiftImage(image);


        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }

    public static void ShiftImage(Mat image)
    {
         Cv2.ImShow("original", image);

        Mat M = new Mat(2, 3, MatType.CV_32FC1);
        M.Set(0, 0, 1.0f);
        M.Set(0, 1, 0.0f);
        M.Set(0, 2, 50.0f);
        M.Set(1, 0, 0.0f);
        M.Set(1, 1, 1.0f);
        M.Set(1, 2, 50.0f);

        Mat dest = new Mat();
        Cv2.WarpAffine(image, dest,M, new Size(image.Width + 60,image.Height + 60));
        Cv2.ImShow("shifted", dest);
    }
}