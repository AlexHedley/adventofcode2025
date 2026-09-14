#load "nuget:ScriptUnit, 0.2.0"
#r "nuget:FluentAssertions, 6.12.2"

#load "../utils/utils.csx"
#load "solution.csx"

using static ScriptUnit;
using FluentAssertions;

return await AddTestsFrom<Day6Tests>().Execute();

public class Day6Tests : IDisposable
{
    public Day6 day;

    public Day6Tests()
    {
        day = new Day6();
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