using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens'"))
                .ToList();
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NonFootballLeagues = _context.Leagues
                .Where(l => !l.Sport.Contains("Football"))
                .ToList();
            ViewBag.ConferenceName = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.DallasTeams = _context.Teams
                .Where(t => t.Location.Contains("Dallas"))
                .ToList();
            ViewBag.RaptorTeams = _context.Teams
                .Where(t => t.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.CityTeams = _context.Teams
                .Where(t => t.Location.Contains("City"))
                .ToList();
            ViewBag.TTeams = _context.Teams
                .Where(t => t.TeamName.Contains("T"))
                .ToList();
            ViewBag.AllTeamsInAlphabeticOrder = _context.Teams
                .Where(t => t.Location.Contains(""))
                .OrderBy(t => t.Location)
                .ToList();
            ViewBag.AllTeamsInDecsendingOrder = _context.Teams
                .Where(t => t.TeamName.Contains(""))
                .OrderByDescending(t => t.TeamName)  
                .ToList();
            ViewBag.CooperLastName = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.JoshuaFirstName = _context.Players
                .Where(p => p.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.CooperNotJoshua = _context.Players
                .Where(p => p.LastName.Contains("Cooper") && !p.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.AlexanderAndWyatt = _context.Players
                .Where(p => p.FirstName.Contains("Wyatt") || p.FirstName.Contains("Alexander"))
                .ToList();
            return View();
        }


        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}