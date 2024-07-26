using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace TwoPointerEdgeFinder.Tests
{
    public class MatrixTests
    {
        [Fact]
        public async Task GetPiece_ShouldReturnCorrectPiece()
        {
            // Arrange
            var matrix = new byte[]
            {
                1, 2, 3, 4, 5,
                6, 7, 8, 9, 10,
                11, 12, 13, 14, 15,
                16, 17, 18, 19, 20,
                21, 22, 23, 24, 25
            };
            var width = 5;
            var height = 5;
            var targetMatrix = new Matrix(matrix, width, height);
            var x = 2;
            var y = 2;
            var kernelSize = 3;
            byte fill = 255;

            var expectedPiece = new byte[]
            {
                7, 8, 9,
                12, 13, 14,
                17, 18, 19
            };

            // Act
            var result = await targetMatrix.GetPiece(x, y, kernelSize, fill);

            // Assert
            result.Should().BeEquivalentTo(expectedPiece);
        }

        [Theory]
        [InlineData(Direction.Right, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 120, true)]
        [InlineData(Direction.Left, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 120, true)]
        [InlineData(Direction.Up, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 120, true)]
        [InlineData(Direction.Down, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 120, true)]
        [InlineData(Direction.DownRight, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 120, true)]
        public async Task CheckWhiteSides_ShouldReturnCorrectResult(Direction direction, byte[] kernel, int kernelSize, byte threshold, bool expectedResult)
        {
            // Act
            var result = await Matrix.CheckWhiteSides(direction, kernel, kernelSize, threshold);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}