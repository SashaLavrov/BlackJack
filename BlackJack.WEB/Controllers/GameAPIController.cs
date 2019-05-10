using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameAPIController : ControllerBase
    {
        private IGameService _gameService;
        private IGameStateService _gameStateService;
        public GameAPIController(IGameService gameService, IGameStateService gameStateService)
        {
            _gameService = gameService;
            _gameStateService = gameStateService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            IEnumerable<CurrentPlayerStateView> state = _gameStateService.CurrentGameState();
            return Ok(state);
        }

        [HttpGet("getAllGameStory")]
        public IActionResult GetStory()
        {
            return Ok(_gameService.GetAllGames());
        }

        [HttpGet("gamedateils/{id}")]
        public IActionResult GetGameStory(int id)
        {
            try
            {
                var res = _gameStateService.GameState(id);
                return Ok(res);
            }
            catch(NullReferenceException)
            {
                return NotFound("Wrong game id");
            }
        }
    }
}