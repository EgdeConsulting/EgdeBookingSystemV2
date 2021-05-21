using EgdeBookingSystemV2.Models;
using EgdeBookingSystemV2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EgdeBookingSystemV2.Data
{
    // Seeding av databasen. Kalles på i Program.cs. Kun for testing. Kan fjernes etter behov.
    public class DbInitializer
    {
        public static void Initialize(EgdeBookingSystemConnection context)
        {
            //context.Database.EnsureCreated();

            //if (!context.Categories.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var categories = new Category[]
            {
                new Category { Name = "Tv" },
                new Category { Name = "Mobil" },
                new Category { Name = "PC" },
                new Category { Name = "Sensorer" },
                new Category { Name = "Diverse" }

            };
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }


            var locations = new Location[]
            {
                new Location { Name = "KRS" },
                new Location { Name = "GRM" }
            };

            if (!context.Locations.Any())
            {
                context.Locations.AddRange(locations);
                context.SaveChanges();

            }

            var equipments = new Equipment[]
            {
                new Equipment { 
                    Name = "Iphone X", 
                    Info = "Hasta la vista BABY",
                    ModelNumber = "1500 5151",
                    CategoryID = categories.Single( i => i.ID == 1).ID,
                    LocationID = locations.Single( i => i.ID == 2).ID
                },

                new Equipment { 
                    Name = "Samsung S8", 
                    Info = "Hasta la mista BABY",
                    ModelNumber = "1354648",
                    CategoryID = categories.Single( s => s.Name == "Mobil").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },
                new Equipment { 
                    Name = "LG 40", 
                    Info = "Mellomstor TV",
                    ModelNumber = "1355644648",
                    CategoryID = categories.Single( s => s.Name == "Tv").ID,
                    LocationID = locations.Single( s => s.Name == "GRM").ID
                },

                new Equipment { 
                    Name = "Samsung 70", 
                    Info = "Stor TV",
                    CategoryID = categories.Single( s => s.Name == "Tv").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Iphone S",
                    ModelNumber = "1354 6248",
                    CategoryID = categories.Single( i => i.ID == 1).ID,
                    LocationID = locations.Single( i => i.ID == 2).ID
                },

                new Equipment { 
                    Name = "Samsung S7", 
                    Info = "Gammel mobil",
                    ModelNumber = "1354648",
                    CategoryID = categories.Single( s => s.Name == "Mobil").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "LG 46", 
                    Info = "Mellomstor TV",
                    CategoryID = categories.Single( s => s.Name == "Tv").ID,
                    LocationID = locations.Single( s => s.Name == "GRM").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "111111",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "22222",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "333333",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "4444444",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "555555",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "6666666",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "777777",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                },

                new Equipment { 
                    Name = "Sensor",
                    ModelNumber = "88888",
                    CategoryID = categories.Single( s => s.Name == "Sensorer").ID,
                    LocationID = locations.Single( s => s.Name == "KRS").ID
                }

            };

            if (!context.Equipments.Any())
            {
                context.Equipments.AddRange(equipments);
                context.SaveChanges();
            }

            var bookings = new Booking[]
            {
                new Booking {
                    UserEmail = "test@gmail.com",
                    StartDate = DateTime.Parse("2021-09-01 19:32"),
                    EndDate = DateTime.Parse("2021-09-10 19:33"),
                    EquipmentID = equipments.Single( i => i.ID == 1).ID
                },
                new Booking {
                    UserEmail = "test@gmail.com",
                    StartDate = DateTime.Parse("2020-09-01 19:32"),
                    EndDate = DateTime.Parse("2021-09-10 19:33"),
                    EquipmentID = equipments.Single( i => i.ID == 1).ID
                },
                new Booking {
                    UserEmail = "test@gmail.com",
                    StartDate = DateTime.Parse("2007-09-01 19:32"),
                    EndDate = DateTime.Parse("2007-09-10 19:33"),
                    EquipmentID = equipments.Single( i => i.ID == 1).ID
                },
                new Booking {
                    UserEmail = "test@gmail.com",
                    StartDate = DateTime.Parse("2007-09-01 19:32"),
                    EndDate = DateTime.Parse("2007-09-10 19:33"),
                    EquipmentID = equipments.Single( i => i.ID == 1).ID
                },
                new Booking {
                    UserEmail = "test@gmail.com",
                    StartDate = DateTime.Parse("2007-09-01 19:32"),
                    EndDate = DateTime.Parse("2007-09-10 19:33"),
                    EquipmentID = equipments.Single( i => i.ID == 1).ID
                },
                    new Booking {
                    UserEmail = "test@gmail.com",
                    StartDate = DateTime.Parse("2021-02-01 00:00:00"),
                    EndDate = DateTime.Parse("2021-01-10 00:00:00"),
                    EquipmentID = equipments.Single( i => i.ID == 2).ID
                }



            };


            context.Bookings.AddRange(bookings);
            context.SaveChanges();

            //var bookings = new Booking[]
            //            {
            //                new Booking { UserEmail = "test@email.com", StartDate = DateTime.parse("2021-09-01"), Endate = DateTime.parse("2021-09-01"), EquipmentID = 1 }
            //            };

            //            context.Bookings.AddRange(bookings);
            //            context.SaveChanges();

        }
    }
}
