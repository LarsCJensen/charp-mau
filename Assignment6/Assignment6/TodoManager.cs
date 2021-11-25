using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class TodoManager
    {
        private List<Todo> todos = new List<Todo>();
        public void AddTodo(Todo todo) 
        {
            todos.Add(todo);
        }

        public void AddTodo(DateTime todoDate, string priority, string title)
        {
            Todo newTodo = new Todo();
            newTodo.Title = title;
            newTodo.TodoDate = todoDate;
            newTodo.Priority = priority;
            todos.Add(newTodo);
        }

        public void EditTodo(Todo editedTodo, int todoIndex) 
        {
            todos[todoIndex] = editedTodo;
        }
        public void DeleteTodo(int todoIndex) 
        {
            todos.RemoveAt(todoIndex);
        }
        public Todo GetTodo(int todoIndex)
        {
            if (todoIndex >= 0 && todoIndex <= todos.Count - 1)
            {
                return todos[todoIndex];
            }
            return null;
        }
    }
}
