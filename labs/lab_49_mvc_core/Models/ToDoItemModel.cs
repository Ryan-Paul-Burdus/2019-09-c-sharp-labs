namespace lab_49_MVC_core
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoItemModel : DbContext
    {
        public ToDoItemModel(DbContextOptions<ToDoItemModel> options)
            : base(options)
        {
            //Database.Delete();
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ToDoItem> ToDoItems { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDoItem>()
                .Property(e => e.Item)
                .IsUnicode(false);

            //One category has many todoItems 
            builder.Entity<Category>().HasMany(t => t.ToDoItems).WithOne(c => c.Category);
            //Category to be seen in lookups for category  : enforce name
            builder.Entity<Category>().Property(c => c.CategoryName).IsRequired();

            //one user : many todos
            builder.Entity<User>().HasMany(t => t.ToDoItems).WithOne(u => u.User);
            //Enforce username
            builder.Entity<User>().Property(u => u.UserName).IsRequired();

            //other way round : one todo item
            builder.Entity<ToDoItem>().HasOne(c => c.Category).WithMany(t => t.ToDoItems);
            builder.Entity<ToDoItem>().HasOne(u => u.User).WithMany(t => t.ToDoItems);

            //description required
            builder.Entity<ToDoItem>().Property(t => t.Item).IsRequired();
        }
    }
}
