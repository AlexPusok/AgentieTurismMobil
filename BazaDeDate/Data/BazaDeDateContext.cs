using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BazaDeDate.Models;

namespace BazaDeDate.Data
{
    public class BazaDeDateContext : DbContext
    {
        public BazaDeDateContext (DbContextOptions<BazaDeDateContext> options)
            : base(options)
        {
        }

        public DbSet<BazaDeDate.Models.User> User { get; set; } = default!;
        public DbSet<BazaDeDate.Models.Vacation> Vacation { get; set; } = default!;
        public DbSet<BazaDeDate.Models.Booking> Booking { get; set; } = default!;
    }
}
