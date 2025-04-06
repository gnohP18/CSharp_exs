using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleDotNet.Database;
using SampleDotNet.Database.Models;

namespace Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ModelCreating.OnModelCreating(builder);
            SeedData.Seeder(builder);
        }
    }
}