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
        char[] markerArray1 = new char[4];
        char[] markerArray2 = new char[14];
        long solution1 = -1;
        long solution2 = -1;
        
        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            input = streamReader.ReadToEnd();
        }

        for (var charIndex = 0; charIndex < input.Length; charIndex++)
        {
            markerArray1[charIndex % markerArray1.Length] = input[charIndex];
            if (ArrayIsUnique(markerArray1))
            {
                solution1 = charIndex + 1;
                break;
            }
        }

        AnswerPart1(solution1);

        for (var charIndex = 0; charIndex < input.Length; charIndex++)
        {
            markerArray2[charIndex % markerArray2.Length] = input[charIndex];
            if (ArrayIsUnique(markerArray2))
            {
                solution2 = charIndex + 1;
                break;
            }
        }
        AnswerPart2(solution2);
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1(long solution)
    {
        Console.WriteLine($"The first answer is {solution}");
    }

    private static void AnswerPart2(long solution)
    {
        Console.WriteLine($"The second answer is {solution}");
    }

    private static bool ArrayIsUnique(char[] markerArray)
    {
        char[] localArray = new char[markerArray.Length];
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