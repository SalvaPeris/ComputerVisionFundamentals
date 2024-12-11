using OpenCvSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"..\..\..\..\..\images\lena.jpg";
        Mat image = Cv2.ImRead(path, ImreadModes.Grayscale);

        Mat histogram = ComputeHistogram(image);
        PlotHistogram(histogram);
    }

    private static Mat ComputeHistogram(Mat image)
    {
        Mat histogram = new Mat();
        //  int[] hdims = { 256 }; // Histogram size for each dimension
        Rangef[] ranges = { new Rangef(0, 256), }; // min/max 
        int[] channels = new int[] { 0 };
        int[] histSize = new int[] { 256 };

        Cv2.CalcHist(new Mat[] { image }, channels, null, histogram, 1, histSize, ranges);
        return histogram;
    }

    private static void PlotHistogram(Mat histogram)
    {
        int plotWidth = 1024, plotHeight = 400;
        int binWidth = (plotWidth / histogram.Rows);
        Mat canvas = new Mat(plotHeight, plotWidth, MatType.CV_8UC3, new Scalar(0, 0, 0));
        // Normalize the values ( frequency and the pixel)
        Cv2.Normalize(histogram, histogram, 0, plotHeight, NormTypes.MinMax);
        // we iterate over the rows of the histogram object to read the pixel frequency values.
        // Each row number corresponds to a pixel value equivalent of the number.
        for (int rows = 1; rows < histogram.Rows; ++rows)
        {
            // Use the Line method to connect the y values corresponding to each x value 
            //pay attention to the histogram.At<float>() method by which we extract the frequency value at each row 
            // This is another way of reaching and getting values from Mat object locations
            //We have seen Get/Set and Indexer methods before. So you have added another knowledge in your knowledge set.

            Cv2.Line(canvas,
            new Point((binWidth * (rows - 1)), (plotHeight - (float)(histogram.At<float>(rows - 1, 0)))),
            new Point(binWidth * rows, (plotHeight - (float)(histogram.At<float>(rows, 0)))),
            new Scalar(125, 125, 125), 2);

        }

        Cv2.ImShow("Histogram", canvas);

        Cv2.WaitKey(0);
        Cv2.DestroyAllWindows();
    }
}