using Microsoft.EntityFrameworkCore;
using Sazi.EmailComms.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sazi.EmailComms.Infrastructure.Data
{


    public class CommsDBContext : DbContext
    {
        public CommsDBContext(DbContextOptions<CommsDBContext> dbco) : base(dbco) { }
        public DbSet<User>  Users { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

    }
}
