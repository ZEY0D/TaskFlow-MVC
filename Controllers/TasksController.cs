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

    

    // view all tasks
    public async Task<IActionResult> Index(){
        var Tasks = await _itaskservice.GetAllAsync();
        return View(Tasks);
    }

    // view a specific task with id 
    public async Task<IActionResult> Details(int? id){
        if (id == null)
            return NotFound();

        var task =await _itaskservice.GetTaskByIdAsync(id.Value);
        if (task == null)
            return NotFound();

        return View(task);
    }


    // GET to get the view of data filling
    public IActionResult Create(){
        return View();
    }

    // POST to add a task to the database
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ToDoTask todotask){
        if(ModelState.IsValid){
            await _itaskservice.AddAsync(todotask);
            // after successfully added, return to the view of showing all tasks
            return RedirectToAction("Index");
        }
        // return the same view to enter a valid task
        return View(todotask);  // get back to the same filled form so the user fills it correctly
    }


    // GET to get the task to be edited by id
        // same as getting the task by id
    public async Task<IActionResult> Edit(int? id){
        if (id == null)
            return NotFound();

        var task =await _itaskservice.GetTaskByIdAsync(id.Value);
        if (task == null)
            return NotFound();

        return View(task);
    }


    // POST to save changes to the modified task
    [HttpPost]
    [ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, ToDoTask task)
{
    if (id != task.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        await _itaskservice.UpdateAsync(task);
        return RedirectToAction("Index");
    }

    return View(task);
}



// Get to show the task to be deleted 
public async Task<IActionResult> Delete(int? id){
    if (id == null) return  NotFound();

    var task = await _itaskservice.GetTaskByIdAsync(id.Value);
    if (task == null) return NotFound();
    return View(task);
}



// POST to apply the change and actually delete the task
    // action name to avoid conflict
[HttpPost, ActionName ("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id){
    await _itaskservice.DeleteAsync(id);
    return RedirectToAction("Index");
}
}
}