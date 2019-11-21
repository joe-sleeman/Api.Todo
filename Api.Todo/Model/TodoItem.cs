using System;

namespace Api.Todo.Model
{
    public class TodoItem
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal PercentComplete { get; set; }
        public bool Done { get; set; }
    }
}
