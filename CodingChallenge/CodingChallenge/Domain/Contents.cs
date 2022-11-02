using System.Text.Json.Serialization;

namespace CodingChallenge.Domain;

public class Contents
{
    public Sand sand { get; set; }
    public Boots? boots { get; set; }
    public Coins coins { get; set; }
    public Armour armour { get; set; }
    public Helmet helmet { get; set; }
    public Diamond? diamond { get; set; }
    public Jewelry jewelry { get; set; }
    public Ruby? ruby { get; set; }
    public Robes robes { get; set; }
    public Sword sword { get; set; }
    public Bottle bottle { get; set; }
    public Spider? spider { get; set; }
    public Sapphire? sapphire { get; set; }
    public Skeleton skeleton { get; set; }
    public Gold gold { get; set; }
    public Silver silver { get; set; }
    [JsonPropertyName("holy-grail")]
    public HolyGrail? HolyGrail { get; set; }
    public string message { get; set; }
}

public class HolyGrail
{
}