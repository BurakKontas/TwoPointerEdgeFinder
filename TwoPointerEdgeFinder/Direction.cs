namespace TwoPointerEdgeFinder;
public enum Direction
{
    Right,
    Down,
    Left,
    Up,
    DownRight,
    UpRight,
    DownLeft,
    UpLeft
}

public static class DirectionExtensions
{
    public static (int, int) ToOffset(this Direction direction)
    {
        return direction switch
        {
            Direction.Right => (0, 1),
            Direction.Down => (1, 0),
            Direction.Left => (0, -1),
            Direction.Up => (-1, 0),
            Direction.DownRight => (1, 1),
            Direction.UpRight => (-1, 1),
            Direction.DownLeft => (1, -1),
            Direction.UpLeft => (-1, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}