public class Day02
{
    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        string input;
        
        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            input = streamReader.ReadToEnd();
        }

        string[] inputLines = input.Split("\r\n");
        SanityCheck(inputLines);


        AnswerPart1();
        AnswerPart2();
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1()
    {
        Console.WriteLine($"Answer part 1: ");
    }

    private static void AnswerPart2()
    {
        Console.WriteLine($"Answer part 2: ");
    }
}