namespace CodingChallenge.Services;

public class ClueTraverser : IClueTraverser
{
    private readonly IClueFinder _clueFinder;
    private readonly IClueDownloader _clueDownloader;
    private readonly IEnumerable<IContentInspectorService> _contentInspectorService;

    public ClueTraverser(IClueFinder clueFinder, IClueDownloader clueDownloader,IEnumerable<IContentInspectorService> contentInspectorService)
    {
        _clueFinder = clueFinder;
        _clueDownloader = clueDownloader;
        _contentInspectorService = contentInspectorService;
    }


    public async Task TraverseUrl(string startUrl)
    {
        var response = await _clueDownloader.Download(startUrl);
        if (response != null)
            foreach (var clue in response)
            {
                InspectClue(clue);
                var urls = _clueFinder.FindClues(clue);
                if (urls == null) continue;
                foreach (var url in urls)
                {
                    await TraverseUrl(url);
                }
            }
    }

    private void InspectClue(ClueResponse clue)
    {
        foreach (var contentInspectorService in _contentInspectorService)
        {
            contentInspectorService.AddContents(clue);
        }
    }
}