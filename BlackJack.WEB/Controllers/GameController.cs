using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;
using BlackJack.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class GameController : Controller
    {
        private IStartGameService _startGameService;
        private UserManager<ApplicationUser> _userManager;
        public GameController(IStartGameService startGameService, UserManager<ApplicationUser> userManager)
        {
            _startGameService = startGameService;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpPost]
        public async Task<IActionResult> Index(int botsCount)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            _startGameService.StartNewGame(3, user.Id);
            return View();
        }

    }
}