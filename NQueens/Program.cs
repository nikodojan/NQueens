using NQueens.ChessBoardComponents;

namespace NQueens;

internal class Program
{
    static void Main()
    {
        int n = 8;
        var controller = new QueensController(n);
        var result = controller.Run();

        PrintResults(n, result.MaxQueens, result.Positions);

        Console.WriteLine("Press any key to close the console.");
        Console.ReadKey();
    }

    private static void PrintResults(int n, int max, List<List<Position>> combinationsList)
    {
        Console.Clear();
        Console.WriteLine($"The maximum number of Queens that fit on a {n} x {n} chessboard is {max}.");
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine($"Possible distinct positions of {max} Queens:");
        foreach (var combination in combinationsList.Where(l=>l.Count == max))
        {
            Console.WriteLine($"\t{string.Join(',', combination)}");
        }
    }
}
