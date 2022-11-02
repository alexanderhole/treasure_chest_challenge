namespace CodingChallenge.Tests;

public class ClueDownloaderTests
{
    private readonly ClueDownloader _service;

    public ClueDownloaderTests()
    {
        _service = new ClueDownloader();
    }

    [Theory]
    [InlineData("https://google.com")]
    [InlineData("https://bbc.co.uk")]
    public async Task ClueDownloader_CallsUrlGiven(string url)
    {
        using var httpTest = new HttpTest();
        
        await _service.Download(url);

        httpTest.ShouldHaveCalled(url);
    }

    [Fact]
    public async Task ClueDownload_ReturnsModel()
    {
        var exampleNote = "test note";
        using var httpTest = new HttpTest();
        httpTest.RespondWithJson(new List<ClueResponse>(){new ClueResponse() { note = exampleNote }});

        var clueResponses = await _service.Download("https://clue.com");

        Assert.Equal(clueResponses.First().note, exampleNote);
    }

}