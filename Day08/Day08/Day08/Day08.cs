public class Day08
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

        string[] lines = input.Split("\r\n");

        long[,] values = new long[lines[0].Length, lines.Length];
        bool[,] seeArray = new bool[lines[0].Length, lines.Length];

        for (long lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            string line = lines[lineIndex];

            for (var charIndex = 0; charIndex < line.Length; charIndex++)
            {
                values[lineIndex, charIndex] = long.Parse(line[charIndex].ToString());
            }
        }

        #region Part1




        for (var turnIndex = 0; turnIndex < 4; turnIndex++)
        {
            long columnStart = 0, columnEnd = 0, rowStart = 0, rowEnd = 0;

            switch (turnIndex)
            {
                case 0:
                    columnStart = 0;
                    columnEnd = values.GetLength(0);
                    rowStart = 0;
                    rowEnd = values.GetLength(1); break;
                case 1:
                    columnStart = 0;
                    columnEnd = values.GetLength(0);
                    rowStart = values.GetLength(1) - 1;
                    rowEnd = -1; break;
                case 2:
                    columnStart = 0;
                    columnEnd = values.GetLength(0);
                    rowStart = 0;
                    rowEnd = values.GetLength(1); break;

                case 3:
                    columnStart = values.GetLength(0) - 1;
                    columnEnd = -1;
                    rowStart = values.GetLength(1) - 1;
                    rowEnd = -1; break;
            }


            if (turnIndex < 2)
            {
                for (var columnIndex = columnStart; columnIndex != columnEnd; columnIndex += (columnStart < columnEnd ? 1 : -1))
                {
                    long highestValueInLine = -1;

                    for (var rowIndex = rowStart; rowIndex != rowEnd; rowIndex += (rowStart < rowEnd ? 1 : -1))
                    {
                        if (values[columnIndex, rowIndex] > highestValueInLine)
                        {
                            seeArray[columnIndex, rowIndex] = true;
                            highestValueInLine = values[columnIndex, rowIndex];
                        }
                    }
                }
            }
            else
            {
                for (var rowIndex = rowStart; rowIndex != rowEnd; rowIndex += (rowStart < rowEnd ? 1 : -1))
                {
                    long highestValueInLine = -1;

                    for (var columnIndex = columnStart; columnIndex != columnEnd; columnIndex += (columnStart < columnEnd ? 1 : -1))
                    {
                        if (values[columnIndex, rowIndex] > highestValueInLine)
                        {
                            seeArray[columnIndex, rowIndex] = true;
                            highestValueInLine = values[columnIndex, rowIndex];
                        }
                    }
                }
            }
        }


        long score1 = 0;
        for (var columnIndex = 0; columnIndex < values.GetLength(0); columnIndex++)
        {
            for (var rowIndex = 0; rowIndex < values.GetLength(1); rowIndex++)
            {
                if (seeArray[columnIndex, rowIndex])
                {
                    score1++;
                }
            }
        }

        AnswerPart1(score1);
        #endregion

        long score2 = 0;
        for (var currentColumnIndex = 0; currentColumnIndex < values.GetLength(0); currentColumnIndex++)
        {
            for (var currentRowIndex = 0; currentRowIndex < values.GetLength(1); currentRowIndex++)
            {
                long positionValue = values[currentColumnIndex, currentRowIndex];
                long right = 0, left = 0, down = 0, up = 0;

                if (currentColumnIndex == 1 && currentRowIndex == 2)
                {

                }

                for (var rowIndex = currentRowIndex + 1; rowIndex < values.GetLength(1); rowIndex++)
                {
                    right++;
                    if (values[currentColumnIndex, rowIndex] >= positionValue)
                    {
                        break;
                    }
                }


                for (var rowIndex = currentRowIndex - 1; rowIndex >= 0; rowIndex--)
                {
                    left++;
                    if (values[currentColumnIndex, rowIndex] >= positionValue)
                    {
                        break;
                    }
                }


                for (var columnIndex = currentColumnIndex + 1; columnIndex < values.GetLength(0); columnIndex++)
                {
                    down++;
                    if (values[columnIndex, currentRowIndex] >= positionValue)
                    {
                        break;
                    }
                }

                for (var columnIndex = currentColumnIndex - 1; columnIndex >= 0; columnIndex--)
                {
                    up++;
                    if (values[columnIndex, currentRowIndex] >= positionValue)
                    {
                        break;
                    }
                }

                var positionScore = left * right * up * down;

                if (positionScore > score2)
                {
                    score2 = positionScore;
                }
            }
        }

        AnswerPart2(score2);
    }

    private static void SanityCheck(string[] inputLines)
    {
        Console.WriteLine($"{inputLines.Length} lines read, first entry is {inputLines[0]}, last entry is {inputLines[^2]}");
    }

    private static void AnswerPart1(long score)
    {
        Console.WriteLine($"The first score is {score}");
    }

    private static void AnswerPart2(long score)
    {
        Console.WriteLine($"The second score is {score}");
    }
}