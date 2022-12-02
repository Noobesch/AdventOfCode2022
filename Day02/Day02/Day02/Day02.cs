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
        AnswerPart2(rounds);
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

    private static void AnswerPart2((RockPaperScissorsState opponent, RockPaperScissorsState outcome)[] rounds)
    {
        long points = 0;

        //We use rock = lose, paper = draw, scissors = win
        foreach (var round in rounds)
        {
            points += round.outcome switch
            {
                RockPaperScissorsState.Rock => 0,
                RockPaperScissorsState.Paper => 3,
                RockPaperScissorsState.Scissors => 6
            };

            //Case lose.
            if (round.outcome == RockPaperScissorsState.Rock)
            {
                points += round.opponent switch
                {
                    RockPaperScissorsState.Rock => 3,
                    RockPaperScissorsState.Paper => 1,
                    RockPaperScissorsState.Scissors => 2
                };
            }
            //Case draw
            else if (round.outcome == RockPaperScissorsState.Paper)
            {
                points += round.opponent switch
                {
                    RockPaperScissorsState.Rock => 1,
                    RockPaperScissorsState.Paper => 2,
                    RockPaperScissorsState.Scissors => 3
                };
            }
            //Case win
            else
            {
                points += round.opponent switch
                {
                    RockPaperScissorsState.Rock => 2,
                    RockPaperScissorsState.Paper => 3,
                    RockPaperScissorsState.Scissors => 1
                };
            }
        }
        Console.WriteLine($"Answer part 2: The score is {points}");
    }
}