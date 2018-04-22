using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using PokemonMVCApp.Models;
using static Dapper.SqlMapper;

namespace PokemonMVCApp.DBConnections
{
    public class PokemonConnection : IPokemonConnection
    {
        List<Pokemon> IPokemonConnection.GetAllPokemon()
        {
            var allPokemon = new List<Pokemon>();

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
                                              p.Type1,   
                                              p.Type2,   
                                              n.NoteId,
                                              n.NoteText,
                                              e.EvolutionText,
                                              locations.Name,
                                              locations.Region
                                         FROM
                                              pokemons as p
                                              LEFT JOIN
                                                notes as n
                                                ON p.ID = n.ID
                                              LEFT JOIN
                                                evolutions as e
                                                ON p.ID = e.ID
                                              LEFT OUTER JOIN pokemons_locations                                                     ON p.ID = pokemons_locations.PokemonID                                               LEFT OUTER JOIN locations                                                     ON pokemons_locations.LocationID = locations.ID
                                        ORDER BY
                                              p.NDexId ASC;
                                        ";


            using (var connection = new SqlConnection(cb.ConnectionString))
            {
                connection.Open();
                var noteDictionary = new Dictionary<Guid, Pokemon>();
                var locDictionary = new Dictionary<Guid, Pokemon>();
                var evoDictionary = new Dictionary<Guid, Pokemon>();

                allPokemon = connection.Query<Pokemon, string, string, string, Pokemon>(pokemonDetails,
                                                                                       (pokemon, NoteText, LocationName, EvolutionText) =>
                                                                     {
                                                                         Pokemon pokemonEntry;

                                                                         if (!noteDictionary.TryGetValue(pokemon.Id, out pokemonEntry))
                                                                         {
                                                                             pokemonEntry = pokemon;
                                                                             pokemonEntry.Notes = new List<String>();
                                                                             noteDictionary.Add(pokemon.Id, pokemonEntry);
                                                                         }
                                                                         //TODO Find a better way
                                                                         if (!pokemonEntry.Notes.Contains(NoteText))
                                                                         {
                                                                             pokemonEntry.Notes.Add(NoteText);
                                                                         }


                                                                         if (!locDictionary.TryGetValue(pokemon.Id, out pokemonEntry))
                                                                         {
                                                                             pokemonEntry = pokemon;
                                                                             pokemonEntry.Locations = new List<String>();
                                                                             locDictionary.Add(pokemon.Id, pokemonEntry);
                                                                         }
                                                                         //TODO Find a better way
                                                                         if (!pokemonEntry.Locations.Contains(LocationName))
                                                                         {
                                                                             pokemonEntry.Locations.Add(LocationName);
                                                                         }


                                                                         if (!evoDictionary.TryGetValue(pokemon.Id, out pokemonEntry))
                                                                         {
                                                                             pokemonEntry = pokemon;
                                                                             pokemonEntry.Evolutions = new List<String>();
                                                                             evoDictionary.Add(pokemon.Id, pokemonEntry);
                                                                         }
                                                                         //TODO Find a better way
                                                                         if (!pokemonEntry.Evolutions.Contains(EvolutionText))
                                                                         {
                                                                             pokemonEntry.Evolutions.Add(EvolutionText);
                                                                         }


                                                                         return pokemonEntry;

                }, splitOn: "Name, NoteText, EvolutionText").Distinct().ToList();



                return allPokemon;
            }
        }
    }
}


/* Should use something like below but having issues with multiple tables
 * 
 * 
 *                 pokemons = connection.Query<Pokemon, string, Pokemon>(pokemonDetails,
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
*/