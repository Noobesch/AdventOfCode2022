using System;


public class Day01
{
    private static string INPUT_PATH = "D:\\Studium\\Semester5\\AdventOfCode\\AdventOfCode2022\\Day01\\AdventOfCode2022_01\\AdventOfCode2022_01\\input.txt";

    public static void Main()
    {
        string input;
        string[] inputLines;
        using (StreamReader streamReader = new StreamReader(INPUT_PATH))
        {
            input = streamReader.ReadToEnd();
        }

        inputLines = input.Split("\r\n");

        SanityCheck(inputLines);
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[inputLines.Length - 1]}");
    }
}