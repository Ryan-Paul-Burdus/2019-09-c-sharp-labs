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
    }

    public class User
    {
        //public User()
        //{
        //    TaskItems = new HashSet<TaskItem>();
        //}

        public int UserId { get; set; }
        public string UserName { get; set; }

        //public virtual ICollection<TaskItem> TaskItems { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
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
                Database.EnsureCreated();
                Trace.WriteLine("Test data");
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source=ToDoDatabase.db");
        }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
