﻿namespace SqliteBox
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;

    public class Database : DbContext
    {
        public static readonly string FileName = Path.GetFullPath("test.db");

        public Database()
        {
            if (!File.Exists(FileName))
            {
                this.Database.EnsureDeleted();
                this.Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite($"Data Source={FileName}");
        }
 
        public DbSet<Foo> Foos { get; set; }
    }
}