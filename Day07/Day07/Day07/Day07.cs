using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

public class Node
{
    public string Name;
    public List<Node> Children;
    public Node Parent;
    public long Size;
    public bool IsDir;

    public Node(string name)
    {
        Name = name;
        Children = new List<Node>();
    }


    public void AddChild(Node child)
    {
        Children.Add(child);
        child.Parent = this;
    }

    public Node FindChild(string name)
    {
        return Children.Find(node => node.Name == name);
    }


    public override string ToString()
    {
        return Name + " " + GetSize();
    }

    public long GetSize()
    {
        long size = Size;

        foreach (var child in Children)
        {
            size += child.GetSize();
        }

        return size;
    }
}

public class Tree
{
    public Node Root;
    public Node CurrentNode;
    public List<Node> ContainedNodes = new List<Node>();

    public Tree()
    {
        Root = new Node("/");
        CurrentNode = Root;
    }

    public void AddNode(Node node)
    {

        if (Root == null)
        {
            Root = node;
        }
        else
        {
            CurrentNode.AddChild(node);
        }

        ContainedNodes.Add(node);
    }

    public void ChangeActiveNode(string name)
    {
        if (name == "..")
        {
            CurrentNode = CurrentNode.Parent;
        }
        else if (CurrentNode.Name != name)
        {
            CurrentNode = CurrentNode.FindChild(name);
        }

    }
}

public class Day07
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";
    private const int THRESHOLD = 100000;


    public static void Main()
    {
        Tree tree = new Tree();

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            string line;
            while (!streamReader.EndOfStream)
            {

                //Read input line.
                line = streamReader.ReadLine().Replace("\r\n", "");
                 

                //Check for directory change
                if (line.Contains("$ cd "))
                {
                    string name = line.Replace("$ cd ", "");
                    tree.ChangeActiveNode(name);
                }
                //Check for print
                else if (!line.Contains("$ ls"))
                {
                    string[] information = line.Split(" ");
                    string name = information[1];
                    bool isLeaf = long.TryParse(information[0], out long size);

                    Node newNode = new Node(name);

                    if (isLeaf)
                    {
                        newNode.Size = size;
                    }
                    else
                    {
                        newNode.IsDir = true;
                    }
                    tree.AddNode(newNode);
                }
            }
        }


        AnswerPart1(tree);
        AnswerPart2();
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1(Tree tree)
    {
        long sum = 0;


        foreach (var node in tree.ContainedNodes)
        {
            if (!node.IsDir)
            {
                continue;
            }

            long size = node.GetSize();
            if (size < THRESHOLD)
            {
                sum += size;
            }
        }
        Console.WriteLine($"The first answer is {sum}");
    }

    private static void AnswerPart2()
    {
        Console.WriteLine($"The second answer is ");
    }
}