namespace CodingChallenge.Services.ContentsInspectors;

public class HolyGrailInspectorService : IContentInspectorService
{
    private string _location = "";

    public string GetOutputString()
    {
        return _location;
    }

    public void AddContents(ClueResponse clueResponse)
    {
        if (clueResponse.contents?.HolyGrail is not null)
            _location = $"Holy Grail location: {clueResponse.location}";
    }
}