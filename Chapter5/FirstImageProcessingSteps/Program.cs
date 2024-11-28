using OpenCvSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"..\..\..\..\..\images\lena.jpg";
        Mat image = Cv2.ImRead(path, ImreadModes.Color);

        //5.2 - Image shifting
        //Translation Matrix
        //[1,0,tx]
        //[0,1,ty]
        //ShiftImage(image);

        //5.3 - Image rotation
        //RotateImage(image);


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

    public static void RotateImage(Mat image)
    {
        var center = new Point2f(image.Width / 2, image.Height / 2);
        double angle = -45.0;
        Mat RM = Cv2.GetRotationMatrix2D(center, angle, 0.5);
        Mat dest = new Mat();

        Cv2.WarpAffine(image, dest, RM, new Size(image.Width, image.Height));
        Cv2.ImShow("rotated", dest);
        Cv2.WarpAffine(image, dest, RM, new Size(image.Width, image.Height));
    }
}