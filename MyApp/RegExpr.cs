using System.Text.RegularExpressions;

namespace MyApp;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines){
        Regex reg = new Regex(@"\w+");
        foreach(var line in lines){
            var matches = reg.Matches(line).Cast<Match>().Select(m => m.Value).ToArray();
            foreach(var match in matches){
                yield return match;
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions){
        Regex reg = new Regex(@"[0-9]{3,4}");
        var matches = reg.Matches(resolutions).Cast<Match>().Select(m => m.Value).ToArray();
        for(int i = 0; i < matches.Length; i += 2){
            yield return (int.Parse(matches[i]), int.Parse(matches[i+1]));
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag){
        Regex reg = new Regex(@$"<({tag})>(.*?)<\/\1>");
        var matches = reg.Matches(html);
        foreach(Match match in matches){
            yield return match.Groups[2].Value;
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html) 
    {
        var reg = new Regex("<(?<tag>\\w+).*?((?<url>https?:\\/\\/\\S+(?=\\\")).*?|(title=\"(?<title>\\S+)\").*?){1,2}>([\\w \\n]+<\\/\\w+>)?");
        var matches = reg.Matches(html);
        foreach (Match match in matches.Cast<Match>())
        {
            var url = match.Groups["url"].Value;
            var titleOrInner = match.Groups["title"].Value;
            if (titleOrInner == "" || titleOrInner == null)
            {
                var tag = match.Groups["tag"].Value;
                titleOrInner = InnerText(match.Value, tag).ToList()[0];
            }
            yield return new(new(url), titleOrInner);
        }
    }
}