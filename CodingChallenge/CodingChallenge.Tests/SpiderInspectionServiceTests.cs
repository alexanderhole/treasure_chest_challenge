using CodingChallenge.Services.ContentsInspectors;

namespace CodingChallenge.Tests;

public class SpiderInspectionServiceTests
{
    [Fact]
    public void NoSpider_Found()
    {
        var service = new SpiderInspectorService();
        service.AddContents(new ClueResponse());
        
        Assert.Equal("Dead spiders: 0", service.GetOutputString());
    }
    
    [Fact]
    public void Dead_Spider_Found()
    {
        var service = new SpiderInspectorService();
        service.AddContents(new (){contents = new(){spider = new(){alive = false}}});
        
        Assert.Equal("Dead spiders: 1", service.GetOutputString());
    }
    
    [Fact]
    public void Alive_Spider_Found()
    {
        var service = new SpiderInspectorService();
        service.AddContents(new (){contents = new(){spider = new(){alive = true}}});
        
        Assert.Equal("Dead spiders: 0", service.GetOutputString());
    }
    
    
    [Fact]
    public void Alive_And_Dead_Spider_Found()
    {
        var service = new SpiderInspectorService();
        service.AddContents(new (){contents = new(){spider = new(){alive = true}}});
        service.AddContents(new (){contents = new(){spider = new(){alive = false}}});

        Assert.Equal("Dead spiders: 1", service.GetOutputString());
    }
}