namespace CodingChallenge.Services.ContentsInspectors;

public class DoubloonInspectorService : IContentInspectorService
{
    private int Doubloons { get; set; }


    public string GetOutputString()
    {
        return $"Total chest value: {Doubloons} doubloons";
    }

    public void AddContents(ClueResponse clueResponse)
    {
        var contents = clueResponse.contents;
        if (contents == null) return;
        if (contents.sapphire != null) Doubloons += contents.sapphire.count * 200;
        if (contents.ruby != null) Doubloons += contents.ruby.count * 250;
        if (contents.diamond != null) Doubloons += contents.diamond.count * 400;
    }
}