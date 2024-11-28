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

        //5.4 - Image resize
        //ResizeImage(image);

        //5.5 - Image flipping
        //FlipImage(image);

        //5.6 - Images Operations
        BitwiseImage();

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

    public static void ResizeImage(Mat image)
    {
        Mat dest = new Mat();
        Cv2.Resize(image, dest, new Size(0, 0), 0.5, 0.5);
        Cv2.ImShow("resized", dest);
    }

    public static void FlipImage(Mat image)
    {
        Mat dest = new Mat();
        Mat dest2 = new Mat();
        Mat dest3 = new Mat();
        Cv2.Flip(image, dest, FlipMode.X);
        Cv2.Flip(image, dest2, FlipMode.Y);
        Cv2.Flip(image, dest3, FlipMode.XY);

        Cv2.ImShow("Flipped X", dest);
        Cv2.ImShow("Flipped Y", dest2);
        Cv2.ImShow("Flipped XY", dest3);

    }

    public static void BitwiseImage()
    {
        Mat image1 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);
        Mat image2 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);

        Cv2.Rectangle(image1, new Rect(new Point(0, 0), new Size(image1.Cols / 2, image1.Rows)), new Scalar(255, 255, 255), -1);
        Cv2.ImShow("image1", image1);

        Cv2.Rectangle(image2, new Rect(new Point(150, 100), new Size(200, 50)), new Scalar(255, 255, 255), -1);
        Cv2.ImShow("image2", image2);

        Mat andOp = new Mat();
        Cv2.BitwiseAnd(image1, image2, andOp);
        Cv2.ImShow("Operation AND", andOp);
    }
}