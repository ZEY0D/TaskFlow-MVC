using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Data.Service;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TasksController : Controller{

    private readonly ITaskService _itaskservice;
    
        // dependency injection
    public TasksController(ITaskService itaskservice){
        _itaskservice = itaskservice;
    }

    




























    // {
    //     private readonly ToDoContext _context;

    //     public TasksController(ToDoContext context)
    //     {
    //         _context = context;
    //     }

    //     // GET: Tasks
    //     public async Task<IActionResult> Index()
    //     {
    //         var toDoContext = _context.Tasks.Include(t => t.User);
    //         return View(await toDoContext.ToListAsync());
    //     }

    //     // GET: Tasks/Details/5
    //     public async Task<IActionResult> Details(int? id)
    //     {
    //         if (id == null)
    //         {
    //             return NotFound();
    //         }

    //         var toDoTask = await _context.Tasks
    //             .Include(t => t.User)
    //             .FirstOrDefaultAsync(m => m.Id == id);
    //         if (toDoTask == null)
    //         {
    //             return NotFound();
    //         }

    //         return View(toDoTask);
    //     }

    //     // GET: Tasks/Create
    //     public IActionResult Create()
    //     {
    //         ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
    //         return View();
    //     }

    //     // POST: Tasks/Create
    //     // To protect from overposting attacks, enable the specific properties you want to bind to.
    //     // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     public async Task<IActionResult> Create([Bind("Id,UserId,Title,IsComplete,DueDate")] ToDoTask toDoTask)
    //     {
    //         if (ModelState.IsValid)
    //         {
    //             _context.Add(toDoTask);
    //             await _context.SaveChangesAsync();
    //             return RedirectToAction(nameof(Index));
    //         }
    //         ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", toDoTask.UserId);
    //         return View(toDoTask);
    //     }

    //     // GET: Tasks/Edit/5
    //     public async Task<IActionResult> Edit(int? id)
    //     {
    //         if (id == null)
    //         {
    //             return NotFound();
    //         }

    //         var toDoTask = await _context.Tasks.FindAsync(id);
    //         if (toDoTask == null)
    //         {
    //             return NotFound();
    //         }
    //         ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", toDoTask.UserId);
    //         return View(toDoTask);
    //     }

    //     // POST: Tasks/Edit/5
    //     // To protect from overposting attacks, enable the specific properties you want to bind to.
    //     // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Title,IsComplete,DueDate")] ToDoTask toDoTask)
    //     {
    //         if (id != toDoTask.Id)
    //         {
    //             return NotFound();
    //         }

    //         if (ModelState.IsValid)
    //         {
    //             try
    //             {
    //                 _context.Update(toDoTask);
    //                 await _context.SaveChangesAsync();
    //             }
    //             catch (DbUpdateConcurrencyException)
    //             {
    //                 if (!ToDoTaskExists(toDoTask.Id))
    //                 {
    //                     return NotFound();
    //                 }
    //                 else
    //                 {
    //                     throw;
    //                 }
    //             }
    //             return RedirectToAction(nameof(Index));
    //         }
    //         ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", toDoTask.UserId);
    //         return View(toDoTask);
    //     }

    //     // GET: Tasks/Delete/5
    //     public async Task<IActionResult> Delete(int? id)
    //     {
    //         if (id == null)
    //         {
    //             return NotFound();
    //         }

    //         var toDoTask = await _context.Tasks
    //             .Include(t => t.User)
    //             .FirstOrDefaultAsync(m => m.Id == id);
    //         if (toDoTask == null)
    //         {
    //             return NotFound();
    //         }

    //         return View(toDoTask);
    //     }

    //     // POST: Tasks/Delete/5
    //     [HttpPost, ActionName("Delete")]
    //     [ValidateAntiForgeryToken]
    //     public async Task<IActionResult> DeleteConfirmed(int id)
    //     {
    //         var toDoTask = await _context.Tasks.FindAsync(id);
    //         if (toDoTask != null)
    //         {
    //             _context.Tasks.Remove(toDoTask);
    //         }

    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(Index));
    //     }

    //     private bool ToDoTaskExists(int id)
    //     {
    //         return _context.Tasks.Any(e => e.Id == id);
    //     }
    // }
}
}