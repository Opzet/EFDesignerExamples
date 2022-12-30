using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using Ex7_Mvp.Models;


namespace Ex7_Mvp._Repositories
{
    // Adapted from https://github.com/RJCodeAdvance/CRUD-MVP-C-SHARP-SQL-WINFORMS-PART-3-FINAL

    // MVP Design Pattern for winform
    // ------------------------------
    //<Db Crud <- Model> Presenter layer [Interface] (Wire up Model <-> Gui Controls) based upon events  <Model<-View Events> [GUI] fire Events
    // Model: [Datacontext] 
    // Pesenter: Wire up Model and View together,
    // Interface: events fire CRUD methods in repository
    // View: GUI A passive view 

    //1. Don't depend on classes
    // If you want to have your code testable, depend on interface that is implemented by a class.
    public class PetRepository : IPetRepository
    {
        //Constructor
        public PetRepository()
        {
            using (EFContainer db = new EFContainer())
            {
                db.Database.Log = Logger.Log;
               
                if (!db.Database.Exists())
                {
                    //Initalises just first time
                    DeleteandSeed();
                }
                
            }
        }

        public void DeleteandSeed()
        {
            using (EFContainer db = new EFContainer())
            {
                db.Database.Log = Logger.Log;

                //Reset Database
                if (db.Database.Exists())
                {
                    db.Database.Delete();
                    Console.WriteLine("Deleted DB\r\n");
                }

                db.Database.Create();
                Console.WriteLine("Created DB\r\n");

                Console.WriteLine(db.Database.Connection.ConnectionString);
            }

            SeedData();

        }

        public class Logger
        {
            //TO DO Show in text box on screen

            public static void Log(string message)
            {
                Console.WriteLine("EF Message: {0} ", message);
            }
        }
        void SeedData()
        {
            using (EFContainer db = new EFContainer())
            {
                List<PetModel> Pets = new List<PetModel>
                {
                    new PetModel{Name= "Buttons", Type = "Dog", Colour = "White"},
                    new PetModel{Name= "Coda", Type = "Cat", Colour = "Multicolor"},
                    new PetModel{Name= "Merlin", Type = "Parrot", Colour = "Green-Yellow"},
                    new PetModel{Name= "Nina", Type = "Turtle", Colour = "Dark Gray"},
                    new PetModel{Name= "Luna", Type = "Rabbit", Colour = "White"},
                    new PetModel{Name= "Domino", Type = "Hamster", Colour = "Orange"},
                    new PetModel{Name= "Lucy", Type = "Monkey", Colour = "Brown"},
                    new PetModel{Name= "Daysi", Type = "Horse", Colour = "White"},
                    new PetModel{Name= "Zoe", Type = "Snake", Colour = "Yellow white"},
                    new PetModel{Name= "Max", Type = "Budgie", Colour = "Yellow"},
                    new PetModel{Name= "Charlie", Type = "Mouse", Colour = "White"},
                    new PetModel{Name= "Rocky", Type = "Squirrel", Colour = "Brown-Orange"},
                    new PetModel{Name= "Leo", Type = "Dog", Colour = "White-Black"},
                    new PetModel{Name= "Loki", Type = "Cat", Colour = "Black"},
                    new PetModel{Name= "Jasper", Type = "Dog", Colour = "Silver"},
                    
                };

                foreach (PetModel p in Pets)
                {
                    PetModel pet = db.PetModels.Create();
                    pet.Name = p.Name;
                    pet.Type = p.Type;
                    pet.Colour = p.Colour;

                    db.PetModels.Add(pet);
                    Console.WriteLine($"Added Pet: {pet.Name}");
                }
                //'PK_dbo.PetModels'. Cannot insert duplicate key in object 'dbo.PetModels'. The duplicate key value is (0).

                db.SaveChanges();
                Console.WriteLine("Saved seed data to Db ok");
            }
        }


                //Methods
        public void Add(PetModel petModel)
        {
            using (EFContainer db = new EFContainer())
            {
                db.PetModels.Add(petModel);
                db.SaveChanges();
            }
            //using (var connection = new SqlConnection(connectionString))
            //using (var command = new SqlCommand())
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandText = "insert into Pet values (@name, @type, @colour)";
            //    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petModel.Name;
            //    command.Parameters.Add("@type", SqlDbType.NVarChar).Value = petModel.Type;
            //    command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = petModel.Colour;
            //    command.ExecuteNonQuery();
            //}
        }
        public void Delete(long id)
        {
            using (EFContainer db = new EFContainer())
            {
                //PetModel pet = db.PetModels.FirstOrDefault(p => p.Id == id);
                PetModel pet = db.PetModels.Find(id);
                db.PetModels.Remove(pet);
                db.SaveChanges();
            }

            //using (var connection = new SqlConnection(connectionString))
            //using (var command = new SqlCommand())
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandText = "delete from Pet where Pet_Id=@id";
            //    command.Parameters.Add("@id", SqlDbType.Int).Value = id;           
            //    command.ExecuteNonQuery();
            //}
        }
        public void Edit(PetModel pet)
        {
            using (EFContainer db = new EFContainer())
            {
                PetModel petinDb = db.PetModels.Find(pet.Id);
                petinDb.Name = pet.Name;
                petinDb.Type = pet.Type;
                petinDb.Colour = pet.Colour;
                db.SaveChanges();
            }

            //using (var connection = new SqlConnection(connectionString))
            //using (var command = new SqlCommand())
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandText = @"update Pet 
            //                            set Pet_Name=@name,Pet_Type= @type,Pet_Colour= @colour 
            //                            where Pet_Id=@id";
            //    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petModel.Name;
            //    command.Parameters.Add("@type", SqlDbType.NVarChar).Value = petModel.Type;
            //    command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = petModel.Colour;
            //    command.Parameters.Add("@id", SqlDbType.Int).Value = petModel.Id;
            //    command.ExecuteNonQuery();
            //}
        }

        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();
            using (EFContainer db = new EFContainer())
            {
                petList = db.PetModels.ToList();
            }
            //using (var connection = new SqlConnection(connectionString))
            //using (var command = new SqlCommand())
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandText = "Select *from Pet order by Pet_Id desc";
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var petModel = new PetModel();
            //            petModel.Id = (int)reader[0];
            //            petModel.Name = reader[1].ToString();
            //            petModel.Type = reader[2].ToString();
            //            petModel.Colour = reader[3].ToString();
            //            petList.Add(petModel);
            //        }
            //    }
            //}
            return petList;
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            List<PetModel> petList = new List<PetModel>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            using (EFContainer db = new EFContainer())
            {
                // Query for all pets that match value in any field
                var enumpetList = from b in db.PetModels
                                  where
                                  (
                                        b.Id == petId 
                                        || b.Name.ToUpper().Contains(value.ToUpper())
                                        || b.Type.ToUpper().Contains(value.ToUpper()) 
                                        || b.Colour.ToUpper().Contains(value.ToUpper())
                                   )
                                   select b;

                petList = enumpetList.ToList();
            }
             //string petName = value;
            //using (var connection = new SqlConnection(connectionString))
            //using (var command = new SqlCommand())
            //{
            //    connection.Open();
            //    command.Connection = connection;
            //    command.CommandText = @"Select *from Pet
            //                            where Pet_Id=@id or Pet_Name like @name+'%' 
            //                            order by Pet_Id desc";
            //    command.Parameters.Add("@id", SqlDbType.Int).Value = petId;
            //    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petName;

            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var petModel = new PetModel();
            //            petModel.Id = (int)reader[0];
            //            petModel.Name = reader[1].ToString();
            //            petModel.Type = reader[2].ToString();
            //            petModel.Colour = reader[3].ToString();
            //            petList.Add(petModel);
            //        }
            //    }
            //}
            return petList;
        }
    }
}
