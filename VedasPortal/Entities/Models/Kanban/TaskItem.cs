namespace VedasPortal.Entities.Models.Kanban
{
    public class TaskItem : Base.BaseEntity
    {
        public string TaskName { get; set; }
        public TaskPriority Priority { get; set; }
    }

    public enum TaskPriority
    {
        Yuksek,
        Orta,
        Dusuk
    }
}
