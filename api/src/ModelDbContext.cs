using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class ModelDbContext : DbContext {
    public DbSet<TodoItem> Items { get; set; }
    public string DbPath { get; }
    public ModelDbContext() {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "todolist.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}

public class TodoItem {
    public Int32 Id { get; set; }
    public Boolean IsDone { get; set; }
    public String Name { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}
