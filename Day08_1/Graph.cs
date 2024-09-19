using System.Text.RegularExpressions;

namespace Day08_1
{
    public class Graph
    {
        private readonly Dictionary<string, Node> _nodes;
        private readonly string _directions;

        public Graph(string filePath)
        {
            _nodes = new Dictionary<string, Node>();
            using var inputStream = File.OpenRead(filePath);
            using var reader = new StreamReader(inputStream);

            _directions = reader.ReadLine()!;
            reader.ReadLine();

            while (reader.ReadLine() is { } line)
            {
                var parts = line.Split('=');
                var nodeName = parts[0].Trim();

                var match = Regex.Match(parts[1], @"\(([^)]+)\)");
                if (match.Success)
                {
                    var destinations = match.Groups[1].Value.Split(',');
                    if (destinations.Length != 2)
                    {
                        throw new FormatException($"Invalid number of destinations in line: {line}");
                    }

                    var leftNodeName = destinations[0].Trim();
                    var rightNodeName = destinations[1].Trim();

                    if (string.IsNullOrEmpty(leftNodeName) || string.IsNullOrEmpty(rightNodeName))
                    {
                        throw new FormatException($"Invalid destination names in line: {line}");
                    }

                    var node = new Node(nodeName, leftNodeName, rightNodeName);
                    _nodes[nodeName] = node;
                }
                else
                {
                    throw new FormatException($"Invalid format for destinations in line: {line}");
                }
            }
        }

        public int TraverseGraph()
        {
            int steps = 0;
            int currentInstructionIndex = 0;
            string currentNodeName = "AAA";

            while (currentNodeName != "ZZZ")
            {
                char instruction = _directions[currentInstructionIndex];
                currentInstructionIndex++;
                currentInstructionIndex %= _directions.Length;
                steps++;

                var currentNode = _nodes[currentNodeName];

                if (instruction == 'L')
                    currentNodeName = currentNode.Left;
                else
                    currentNodeName = currentNode.Right;
            }

            return steps;
        }
    }
}