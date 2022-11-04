using CodingChallenge.Services.ContentsInspectors;

namespace CodingChallenge.Tests;

public class DoubloonsCounterServiceTests
{
    [Theory]
    [InlineData(1,200)]
    [InlineData(2,400)]
    [InlineData(4,800)]
    public void Sapphires_Adding(int numberOfShapphires, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new(){contents = new(){sapphire = new Sapphire(){count = numberOfShapphires}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    [Theory]
    [InlineData(1,250)]
    [InlineData(2,500)]
    [InlineData(4,1000)]
    public void Rubies_Adding(int numberOfRubies, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new(){contents = new(){ruby = new Ruby(){count = numberOfRubies}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    [Theory]
    [InlineData(1,400)]
    [InlineData(2,800)]
    [InlineData(4,1600)]
    public void Diamonds_Adding(int numberOfDiamonds, int expectedValue)
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new(){contents = new(){diamond = new Diamond(){count = numberOfDiamonds}}});
        
        Assert.Equal($"Total chest value: {expectedValue} doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void No_Contents()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new());
        
        Assert.Equal($"Total chest value: 0 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Armour_Adding()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){armour = new(){value = new(){value = 87}}}
        });
        
        Assert.Equal($"Total chest value: 87 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Armour_Adding_Multiple()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){armour = new(){value = new(){value = 87}}}
        });
        doubloonService.AddContents(new()
        {
            contents = new(){armour = new(){value = new(){value = 13}}}
        });
        
        Assert.Equal($"Total chest value: 100 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Coins_Adding()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){coins = new(){value = 88}}
        });
        
        Assert.Equal($"Total chest value: 88 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Coins_Adding_Multiple()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){coins = new(){value = 12}}
        });
        doubloonService.AddContents(new()
        {
            contents = new(){armour = new(){value = new(){value = 13}}}
        });
        
        Assert.Equal($"Total chest value: 25 doubloons",doubloonService.GetOutputString());
    }
    [Fact]
    public void Helmet_Adding()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){helmet = new(){value = new(){value = 99}}}
        });
        
        Assert.Equal($"Total chest value: 99 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Helmet_Adding_Multiple()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){helmet = new(){value = new(){value = 99}}}
        });
        doubloonService.AddContents(new()
        {
            contents = new(){helmet = new(){value = new(){value = 11}}}
        });
        
        Assert.Equal($"Total chest value: 110 doubloons",doubloonService.GetOutputString());
    }
    [Fact]
    public void Jewelry_Adding()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){jewelry = new(){value = 1}}
        });
        
        Assert.Equal($"Total chest value: 1 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Jewlery_Adding_Multiple()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){jewelry = new(){value = 99}}
        });
        doubloonService.AddContents(new()
        {
            contents = new(){helmet = new(){value = new(){value = 1}}}
        });
        
        Assert.Equal($"Total chest value: 100 doubloons",doubloonService.GetOutputString());
    }
    [Fact]
    public void Silver_Adding()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){silver = new(){value = 121}}
        });
        
        Assert.Equal($"Total chest value: 121 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Silver_Adding_Multiple()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){silver = new(){value = 99}}
        });
        doubloonService.AddContents(new()
        {
            contents = new(){silver = new(){value = 1}}
        });
        
        Assert.Equal($"Total chest value: 100 doubloons",doubloonService.GetOutputString());
    }
    [Fact]
    public void Skeleton_Adding()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){skeleton = new(){coins = new(){value = 12}}}
        });
        
        Assert.Equal($"Total chest value: 12 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Skeletons_Adding_Multiple()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){skeleton = new(){coins = new(){value = 99}}}
        });
        doubloonService.AddContents(new()
        {
            contents = new(){skeleton = new(){coins = new(){value = 111}}}
        });
        
        Assert.Equal($"Total chest value: 210 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Sword_Adding()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){sword = new(){value = new(){value = 122}}}
        });
        
        Assert.Equal($"Total chest value: 122 doubloons",doubloonService.GetOutputString());
    }
    
    [Fact]
    public void Sword_Adding_Multiple()
    {
        var doubloonService = new DoubloonInspectorService();
        doubloonService.AddContents(new()
        {
            contents = new(){sword = new(){value = new (){value = 99}}}
        });
        doubloonService.AddContents(new()
        {
            contents = new(){sword = new(){value = new(){ value = 10}}}
        });
        
        Assert.Equal($"Total chest value: 109 doubloons",doubloonService.GetOutputString());
    }
}