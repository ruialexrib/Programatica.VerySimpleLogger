using Microsoft.EntityFrameworkCore;
using Programatica.Framework.Data.Context;
using Programatica.VerySimpleLogger.Data.Models;
using System;
using System.Linq;

//https://snede.net/you-dont-need-a-idesigntimedbcontextfactory/

namespace Programatica.VerySimpleLogger.Data.Migrations.Context
{
    public class AppDbContext : BaseDbContext
    {
        public DbSet<Log> Logs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // disable ManyToMany Cascade Delete
            var fks = modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in fks)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
