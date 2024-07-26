using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoPointerEdgeFinder;

public class EdgeFinder
{
    private readonly int _threshold;

    private readonly int _width;
    private readonly int _height;
    private readonly byte[] _image;

    public Matrix Matrix => new Matrix(_image, _width, _height);

    public EdgeFinder(int threshold, byte[] image, int width, int height)
    {
        _threshold = threshold;
        _image = image;
        _width = width;
        _height = height;
    }

    //public async Task<IEnumerable<(int, int)>> Positive()
    //{

    //}

    //public async Task<IEnumerable<(int, int)>> Negative()
    //{

    //}
}
