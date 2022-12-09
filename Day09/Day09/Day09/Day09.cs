
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

        (int width, int height) size = (801, 801);
        (int horizontal, int vertical) startPoint = (400,400);

        bool[,] visitedArray = new bool[size.width, size.height];

        (int horizontal, int vertical)[] knotArray = new(int horizontal, int vertical)[]
        {
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical),
            (startPoint.horizontal,startPoint.vertical)
        };

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            while (!streamReader.EndOfStream)
            {
                string[] line = streamReader.ReadLine().Replace("\r\n", "").Split(' ');
                var moveInstruction = mappingDict[line[0]];

                for (var moveIndex = 0; moveIndex < int.Parse(line[1]); moveIndex++)
                {
                    knotArray[0] = (knotArray[0].horizontal + moveInstruction.horizontal,
                        knotArray[0].vertical + moveInstruction.vertical);


                    for (var knotIndex = 1; knotIndex < knotArray.Length; knotIndex++)
                    {
                        if (knotIndex == 5)
                        {

                        }

                        int horizontalDif = knotArray[knotIndex - 1].horizontal - knotArray[knotIndex].horizontal;
                        int verticalDif = knotArray[knotIndex - 1].vertical - knotArray[knotIndex].vertical;

                        if (Math.Abs(horizontalDif) > 2 || Math.Abs(verticalDif) > 2)
                        {
                            throw new ArgumentException();
                        }

                        if (Math.Abs(horizontalDif) == 2 && Math.Abs(verticalDif) == 2)
                        {
                            knotArray[knotIndex] = (knotArray[knotIndex].horizontal + horizontalDif / 2, knotArray[knotIndex].vertical + verticalDif / 2);
                        }
                        else if (Math.Abs(horizontalDif) == 2 && Math.Abs(verticalDif) == 1)
                        {
                            knotArray[knotIndex] = (knotArray[knotIndex].horizontal + horizontalDif / 2, knotArray[knotIndex].vertical + verticalDif);
                        }
                        else if (Math.Abs(verticalDif) == 2 && Math.Abs(horizontalDif) == 1)
                        {
                            knotArray[knotIndex] = (knotArray[knotIndex].horizontal + horizontalDif, knotArray[knotIndex].vertical + verticalDif / 2);
                        }
                        else if (Math.Abs(horizontalDif) == 2)
                        {
                            knotArray[knotIndex] = (knotArray[knotIndex].horizontal + horizontalDif / 2, knotArray[knotIndex].vertical);
                        }
                        else if (Math.Abs(verticalDif) == 2)
                        {
                            knotArray[knotIndex] = (knotArray[knotIndex].horizontal, knotArray[knotIndex].vertical + verticalDif / 2);
                        }
                    }

                    (int horizontal, int vertical) currentTailPosition = knotArray[9];
                    visitedArray[currentTailPosition.horizontal, currentTailPosition.vertical] = true;
                }
                //for (var rowIndex = 0; rowIndex < visitedArray.GetLength(0); rowIndex++)
                //{
                //    string outLine = "";
                //    for (var columnIndex = 0; columnIndex < visitedArray.GetLength(1); columnIndex++)
                //    {
                //        string charToAdd = ".";
                //        for (var knotIndex = 0; knotIndex < knotArray.Length; knotIndex++)
                //        {
                //            if (knotArray[knotIndex] == (columnIndex, rowIndex))
                //            {
                //                charToAdd = knotIndex.ToString();
                //                break;
                //            }
                //        }
                //        outLine += charToAdd;
                //    }
                //    Console.WriteLine(outLine);
                //}

                //Console.WriteLine("\n\n");
            }
        }

        long score = 0;
        for (var rowIndex = 0; rowIndex < visitedArray.GetLength(0); rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < visitedArray.GetLength(1); columnIndex++)
            {
                if (visitedArray[rowIndex, columnIndex])
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