using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class ShortenedUrl
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        public string Hash { get; set; }
    }
}