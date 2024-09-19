namespace Day08_1
{
    public class Node
    {
        public string Name { get; }
        public string Left { get; }
        public string Right { get; }

        public Node(string name, string left, string right)
        {
            Name = name;
            Left = left;
            Right = right;
        }
    }
}