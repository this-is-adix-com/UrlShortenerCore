using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Interfaces;

namespace UrlShortener.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IUrlsRepository urlsRepository;

        public NavigationController(IUrlsRepository urlsRepository)
        {
            this.urlsRepository = urlsRepository;
        }

        [HttpGet]
        [Route("/{hash}")]
        public IActionResult Index(string hash)
        {
            return Redirect(this.urlsRepository.GetSingle(hash).Url);
        }
    }
}
