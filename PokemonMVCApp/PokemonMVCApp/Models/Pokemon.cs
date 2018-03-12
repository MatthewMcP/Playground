using System;
namespace PokemonMVCApp.Models
{
    public class Pokemon
    {
        public Pokemon(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }

        public string Id { get; set; }

    }
}
