using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace TwoPointerEdgeFinder.Tests
{
    public class ImageHelperTests
    {
        [Fact]
        public async Task ConvertMatToMonochromeByteArray_ShouldReturnCorrectByteArray()
        {
            // Arrange
            var image = new OpenCvSharp.Mat(3, 3, OpenCvSharp.MatType.CV_8UC3, new OpenCvSharp.Scalar(255, 255, 255));
            var expectedByteArray = new byte[] { 255, 255, 255, 255, 255, 255, 255, 255, 255 };

            // Act
            var result = ImageHelper.ConvertMatToMonochromeByteArray(image);

            // Assert
            result.Should().BeEquivalentTo(expectedByteArray);
        }
    }
}