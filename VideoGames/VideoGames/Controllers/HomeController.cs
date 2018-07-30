using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using video_games.Repositories;
using video_games.Models;

namespace video_games.Controllers
{
    public class HomeController : Controller
    {
        private IRepository games;

        
        public HomeController(IRepository repository)
        {
            games = repository;
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.GamesList = games.GetGames();

            return View();
        }

        
        [HttpPost]
        public IActionResult Index(string searchName)
        {
            var gamesSearch = games.GetGames();

            if (!String.IsNullOrEmpty(searchName))
            {
                gamesSearch = games.SearchWord(searchName);
            }

            ViewBag.GamesList = gamesSearch;

            return View();
        }
        //video_games.Repositories.Repository' to 'System.Collections.IEnumerable

        public IActionResult GameInfo(int ID)
        {
            ViewData["Title"] = "Информация за";

            ViewBag.Game = games.FindById(ID);

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
