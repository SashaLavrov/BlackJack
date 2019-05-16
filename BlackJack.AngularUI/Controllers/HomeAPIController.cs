using BlackJack.BLL.Interfaces;
using BlackJack.AngularUI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackJack.AngularUI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeAPIController : Controller
    {
        private readonly IStartGameService _startGameService;

        public HomeAPIController(IStartGameService startGameService, IGameStateService gameStateService)
        {
            _startGameService = startGameService;
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
