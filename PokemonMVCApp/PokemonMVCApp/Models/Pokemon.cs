using System;
using System.Collections.Generic;

namespace PokemonMVCApp.Models
{
    public class Pokemon
    {
        public Pokemon()
        {
        }

        public Pokemon(string name,
                       int ndexid,
                       bool? missable,
                       bool? legendary,
                       PokemonTypes pokemontypes,
                       string evolutionDetails,
                       List<string> locations,
                       List<string> notes)
        {
            Name = name;
            Id = new Guid();
            NDexId = ndexid;
            IsLegendary = legendary.HasValue && legendary.Value;
            IsMissable = missable.HasValue && missable.Value;

            //PokemonTypesEnum = pokemontypes;
            Evolutions = new List<string> { evolutionDetails };
            Locations = locations;
            Notes = notes;
        }

        public Guid Id { get; set; }
        public int NDexId { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsMissable { get; set; }

        public string Type1 { get; set; }
        public string Type2 { get; set; }

        // TODO PokemonTypes PokemonTypesEnum { get; set; }         
        public List<string> PokemonTypesList
        {
            get
            {
                /*TODO
                 * List<string> list = new List<string>();
                foreach (Enum value in Enum.GetValues(PokemonTypesEnum.GetType()))
                {
                    if (PokemonTypesEnum.HasFlag(value))
                    {
                        list.Add(value.ToString());
                    }
                }*/

                if (String.IsNullOrWhiteSpace(Type2))
                {
                    return new List<string> { Type1 };
                }
                return new List<string> { Type1, Type2 };
            }
        }


        public List<string> Evolutions { get; set; }

        public List<string> Locations { get; set; }

        public List<string> Notes { get; set; }

        public string ImageClassName
        {
            get
            {
                var temp = NDexId.ToString().PadLeft(3, '0');
                return String.Concat("pkm", temp);
            }
        }
    }
}
