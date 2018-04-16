using System;
namespace DBConnection
{
    public class InsertCommand
    {
        public static string Build_3_Tsql_Inserts()
        {

            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();
            var guid11 = Guid.NewGuid();
            var guid12 = Guid.NewGuid();
            var guid13 = Guid.NewGuid();
            var message = @"


-- Pokemons
INSERT INTO pokemons
   (ID, NDexId, Name, Type, Legendary, Missable)
      VALUES
   ('{0}', '24', 'Ekans', 'Type', 0, 0),
   ('{1}', '25', 'Pikachu', 'Type', 0, 1),
   ('{2}', '26', 'Raichu', 'Type', 1, 0);

INSERT INTO notes
   (ID, NoteText)
      VALUES
   ('{0}', 'Found in PalletTown'),
   ('{0}', 'Only in Pokemon Blue'),
   ('{1}', 'Must be caught using Masterball');

INSERT INTO locations
   (ID, Name, Code, Region)
      VALUES
   ('{2}', 'Route 001', 'R.001', 'Kanto'),
   ('{3}', 'Route 420', 'R.420', 'Kanto'),
   ('{4}', 'Route 069', 'R.069', 'Kanto');

INSERT INTO pokemons_locations
   (PokemonID, LocationID)
      VALUES
   ('{0}', '{3}'),
   ('{0}', '{4}'),
   ('{1}', '{3}');

-- The company has these departments.
INSERT INTO tabDepartment
   (DepartmentCode, DepartmentName)
      VALUES
   ('acct', 'Accounting'),
   ('hres', 'Human Resources'),
   ('legl', 'Legal');

-- The company has these employees, each in one department.
INSERT INTO tabEmployee
   (EmployeeName, EmployeeLevel, DepartmentCode)
      VALUES
   ('Alison'  , 19, 'acct'),
   ('Barbara' , 17, 'hres'),
   ('Carol'   , 21, 'acct'),
   ('Deborah' , 24, 'legl'),
   ('Elle'    , 15, null);
";


            return string.Format(message, guid1, guid2, guid3, guid11, guid12, guid13);
        }
    }
}
