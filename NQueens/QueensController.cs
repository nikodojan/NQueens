using NQueens.ChessBoardComponents;
using System.Data;

namespace NQueens;
internal class QueensController
{
    private readonly int _n;
    private readonly List<List<Position>> _positions = new List<List<Position>>();

    public QueensController(int n)
    {
        _n = n;
    }

    /// <summary>
    /// Runs a calculation for each field from the first row.
    /// </summary>
    /// <returns>The maximal number of Queens and their positions.</returns>
    public QueensResult Run()
    {
        var board = new ChessBoard(_n);
        var piece = new Queen(PieceColor.White);

        for (int col = 0; col < _n; col++)
        {
            StartFromPosition(
                board,
                piece,
                new Position(0, col)
            );
            var queensPositions = board.GetOccupiedFields().Select(x => x.Position).ToList();
            _positions.Add(queensPositions);
            board.ResetBoard();
        }
       
        var maxCount = _positions.OrderByDescending(list => list.Count).First().Count;
        var maxPositions = _positions.Where(list => list.Count == maxCount).ToList() ?? new List<List<Position>>();

        return new QueensResult(maxCount, maxPositions);
    }

    private void StartFromPosition(ChessBoard board, ChessPiece piece, Position startPosition)
    {
        var startCol = startPosition.Col;
        bool piecePlaced = false;

        for (int row = startPosition.Row; row < board.Size; row++)
        {
            piecePlaced = false;
            for (int col = startCol; col < board.Size; col++)
            {
                if (piece.TryPlace(board, new Position(row, col)))
                {
                    piecePlaced = true;
                    piece = new Queen(PieceColor.White);
                    startCol = 0;
                    break;
                }
            }
            if (!piecePlaced)
            {
                var previousCol = board.FieldsGrid[row - 1].Single(field => field.IsOccupied).Position.Col;
                startCol = previousCol + 1;
                board.ClearRow(row - 1);
                row -= 2;
            }
        }
    }
}
