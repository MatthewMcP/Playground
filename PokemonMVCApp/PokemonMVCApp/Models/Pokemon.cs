﻿using System;
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
            Missable = missable.HasValue && missable.Value;
            Legendary = legendary.HasValue && legendary.Value;
            PokemonTypesEnum = pokemontypes;
            //EvolutionDetails = evolutionDetails;
            //Locations = locations;
            //Notes = notes;
        }

        public Guid Id { get; set; }
        public int NDexId { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public bool Legendary { get; set; }
        public bool Missable { get; set; }

        public string ImageClassName
        {
            get
            {
                var temp = NDexId.ToString().PadLeft(3, '0');
                return String.Concat("pkm", temp);
            }
        }

        PokemonTypes PokemonTypesEnum { get; set; }

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

                return new List<string> { "Electric" };
                //return list;
            }
        }

        public string EvolutionDetails
        {
            get
            {
                return "Evolves at Level 10";
            }
        }

        public List<string> Locations
        {
            get
            {
                return new List<string> { "Viridian Forest " };
            }
        }

        public List<string> Notes { get; set; }
       /* {
            get { return new List<string> { "Viridian Forest Notes " }; }

        }*/
    }
}
