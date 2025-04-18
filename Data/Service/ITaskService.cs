using System;
using System.Collections;
using ToDo.Models;

namespace ToDo.Data.Service;

public interface ITaskService
{
    // getting all tasks
    Task<IEnumerable<ToDoTask>> GetAllAsync();
    Task<ToDoTask?> GetTaskByIdAsync(int Id);
    
    Task AddAsync(ToDoTask task);
    Task UpdateAsync(ToDoTask task);
    Task DeleteAsync(int Id);    // delete with id
}
