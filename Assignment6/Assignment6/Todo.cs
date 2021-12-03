using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    /// <summary>
    /// Class to hold todo information
    /// </summary>
    class Todo
    {
        private static int idCounter = 1000;
        private int todoId;
        public int TodoId
        {
            // Only allowed to get
            get
            {
                return todoId;
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private DateTime todoDate;
        public DateTime TodoDate
        {
            get
            {
                return todoDate;
            }
            set
            {
                todoDate = value;
            }
        }
        private string priority;
        public string Priority
        {
            get
            {
                return priority;
            }            
            set
            {
                priority = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Todo() { }

        /// <summary>
        /// Overloaded constructor for adding todo
        /// </summary>
        /// <param name="newTodo"></param>
        public Todo(Todo newTodo)
        {
            todoId = getTodoId();
            title = newTodo.Title;
            todoDate = newTodo.TodoDate;
            priority = newTodo.Priority;
        }

        
        /// <summary>
        /// Checking if title and date is valid
        /// </summary>
        /// <returns></returns>
        public bool ValidateData()
        {
            if (string.IsNullOrEmpty(title) ||
                (todoDate <= DateTime.Now))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Perhaps overkill with a helper method for this, but it gives an abstraction in case we want to change how id's are set.
        /// </summary>
        /// <returns></returns>
        private int getTodoId()
        {
            idCounter = idCounter += 1;
            return idCounter;
        }
    }
}
