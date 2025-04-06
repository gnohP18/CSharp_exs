using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleDotNet.Database.Models;

namespace SampleDotNet.Database
{
    public static class ModelCreating
    {
        public static ModelBuilder OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.Property<string>(entity => entity.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .IsRequired(true);

                entity.Property<string>(entity => entity.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .IsRequired(true);

                entity.Property<string>(entity => entity.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .IsRequired(true);
            });

            return builder;
        }
    }
}