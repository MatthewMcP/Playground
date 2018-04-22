using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View(ViewModel);
        }
    }
}
