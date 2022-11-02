namespace CodingChallenge.Tests;

public class ClueFinderTests
{
    private readonly ClueFinder _serviceUnderTest;

    public ClueFinderTests()
    {
        _serviceUnderTest = new ClueFinder();
    }
    
    [Fact]
    public void FindClue_ObjectIsNull()
    {
        var clues = _serviceUnderTest.FindClues(null);
        
        Assert.Empty(clues);
    }
    
    [Fact]
    public void FindUrlsInSimpleObject()
    {
        var hiddenUrl = "https://google.com";
        var clues = _serviceUnderTest.FindClues(new ClueResponse() { note = hiddenUrl, buriedDate = DateTime.Now});
        
        Assert.Single(clues);
        Assert.Equal(hiddenUrl, clues.First());
    }
    
    [Fact]
    public void FindUrlsInChildObject()
    {
        var hiddenUrl = "https://google.com";
        var clues = _serviceUnderTest.FindClues(new ClueResponse() { contents = new Contents(){message = hiddenUrl }});
        
        Assert.Single(clues);
        Assert.Equal(hiddenUrl, clues.First());
    }
    
    [Theory]
    [InlineData("test https://google.com", "https://google.com")]
    [InlineData("Pariatur culpa minim incididunt pariatur labore aliquip commodo pariatur ut sit quis: https://e0f5e8673c64491d8cce34f5.z35.web.core.windows.net/f4c3740481ad4e2ca9fb0ba1b8a55f0f.json", "https://e0f5e8673c64491d8cce34f5.z35.web.core.windows.net/f4c3740481ad4e2ca9fb0ba1b8a55f0f.json")]
    public void FindUrlsInChildObject_NotAtStart(string contents, string url)
    {
        var clues = _serviceUnderTest.FindClues(new ClueResponse() { contents = new Contents(){armour = new Armour(){ engraving = contents }}});
        
        Assert.Single(clues);
        Assert.Equal(url, clues.First());
    }
    
    [Theory]
    [InlineData("test https://google.com", "https://google.com")]
    [InlineData("Pariatur culpa minim incididunt pariatur labore aliquip commodo pariatur ut sit quis: https://e0f5e8673c64491d8cce34f5.z35.web.core.windows.net/f4c3740481ad4e2ca9fb0ba1b8a55f0f.json", "https://e0f5e8673c64491d8cce34f5.z35.web.core.windows.net/f4c3740481ad4e2ca9fb0ba1b8a55f0f.json")]
    public void FindUrlsInChildObject_Notes(string contents, string url)
    {
        var clues = _serviceUnderTest.FindClues(new ClueResponse() { note = contents});
        
        Assert.Single(clues);
        Assert.Equal(url, clues.First());
    }
    
    [Theory]
    [InlineData("https://e0f5e8673c64491d8cce34f5.z35.web.core.windows.net/8dbe01d0038e4c4cb7da9590b09967d1.json", "https://e0f5e8673c64491d8cce34f5.z35.web.core.windows.net/8dbe01d0038e4c4cb7da9590b09967d1.json")]
    public void FindUrlsInChildObject_Engraving(string contents, string url)
    {
        var sword = new Sword(){engraving = contents};
        var clueResponse = new ClueResponse() { contents = new(){sword = sword}};
        var clues = _serviceUnderTest.FindClues(clueResponse);
        
        Assert.Single(clues);
        Assert.Equal(url, clues.First());
    }
}