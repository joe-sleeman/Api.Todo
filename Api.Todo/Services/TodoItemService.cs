using System;
using System.Collections.Generic;
using Api.Todo.DataAccess;
using Api.Todo.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Todo.Services
{
    public class TodoItemService
    {
        private ITodoRepository _todoRepository;

        public TodoItemService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult GetTodoItem(Guid id)
        {
            TodoItem result = _todoRepository.GetTodoItemById(id);
            if (result != null)
                return new OkObjectResult(result);
            return new NotFoundObjectResult($"No Todo found with Id: {id}.");
        }

        public IActionResult GetTodoItems()
        {
            List<TodoItem> todoItems = _todoRepository.GetTodoItems();
            if (todoItems != null)
                return new OkObjectResult(todoItems);
            return new NotFoundObjectResult("No Todos found.");
        }

        public IActionResult CreateTodoItem(TodoItem todoItem)
        {
            IActionResult result;
            try
            {
                todoItem.Id = todoItem.Id ?? Guid.NewGuid();
                _todoRepository.CreateTodoItem(todoItem);
                result = new CreatedResult(new Uri($"/todo/{todoItem.Id}", UriKind.Relative), todoItem);
            }
            catch (Exception exception)
            {
                result = new ObjectResult($"Error creating Todo: {exception.Message}.");
            }

            return result;
        }

        public IActionResult UpdateTodoItem(Guid id,
            TodoItem todoItem)
        {
            IActionResult result;
            try
            {
                _todoRepository.UpdateTodoItem(id, todoItem);
                result = new OkObjectResult($"Updated Todo with Id: {id}");
            }
            catch (Exception exception)
            {
                result = new ObjectResult($"Error updating Todo: {exception.Message}.");
            }

            return result;
        }

        public IActionResult DeleteTodoItem(Guid id)
        {
            IActionResult result;
            try
            {
                _todoRepository.DeleteTodoItem(id);
                result = new NotFoundObjectResult($"Deleted todo with Id: {id}.");
            }
            catch (Exception exception)
            {
                result = new ObjectResult($"Error deleting Todo: {exception.Message}.");
            }

            return result;
        }
    }
}
