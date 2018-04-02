using System;
using System.Collections.Generic;
using PokemonMVCApp.Models;

namespace PokemonMVCApp
{
    public interface IPokemonConnection
    {
        List<Pokemon> GetAllPokemon();
    }
}
