using OpenCvSharp;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"..\..\..\..\images\lena.jpg";
        Mat colorImage = Cv2.ImRead(path, ImreadModes.Color);

        //4.2 Mat Object creation
        //CreateMatObject();

        //4.3. Copy and clone Mat objects
        //CopyMatObject(colorImage);

        //RoiMatObject(colorImage);

        //4.5 Mat Object Image manipulation
        //GetPixels(colorImage);

        //4.6 Mat Object Image manipulation - Second Method
        //GetPixelsIndexer(colorImage);

        //4.6.2 Mat Object Image manipulation - Third Method
        // MatOfByte3 - Object not found in library

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

    private static void CopyMatObject(Mat colorImage)
    {
        Cv2.ImShow("original", colorImage);

        Mat clonedImage = colorImage.Clone();
        Cv2.ImShow("cloned", clonedImage);

        Mat anotherClonedImage = new Mat();
        colorImage.CopyTo(anotherClonedImage);
        Cv2.ImShow("anotherCloned", anotherClonedImage);
    }

    private static void RoiMatObject(Mat colorImage)
    {
        Mat[] channels;
        Cv2.Split(colorImage, out channels);
        Cv2.ImShow("Blue", channels[0]);
        Cv2.ImShow("Green", channels[1]);
        Cv2.ImShow("Red", channels[2]);
        Mat roiImage = new Mat(colorImage, new Rect(50, 50, 250, 250));
        Cv2.ImShow("roi", roiImage);
    }

    private static void GetPixels(Mat colorImage)
    {
        int numRows = colorImage.Rows;
        int numCols = colorImage.Cols;
        Mat cImage = colorImage.Clone();

        for (int y = 0; y < numRows; y++)
        {
            for (int x = 0; x < numCols; x++)
            {
                Vec3b pixel = cImage.Get<Vec3b>(y, x);
                byte blue = pixel.Item0;
                byte red = pixel.Item2;
                byte green = pixel.Item1;
                byte temp = blue;
                pixel.Item0 = red;
                pixel.Item2 = temp;

                cImage.Set<Vec3b>(y, x, pixel);
            }
        }

        Cv2.ImShow("swapped", cImage);
    }

    private static void GetPixelsIndexer(Mat colorImage)
    {
        int numRows = colorImage.Rows;
        int numCols = colorImage.Cols;
        Mat cImage = colorImage.Clone();

        var indexer = cImage.GetGenericIndexer<Vec3b>();

        for (int y = 100; y < numRows - 100; y++)
        {
            for (int x = 100; x < numCols - 100; x++)
            {
                Vec3b pixel = indexer[y, x];
                byte blue = pixel.Item0;
                byte red = pixel.Item2;
                byte green = pixel.Item1;
                byte temp = blue;
                pixel.Item0 = red;
                pixel.Item2 = temp;

                indexer[y, x] = pixel;
            }
        }

        Cv2.ImShow("swapped", cImage);
    }
}