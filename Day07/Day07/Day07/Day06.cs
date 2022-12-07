using System.Collections.Generic;

public class Node
{
    public string name;
    public string collectiveSize;
    public Node parent;
    public List<(string id, Node node)> children = new List<(string, Node)>();
    public string ID
    {
        get => collectiveSize + name;
    }
}

public class Tree
{
    public Node root = null;

    public void AddAsChild(Node parent, Node child)
    {
        FindInChildren(parent, root).children.Add((child.ID, child));
    }

    public Node FindInChildren(Node nodeToFind, Node startNode)
    {
        if (startNode == null)
        {
            return null;
        }

        Node foundNode = startNode.children.Find(child => child.id == nodeToFind.ID).node;

        if (foundNode != null)
        {
            return foundNode;
        }
        else
        {
            foreach (var tuple in startNode.children)
            {
                foundNode = FindInChildren(nodeToFind, tuple.node);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
        }

        return null;
    }
}

public class Day07
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";
    private static Dictionary<string, List<(string size, string name)>> sizeDict = new Dictionary<string, List<(string, string)>>();
    private const int THRESHOLD = 100000;


    public static void Main()
    {
        //Sample Entry, D, new List() {(123, b.text), (345, c.text), (dir, d)
        List<(string size, string name)> activeList = new List<(string size, string name)>();

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            string line;
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine().Replace("\r\n", "");


                if (line.Contains("$ cd "))
                {
                    var directory = line.Replace("$ cd ", "");

                    if (directory == "..")
                    {
                        continue;
                    }

                    if (sizeDict.ContainsKey(directory))
                    {
                        activeList = sizeDict[directory];
                        continue;
                    }

                    sizeDict.Add(directory, new List<(string size, string name)>());
                    activeList = sizeDict[directory];
                }
                else if (!line.Contains("$ ls"))
                {
                    var stringArray = line.Split(' ');
                    activeList.Add((stringArray[0], stringArray[1]));
                }
            }
        }

        while (!DictionaryIsFinished())
        {
            Dictionary<string, List<(string size, string name)>> tempDict = new Dictionary<string, List<(string, string)>>();
            foreach (var entry in sizeDict)
            {
                List<(string size, string name)> tempEntry = new List<(string, string)>();
                tempEntry.AddRange(entry.Value);


                foreach (var tuple in entry.Value)
                {
                    if (tuple.size == "dir")
                    {
                        tempEntry.Remove(tuple);
                        tempEntry.Add((SumEntryAt(tuple.name), tuple.name));
                    }
                }

                tempDict.Add(entry.Key, tempEntry);
            }

            sizeDict = tempDict;
        }

        AnswerPart1();
        AnswerPart2();
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1()
    {
        long sum = 0;

        foreach (var entry in sizeDict)
        {
            long entrySum = int.Parse(SumEntryAt(entry.Key));

            if (entrySum <= THRESHOLD)
            {
                sum += entrySum;
            }

        }
        Console.WriteLine($"The first answer is {sum}");
    }

    private static void AnswerPart2()
    {
        Console.WriteLine($"The second answer is ");
    }

    private static bool DictionaryIsFinished()
    {
        foreach (var tupleList in sizeDict.Values)
        {
            bool containsDir = tupleList.Any(tuple => tuple.size == "dir");
            if (containsDir)
            {
                return false;
            }
        }

        return true;
    }

    private static string SumEntryAt(string key)
    {
        var entries = sizeDict[key];

        long sum = 0;

        foreach (var entry in entries)
        {
            if (entry.size != "dir")
            {
                sum += int.Parse(entry.size);
            }
            else
            {
                return entry.size;
            }
        }

        return sum.ToString();
    }
}