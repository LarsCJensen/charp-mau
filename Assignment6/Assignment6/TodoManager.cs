/*
 * 2021-12-02
 * Lars Jensen
 */

using System;
using System.Collections.Generic;

namespace Assignment6
{
    /// <summary>
    /// Class which holds all todos'
    /// </summary>
    class TodoManager
    {
        private List<Todo> todos = new List<Todo>();
        /// <summary>
        /// Method to add Todo. 
        /// </summary>
        /// <param name="todo">Instance of class Todo</param>
        public void AddTodo(Todo todo) 
        {
            todos.Add(todo);
        }
        /// <summary>
        /// Overloaded method when adding Todo from file
        /// </summary>
        /// <param name="todoDate">Date/Time of todo</param>
        /// <param name="priority">Priority of todo</param>
        /// <param name="title">Title of todo</param>
        public void AddTodo(DateTime todoDate, string priority, string title)
        {
            Todo newTodo = new Todo();
            newTodo.Title = title;
            newTodo.TodoDate = todoDate;
            newTodo.Priority = priority;
            todos.Add(newTodo);
        }
        /// <summary>
        /// Edit todo
        /// </summary>
        /// <param name="editedTodo">Edited todo</param>
        /// <param name="todoIndex">Index of todo being edited</param>
        public void EditTodo(Todo editedTodo, int todoIndex) 
        {
            todos[todoIndex] = editedTodo;
        }
        /// <summary>
        /// Delete todo
        /// </summary>
        /// <param name="todoIndex">Index of todo being deleted</param>
        public void DeleteTodo(int todoIndex) 
        {
            todos.RemoveAt(todoIndex);
        }
        /// <summary>
        /// Get todo from selected index
        /// </summary>
        /// <param name="todoIndex">Index of todo to get</param>
        /// <returns></returns>
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
