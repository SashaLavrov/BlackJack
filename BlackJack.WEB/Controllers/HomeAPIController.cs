using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackJack.WEB.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeAPIController : Controller
    {
        private IStartGameService _startGameService;
        private IGameStateService _gameStateService;

        public HomeAPIController(IStartGameService startGameService, IGameStateService gameStateService)
        {
            _startGameService = startGameService;
            _gameStateService = gameStateService;
        }

        [HttpPost("startgame")]
        public IActionResult StartGame(StartGameView model)
        {
            if (!string.IsNullOrEmpty(model.PlayerName) && model.PlayerName != "Dealer")
            {
                _startGameService.StartNewGame(model.BotsCount, model.PlayerName);
                return Ok();
            }
            return BadRequest();
        }
    }
}
