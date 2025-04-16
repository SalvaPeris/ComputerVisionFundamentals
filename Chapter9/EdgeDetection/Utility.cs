using OpenCvSharp;

namespace EdgeDetection
{
    class Utility
    {
        public static Mat GetContainer(Mat image, int count, MatType dept)
        {
            Mat container = new Mat(image.Height, count * (image.Width) + 20 * count, dept);
            return container;
        }

        public static void ShowImages(Mat[] images, MatType dept)
        {
            Mat container = GetContainer(images[0], images.Length, dept);
            int w = images[0].Width;
            int h = images[0].Height;
            for (int i = 0; i < images.Length - 1; i++)
            {
                container[new Rect(new Point(i * w + i * 20, 0), new Size(w, h))] = images[i];
            }
        }
    }
}