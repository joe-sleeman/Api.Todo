using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Todo.Model;

namespace Api.Todo.DataAccess
{
    public interface ITodoRepository
    {
        TodoItem GetTodoItemById(Guid id);
        List<TodoItem> GetTodoItems();
        void CreateTodoItem(TodoItem todoItem);
        void UpdateTodoItem(Guid id, TodoItem todoItem);
        void DeleteTodoItem(Guid id);
    }
}
