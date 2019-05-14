using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGameStateService _gameStateService;
        public GameController(IGameStateService gameStateService, IGameService gameService)
        {
            _gameService = gameService;
            _gameStateService = gameStateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<CurrentPlayerStateView> state = _gameStateService.CurrentGameState();

            return View(state);
        }

        [HttpGet]
        public IActionResult Hitme()
        {
            _gameService.Hit();
            return RedirectToAction("Index", "Game");
        }

        [HttpGet]
        public IActionResult FinishRound()
        {
            _gameService.FinishRound();
            return RedirectToAction("Index", "Game");
        }

        [HttpGet]
        public IActionResult StartNewRound()
        {
            _gameService.StartNewRound();
            return RedirectToAction("Index", "Game");
        }

        [HttpGet]
        public IActionResult GetStory()
        {
            return View(_gameService.GetAllGames());
        }

        [HttpGet]
        public IActionResult GetGameStory(int gameId)
        {
            return View(_gameStateService.GameState(gameId));
        }
    }
}