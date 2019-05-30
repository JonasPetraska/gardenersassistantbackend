using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garden.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Common.Models.Garden> Gardens { get; set; }
        public virtual DbSet<Common.Models.Location> Locations { get; set; }
        public virtual DbSet<Common.Models.Worker> Workers { get; set; }
        public virtual DbSet<Common.Models.Owner> Owners { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
