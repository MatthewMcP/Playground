using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PokemonMVCApp.DBConnections;
using PokemonMVCApp.Models;

namespace PokemonMVCApp.Controllers
{
    public class PokemonController : Controller
    {

        PokemonSearchViewModel ViewModel;
        public PokemonController(IPokemonConnection pokemonConnection)
        {

            ViewModel = new PokemonSearchViewModel
            {
                PokemonList = pokemonConnection.GetAllPokemon()
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(ViewModel);
        }
    }
}
