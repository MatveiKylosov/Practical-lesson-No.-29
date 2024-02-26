using Microsoft.EntityFrameworkCore;
using Practical_lesson_No._29.Classes.Common;
using Practical_lesson_No._29.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_lesson_No._29.Classes
{
    public class ClubsContext : DbContext
    {
        public DbSet<Clubs> Clubs { get; set; }
        public ClubsContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
    }
}
