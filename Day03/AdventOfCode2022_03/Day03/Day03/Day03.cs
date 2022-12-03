
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
        AnswerPart2(inputLines);
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1(List<(string left, string right)> inputLines)
    {
        long score = 0;

        foreach (var line in inputLines)
        {
            foreach (var character in line.left)
            {
                if (line.right.Contains(character))
                {
                    score += CalculateSocre(character);
                    break;
                }
            }
        }
        Console.WriteLine($"Answer part 1: The score is {score}");
    }

    private static void AnswerPart2(List<(string left, string right)> inputLines)
    {
        long score = 0;

        for(var tripleIndex = 0; tripleIndex < inputLines.Count; tripleIndex+=3)
        {
            string line1 = inputLines[tripleIndex].left + inputLines[tripleIndex].right;
            string line2 = inputLines[tripleIndex + 1].left + inputLines[tripleIndex+ 1].right;
            string line3 = inputLines[tripleIndex + 2].left + inputLines[tripleIndex + 2].right;

            foreach(var character in line1)
            {
                if(line2.Contains(character) && line3.Contains(character))
                {
                    score += CalculateSocre(character);
                    break;
                }
            }
        }

        Console.WriteLine($"Answer part 2: The score is {score}");
    }

    private static long CalculateSocre(char c)
    {
        return c switch
        {
            var lower when lower > 90 => lower - 96,
            var upper when upper <= 90 => upper - 38,
            _ => throw new ArgumentException()
        };
    }
}