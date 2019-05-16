using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlackJack.BLL.Interfaces;
using BlackJack.WEB.Models;
using BlackJack.WEB.ViewModels;

namespace BlackJack.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStartGameService _startGameService;
        public HomeController(IStartGameService startGameService)
        {
            _startGameService = startGameService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartPlay(StartGameView model)
        {
            if (!string.IsNullOrEmpty(model.PlayerName))
            {
                _startGameService.StartNewGame(model.BotsCount, model.PlayerName);
                return RedirectToAction("Index", "Game");
            }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
