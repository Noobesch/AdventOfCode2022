
using System;
using System.Collections.Generic;
using System.IO;

public class Day10
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        int tickCounter = 0;
        long signalCounter = 1;

        //using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        //{
        //while (!streamReader.EndOfStream)
        //{
        //    string line = streamReader.ReadLine().Replace("\r\n", "");

        //    tickCounter++;

        //    if (tickCounter % 40 == 20)
        //    {
        //        Console.WriteLine($"At {tickCounter} the signal strength is {tickCounter * signalCounter}");
        //        sum += (tickCounter * signalCounter);
        //    }

        //    if (line.Contains("addx"))
        //    {
        //        tickCounter++;
        //        if (tickCounter % 40 == 20)
        //        {
        //            Console.WriteLine($"At {tickCounter} the signal strength is {tickCounter * signalCounter}");
        //            sum += (tickCounter * signalCounter);
        //        }
        //        signalCounter += int.Parse(line.Replace("addx ", ""));
        //    }
        //}
        //}
        //AnswerPart1(sum);


        tickCounter = 0;
        signalCounter = 1;

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            string answerString = "";
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine().Replace("\r\n", "");
                

                if(Math.Abs(tickCounter % 40 - signalCounter % 40) <= 1)
                {
                    answerString += "#";
                }
                else
                {
                    answerString += ".";
                }

                tickCounter++;

                if (tickCounter%40 == 0)
                {
                    Console.WriteLine(answerString);
                    answerString = "";
                }

                if (line.Contains("addx"))
                {
                    if (Math.Abs(tickCounter % 40 - signalCounter % 40) <= 1)
                    {
                        answerString += "#";
                    }
                    else
                    {
                        answerString += ".";
                    }

                    tickCounter++;

                    if (tickCounter % 40 == 0)
                    {
                        Console.WriteLine(answerString);
                        answerString = "";
                    }

                    signalCounter += int.Parse(line.Replace("addx ", ""));
                }
            }
        }

    }
    private static void AnswerPart1(long solution)
    {
        Console.WriteLine($"Answer part 1: The score is {solution}");
    }

    private static void AnswerPart2(string solution)
    {
        Console.WriteLine($"Answer part 1: The score is {solution}");
    }
}