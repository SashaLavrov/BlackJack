﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.AngularUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameAPIController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IGameStateService _gameStateService;
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
            catch (NullReferenceException)
            {
                return NotFound("Wrong game id");
            }
        }

        [HttpGet("Hit")]
        public IActionResult Hitme()
        {
            _gameService.Hit();
            IEnumerable<CurrentPlayerStateView> state = _gameStateService.CurrentGameState();
            return Ok(state);
        }

        [HttpGet("Enough")]
        public IActionResult Enough()
        {
            _gameService.FinishRound();
            IEnumerable<CurrentPlayerStateView> state = _gameStateService.CurrentGameState();
            return Ok(state);
        }

        [HttpGet("FinishRound")]
        public IActionResult FinishRound()
        {
            _gameService.StartNewRound();
            IEnumerable<CurrentPlayerStateView> state = _gameStateService.CurrentGameState();
            return Ok(state);
        }
    }
}