using System;
using System.Collections.Generic;
using System.Linq;
using HashidsNet;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Repositories
{
    public class UrlsRepository : IUrlsRepository
    {
        private readonly int MinHashLength = 6;
        private List<ShortenedUrl> shortenedUrls;

        public UrlsRepository()
        {
            this.shortenedUrls = new List<ShortenedUrl>();
            this.ShortenAndAddUrl("http://microsoft.com");
            this.ShortenAndAddUrl("http://trojmiasto.pl");
        }
        
        public List<ShortenedUrl> GetAllShortenedUrls()
        {
            return this.shortenedUrls;
        }

        public ShortenedUrl GetSingle(int id)
        {
            return this.shortenedUrls.SingleOrDefault(elem => elem.Id == id);
        }

        public ShortenedUrl GetSingle(string hash)
        {
            return this.shortenedUrls.SingleOrDefault(elem => elem.Hash == hash);
        }

        public void DeleteSingle(int id)
        {
            this.shortenedUrls.Remove(this.shortenedUrls.Single(elem => elem.Id == id));
        }

        public void UpdateSingle(int id, string url)
        {
            int index = this.shortenedUrls.FindIndex(elem => elem.Id == id);
            if (index != -1)
                this.shortenedUrls[index].Url = url;
        }

        public void ShortenAndAddUrl(string url)
        {
            var hashIds = new Hashids(url, this.MinHashLength);
            int nextId = this.GetNextId();
            this.shortenedUrls.Add(new ShortenedUrl()
            {
                Id = nextId,
                Url = url,
                Hash = hashIds.Encode(nextId)
            });
        }

        private int GetNextId()
        {
            return this.shortenedUrls.Any() ? this.shortenedUrls.Last().Id + 1 : 1;
        }
    }
}