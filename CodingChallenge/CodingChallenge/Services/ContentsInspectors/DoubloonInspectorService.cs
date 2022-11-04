namespace CodingChallenge.Services.ContentsInspectors;

public class DoubloonInspectorService : IContentInspectorService
{
    private const int SapphireValue = 200;
    private const int RubyValue = 250;
    private const int DiamondValue = 400;
    private int doubloons { get; set; }


    public string GetOutputString()
    {
        return $"Total chest value: {doubloons} doubloons";
    }

    public void AddContents(ClueResponse clueResponse)
    {
        var contents = clueResponse.contents;
        if (contents == null) return;
        if (contents.sapphire != null) doubloons += contents.sapphire.count * SapphireValue;
        if (contents.ruby != null) doubloons += contents.ruby.count * RubyValue;
        if (contents.diamond != null) doubloons += contents.diamond.count * DiamondValue;
        if (contents.armour != null) doubloons += contents.armour.value.value;
        if (contents.coins != null) doubloons += contents.coins.value;
        if (contents.helmet != null) doubloons += contents.helmet.value.value;
        if (contents.silver != null) doubloons += contents.silver.value;
        if (contents.skeleton != null) doubloons += contents.skeleton.coins.value;
        if (contents.gold != null) doubloons += contents.gold.value;
        if (contents.jewelry != null) doubloons += contents.jewelry.value;
        if (contents.sword != null) doubloons += contents.sword.value.value;
    }
}