#load "nuget:ScriptUnit, 0.2.0"
#r "nuget:FluentAssertions, 6.12.2"

#load "../utils/utils.csx"
#load "solution.csx"

using static ScriptUnit;
using FluentAssertions;

return await AddTestsFrom<Day3Tests>().Execute();

public class Day3Tests : IDisposable
{
    public Day3 day3;

    public Day3Tests()
    {
        day3 = new Day3();
    }

    public void Dispose() { }

    // public void Success()
    // {
    //     "Ok".Should().Be("Ok");
    // }

    // public void Fail()
    // {
    //     "Ok".Should().NotBe("Ok");
    // }
}