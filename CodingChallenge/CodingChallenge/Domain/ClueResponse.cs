namespace CodingChallenge.Domain;

public class ClueResponse
{
    public string note { get; set; }
    public Contents? contents { get; set; }
    public string location { get; set; }
    public DateTime buriedDate { get; set; }
}