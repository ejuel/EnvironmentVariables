// <copyright file="GameData.cs" company="ejuel.net">
//     ejuel.net All rights reserved.
// </copyright>
// <author>Ezekiel Juel</author>
using System;
using System.Collections.Generic;

//Should be run when building new environment (Dev, Staging, Production, etc.) to set environment variabls
// Preparation, you should have a SQL database set up with tblEnvironmentVariables (fstrVariable, fblnActive, fstrDefaultValue, fstrDescription) to populate from

//Note: Feel free to modify code and replace SQL/tblEnvironmentVariables to support other database types

namespace Program
{
    using ZkEnvironment;
    internal class Program
    {
        private static void Main(string[] args)
        {
            string userInput;
            zkEnvironmentSetup objSetup = new zkEnvironmentSetup();

            Console.WriteLine("Code called manually to verify environment variables or initialize for deployment");

            string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
            if (connectionString is null)
            {

                connectionString = GetConnectionString();
                Environment.SetEnvironmentVariable("SQL_CONNECTION_STRING", connectionString);
            }
            else
            {
                Console.WriteLine("SQL Connection string is set to '{0}', is this correct? (y/n)", connectionString);
                userInput = Console.ReadLine();
                if (!userInput.ToUpper()[0].Equals("Y"))
                {
                    connectionString = GetConnectionString();
                }
            }

            //ToDo: Check SQL for table containing list of global parameters needed by larger project.

            //ToDo: Get variable list from SQL table (tblEnvironmentVariables should contain fstrVariable, fblnActive, fstrDefaultValue, fstrDescription

            //
            Console.WriteLine("How would you like to import variables? (default is 'A')");
            Console.WriteLine("A: Automatic - Quickly add/remove environmental variables and set them to table default values");
            Console.WriteLine("M: Manual    - Manually review every table variable regardless of changes (Yes, No, Custom)");
            Console.WriteLine("S: Semi-Auto - If variable is new or changes system prompts user to verify change with (Yes, No)");
            //ToDo: Create EnvirnmentVariables classes that are called for each of the above options

            Dictionary<string, bool> userOptions = new Dictionary<string, bool>
            {
                //ToDo: possibly replace bool with environment variables
                { "A", true },
                { "M", true },
                { "S", true }
            };
            do
            {
                Console.Write("User action: ");
                userInput = Console.ReadLine();

            } while (!userOptions.ContainsKey(userInput[0].ToString().ToUpper()));





        }

        private static string GetConnectionString()
        {
            string connectionString = "";
            bool validConnectionString = false;

            do
            {
                //ToDo: replace WriteLine and ReadLine with my CS_SQL class ManualConnectionString function to set connection string
                Console.WriteLine("SQL Connection String has not been set, please enter the connection string:");
                connectionString = Console.ReadLine();

                //ToDo: Verify connection string is valid
                validConnectionString = (connectionString.Length > 0);

            } while (!validConnectionString);

            return connectionString;
        }
    }
}
