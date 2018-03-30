﻿using System;
using System.Data.SqlClient;

namespace DBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "matthewmcp-pokemon.database.windows.net";
                cb.UserID = LoginDetails.username;
                cb.Password = LoginDetails.password;
                cb.InitialCatalog = "PokemonV0.1";

                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connected!");

                    Submit_Tsql_NonQuery(connection, "2 - Create-Tables",
                       CreateCommand.Build_2_Tsql_CreateTables());

                    Submit_Tsql_NonQuery(connection, "3 - Inserts",
                        InsertCommand.Build_3_Tsql_Inserts());

                    /*Submit_Tsql_NonQuery(connection, "4 - Update-Join",
                       Build_4_Tsql_UpdateJoin(),
                       "@csharpParmDepartmentName", "Accounting");

                    Submit_Tsql_NonQuery(connection, "5 - Delete-Join",
                       Build_5_Tsql_DeleteJoin(),
                       "@csharpParmDepartmentName", "Legal");

    */

                    Submit_6_Tsql_SelectEmployees(connection);

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("View the report output here, then press any key to end the program...");
            Console.ReadKey();

        }

        static  string Build_6_Tsql_SelectEmployees()
        {
            return @"
-- Look at all the final Employees.
SELECT
      empl.EmployeeGuid,
      empl.EmployeeName,
      empl.EmployeeLevel,
      empl.DepartmentCode,
      dept.DepartmentName
   FROM
      tabEmployee   as empl
      LEFT OUTER JOIN
      tabDepartment as dept ON dept.DepartmentCode = empl.DepartmentCode
   ORDER BY
      EmployeeName;
";
        }



        static void Submit_Tsql_NonQuery(
         SqlConnection connection,
         string tsqlPurpose,
         string tsqlSourceCode,
         string parameterName = null,
         string parameterValue = null
         )
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("T-SQL to {0}...", tsqlPurpose);

            using (var command = new SqlCommand(tsqlSourceCode, connection))
            {
                if (parameterName != null)
                {
                    command.Parameters.AddWithValue(  // Or, use SqlParameter class.
                       parameterName,
                       parameterValue);
                }
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " = rows affected.");
            }
        }

        static void Submit_6_Tsql_SelectEmployees(SqlConnection connection)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Now, SelectEmployees (6)...");

            string tsql = Build_6_Tsql_SelectEmployees();

            using (var command = new SqlCommand(tsql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} , {1} , {2} , {3} , {4}",
                           reader.GetGuid(0),
                           reader.GetString(1),
                           reader.GetInt32(2),
                           (reader.IsDBNull(3)) ? "NULL" : reader.GetString(3),
                           (reader.IsDBNull(4)) ? "NULL" : reader.GetString(4));
                    }
                }
            }
        }
    } // EndOfClass
}
