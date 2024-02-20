namespace NQueens.ChessBoardComponents;
internal record Position(int Row, int Col)
{
    public override string ToString()
    {
        return $"[Row:{Row},Col:{Col}]";
    }
}
