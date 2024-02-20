namespace NQueens.ChessBoardComponents;
internal class Queen : ChessPiece
{
    public Queen(PieceColor color)
    {
        Color = color;
    }

    public override PieceColor Color { get; init; }

    public override void Threaten(ChessBoard board, Position position)
    {
        Threat.Clear();
        ThreatenWholeColumn(board, position);
        ThreatenWholeRow(board, position);
        ThreatenDiagonallyDownRight(board, position);
        ThreatenDiagonallyDownLeft(board, position);
        ThreatenDiagonallyUpLeft(board, position);
        ThreatenDiagonallyUpRight(board, position);
    }

    private void ThreatenWholeColumn(ChessBoard board, Position threatSource)
    {
        foreach (var field in board.FieldsGrid[threatSource.Row])
        {
            if (!field.IsOccupied)
            {
                Threat.Add(field.Position);
            }
        }
    }

    private void ThreatenWholeRow(ChessBoard board, Position threatSource)
    {
        foreach (var row in board.FieldsGrid)
        {
            if (!row[threatSource.Col].IsOccupied)
            {
                Threat.Add(row[threatSource.Col].Position);
            }
        }
    }

    private void ThreatenDiagonallyDownRight(ChessBoard board, Position threatSource)
    {
        var currentRow = threatSource.Row;
        var currentCol = threatSource.Col;
        while (currentRow < board.Size && currentCol < board.Size)
        {
            Threat.Add(board.FieldsGrid[currentRow][currentCol].Position);
            currentRow++;
            currentCol++;
        }
    }

    private void ThreatenDiagonallyDownLeft(ChessBoard board, Position threatSource)
    {
        var currentRow = threatSource.Row;
        var currentCol = threatSource.Col;
        while (currentRow < board.Size && currentCol >= 0)
        {
            Threat.Add(board.FieldsGrid[currentRow][currentCol].Position);
            currentRow++;
            currentCol--;
        }
    }

    private void ThreatenDiagonallyUpLeft(ChessBoard board, Position threatSource)
    {
        var currentRow = threatSource.Row;
        var currentCol = threatSource.Col;
        while (currentRow >= 0 && currentCol >= 0)
        {
            Threat.Add(board.FieldsGrid[currentRow][currentCol].Position);
            currentRow--;
            currentCol--;
        }
    }

    private void ThreatenDiagonallyUpRight(ChessBoard board, Position threatSource)
    {
        var currentRow = threatSource.Row;
        var currentCol = threatSource.Col;
        while (currentRow >= 0 && currentCol < board.Size)
        {
            Threat.Add(board.FieldsGrid[currentRow][currentCol].Position);
            currentRow--;
            currentCol++;
        }
    }
}
