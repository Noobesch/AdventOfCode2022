public class Day01
{
    private static string INPUT_PATH = "D:\\Studium\\Semester5\\AdventOfCode\\AdventOfCode2022\\Day01\\AdventOfCode2022_01\\AdventOfCode2022_01\\input1.txt";
    private static List<int> _calorieList = new();

    public static void Main()
    {
        string input;
        
        using (StreamReader streamReader = new StreamReader(INPUT_PATH))
        {
            input = streamReader.ReadToEnd();
        }

        string[] inputLines = input.Split("\r\n");
        SanityCheck(inputLines);

        int currentElfCalories = 0;

        foreach(var line in inputLines)
        {
            if(line == "")
            {
                _calorieList.Add(currentElfCalories);
                currentElfCalories = 0;
            }
            else
            {
                currentElfCalories += int.Parse(line);
            }
        }

        _calorieList.Sort();

        AnswerPart1();
        AnswerPart2();
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1()
    {
        Console.WriteLine($"Answer part 1: The lowest value ist {_calorieList[0]}, highest is {_calorieList[^1]}");
    }

    private static void AnswerPart2()
    {
        long summedVal = _calorieList[^1] + _calorieList[^2] + _calorieList[^3];
        Console.WriteLine($"Answer part 2: The highest summed value is {summedVal}");
    }
}