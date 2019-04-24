using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlackJack.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace BlackJack.WEB.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.UserList = _userManager.Users.ToList();
            return View();
        }

        public IActionResult GoPlay(string userName)
        {
            var users = _userManager.Users.ToList();
            if (users.Where(x => x.UserName == userName).FirstOrDefault() == null)
            {
                return RedirectToAction("Register", "Account");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
