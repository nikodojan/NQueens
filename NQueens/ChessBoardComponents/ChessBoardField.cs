namespace NQueens.ChessBoardComponents;
internal class ChessBoardField
{
    public ChessBoardField(int row, int col)
    {
        Position = new Position(row, col);
    }

    public ChessPiece? Piece { get; set; } = null;
    public bool IsOccupied => Piece != null;
    public Position Position { get; set; }
}
