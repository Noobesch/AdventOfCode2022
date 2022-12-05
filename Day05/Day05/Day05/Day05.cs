
using System;
using System.Collections.Generic;
using System.IO;

public class Day03
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        bool endOfStacksReached = false;

        List<string> givenStartingStacks = new List<string>();
        List< (int amount, int from, int to)> givenInstructions = new List<(int amount, int from, int to)>();
        int numberOfStacks = 0;

        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            while (!streamReader.EndOfStream && !endOfStacksReached)
            {
                string line = streamReader.ReadLine();

                if (!line.Contains("["))
                {
                    endOfStacksReached = true;
                    numberOfStacks = int.Parse(line.Split(' ')[^2]);
                    streamReader.ReadLine();

                    break;
                }
                givenStartingStacks.Add(line);
            }


            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string[] valueStrings = line.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ",").Split(",");
                int[] values = Array.ConvertAll(valueStrings, s => int.Parse(s));

                givenInstructions.Add((values[0], values[1], values[2]));
            }
        }

        givenStartingStacks.Reverse();
        Stack<string>[] stacks = new Stack<string>[numberOfStacks];

        foreach (var layer in givenStartingStacks)
        {
            string[] stackLayer = layer.Replace("    ", " [-]").Split(new char[]{' ', '[', ']'});

            for (var stackIndex = 1; stackIndex < stackLayer.Length; stackIndex += 3)
            {
                if (stacks[stackIndex / 3] == null)
                {
                    stacks[stackIndex / 3] = new Stack<string>();
                }

                var value = stackLayer[stackIndex];

                if (value != "-" && value != "")
                {
                    stacks[stackIndex / 3].Push(stackLayer[stackIndex]);
                }

            }
        }

        foreach (var givenInstruction in givenInstructions)
        {
            List<string> moveList = new List<string>();
            for (var amountIndex = 0; amountIndex < givenInstruction.amount; amountIndex++)
            {
                moveList.Add(stacks[givenInstruction.from - 1].Pop());
            }

            moveList.Reverse();
            foreach (var item in moveList)
            {
                stacks[givenInstruction.to - 1].Push(item);
            }
        }
        
        string solution = "";
        foreach (var stack in stacks)
        {
            solution += stack.Peek();
        }


        AnswerPart(solution);
    }
    private static void AnswerPart(string solution)
    {
        Console.WriteLine($"Answer part 1: The score is {solution}");
    }
}