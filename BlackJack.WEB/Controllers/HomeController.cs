using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.WEB.Models;
using BlackJack.BLL.Interfaces;

namespace BlackJack.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ICardService _cardService;

        public HomeController(ICardService cardService)
        {
            _cardService = cardService;
        }
        public IActionResult Index()
        {
            var res = _cardService.Get(1);
            CardViewModel model = new CardViewModel() {
                CardId = res.CardId,
                Type = res.Type,
                Value = res.Value
            };
           
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
