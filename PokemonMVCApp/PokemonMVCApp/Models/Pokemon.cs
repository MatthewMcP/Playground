using System;
using System.Collections.Generic;

namespace PokemonMVCApp.Models
{
    public class Pokemon
    {
        public Pokemon(string name, string id)
        {
            Name = name;
            Id = id;
            EvolutionDetails = "Evolves at 39 on a full moon at the middle of the street";
            PokemonTypesEnum = PokemonTypes.Fighting | PokemonTypes.Poison;
            Locations = new List<string> { "Route 1", "Route 66: Talk to Jessica -> Trade for Abra" };
            Missable = true;
            Legendary = true;
        }

        public string Name { get; set; }

        //Need to change
        public string Id { get; set; }

        public string EvolutionDetails { get; set; }

        public List<string> Locations { get; set; }

        private PokemonTypes PokemonTypesEnum { get; set; }

        public List<string> PokemonTypesList
        {
            get
            {
                List<string> list = new List<string>();
                foreach (Enum value in Enum.GetValues(PokemonTypesEnum.GetType()))
                {
                    if (PokemonTypesEnum.HasFlag(value))
                    {
                        list.Add(value.ToString());
                    }

                }
                return list;
            }
        }

        public bool Legendary { get; set; }

        public bool Missable { get; set; }


    }
}
