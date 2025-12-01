#load "../utils/utils.csx"

public class Day1
{
    bool logToConsole = true;
    bool logToFile = true;

    long max = 99L;
    long zeroCount = 0;

    // Utils.Log($"{}", logToConsole, logToFile);

    public void Part1(string[] lines)
    {
        // var startingNumber = 50;
        var currentNumber = 50L;
        
        foreach (var line in lines)
        {
            (string direction, long turns) item = (line.Substring(0, 1), long.Parse(line.Substring(1)));
            // Console.WriteLine(item.direction);
            // Console.WriteLine(item.turns);

            currentNumber = UpdateDial(currentNumber, item.direction, item.turns);

            Utils.Log($"currentNumber: {currentNumber}", logToConsole, logToFile);
            if (currentNumber == 0) zeroCount++;
        }

        Utils.Answer($"{zeroCount}", logToConsole, logToFile);
    }

    long UpdateDial(long currentPosition, string direction, long rotation)
    {
        var position = 0L;

        Utils.Log($"Current Position: {currentPosition} | Direction: {direction} | Rotation: {rotation}", logToConsole, logToFile);
        
        // if (rotation > max)
        // {
        //      rotation / max
        // }

        switch (direction)
        {
            case "L":
                if ((currentPosition - rotation) < 0)
                {
                    position = max - Math.Abs(currentPosition - rotation) + 1;
                }
                else
                {
                    position = currentPosition - rotation;
                }
                break;
            case "R":
                if ((currentPosition + rotation) > max)
                {
                    position = currentPosition + rotation - max - 1;
                }
                else
                {
                    position = currentPosition + rotation;
                }
                break;
            default:
                Utils.Error("ERROR", logToConsole, logToFile);
                break;
        }

        return position;
    }

    // public void Part2(string[] lines)
    // {
    // }
}

Utils.Log("-- Day 1 --", true, true);
Utils.Log("-----------", true, true);

var day = new Day1();

string fileName = @"input-sample.txt";
// string fileName = @"input.txt";
var lines = Utils.GetLines(fileName);

// Part 1
Utils.Log("Part 1", true, true);
day.Part1(lines);

// Part 2
// Utils.Log("Part 2", true, true);
// day.Part2(lines);

Console.Beep();

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();