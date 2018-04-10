using System;
namespace DBConnection
{
    public class InsertCommand
    {
        public static string Build_3_Tsql_Inserts()
        {
            return @"


-- Pokemons
INSERT INTO pokemons
   (NDexId, Name, Type, Legendary, Missible)
      VALUES
   ('24', 'Ekans', 'Type', 0, 0),
   ('25', 'Pikachu', 'Type', 0, 0),
   ('26', 'Raichu', 'Type', 1, 0);


INSERT INTO pokemons
   (NDexId, Name, Type, Legendary, Missible)
      VALUES
   ('24', 'Ekans', 'Type', 0, 0),
   ('25', 'Pikachu', 'Type', 0, 0),
   ('26', 'Raichu', 'Type', 1, 0);

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
            
        }
    }
}
