using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PokemonMVCApp.Models;

namespace PokemonMVCApp.DBConnections
{
    public class HardcodedDataSource : IPokemonConnection
    {
        public List<Pokemon> GetAllPokemon()
        {
            return new List<Pokemon>
                {
                new Pokemon("Bulbasaur", 1, true, null, PokemonTypes.Grass, "Evolves at Level 16",
                            new List<string> { "Chosen At Start"}, new List<string>{ "None"}),
                new Pokemon("Ivysaur", 2, true, null, PokemonTypes.Grass, "Evolves at Level 32",
                            new List<string> {"None"}, new List<string>{"Can only be evolved"}),
                new Pokemon("Venusaur", 3, true, null, PokemonTypes.Grass, "Does not evolve",
                            new List<string> { "None"}, new List<string>{"Can only be evolved"}),
                new Pokemon("Charmander", 4, true, null, PokemonTypes.Fire, "Evolves at Level 16",
                            new List<string> { "Chosen At Start"}, new List<string>{ "None"}),
                new Pokemon("Charmeleon", 5, true, null, PokemonTypes.Fire, "Evolves at Level 32",
                            new List<string> { "None"}, new List<string>{"Can only be evolved"}),
                new Pokemon("Charizard", 6, true, null, PokemonTypes.Fire| PokemonTypes.Flying, "Does not evolve",
                            new List<string> { "None"}, new List<string>{"Can only be evolved"}),
                new Pokemon("Squirtle", 7, true, null, PokemonTypes.Water , "Evolves at Level 16",
                            new List<string> { "Chosen At Start"}, new List<string>{ "None"}),
                new Pokemon("Wartortle",8, true, null, PokemonTypes.Water, "Evolves at Level 36",
                            new List<string> { "None"}, new List<string>{"Can only be evolved"}),
                new Pokemon("Blastoise", 9, true, null, PokemonTypes.Water, "Does not evolve",
                            new List<string> { "None"}, new List<string>{"Can only be evolved"}),
                new Pokemon("Caterpie", 10, null, null, PokemonTypes.Bug, "Evolves at Level 7",
                            new List<string> { "Viridian Forest ", "Route 24"}, new List<string>{ "None"}),
                new Pokemon("Metapod", 11, null, null, PokemonTypes.Bug, "Evolves at Level 10",
                            new List<string> { "Viridian Forest ", "Route 24"}, new List<string>{ "None"}),
                new Pokemon("Butterfree", 12, null, null, PokemonTypes.Bug, "Does not evolve",
                            new List<string> { "Viridian Forest "}, new List<string>{ "None"}),
                new Pokemon("Weedle", 13, null, null, PokemonTypes.Bug, "Evolves at Level 7",
                            new List<string> { "Viridian Forest ", "Route 24"}, new List<string>{ "None"}),
                new Pokemon("Kakuna", 14, null, null, PokemonTypes.Bug, "Evolves at Level 10",
                            new List<string> { "Viridian Forest ", "Route 24"}, new List<string>{ "None"}),
                new Pokemon("Beedrill", 15, null, null, PokemonTypes.Bug, "Does not evolve",
                            new List<string> { "Viridian Forest "}, new List<string>{ "None"}),
                new Pokemon("Snorlax", 143, true, null, PokemonTypes.Normal, "Does not evolve",
                            new List<string> { "Route 16", "Route 12"}, new List<string>{ "Need pokeflute to wake up"}),
                new Pokemon("Mewtwo", 150, true, true, PokemonTypes.Normal, "Does not evolve",
                            new List<string> { "Unkown Dungeon"}, new List<string>{ "Must be caught with masterball"})
            };
        }
    }
}
