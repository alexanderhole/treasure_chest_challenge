using CodingChallenge.Services.ContentsInspectors;

namespace CodingChallenge.Tests;

public class BootInspectorServiceTests
{
    [Fact]
    public void No_Boots_Zero_Size()
    {
        var service = new BootInspectorService();
        service.AddContents(new());
        
        Assert.Equal("Most common boot size: 0", service.GetOutputString());
    }
    
    [Fact]
    public void SingleBoot_Eight_Size()
    {
        var service = new BootInspectorService();
        service.AddContents(new(){contents = new(){boots = new (){size = 8}}});
        
        Assert.Equal("Most common boot size: 8", service.GetOutputString());
    }
    
    [Fact]
    public void Two_Boots_Eight_Size()
    {
        var service = new BootInspectorService();
        service.AddContents(new(){contents = new(){boots = new (){size = 8}}});
        service.AddContents(new(){contents = new(){boots = new (){size = 8}}});
        
        Assert.Equal("Most common boot size: 8", service.GetOutputString());
    }
    
    [Fact]
    public void Many_Boots_Multiple_Size()
    {
        var service = new BootInspectorService();
        service.AddContents(new(){contents = new(){boots = new (){size = 2}}});
        service.AddContents(new(){contents = new(){boots = new (){size = 8}}});
        service.AddContents(new(){contents = new(){boots = new (){size = 8}}});
        service.AddContents(new(){contents = new(){boots = new (){size = 8}}});
        service.AddContents(new(){contents = new(){boots = new (){size = 2}}});
        service.AddContents(new(){contents = new(){boots = new (){size = 20}}});
        service.AddContents(new(){contents = new(){boots = new (){size = 200}}});
        
        Assert.Equal("Most common boot size: 8", service.GetOutputString());
    }
}