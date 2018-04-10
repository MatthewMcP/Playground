﻿namespace DBConnection
{
    class CreateCommand
    {

        public static string Build_2_Tsql_CreateTables()
        {
            
            return @"

DROP TABLE IF EXISTS notes;
DROP TABLE IF EXISTS pokemons;

DROP TABLE IF EXISTS tabEmployee;
DROP TABLE IF EXISTS tabDepartment;  -- Drop parent table last.


CREATE TABLE pokemons
(
    ID              uniqueidentifier  not null default NewId() PRIMARY KEY ,
    NDexId          int               not null UNIQUE,
    Name            nvarchar(128)     not null,
    Type            nvarchar(128)     not null,
    Legendary       BIT               not null,
    Missable        BIT               not null,
);

CREATE TABLE notes
(
   NoteID       uniqueidentifier    not null default NewId() PRIMARY KEY,
   Note         nvarchar(128)       not null,
   ID           uniqueidentifier    null
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

";
            
        }
    }
}