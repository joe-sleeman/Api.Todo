namespace Api.Todo.Model
{
    public class UpdatedTodoItemInformation
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal? PercentComplete { get; set; }
        public bool? Done { get; set; }
    }
}
