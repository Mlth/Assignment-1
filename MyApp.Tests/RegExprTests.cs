namespace MyApp.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLineGivenListOfThreeLinesReturnsNineWords(){
        IEnumerable<string> lines = new List<string>{"Hey hey hEy", "ABC yo yo", "idk idk 958"};
        Assert.Equal(new List<string>{"Hey", "hey", "hEy", "ABC" ,"yo", "yo", "idk", "idk", "958"}, RegExpr.SplitLine(lines));
    }

    [Fact]
    public void Urls_given_html_with_all_matches_having_title_returns_list_of_tuples()
    {
        var html = "<tag text href=\"http://link.com\" text title=\"hej\" text>" +
            "\r\n<tag text href=\"http://link.com\" text title=\"hej\" text> inner text </tag>" +
            "\r\n<tag text title=\"hej\" text href=\"http://link.com\" text>" +
            "\r\n<tag text title=\"hej\" text href=\"http://link.com\" text> inner text </tag>" +
            "\r\n<tag text href=\"http://link.com\" text title=\"hej\" text> " +
            "\r\n    inner text" +
            "\r\n</tag>";

        var expected = new List<(Uri, string)> 
        { 
            (new("http://link.com"), "hej"),
            (new("http://link.com"), "hej"),
            (new("http://link.com"), "hej"),
            (new("http://link.com"), "hej"),
            (new("http://link.com"), "hej")
        };
        var actual = RegExpr.Urls(html);

        Assert.Equal(expected, actual);
    }
}