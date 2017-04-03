using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidEF.Standard
{
    public class ToDoContext:DbContext
    {
        public DbSet<ToDoItem > ToDoItems { get; set; }

        private string DatabasePath { get; set; }

        public ToDoContext()
        {

        }

        public ToDoContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
