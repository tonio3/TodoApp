using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Todolist
{


    public class ModelDbContext : DbContext
    {
        public DbSet<TodoItem> Items { get; set; }
        public string DbPath { get; }
        public ModelDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=TodoItems.db;");
        }
    }


}