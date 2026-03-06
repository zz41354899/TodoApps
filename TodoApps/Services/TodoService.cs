using Microsoft.EntityFrameworkCore;
using TodoApps.Data;
using TodoApps.Models;

namespace TodoApps.Services;

public class TodoService
{
    private readonly TodoDbContext _context;

    public TodoService(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> GetAllTodosAsync()
    {
        return await _context.TodoItems
            .Include(t => t.SubTasks)
            .Where(t => t.ParentId == null)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<TodoItem?> GetTodoByIdAsync(int id)
    {
        return await _context.TodoItems
            .Include(t => t.SubTasks)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
    
    public async Task<List<TodoItem>> GetSubTasksAsync(int parentId)
    {
        return await _context.TodoItems
            .Where(t => t.ParentId == parentId)
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<TodoItem> CreateTodoAsync(TodoItem todo)
    {
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<TodoItem?> UpdateTodoAsync(TodoItem todo)
    {
        var existing = await _context.TodoItems.FindAsync(todo.Id);
        if (existing == null) return null;

        existing.Title = todo.Title;
        existing.Description = todo.Description;
        existing.IsCompleted = todo.IsCompleted;
        existing.Priority = todo.Priority;
        existing.Category = todo.Category;
        existing.Icon = todo.Icon;
        existing.DueDate = todo.DueDate;
        existing.Tags = todo.Tags;
        existing.IsStarred = todo.IsStarred;
        existing.RecurringType = todo.RecurringType;
        existing.RecurringInterval = todo.RecurringInterval;
        existing.EstimatedMinutes = todo.EstimatedMinutes;
        existing.AssignedTo = todo.AssignedTo;
        existing.Notes = todo.Notes;
        existing.ParentId = todo.ParentId;
        existing.CompletedAt = todo.IsCompleted ? DateTime.Now : null;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteTodoAsync(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id);
        if (todo == null) return false;

        _context.TodoItems.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ToggleCompleteAsync(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id);
        if (todo == null) return false;

        todo.IsCompleted = !todo.IsCompleted;
        todo.CompletedAt = todo.IsCompleted ? DateTime.Now : null;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Dictionary<string, int>> GetStatisticsAsync()
    {
        var total = await _context.TodoItems.CountAsync();
        var completed = await _context.TodoItems.CountAsync(t => t.IsCompleted);
        var pending = total - completed;
        var highPriority = await _context.TodoItems.CountAsync(t => t.Priority == "High" && !t.IsCompleted);

        return new Dictionary<string, int>
        {
            { "Total", total },
            { "Completed", completed },
            { "Pending", pending },
            { "HighPriority", highPriority }
        };
    }
}
