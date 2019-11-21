using System;
using System.Collections.Generic;
using Api.Todo.Model;

namespace Api.Todo.DataAccess
{
    public class MockTodoRepository : ITodoRepository
    {
        private List<TodoItem> _todoItems;

        public MockTodoRepository()
        {
            GenerateTodoItemList();
        }

        public TodoItem GetTodoItemById(Guid id)
        {
            TodoItem result = _todoItems.Find(i => i.Id == id);
            return result;
        }

        public List<TodoItem> GetTodoItems()
        {
            return _todoItems;
        }

        public void CreateTodoItem(TodoItem todoItem)
        {
            _todoItems.Add(todoItem);
        }

        public void UpdateTodoItem(Guid id, TodoItem todoItem)
        {
            int todoItemIndex = _todoItems.FindIndex(i => i.Id == id);
            todoItem.Id = id;
            if (todoItemIndex != -1)
                _todoItems.Insert(todoItemIndex, todoItem);
        }

        public void DeleteTodoItem(Guid id)
        {
            int todoItemIndex = _todoItems.FindIndex(i => i.Id == id);
            if (todoItemIndex != -1)
                _todoItems.RemoveAt(todoItemIndex);
        }

        private void GenerateTodoItemList()
        {
            _todoItems = new List<TodoItem>();
            var todo1 = new TodoItem
            {
                Id = new Guid("24397e79-2556-49e9-8bb5-6ca8de44aa79"),
                Name = "Create Mock Repository",
                Details = "Create a mock repository so that we have some dummy data to play with.",
                Done = false,
                PercentComplete = 25.00m
            };
            var todo2 = new TodoItem
            {
                Id = new Guid("563e259c-65fc-4232-851e-2515330cd3b7"),
                Name = "Create GET Endpoint",
                Details = "Create a GET endpoint so that we can get some todos.",
                Done = false,
                PercentComplete = 0.00m
            };
            var todo3 = new TodoItem
            {
                Id = new Guid("57ab6953-8fdf-4660-817b-1da1d8cde0c7"),
                Name = "Add Logging Middleware",
                Details = "Add some logging middleware so that we can view logs.",
                Done = false,
                PercentComplete = 0.00m
            };
            var todo4 = new TodoItem
            {
                Id = new Guid("50fb0753-a682-4cd4-bd5d-153125eb7057"),
                Name = "Add Swagger",
                Details = "Add Swagger to the project.",
                Done = false,
                PercentComplete = 0.00m
            };

            _todoItems.Add(todo1);
            _todoItems.Add(todo2);
            _todoItems.Add(todo3);
            _todoItems.Add(todo4);
        }
    }
}
