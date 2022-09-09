using System.Text.RegularExpressions;

namespace MyApp;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines){
        Regex reg = new Regex(@"[a-zA-Z0-9]+");
        foreach(var line in lines){
            var matches = reg.Matches(line).Cast<Match>().Select(m => m.Value).ToArray();
            foreach(var match in matches){
                yield return match;
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) => throw new NotImplementedException();

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();

    public static IEnumerable<(Uri url, string title)> Urls(string html) => throw new NotImplementedException();
}