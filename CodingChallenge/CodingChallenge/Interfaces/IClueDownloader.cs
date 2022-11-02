namespace CodingChallenge.Interfaces;

public interface IClueDownloader
{
    Task<List<ClueResponse>?> Download(string url);
}