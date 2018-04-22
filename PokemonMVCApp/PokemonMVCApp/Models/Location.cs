using System;
namespace PokemonMVCApp.Models
{
    public class Location
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Region { get; set; }
    }
}
