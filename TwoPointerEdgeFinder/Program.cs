using OpenCvSharp;
using TwoPointerEdgeFinder;

var image = Cv2.ImRead(@"C:\Users\abura\source\repos\TwoPointerEdgeFinder\TwoPointerEdgeFinder\assets\10_crop.png");

var gray = ImageHelper.ConvertMatToMonochromeByteArray(image);

var edgeFinder = new EdgeFinder(130, gray, image.Width, image.Height);

static void DrawAndShowEdges(Mat image, IEnumerable<(int, int)> positiveEdge, IEnumerable<(int, int)> negativeEdge)
{
    // Copy the original image to draw on
    var outputImage = image.Clone();

    // Draw positive edge in blue
    foreach (var (x, y) in positiveEdge)
    {
        Cv2.Circle(outputImage, new Point(x, y), 1, Scalar.Blue, -1);
    }

    // Draw negative edge in red
    foreach (var (x, y) in negativeEdge)
    {
        Cv2.Circle(outputImage, new Point(x, y), 1, Scalar.Red, -1);
    }

    Mat resizedImage = new Mat();
    Cv2.Resize(outputImage, resizedImage, new Size(image.Width * 10, image.Height * 10), 0, 0, InterpolationFlags.Nearest);


    // Show the image
    Cv2.ImShow("Edges", resizedImage);
    Cv2.WaitKey(0);
    Cv2.DestroyAllWindows();
}