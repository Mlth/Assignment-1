namespace MyApp.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLineGivenListOfThreeLinesReturnsNineWords(){
        IEnumerable<string> lines = new List<string>{"Hey hey hEy", "ABC yo yo", "idk idk 958"};
        Assert.Equal(new List<string>{"Hey", "hey", "hEy", "ABC" ,"yo", "yo", "idk", "idk", "958"}, RegExpr.SplitLine(lines));
    }

    [Fact]
    public void ResolutionGivenStringWithThreeResolutionsReturnsThreeTuples(){
        var resolutions = "1920x1080 \n 1024x768, 800x600, 640x480 \n 320x200, 320x240, 800x600 \n 1280x960";
        Assert.Equal(new List<(int, int)>{(1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960)}, RegExpr.Resolution(resolutions));
    }

    [Fact]
    public void InnerTextGivenStringWithFourDifferentTagsReturnsInnerTextFromDivTag(){
        var html = "<html><body><div>Text to be returned</div><button>This text should not be returned</button></body></html>";
        Assert.Equal(new List<string>{"Text to be returned"}, RegExpr.InnerText(html, "div"));
    }
}