using Day08_1;

internal class Program
{
    private static void Main()
    {
        var graph = new Graph("input.txt");
        int steps = graph.TraverseGraph();
        Console.WriteLine(steps);
    }
}