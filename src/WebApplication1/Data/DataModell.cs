using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataModell : DbContext
    {

        public DbSet<Member> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<MemberTeam> MemberTeams { get; set; }

        // SQL-Server-Connection
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            /// String für lokale MSSQL Datenbank
			String Connection = @"Data Source = localhost; Initial Catalog = ScrumDB; Integrated Security = True";
            builder.UseSqlServer(Connection);
        }

        // Zusammenhaenge von Entitaeten definieren
        // Default Values definieren
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MemberTeam>().HasKey(t => new { t.MemberId, t.TeamId });
            builder.Entity<MemberTeam>().HasOne(pt => pt.Team).WithMany(p => p.MemberTeams).HasForeignKey(pt => pt.TeamId);
            builder.Entity<MemberTeam>().HasOne(pt => pt.Member).WithMany(t => t.MemberTeams).HasForeignKey(pt => pt.MemberId);
            builder.Entity<Item>().HasOne(c => c.Sprint).WithMany(u => u.Items).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Member>().HasIndex(b => b.Name).IsUnique();
        }
    }
}
