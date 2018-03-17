using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class UrlsController : Controller
    {
        private readonly IUrlsRepository urlsRepository;

        public UrlsController(IUrlsRepository urlsRepository) 
        {
            this.urlsRepository = urlsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
           return View(this.urlsRepository.GetAllShortenedUrls());
        }

        [HttpPost]
        public IActionResult Create(string url)
        {
            this.urlsRepository.ShortenAndAddUrl(url);
            return Redirect("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            this.urlsRepository.DeleteSingle(id);
            return Redirect("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(this.urlsRepository.GetSingle(id));
        }

        [HttpGet]
        public IActionResult Update(int Id, string Url)
        {
            this.urlsRepository.UpdateSingle(Id, Url);
            return Redirect("index");
        }
    }
}