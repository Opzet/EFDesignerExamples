using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Threading.Tasks;
using FileBaseContext.Extensions;



// Step 1: Entity Framework Core has come a long way from only supporting Microsoft SQL Server.
//PM > Install-Package Microsoft.EntityFrameworkCore.SqlServer
using Microsoft.EntityFrameworkCore;


namespace Ex1_ModelPerson
{
    public partial class PersonModel : DbContext
    {
        // https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontextoptions

        // In EF Core the configuration system is very flexible,
        // and the connection string could be stored in :
        //  1. appsettings.json,
        //  2. an environment variable,
        //  3. the user secret store,
        //  4. or another configuration source.

        // NUGET Microsoft.EntityFrameworkCore.SqlServer
        //Microsoft SQL Server database provider for Entity Framework Core.
        //partial void CustomInit(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(PersonModel.ConnectionString);
        //}

        /// <summary>
        // NUGET EntityFilesystem
        // using FileBaseContext.Extensions;
        // https://github.com/Opzet/FileBaseContext
        /// FileBaseContext is a provider of Entity Framework Core 8 to store database information in files.
        /// </summary>
        public static string DatabaseName = "my_local_db"; // Will create folder \bin\my_local_db and tables.json files
        private static string SchemaVersion = "1.0"; // Update this version when schema changes
        private static string VersionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseName, "schema_version.txt");


        partial void CustomInit(DbContextOptionsBuilder optionsBuilder)
        {

            if (HasSchemaChanged())
            {
                DeleteOldStore();
                SaveCurrentSchemaVersion();
            }

            if (Debugger.IsAttached)
            {
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
            }
            optionsBuilder.UseFileBaseContextDatabase(databaseName: DatabaseName);
        }

        private bool HasSchemaChanged()
        {
            if (!File.Exists(VersionFilePath))
            {
                return true;
            }

            string storedVersion = File.ReadAllText(VersionFilePath);
            return !storedVersion.Equals(SchemaVersion, StringComparison.OrdinalIgnoreCase);
        }

        public void DeleteOldStore()
        {
            string contextPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseName);

            if (Directory.Exists(contextPath))
            {
                try
                {
                    Directory.Delete(contextPath, true);
                    Console.WriteLine("Old FileBasedContext store deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while deleting the context store: {ex.Message}");
                }
            }
        }

        private void SaveCurrentSchemaVersion()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(VersionFilePath));
            File.WriteAllText(VersionFilePath, SchemaVersion);
        }
    }
}