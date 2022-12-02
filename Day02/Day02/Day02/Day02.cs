using System.Diagnostics;

public enum RockPaperScissorsState
{
    Rock,
    Paper,
    Scissors
}

public class Day02
{

    private static string REAL_INPUT_PATH = "..\\..\\..\\realInput.txt";
    private static string SAMPLE_INPUT_PATH = "..\\..\\..\\testInput.txt";

    public static void Main()
    {
        string input;
        
        using (StreamReader streamReader = new StreamReader(REAL_INPUT_PATH))
        {
            input = streamReader.ReadToEnd();
        }


        string[] inputLines = input.Split("\r\n");
        SanityCheck(inputLines);
        
        (RockPaperScissorsState opponent, RockPaperScissorsState player)[] rounds = new (RockPaperScissorsState opponent, RockPaperScissorsState player)[inputLines.Length];
        
        for (long lineIndex = 0; lineIndex < inputLines.Length; lineIndex++)
        {
            string[] lineContent = inputLines[lineIndex].Split(" ");

            RockPaperScissorsState opponent = lineContent[0] switch
            {
                "A" => RockPaperScissorsState.Rock,
                "B" => RockPaperScissorsState.Paper,
                "C" => RockPaperScissorsState.Scissors,
                _ => throw new ArgumentException()
            };

            RockPaperScissorsState player = lineContent[1] switch
            {
                "X" => RockPaperScissorsState.Rock,
                "Y" => RockPaperScissorsState.Paper,
                "Z" => RockPaperScissorsState.Scissors,
                _ => throw new ArgumentException()
            };

            rounds[lineIndex] = (opponent, player);
        }



        AnswerPart1(rounds);
        AnswerPart2();
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1((RockPaperScissorsState opponent, RockPaperScissorsState player)[] rounds)
    {
        long points = 0;
        foreach (var round in rounds)
        {
            if (round.opponent == RockPaperScissorsState.Rock && round.player == RockPaperScissorsState.Paper ||
                round.opponent == RockPaperScissorsState.Paper && round.player == RockPaperScissorsState.Scissors ||
                round.opponent == RockPaperScissorsState.Scissors && round.player == RockPaperScissorsState.Rock)
            {
                points += 6;
            }
            else if (round.opponent == round.player)
            {
                points += 3;
            }

            points += round.player switch
            {
                RockPaperScissorsState.Rock => 1,
                RockPaperScissorsState.Paper => 2,
                RockPaperScissorsState.Scissors => 3
            };
        }

        Console.WriteLine($"Answer part 1: The score is {points}");
    }

    private static void AnswerPart2()
    {
        Console.WriteLine($"Answer part 2: ");
    }
}