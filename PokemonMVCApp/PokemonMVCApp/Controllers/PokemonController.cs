using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PokemonMVCApp.Models;

namespace PokemonMVCApp.Controllers
{
    public class PokemonController : Controller
    {

        PokemonSearchViewModel ViewModel;
        public PokemonController()
        {
            
            ViewModel = new PokemonSearchViewModel
            {
                PokemonList = HardcodedDataSource.GetPokemons()
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(ViewModel);
        }
    }
}
