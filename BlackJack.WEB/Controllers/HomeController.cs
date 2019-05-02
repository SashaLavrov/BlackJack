using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using BlackJack.BLL.Interfaces;

namespace BlackJack.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IStartGameService _startGameService;
        public HomeController( IStartGameService startGameService)
        {
            _startGameService = startGameService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartPlay(int botsCount, string playerName)
        {
            _startGameService.StartNewGame(botsCount, playerName);
            return RedirectToAction("Index", "Game");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
