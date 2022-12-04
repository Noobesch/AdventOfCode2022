
using System;
using System.Collections.Generic;
using System.IO;

public class Day03
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        long score1 = 0;
        long score2 = 0;

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] strings = line.Replace("\r\n", "").Split(new char[] { ',', '-' });
                int[] ints = Array.ConvertAll(strings, s => int.Parse(s));

                string leftString = "";
                string rightString = "";
                
                for (var leftIndex = ints[0]; leftIndex <= ints[1]; leftIndex++)
                {
                    leftString += ","+leftIndex + ",#";
                }

                for (var rightIndex = ints[2]; rightIndex <= ints[3]; rightIndex++)
                {
                    rightString += ","+rightIndex + ",#";
                }


                if(rightString.Contains(leftString) ||
                    leftString.Contains(rightString))
                {
                    score1++;
                }

                foreach (var character in leftString.Split("#"))
                {
                    if(rightString.Contains(character) && !string.IsNullOrEmpty(character))
                    {
                        score2++;
                        break;
                    }
                }
            }
        }

        

        AnswerPart1(score1);
        AnswerPart2(score2);
    }
    private static void AnswerPart1(long score)
    {
        Console.WriteLine($"Answer part 1: The score is {score}");
    }

    private static void AnswerPart2(long score)
    {
        Console.WriteLine($"Answer part 2: The score is {score}");
    }
}