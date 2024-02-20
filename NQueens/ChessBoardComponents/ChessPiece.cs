namespace NQueens.ChessBoardComponents;
internal abstract class ChessPiece
{
    public virtual string Type => GetType().Name;
    public abstract PieceColor Color { get; init; }
    public HashSet<Position> Threat { get; protected set; } = new HashSet<Position>();
    
    public bool TryPlace(ChessBoard chessBoard, Position position)
    {
        var field = chessBoard.FieldsSet.Single(f => f.Position == position);
        if (field.IsOccupied)
        {
            return false;
        }

        var threatenedPositions = chessBoard.FieldsSet
                .Where(f => f.IsOccupied)
                .SelectMany(f => f.Piece!.Threat);

        if (threatenedPositions.Contains(position))
        {
            return false;
        }

        field.Piece = this;
        Threaten(chessBoard, position);
        return true;
    }

    public abstract void Threaten(ChessBoard board, Position position);
}
