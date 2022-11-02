namespace CodingChallenge.Services.ContentsInspectors;

public class BootInspectorService : IContentInspectorService
{
    public string GetOutputString()
    {
        var mode = GetModeAverage(BootSizes) ?? 0;
        return $"Most common boot size: {mode}";
    }

    private List<int> BootSizes { get; } = new();

    public void AddContents(ClueResponse clueResponse)
    {
        if (clueResponse.contents?.boots != null) BootSizes.Add(clueResponse.contents.boots.size);
    }

    private int? GetModeAverage(List<int> numbers)
    {
        return numbers
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count()).ThenBy(x => x.Key)
                .Select(x => (int?)x.Key)
                .FirstOrDefault();
    }
}