using System;
using System.Collections.Generic;

namespace DBConnection
{
    public class pokemons
    {

        public pokemons(){
            
        }
        public pokemons(string name,
                       string id,
                       bool? missable,
                       bool? legendary,
                       string evolutionDetails,
                       List<string> locations,
                       List<string> notes)
        {
            Name = name;
            Id = id;
            Missable = missable.HasValue && missable.Value;
            Legendary = legendary.HasValue && legendary.Value;
            EvolutionDetails = evolutionDetails;
            Locations = locations;
            Notes = notes;
        }

        public string Name { get; set; }

        //Need to change
        public string Id { get; set; }

        public bool Legendary { get; set; }

        public bool Missable { get; set; }

        public string ImageClassName
        {
            get
            {
                var temp = Id.PadLeft(3, '0');
                return String.Concat("pkm", temp);
            }
        }

        string PokemonTypesEnum { get; set; }

        public List<string> PokemonTypesList
        {
            get
            {
                List<string> list = new List<string>();
                return list;
            }
        }

        public string EvolutionDetails { get; set; }

        public List<string> Locations { get; set; }

        public List<string> Notes { get; set; }
    }
}
