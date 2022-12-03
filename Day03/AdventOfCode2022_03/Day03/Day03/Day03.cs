
using System;
using System.Collections.Generic;
using System.IO;

public class Day03
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        List<(string left, string right)> inputLines = new List<(string left, string right)>();

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                int length = line.Length;

                inputLines.Add((line.Substring(0, length / 2), line.Substring(length / 2, length / 2)));
            }
        }

        AnswerPart1(inputLines);
        //AnswerPart2();
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1(List<(string left, string right)> inputLines)
    {
        var test2 = (int)'A'; //65
        var test4 = (int)'Z'; //90
        var test1 = (int)'a'; //97
        var test3 = (int)'z'; //122

        //Uppercase => -38
        //Lowercase => -96

        long score = 0;

        foreach (var line in inputLines)
        {
            foreach (var character in line.left)
            {
                if (line.right.Contains(character))
                {
                    score += character switch
                    {
                        var lower when lower > 90 => lower - 96,
                        var upper when upper <= 90 => upper - 38,
                        _ => throw new ArgumentException()
                    };
                    break;
                }
            }
        }
        Console.WriteLine($"Answer part 1: The score is {score}");
    }

    private static void AnswerPart2()
    {
        Console.WriteLine($"Answer part 2: The score is");
    }
}