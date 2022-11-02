namespace CodingChallenge.Tests;

public class HuntServiceTests
{
    private readonly HuntService _service;
    private Mock<IClueTraverser> _clueTraverserMock;
    private IEnumerable<Mock<IContentInspectorService>> _inspectorsMocks;

    public HuntServiceTests()
    {
        var firstInspector = new Mock<IContentInspectorService>();
        var secondInspector = new Mock<IContentInspectorService>();
        _inspectorsMocks = new List<Mock<IContentInspectorService>> { firstInspector, secondInspector };
        _clueTraverserMock = new Mock<IClueTraverser>();
        _service = new HuntService(_clueTraverserMock.Object, _inspectorsMocks.Select(x => x.Object));
    }

    [Fact]
    public async Task Hunt_Calls_ClueTraverser()
    {
        await _service.Hunt("");
        
        _clueTraverserMock.Verify(x => x.TraverseUrl(It.IsAny<string>()));
    }

    [Fact]
    public async Task Hunt_Calls_ClueTraverser_WithCorrectUrl()
    {
        var url = "https://google.com";
        await _service.Hunt(url);
        
        _clueTraverserMock.Verify(x => x.TraverseUrl(It.Is<string>(s => s == url)));
    }

    [Fact]
    public async Task Hunt_Calls_Each_Inspector()
    {
        await _service.Hunt("");

        foreach (var mock in _inspectorsMocks)
        {
            mock.Verify(x => x.GetOutputString());
        }
    }
}