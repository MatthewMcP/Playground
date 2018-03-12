using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonMVCApp.Models;

namespace PokemonMVCApp.Controllers
{
    public class PokemonController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new Pokemon("Dan", "2"));
        }
    }
}
