namespace TodoApps.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? CompletedAt { get; set; }
    public string Priority { get; set; } = "Medium";
    public string? Category { get; set; }
    public string Icon { get; set; } = "📝";
    
    // 進階功能欄位
    public DateTime? DueDate { get; set; }
    public string? Tags { get; set; }
    public bool IsStarred { get; set; }
    public string? RecurringType { get; set; }
    public int? RecurringInterval { get; set; }
    public string? AssignedTo { get; set; }
    public int EstimatedMinutes { get; set; }
    public string? Notes { get; set; }
    
    // 子任務階層
    public int? ParentId { get; set; }
    public TodoItem? Parent { get; set; }
    public List<TodoItem> SubTasks { get; set; } = new();
}
