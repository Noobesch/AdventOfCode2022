using System.Diagnostics;

public enum RockPaperScissorsState
{
    Rock,
    Paper,
    Scissors
}

public class Day02
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        string input;
        char[] markerArray = new char[4];
        long solution = -1;
        
        using (StreamReader streamReader = new StreamReader(SAMPLE_INPUT_PATH))
        {
            input = streamReader.ReadToEnd();
        }

        for (var charIndex = 0; charIndex < input.Length; charIndex++)
        {
            markerArray[charIndex%4] = input[charIndex];
            if (ArrayIsUnique(markerArray))
            {
                solution = charIndex + 1;
                break;
            }
        }

        AnswerPart1(solution);
        AnswerPart2();
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1(long solution)
    {
        Console.WriteLine($"The first answer is {solution}");
    }

    private static void AnswerPart2()
    {

    }

    private static bool ArrayIsUnique(char[] markerArray)
    {
        char[] localArray = new char[4];
        Array.Copy(markerArray, localArray, markerArray.Length);
        Array.Sort(localArray);
        
        for (var index = 0; index < localArray.Length - 1; index++)
        {
            if (localArray[index] == localArray[index + 1] ||
                localArray[index + 1] == default(char) ||
                localArray[index] == default(char))
            {
                return false;
            }
        }

        return true;
    }
}