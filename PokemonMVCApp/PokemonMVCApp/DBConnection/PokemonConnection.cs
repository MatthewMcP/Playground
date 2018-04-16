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
                                              n.Note,
                                              locations.Name
                                         FROM
                                              pokemons as p
                                              LEFT JOIN
                                              notes as n 
                                                ON p.ID = n.ID
                                              LEFT OUTER JOIN pokemons_locations                                                     ON p.ID = pokemons_locations.PokemonID                                               LEFT OUTER JOIN locations                                                     ON pokemons_locations.LocationID = locations.ID
                                        ORDER BY
                                              p.NDexId ASC;
                                        ";

            using (var connection = new SqlConnection(cb.ConnectionString))
            {
                connection.Open();

                var results = connection.QueryMultiple(@"Select
                                                          p.ID,
                                                          p.NDexId,
                                                          p.Name,
                                                          p.Legendary,
                                                          p.Missable from pokemons as p; 
                                                select * from notes; 
                                                select * from locations;
                                                select * from pokemons_locations");
                var notes = results.Read<Notedd>();
                var pokemons = results.Read<Pokemon>();
                var locations = results.Read<Location>();
                var pokeLocations = results.Read<PokemonLocations>();


                foreach (Pokemon poke in pokemons)
                {
                    foreach (Notedd note in notes)
                    {
                        if (note.Id == poke.Id)
                        {
                            poke.AddNote(note.Note);
                        }
                    }

                    foreach (PokemonLocations pokelocation in pokeLocations)
                    {
                        if (pokelocation.PokemonID == poke.Id)
                        {
                            foreach (Location loc in locations)
                            {
                                if (pokelocation.LocationID == loc.Id)
                                {
                                    poke.AddLocations(loc.Name);
                                }
                            }
                        }
                    }

                    allPokemon.Add(poke);
                }
            }

            return allPokemon;
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