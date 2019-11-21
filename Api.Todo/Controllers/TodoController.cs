using System;
using Api.Todo.Model;
using Api.Todo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Todo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoItemService _todoItemService;

        public TodoController(TodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTodoItem(Guid id)
        {
            return _todoItemService.GetTodoItem(id);
        }

        [HttpGet]
        public IActionResult GetTodoItems()
        {
            return _todoItemService.GetTodoItems();
        }

        [HttpPost]
        public IActionResult CreateTodoItem([FromBody] TodoItem todoItem)
        {
            return _todoItemService.CreateTodoItem(todoItem);
        }

        // Todo: Change this to patch and implement PatchDTO.
        [HttpPut("{id:guid}")]
        public IActionResult UpdateTodoItem(Guid id,
            [FromBody] TodoItem todoItem)
        {
            return _todoItemService.UpdateTodoItem(id, todoItem);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteTodoItem(Guid id)
        {
            return _todoItemService.DeleteTodoItem(id);
        }
    }
}
