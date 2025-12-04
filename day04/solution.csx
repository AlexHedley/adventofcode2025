#load "../utils/utils.csx"

public class Day4
{
    bool logToConsole = true;
    bool logToFile = true;

    // Utils.Log($"{}", logToConsole, logToFile);

    // rolls of paper (@)
    // fewer than four rolls of paper in the eight adjacent positions.
    long rolls = 0L;
    List<Tuple<int, int>> rollCoordinates = new();

    public void Part1(string[] lines)
    {
        var rows = lines.Length;
        var cols = lines[0].Length;

        var matrix = Utils.GenerateMatrix<string>(lines, rows, cols);
        Utils.PrintMatrix(matrix, logToConsole, logToFile);

        FindRolls(matrix);
        // Update Matrix with rollCoordinates.
        // Utils.PrintMatrix(matrix, logToConsole, logToFile);

        Utils.Answer($"{rolls}", logToConsole, logToFile);
    }

    // public void Part2(string[] lines)
    // {
    // }

    public void FindRolls(string[,] matrix)
    {
        int rowLength = matrix.GetLength(0);
        int colLength = matrix.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                if (matrix[i, j] == "@")
                {
                    // var adjecentPositions = Utils.GetAdjacentPositions(matrix, i, j, true, true);
                    // Utils.Info($"{adjecentPositions.Count}", logToConsole, logToFile);
                    // foreach (var adjecentPosition in adjecentPositions)
                    // {
                    //     Utils.Info($"{adjecentPosition.Item1}, {adjecentPosition.Item2}", logToConsole, logToFile);
                    // }
                    var adjacents = Utils.GetAdjacents(matrix, i, j, false, false);
                    // Utils.Info(string.Join(" ", adjacents), logToConsole, logToFile);
                    if (adjacents.Count(r => r == "@") < 4) 
                    {
                        Utils.Log($"{i}:{j} = {matrix[i, j]}", logToConsole, logToFile);
                        rollCoordinates.Add(Tuple.Create(i, j));

                        rolls++;
                    }
                }
            }
        }
    }

    // Tuple<int, int>
}

Utils.Log("-- Day 4 --", true, true);
Utils.Log("-----------", true, true);
Utils.Log($"{DateTime.Now}", true, true);

var day = new Day4();

// string fileName = @"input-sample.txt";
string fileName = @"input.txt";
var lines = Utils.GetLines(fileName);

// Part 1
Utils.Log("Part 1", true, true);
day.Part1(lines);

// Part 2
// Utils.Log("Part 2", true, true);
// day.Part2(lines);

Utils.Log($"{DateTime.Now}", true, true);

Console.Beep();

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();