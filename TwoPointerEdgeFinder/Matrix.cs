using System.Data.Common;

namespace TwoPointerEdgeFinder;

public class Matrix(byte[] matrix, int width, int height)
{
    private readonly byte[] _matrix = matrix;
    private readonly int _width = width;
    private readonly int _height = height;

    public async Task<byte[]> GetPiece(int x, int y, int kernelSize = 3, byte fill = 255)
    {
        if (kernelSize % 2 == 0)
        {
            throw new ArgumentException("Kernel size must be an odd number.");
        }

        var halfKernelSize = kernelSize / 2;
        var matrixSize = kernelSize * kernelSize;
        var matrix = new byte[matrixSize];

        for (int j = -halfKernelSize; j <= halfKernelSize; j++)
        {
            for (int i = -halfKernelSize; i <= halfKernelSize; i++)
            {
                var newX = x + i;
                var newY = y + j;

                var index = (j + halfKernelSize) * kernelSize + (i + halfKernelSize);

                if (IsWithinBounds(newX, newY))
                {
                    matrix[index] = _matrix[newY * _width + newX];
                }
                else
                {
                    matrix[index] = fill;
                }
            }
        }

        return matrix;
    }

    public static async Task<bool> CheckWhiteSides(Direction direction, byte[] kernel, int kernelSize, byte threshold = 120)
    {
        (int dx, int dy) = direction.ToOffset();
        int column = dy == 1 ? kernelSize - 1 : 0;
        int row = dx == 1 ? kernelSize - 1 : 0;

        if (dx == 0 && dy != 0)
        {
            return CheckColumn(kernel, kernelSize, threshold, column);
        }

        if (dy == 0 && dx != 0)
        {
            return CheckRow(kernel, kernelSize, threshold, row);
        }
        
        if (dx != 0 && dy != 0)
        {
            var columnResult = CheckColumn(kernel, kernelSize, threshold, column);
            var rowResult = CheckRow(kernel, kernelSize, threshold, row);
            return columnResult && rowResult;
        }

        throw new ApplicationException("Program should not come here.");
    }

    private static bool CheckColumn(byte[] kernel, int kernelSize, int threshold, int column)
    {
        for (int y = 0; y < kernelSize; y++)
        {
            int index = y * kernelSize + column;

            if (index >= 0 && index < kernel.Length)
            {
                if (kernel[index] >= threshold)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool CheckRow(byte[] kernel, int kernelSize, int threshold, int row)
    {
        for (int x = 0; x < kernelSize; x++)
        {
            int index = row * kernelSize + x;

            if (index >= 0 && index < kernel.Length)
            {
                if (kernel[index] >= threshold)
                {
                    return false;
                }
            }
        }

        return true;
        }


    private bool IsWithinBounds(int x, int y)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }
}