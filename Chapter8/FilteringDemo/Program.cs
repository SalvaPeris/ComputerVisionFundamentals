using OpenCvSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"..\..\..\..\..\images\lena.jpg";
        Mat image = Cv2.ImRead(path, ImreadModes.Color);

        var kernel3x3 = Mat.Ones(new Size(3, 3), MatType.CV_32F) / 9;
        var kernel5x5 = Mat.Ones(new Size(5, 5), MatType.CV_32F) / 25;
        Mat result3x3 = new Mat();
        Mat result5x5 = new Mat();
        Mat container = new Mat(image.Height, 3 * (image.Width) + 20 * 2, MatType.CV_8UC3);
        Mat container1 = new Mat(image.Height, 3 * (image.Width) + 20 * 2, MatType.CV_8UC3);


        /*Cv2.Filter2D(image, result3x3, -1, kernel3x3);
        Cv2.Filter2D(image, result5x5, -1, kernel5x5);
        container[new Rect(new Point(0, 0), new Size(image.Width, image.Height))] = image;
        container[new Rect(new Point(image.Width + 20, 0), new Size(image.Width, image.Height))] = result3x3;
        container[new Rect(new Point(2 * image.Width + 40, 0), new Size(image.Width, image.Height))] = result5x5;*/

        //Cv2.ImShow("Side by Side", container);


        Mat result5x5Gaus = new Mat();
        Mat result5x5Blur = new Mat();
        Cv2.Blur(image, result5x5Blur, new Size(5, 5)); // size of the filter
        container1[new Rect(new Point(0, 0), new Size(image.Width, image.Height))] = image;
        container1[new Rect(new Point(image.Width + 20, 0), new Size(image.Width, image.Height))] = result5x5Blur;


        Cv2.GaussianBlur(image, result5x5Gaus, new Size(5, 5), 1.5, 1.5);
        container1[new Rect(new Point(2 * image.Width + 40, 0), new Size(image.Width, image.Height))] = result5x5Gaus;
        Cv2.ImShow("Lena Original, Blurred and Gaussian", container1);
        

        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }
}