
using System;
using System.Collections.Generic;
using System.IO;

public class Day11
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();

            }

        }

    }
    private static void AnswerPart1(string solution)
    {
        Console.WriteLine($"Answer part 1: The score is {solution}");
    }

    private static void AnswerPart2(string solution)
    {
        Console.WriteLine($"Answer part 1: The score is {solution}");
    }
}