namespace CodingChallenge.Services;

public class HuntService : IHuntService
{
    private readonly IClueTraverser _clueTraverser;
    private readonly IEnumerable<IContentInspectorService> _contentInspectorService;

    public HuntService(IClueTraverser clueTraverser, IEnumerable<IContentInspectorService> contentInspectorService)
    {
        _clueTraverser = clueTraverser;
        _contentInspectorService = contentInspectorService;
    }
    public async Task Hunt(string url)
    {
        await _clueTraverser.TraverseUrl(url);
        foreach (var contentInspectorService in _contentInspectorService)  
        {
            var value = contentInspectorService.GetOutputString();
            Console.WriteLine(value);
        }
    }
}