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
        private IGameService _gameService;
        private IStateGameService _stateGameService;
        public GameController(IStateGameService stateGameService, IGameService gameService)
        {
            _gameService = gameService;
            _stateGameService = stateGameService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<CurrentGameStateView> state = _stateGameService.CurrentGameState();

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

        public IActionResult GetStory()
        {
            return View(_gameService.GetAllGames());
        }

        [HttpPost]
        public IActionResult GetGameStory(int gameId)
        {
            return View(_stateGameService.GameState(gameId));
        }

    }
}