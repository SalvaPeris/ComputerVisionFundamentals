using OpenCvSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        //OthersFilters();
        SobelFilter();
    }

    private static void OthersFilters()
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

    private static void SobelFilter()
    {
        int kSize = 3;

        string path = @"..\..\..\..\..\images\shapes.png";
        Mat image = Cv2.ImRead(path, ImreadModes.Color);

        Cv2.CvtColor(image, image, ColorConversionCodes.BGR2GRAY);
        Cv2.Resize(image, image, new Size(), 0.5, 0.5, InterpolationFlags.Area);
        //Mat sobelX = new Mat(image.Rows, image.Cols, MatType.CV_8U);
        //Mat sobelY = new Mat(image.Rows, image.Cols, MatType.CV_8U);

        Mat sobelX64 = new Mat(image.Rows, image.Cols, MatType.CV_64F);
        Mat sobelY64 = new Mat(image.Rows, image.Cols, MatType.CV_64F);

        //Cv2.Sobel(image, sobelX, MatType.CV_8U, 1, 0, kSize);
        //Cv2.Sobel(image, sobelY, MatType.CV_8U, 0, 1, kSize);

        Cv2.Sobel(image, sobelX64, MatType.CV_64F, 1, 0, kSize);
        Cv2.Sobel(image, sobelY64, MatType.CV_64F, 0, 1, kSize);

        Mat sobelXY = new Mat();
        Mat sobelXY64 = new Mat();

        Cv2.ConvertScaleAbs(sobelX64, sobelX64);
        Cv2.ConvertScaleAbs(sobelY64, sobelY64);
        Cv2.Add(sobelX64, sobelY64, sobelXY64);

        //Cv2.ImShow("Original", image);
        //Cv2.ImShow("SobelX", sobelX);
        Cv2.ImShow("SobelX64", sobelX64);
        //Cv2.ImShow("SobelY", sobelY);
        Cv2.ImShow("SobelY64", sobelY64);
        //Cv2.ImShow("SobelXY", sobelXY);
        Cv2.ImShow("SobelXY64", sobelXY64);

        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }
}