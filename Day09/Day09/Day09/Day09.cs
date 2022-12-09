
using System;
using System.Collections.Generic;
using System.IO;

public class Day09
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        Dictionary<string, (int horizontal, int vertical)> mappingDict = new Dictionary<string, (int horizontal, int vertical)>();
        mappingDict.Add("R", (1, 0));
        mappingDict.Add("L", (-1, 0));
        mappingDict.Add("U", (0, -1));
        mappingDict.Add("D", (0, 1));

        int size = 801;
        int center = 400;

        bool[,] visitedArray = new bool[size, size];
        (int horizontal, int vertical) currentHeadPosition = (center, center);
        (int horizontal, int vertical) currentTailPosition = (center, center);

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            while (!streamReader.EndOfStream)
            {
                string[] line = streamReader.ReadLine().Replace("\r\n","").Split(' ');
                var moveInstruction = mappingDict[line[0]];

                for(var moveIndex = 0; moveIndex < int.Parse(line[1]); moveIndex++)
                {
                    currentHeadPosition = (currentHeadPosition.horizontal + moveInstruction.horizontal, 
                        currentHeadPosition.vertical + moveInstruction.vertical);

                    int horizontalDif = currentHeadPosition.horizontal - currentTailPosition.horizontal;
                    int verticalDif = currentHeadPosition.vertical - currentTailPosition.vertical;
                 
                    if(Math.Abs(horizontalDif) > 2 || Math.Abs(verticalDif) > 2)
                    {
                        throw new ArgumentException();
                    }

                    if(Math.Abs(horizontalDif) == 2 && Math.Abs(verticalDif) == 1) 
                    {
                        currentTailPosition = (currentTailPosition.horizontal + horizontalDif / 2, currentTailPosition.vertical + verticalDif);
                    }
                    else if(Math.Abs(verticalDif) == 2 && Math.Abs(horizontalDif) == 1)
                    {
                        currentTailPosition = (currentTailPosition.horizontal + horizontalDif, currentTailPosition.vertical + verticalDif / 2);
                    }
                    else if(Math.Abs(horizontalDif) == 2)
                    {
                        currentTailPosition = (currentTailPosition.horizontal + horizontalDif / 2, currentTailPosition.vertical);
                    }
                    else if(Math.Abs(verticalDif) == 2)
                    {
                        currentTailPosition = (currentTailPosition.horizontal, currentTailPosition.vertical + verticalDif / 2);
                    }

                    visitedArray[currentTailPosition.horizontal, currentTailPosition.vertical] = true;

                    //for(var rowIndex = 0; rowIndex < visitedArray.GetLength(0); rowIndex++)
                    //{
                    //    string outLine = "";
                    //    for (var columnIndex = 0; columnIndex < visitedArray.GetLength(1); columnIndex++)
                    //    {
                    //        if(currentHeadPosition == (columnIndex, rowIndex))
                    //        {
                    //            outLine += "H"; 
                    //        }
                    //        else if (currentTailPosition == (columnIndex, rowIndex))
                    //        {
                    //            outLine += "T";
                    //        }
                    //        else
                    //        {
                    //            outLine += ".";
                    //        }
                    //    }
                    //    Console.WriteLine(outLine);
                    //}

                    //Console.WriteLine("\n\n");
                }
            }
        }

        long score = 0;
        for (var rowIndex = 0; rowIndex < visitedArray.GetLength(0); rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < visitedArray.GetLength(1); columnIndex++)
            {
                if(visitedArray[rowIndex,columnIndex])
                {
                    score++;
                }
            }
        }
        AnswerPart1(score);
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