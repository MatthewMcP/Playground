namespace DBConnection
{
    class CreateCommand
    {

        public static string Build_2_Tsql_CreateTables()
        {
            return @"


DROP TABLE IF EXISTS pokemons;
DROP TABLE IF EXISTS pokemontypes;
DROP TABLE IF EXISTS tabEmployee;
DROP TABLE IF EXISTS tabDepartment;  -- Drop parent table last.

CREATE TABLE pokemons
(
    ID              uniqueidentifier  not null default NewId() PRIMARY KEY ,
    NDexId          int               not null UNIQUE,
    Name            nvarchar(128)     not null,
    Type            nvarchar(128)     not null,
    Legendary       BIT               not null,
    Missible        BIT               not null,
);


CREATE TABLE notes
(
   Id           uniqueidentifier    not null default NewId() PRIMARY KEY,
   Note         nvarchar(128)       not null,
   PokeId       uniqueidentifier    not null,
        REFERENCES pokemons (ID)
);


CREATE TABLE tabDepartment
(
   DepartmentCode  nchar(4)          not null
      PRIMARY KEY,
   DepartmentName  nvarchar(128)     not null
);

CREATE TABLE tabEmployee
(
   EmployeeGuid    uniqueIdentifier  not null  default NewId()
      PRIMARY KEY,
   EmployeeName    nvarchar(128)     not null,
   EmployeeLevel   int               not null,
   DepartmentCode  nchar(4)              null
      REFERENCES tabDepartment (DepartmentCode)  -- (REFERENCES would be disallowed on temporary tables.)
);








CREATE TABLE locations
(
   ID           uniqueidentifier    not null default NewId() PRIMARY KEY,
   Name         nvarchar(128)       not null,
   Code         nvarchar(128)       not null,
   Region       nvarchar(128)       not null,
);

CREATE TABLE pokemons_locations
(
   PokemonID          uniqueidentifier    not null,
   LocationID         uniqueidentifier    not null,
);

";
            
        }
    }
}