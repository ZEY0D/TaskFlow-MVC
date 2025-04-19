using System;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data.Service;

public class TaskService : ITaskService
{
    private readonly ToDoContext _todocontext;
        // injecting the context into the ctr
    public TaskService(ToDoContext todocontext){
        _todocontext = todocontext;

    }

    // include user data when listing tasks
public async Task<IEnumerable<ToDoTask>> GetAllAsync(){
    return await _todocontext.Tasks.Include(t => t.User).ToListAsync();
}
 

    public async Task<ToDoTask?> GetTaskByIdAsync(int id){
        var task = await _todocontext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        return task;
    }

    public async Task AddAsync(ToDoTask task){
        _todocontext.Tasks.Add(task);
        await _todocontext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ToDoTask task){
        _todocontext.Update(task); //ef
        await _todocontext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id){
        var task = await _todocontext.Tasks.FindAsync(id);
        if (task != null){
            _todocontext.Remove(task);
            await _todocontext.SaveChangesAsync();
        }
    }
}
