using OpenCvSharp;

namespace TwoPointerEdgeFinder;

public class ImageHelper
{
    public static byte[] ConvertMatToMonochromeByteArray(Mat image)
    {
        // Convert the image to grayscale
        Mat grayImage = new Mat();
        Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);

        byte[] byteArray = new byte[grayImage.Rows * grayImage.Cols];
        grayImage.GetArray(out byteArray);

        return byteArray;
    }
}