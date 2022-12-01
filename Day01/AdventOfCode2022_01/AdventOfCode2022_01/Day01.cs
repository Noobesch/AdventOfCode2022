using System;
using System.Linq;


public class Day01
{
    private static string INPUT_PATH1 = "D:\\Studium\\Semester5\\AdventOfCode\\AdventOfCode2022\\Day01\\AdventOfCode2022_01\\AdventOfCode2022_01\\input1.txt";
    private static string INPUT_PATH2 = "D:\\Studium\\Semester5\\AdventOfCode\\AdventOfCode2022\\Day01\\AdventOfCode2022_01\\AdventOfCode2022_01\\input2.txt";

    public static void Main()
    {
        string input;
        string[] inputLines;
        List<int> calorieList = new List<int>();
        using (StreamReader streamReader = new StreamReader(INPUT_PATH1))
        {
            input = streamReader.ReadToEnd();
        }

        inputLines = input.Split("\r\n");

        int currentElfCalories = 0;

        foreach(var line in inputLines)
        {
            if(line == "")
            {
                calorieList.Add(currentElfCalories);
                currentElfCalories = 0;
            }
            else
            {
                currentElfCalories += int.Parse(line);
            }
        }

        calorieList.Sort();

        AnswerPart1(calorieList);
        

        SanityCheck(inputLines);
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[inputLines.Length - 1]}");
    }

    private static void AnswerPart1(List<int> calorieList)
    {
        Console.WriteLine($"The lowest value ist {calorieList[0]}, highest is {calorieList[calorieList.Count - 1]}");
    }

}