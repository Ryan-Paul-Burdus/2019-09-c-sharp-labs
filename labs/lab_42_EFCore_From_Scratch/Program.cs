using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace lab_42_EFCore_From_Scratch
{
    class Program
    {
        static List<ToDoItem> todos = new List<ToDoItem>();
        static void Main(string[] args)
        {
            using (var db = new ToDoItemContext())
            {
                var todo = new ToDoItem()
                {
                    ToDoItemName = "First task",
                    DateCreated = DateTime.Now
                };
                db.ToDoItems.Add(todo);
                db.SaveChanges();
            }

            System.Threading.Thread.Sleep(1000);
            using (var db = new ToDoItemContext())
            {
                todos = db.ToDoItems.ToList();
            }
            todos.ForEach(todo => Console.WriteLine($"{todo.ToDoItemId, -10}{todo.DateCreated, -20}{todo.ToDoItemName}"));
        }
    }

    class ToDoItem
    {
        public int ToDoItemId { get; set; }
        public string ToDoItemName { get; set; }
        public DateTime DateCreated { get; set; }
    }

    //talk to db
    //NUGET : install-package microsoft.entityframeworkcore 
    //                                                      .Sqllite .SqlServer .Design
    //-v 2.1.1
    class ToDoItemContext : DbContext
    {
        public ToDoItemContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ToDoDatabase;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
