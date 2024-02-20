using System.Data;

namespace NQueens.ChessBoardComponents;
internal class ChessBoard
{
    private readonly int _size;
    
    public ChessBoard(int boardSize)
    {
        _size = boardSize;
        InitializeBoard();
    }

    public List<List<ChessBoardField>> FieldsGrid { get; } = new List<List<ChessBoardField>>();

    public HashSet<ChessBoardField> FieldsSet { get; private set; } = new HashSet<ChessBoardField>();

    public int Size => _size;

    private void InitializeBoard()
    {
        for (int row = 0; row < Size; row++)
        {
            FieldsGrid.Add(new List<ChessBoardField>(capacity: Size));

            for (int col = 0; col < Size; col++)
            {
                var field = new ChessBoardField(row, col);
                FieldsGrid[row].Add(field);
                FieldsSet.Add(field);
            }
        }
    }

    public void ResetBoard()
    {
        FieldsGrid.ForEach(row => 
            row.ForEach(field => field.Piece = null));
    }

    public HashSet<Position> GetAvailableFields()
    {
        var occupiedPositions = FieldsSet
            .Where(field => field.IsOccupied).Select(field => field.Position).ToHashSet();

        var threatenedPositions = FieldsSet
            .Where(field => field.IsOccupied)
            .SelectMany(f => f.Piece!.Threat)
            .ToHashSet();
        
        occupiedPositions.UnionWith(threatenedPositions);
        var allPositions = FieldsSet.Where(field=>field.IsOccupied).Select(field=>field.Position).ToHashSet();
        allPositions.RemoveWhere(e=>occupiedPositions.Contains(e));

        return allPositions;
    }

    public IEnumerable<ChessBoardField> GetOccupiedFields()
    {
        return FieldsSet.Where(field => field.IsOccupied);
    }

    public void ClearRow(int row)
    {
        FieldsGrid[row].Single(f=>f.IsOccupied).Piece = null;
    }
}
