namespace CodingChallenge.Tests;

public class ClueTraverserTests
{
    private readonly ClueTraverser _service;
    private Mock<IClueDownloader> _downloadServiceMock;
    private readonly List<Mock<IContentInspectorService>> _inspectorsMocks;
    private Mock<IClueFinder> _clueFinderMock;

    public ClueTraverserTests()
    {
        var firstInspector = new Mock<IContentInspectorService>();
        var secondInspector = new Mock<IContentInspectorService>();
        
        _inspectorsMocks = new List<Mock<IContentInspectorService>> { firstInspector, secondInspector };
        _downloadServiceMock = new Mock<IClueDownloader>();
        _clueFinderMock = new Mock<IClueFinder>();
        _service = new ClueTraverser(_clueFinderMock.Object, _downloadServiceMock.Object, _inspectorsMocks.Select(x => x.Object));
    }

    [Fact]
    public async Task TraverseUrl_Calls_DownloadService()
    {
        await _service.TraverseUrl("");
        
        _downloadServiceMock.Verify(x => x.Download(It.IsAny<string>()));
    }
    
    [Fact]
    public async Task TraverseUrl_Calls_DownloadService_With_CorrectUrl()
    {
        var startUrl = "";
        
        await _service.TraverseUrl(startUrl);
        
        _downloadServiceMock.Verify(x => x.Download(It.Is<string>(url => url == startUrl)));
    }
    
    [Fact]
    public async Task TraverseUrl_Calls_InspectorServices_PerResponse()
    {
        _downloadServiceMock.Setup(x => x.Download(It.IsAny<string>()))
            .ReturnsAsync(new List<ClueResponse>() { new() });
        
        await _service.TraverseUrl("");

        foreach (var inspectorsMock in _inspectorsMocks)
        {
            inspectorsMock.Verify(x => x.AddContents(It.IsAny<ClueResponse>()), Times.Once());
        }
    }
    
    [Fact]
    public async Task TraverseUrl_Calls_InspectorServices_PerResponse_MultipleResponses()
    {
        _downloadServiceMock.Setup(x => x.Download(It.IsAny<string>()))
            .ReturnsAsync(new List<ClueResponse>() { new() , new(),new()});
        
        await _service.TraverseUrl("");

        foreach (var inspectorsMock in _inspectorsMocks)
        {
            inspectorsMock.Verify(x => x.AddContents(It.IsAny<ClueResponse>()), Times.Exactly(3));
        }
    }
    
    [Fact]
    public async Task TraverseUrl_Calls_InspectorServices_PerResponse_CorrectParameters()
    {
        var clueResponse = new ClueResponse();
        var clueResponseTwo = new ClueResponse();
        var clueResponseThree = new ClueResponse();
        _downloadServiceMock.Setup(x => x.Download(It.IsAny<string>()))
            .ReturnsAsync(new List<ClueResponse>() { clueResponse , clueResponseTwo,clueResponseThree});
        
        await _service.TraverseUrl("");

        foreach (var inspectorsMock in _inspectorsMocks)
        {
            inspectorsMock.Verify(x => x.AddContents(clueResponse), Times.Exactly(1));
            inspectorsMock.Verify(x => x.AddContents(clueResponseTwo), Times.Exactly(1));
            inspectorsMock.Verify(x => x.AddContents(clueResponseThree), Times.Exactly(1));
        }
    }
    
    [Fact]
    public async Task TraverseUrl_Calls_ClueFinderService()
    {
        _downloadServiceMock.Setup(x => x.Download(It.IsAny<string>()))
            .ReturnsAsync(new List<ClueResponse>() { new() , new(),new()});
        
        await _service.TraverseUrl("");

        _clueFinderMock.Verify(x => x.FindClues(It.IsAny<ClueResponse>()), Times.Exactly(3));
    }
    
    [Fact]
    public async Task TraverseUrl_Calls_ClueFinderService_Correct_Parameter()
    {
        
        var clueResponse = new ClueResponse();
        var clueResponseTwo = new ClueResponse();
        var clueResponseThree = new ClueResponse();
        _downloadServiceMock.Setup(x => x.Download(It.IsAny<string>()))
            .ReturnsAsync(new List<ClueResponse>() { clueResponse , clueResponseTwo,clueResponseThree});
        
        await _service.TraverseUrl("");

        _clueFinderMock.Verify(x => x.FindClues(clueResponse), Times.Once);
        _clueFinderMock.Verify(x => x.FindClues(clueResponseTwo), Times.Once);
        _clueFinderMock.Verify(x => x.FindClues(clueResponseThree), Times.Once);
    }

    [Fact]
    public async Task TraverseUrl_Calls_DownloadServiceAgain_After_ClueFinderFindsClue()
    {
        var foundUrl = "https://google.com";
        _downloadServiceMock.Setup(x => x.Download(It.IsAny<string>()))
            .ReturnsAsync(new List<ClueResponse>(){new()});
        _clueFinderMock.SetupSequence(x => x.FindClues(It.IsAny<ClueResponse>())).Returns(new List<string>() { foundUrl });

        await _service.TraverseUrl("");
        
        _downloadServiceMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(2));
        _downloadServiceMock.Verify(x => x.Download(foundUrl));
    }
}