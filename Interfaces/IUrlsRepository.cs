using System.Collections.Generic;
using UrlShortener.Models;

namespace UrlShortener.Interfaces
{
    public interface IUrlsRepository
    {
        void ShortenAndAddUrl(string url);
        List<ShortenedUrl> GetAllShortenedUrls();
        ShortenedUrl GetSingle(int id);
        ShortenedUrl GetSingle(string hash);
        void DeleteSingle(int id);
        void UpdateSingle(int id, string url);
    }
}