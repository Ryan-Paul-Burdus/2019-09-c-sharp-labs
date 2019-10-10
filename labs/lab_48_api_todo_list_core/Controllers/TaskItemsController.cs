using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab_48_api_todo_list_core;
using System.Diagnostics;
using System.Threading;

namespace lab_48_api_todo_list_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly TaskItemContext _context;

        public TaskItemsController(TaskItemContext context)
        {
            _context = context;
        }

        // GET: api/TaskItems
        [HttpGet]
        public List<TaskItem> GetTaskItems()
        {
            //var u = new User()
            //{
            //    UserName = "SpartanExtrodianaire"
            //};
            //_context.Add<User>(u);

            //var t = new TaskItem()
            //{
            //    Description = "An Item",
            //    DateDue = DateTime.Parse("21/09/2019"),
            //    TaskDone = false,
            //    UserId = u.UserId
            //};
            //_context.Add<TaskItem>(t);

            //var c = new Category()
            //{
            //    CategoryName = "Category1"
            //};
            //_context.Add<Category>(c);

            //_context.SaveChanges();
            //Trace.WriteLine($"Added a record with id: {t.TaskItemId}, user: {u.UserName}, Category: {c.CategoryId}");
            ////return "You reached this point";
            return _context.TaskItems.ToList();
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return Ok(taskItem);
        }

        // PUT: api/TaskItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem([FromRoute] int id, [FromBody] TaskItem taskItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskItem.TaskItemId)
            {
                return BadRequest();
            }

            _context.Entry(taskItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskItems
        [HttpPost]
        public async Task<IActionResult> PostTaskItem([FromBody] TaskItem taskItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskItem", new { id = taskItem.TaskItemId }, taskItem);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return Ok(taskItem);
        }

        private bool TaskItemExists(int id)
        {
            return _context.TaskItems.Any(e => e.TaskItemId == id);
        }
    }
}