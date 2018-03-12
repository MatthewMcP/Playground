using Microsoft.AspNetCore.Mvc;
using PokemonMVCApp.Models;

namespace PokemonMVCApp.Controllers
{
    public class PokemonController : Controller
    {

        Pokemon[] PokemonArray;
        public PokemonController()
        {
            PokemonArray = new Pokemon[]
        {
                new Pokemon("Dan", "1"),
                new Pokemon("Danny", "2"),
                new Pokemon("Daniel", "3"),
                new Pokemon("Daniella", "4")
        };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new Pokemon("Dan", "2"));
        }

        public IActionResult SearchPokemonName(string name)
        {
            return View(PokemonArray[2]);
        }

        public IActionResult SearchPokemonId(string id)
        {
            return View(PokemonArray[3]);
        }
    }
}
