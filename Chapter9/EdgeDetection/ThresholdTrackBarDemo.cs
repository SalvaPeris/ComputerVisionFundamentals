using OpenCvSharp;

namespace EdgeDetection
{
    public class ThresholdTrackBarDemo
    {

        int max_BINARY_value = 255;
        CvTrackbar CvTrackbarValue;
        CvTrackbar CvTrackbarType;
        Mat src_gray = new Mat();
        Mat dst = new Mat();
        Window MyWindow;
        Mat src;
        public ThresholdTrackBarDemo(string fileName)
        {
            src = Cv2.ImRead(fileName, ImreadModes.Color);
        }
        public void Function()
        {
            int threshold_value = 0;
            int threshold_type = 3;
            int max_value = 255;
            int max_type = 4;

            string trackbar_type = "Type: \n 0: Binary \n 1:Binary Inverted \n 2: Truncate \n 3: To Zero \n 4: To Zero Inverted";
            string trackbar_value = "Value";

            /// Convert the image to Gray
            Cv2.CvtColor(src, src_gray, ColorConversionCodes.BGR2GRAY);

            // Create output window
            MyWindow = new Window("Track", WindowFlags.AutoSize);

            // Whenever the user changes the value of any of the Trackbars,
            // the function Threshold_Demo is called. I needed a common global
            // window object for Threshold_Demo and Function to prevent a
            // internal null reference.
            CvTrackbarType = MyWindow.CreateTrackbar(trackbar_type,
                            threshold_type, max_type, Threshold_Demo);

            CvTrackbarValue = MyWindow.CreateTrackbar(trackbar_value,
                            threshold_value, max_value, Threshold_Demo);

            /// Call the function to initialize
            Threshold_Demo(0);

            /// Wait until user finishes program
            while (true)
            {
                int c;
                c = Cv2.WaitKey(20);
                if ((char)c == 27)
                { break; }
            }
        }

        void Threshold_Demo(int pos)
        {
            /* 0: Binary
               1: Binary Inverted
               2: Threshold Truncated
               3: Threshold to Zero
               4: Threshold to Zero Inverted
             */

            Cv2.Threshold(src_gray, dst, CvTrackbarValue.Pos,
                max_BINARY_value, (ThresholdTypes)CvTrackbarType.Pos);

            MyWindow.Image = dst;
        }
    }
}