using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeWebApp.Controllers
{
    public class AjaxController : Controller
    {
        public readonly TaskTrackerDbContext _context;

        // Our constructor.
        public AjaxController(TaskTrackerDbContext context)
        {
            _context = context;
        }

        // GET: /Ajax/Tasks
        public async Task<IActionResult> Tasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Json(tasks);
        }

        // POST: /Ajax/Create
        [HttpPost]
        public async Task<IActionResult> Create(Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return Json(new { Status = "Success" });
        }
    }
}
