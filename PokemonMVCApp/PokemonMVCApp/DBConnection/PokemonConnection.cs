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
            cb.DataSource = DBConnection.DatabaseConnectionDetails.DataSource;
            cb.UserID = DBConnection.DatabaseConnectionDetails.UserID;
            cb.Password = DBConnection.DatabaseConnectionDetails.Password;
            cb.InitialCatalog = DBConnection.DatabaseConnectionDetails.InitialCatalog;

            string pokemonDetails = @"
                                        SELECT
                                              p.ID,
                                              p.NDexId,
                                              p.Name,
                                              p.Legendary,
                                              p.Missable,   
                                              n.Note
                                         FROM
                                              pokemons as p
                                              LEFT JOIN
                                              notes as n 
                                                ON p.ID = n.ID
                                        ORDER BY
                                              p.NDexId ASC;
                                        ";
            using (var connection = new SqlConnection(cb.ConnectionString))
            {
                connection.Open();

                var pokemonDictionary = new Dictionary<Guid, Pokemon>();
                pokemons = connection.Query<Pokemon, string, Pokemon>(pokemonDetails,
                                                                     (pokemon, note) =>
                {
                    Pokemon pokemonEntry;

                    if (!pokemonDictionary.TryGetValue(pokemon.Id, out pokemonEntry))
                    {
                        pokemonEntry = pokemon;
                        pokemonEntry.Notes = new List<String>();
                        pokemonDictionary.Add(pokemonEntry.Id, pokemonEntry);
                    }

                    pokemonEntry.Notes.Add(note);
                    return pokemonEntry;
                }, splitOn: "note").Distinct().ToList();
            }

            return pokemons;
        }
    }
}
