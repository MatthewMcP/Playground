using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using PokemonMVCApp.Models;

namespace PokemonMVCApp.DBConnections
{
    public class PokemonConnection : IPokemonConnection
    {



        public List<Pokemon> GetAllPokemon()
        {
            var pokemons = new List<Pokemon>();
            //TODO: All of this
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "matthewmcp-pokemon.database.windows.net";
            cb.UserID = "userid";
            cb.Password = @"password";
            cb.InitialCatalog = "PokemonV0.1";

            string pokemonDetails = "SELECT * FROM pokemons;";

            using (var connection = new SqlConnection(cb.ConnectionString))
            {
                connection.Open();

                pokemons = connection.Query<Pokemon>(pokemonDetails).ToList();
            }

            return pokemons;
        }
    }
}
