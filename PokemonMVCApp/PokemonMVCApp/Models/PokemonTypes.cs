using System;
namespace PokemonMVCApp.Models
{
    [Flags] 
    public enum PokemonTypes
    {
        Normal = 1,
        Fire = 2,
        Fighting = 4,
        Water = 8,
        Flying = 16,
        Poison = 32,
        Grass = 64
    }
}
