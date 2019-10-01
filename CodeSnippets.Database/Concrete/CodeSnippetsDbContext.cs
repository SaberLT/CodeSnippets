using CodeSnippets.Database.Repositories;
using CodeSnippets.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CodeSnippets.Database.Concrete
{
    public class CodeSnippetsDbContext : DbContext
    {
        public CodeSnippetsDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connection = "server=localhost;UserId=root;Password=root;database=CodeSnippets";
            
            options.UseMySQL(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodeSnippetsDbContext).Assembly);
        }

    }
}
