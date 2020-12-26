using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtsNamespace.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace lab1_2.Controllers
{
    public class AlbumController : Controller
    {
        ArtDbContext _context;
        IWebHostEnvironment _appEnvironment;
        public AlbumController(ArtDbContext context, IWebHostEnvironment appEnvironment) {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Albums = _context.Album.ToList();

            return View(Albums);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var albumItem = _context.Album.SingleOrDefault(x => x.AlbumId == id);
            var artsData = _context.Art.Where(x => x.AlbumId == id).ToList();
            ViewData["Album"] = albumItem;
            // ViewData["Arts"] = artsData; 
            return View(artsData);
        }
        [HttpPost]
        public IActionResult AddNewImage(int id, IFormFile ImagePath, string name, string description)
        {
            var art = new Art();
            Console.WriteLine(ImagePath);
            art.ImagePath = ImagePath.FileName;
            art.AlbumId = id;
            art.Name = name;
            art.Description = description;

            string path = "/images/" + ImagePath.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                ImagePath.CopyTo(fileStream);
            }
            
            _context.Art.Add(art);
            _context.SaveChanges();
            return Content("You have create new album: " + ImagePath.FileName);
        }
        [HttpPost]
        public IActionResult DeleteArt(int id)
        {
            var art = _context.Art.Find(id);
            _context.Art.Remove(art);
            _context.SaveChanges();

            return Content("Image has removed.");
        }
        [HttpGet]
        public IActionResult AddForm() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddForm(Album album) 
        {
            _context.Album.Add(album);
            _context.SaveChanges();
            return Content("You have create new album: " + album.Name);
        }
    }
}
