using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EgdeBookingSystemV2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgdeBookingSystemV2.Data
{
    public class EgdeBookingSystemConnection : IdentityDbContext
    {
        public EgdeBookingSystemConnection()
        {
        }

        // Setter opp tabellene gitt av DbSet som tabeller i databasen. Reflekterer modellene i mappen models.
        public EgdeBookingSystemConnection(DbContextOptions<EgdeBookingSystemConnection> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Location> Locations { get; set; }
    }

}