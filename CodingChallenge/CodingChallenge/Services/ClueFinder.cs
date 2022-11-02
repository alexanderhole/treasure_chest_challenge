namespace CodingChallenge.Services;

public class ClueFinder : IClueFinder
{
    public List<string> FindClues(ClueResponse clueResponse)
    {
        var clueInObject = FindClueUrlInObject(clueResponse);
        return clueInObject;
    }

    private List<string> FindClueUrlInObject(object? clueResponse)
    {
        var returnList = new List<string>();
        if (clueResponse == null || !clueResponse.GetType().IsClass) return returnList;
        foreach (var property in clueResponse.GetType().GetProperties())
        {
                var propertyValue = property.GetValue(clueResponse);
                if (propertyValue is string)
                    returnList.AddRange(GetUrlFromString(propertyValue.ToString()));
                else if (propertyValue is not null)
                    returnList.AddRange(FindClueUrlInObject(propertyValue));
        }

        return returnList;
    }

    private static IEnumerable<string> GetUrlFromString(string? urlString)
    {
        var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return linkParser.Matches(urlString).Select(x => x.Value);
    }
}