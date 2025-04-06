using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleDotNet.Database.Models;

namespace SampleDotNet.Database
{
    public class SeedData
    {
        public static void Seeder(ModelBuilder modelBuilder)
        {
            var passwordSample = BCrypt.Net.BCrypt.HashPassword("Admin@123");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Uzumaki Naruto",
                    Username = "user1",
                    Password = passwordSample,
                },
                new User
                {
                    Id = 2,
                    Name = "Hayate Kakashi",
                    Username = "user1",
                    Password = passwordSample,
                },
                new User
                {
                    Id = 3,
                    Name = "Uchiha Madara",
                    Username = "user1",
                    Password = passwordSample,
                }
            );
        }
    }
}