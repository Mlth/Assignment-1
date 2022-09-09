namespace MyApp.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLineGivenListOfThreeLinesReturnsNineWords(){
        IEnumerable<string> lines = new List<string>{"Hey hey hEy", "ABC yo yo", "idk idk 958"};
        Assert.Equal(new List<string>{"Hey", "hey", "hEy", "ABC" ,"yo", "yo", "idk", "idk", "958"}, RegExpr.SplitLine(lines));
    }
}