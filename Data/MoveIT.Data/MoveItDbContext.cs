using System;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MoveIT.Core.Models;

namespace MoveIT.Data
{
    public class MoveItDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<MovingProposal> MovingProposals { get; set; }

        public DbSet<Order> Orders { get; set; }

        public MoveItDbContext(DbContextOptions<MoveItDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName.StartsWith(Configuration.IdentityTablePrefix))
                    entity.SetTableName(tableName.Substring(Configuration.IdentityTablePrefix.Length));
            }
            
            modelBuilder.Entity<MovingProposal>().ToTable(Configuration.Tables.MovingProposals);
            modelBuilder.Entity<Order>().ToTable(Configuration.Tables.Orders);
        }
    }
}
