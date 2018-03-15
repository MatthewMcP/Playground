using System;
namespace PokemonMVCApp.Models
{
    public class Pokemon
    {
        public Pokemon(string name, string id)
        {
            Name = name;
            Id = id;
            EvolutionDetails = "Evolves at 39 on a full moon at the middle of the street";
        }

        public string Name { get; set; }

        //Need to change
        public string Id { get; set; }

        public string EvolutionDetails { get; set; }
    }
}
