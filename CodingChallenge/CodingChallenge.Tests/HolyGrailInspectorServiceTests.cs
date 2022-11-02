using CodingChallenge.Services.ContentsInspectors;

namespace CodingChallenge.Tests;

public class HolyGrailInspectorServiceTests
{
    [Fact]
    public void No_Holy_Grail()
    {
        var service = new HolyGrailInspectorService();
        service.AddContents(new());
        
        Assert.Equal("",service.GetOutputString());
    }
    
    [Fact]
    public void Found_Holy_Grail()
    {
        var location = "london";
        var service = new HolyGrailInspectorService();
        service.AddContents(new(){
            contents = new()
            {
                HolyGrail = new()
            },
            location = location});

        Assert.Equal($"Holy Grail location: {location}",service.GetOutputString());
    }
}