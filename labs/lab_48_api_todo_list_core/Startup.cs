using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace lab_48_api_todo_list_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaskItemContext>(); // (options => options.UseSqlite("Data Source=ToDoDatabase.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class TaskItem
    {
        public int TaskItemId { get; set; }
        //data annotations
        [Required]
        public string Description { get; set; }
        public bool? TaskDone { get; set; }

        [Display(Name="Date Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateDue { get; set; }

        //foreign key, int? means it can be null
        public int? UserId { get; set; } //field
        public virtual User User { get; set; } // table

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }


        //public User()
        //{
        //    TaskItems = new HashSet<TaskItem>();
        //}
        //public virtual ICollection<TaskItem> TaskItems { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //public Category()
        //{
        //    TaskItems = new HashSet<TaskItem>();
        //}

        //public virtual ICollection<TaskItem> TaskItems { get; set; }
    }

    public class TaskItemContext : DbContext
    {
        private static bool _dbCreated = false;
        public TaskItemContext()
        {
            if (!_dbCreated)
            {
                _dbCreated = true;
                //Database.EnsureDeleted();
                //Database.EnsureCreated();
                Trace.WriteLine("Test data");
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source=ToDoDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Category1" },
                new Category { CategoryId = 2, CategoryName = "Category2" },
                new Category { CategoryId = 3, CategoryName = "Category3" });

            builder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "User1" },
                new User { UserId = 2, UserName = "User2" },
                new User { UserId = 3, UserName = "User3" },
                new User { UserId = 4, UserName = "User4" });

            builder.Entity<TaskItem>().HasData(
                new TaskItem { TaskItemId = 1, Description = "Study", DateDue = DateTime.Parse("11/10/2019"), TaskDone = false, CategoryId = 2, UserId = 1},
                new TaskItem { TaskItemId = 2, Description = "Work", DateDue = DateTime.Parse("10/10/2019"), TaskDone = false, CategoryId = 3, UserId = 3},
                new TaskItem { TaskItemId = 3, Description = "Do nothing", DateDue = DateTime.Parse("12/10/2019"), TaskDone = false, CategoryId = 1, UserId = 4});

        }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
