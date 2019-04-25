using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class GameController : Controller
    {
        private IStartGameService _startGameService;
        private IStateGameService _stateGameService;
        public GameController(IStartGameService startGameService, IStateGameService stateGameService)
        {
            _startGameService = startGameService;
            _stateGameService = stateGameService;
        }

        [HttpPost]
        public IActionResult Index(int botsCount,string playerName)
        {
            int gameId = _startGameService.StartNewGame(botsCount, playerName);

            IEnumerable<CurrentGameStateView> state = _stateGameService.CurrentGameState(gameId);

            return View(state);
        }
    }
}