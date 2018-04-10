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
            var message = @"


-- Pokemons
INSERT INTO pokemons
   (ID, NDexId, Name, Type, Legendary, Missable)
      VALUES
   ('{0}', '24', 'Ekans', 'Type', 0, 0),
   ('{1}', '25', 'Pikachu', 'Type', 0, 1),
   ('{2}', '26', 'Raichu', 'Type', 1, 0);



INSERT INTO notes
   (ID, Note)
      VALUES
   ('{0}', 'Found in PalletTown'),
   ('{0}', 'Only in Pokemon Blue'),
   ('{1}', 'Must be caught using Masterball');

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


            return string.Format(message, guid1, guid2, guid3);
        }
    }
}
