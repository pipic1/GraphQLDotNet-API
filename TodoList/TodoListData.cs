using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using TodoList.Types;

namespace TodoList
{
    public class TodoListData
    {
        private readonly List<ImportantTodo> _importantTodo = new List<ImportantTodo>();
        private readonly List<SecondaryTodo> _secondaryTodos = new List<SecondaryTodo>();

        public TodoListData()
        {
            _importantTodo.Add(new ImportantTodo
            {
                Id = "1",
                Name = "Acheter du pain",
                Description = "1 baguette",
            });
            _importantTodo.Add(new ImportantTodo
            {
                Id = "1",
                Name = "Aller chercher le colis",
                Description = "Avant 20h",
            });

            _secondaryTodos.Add(new SecondaryTodo
            {
                Id = "1",
                Name = "Planter des fleurs",
            });
            _secondaryTodos.Add(new SecondaryTodo
            {
                Id = "1",
                Name = "Gonfler les pneus",
            });
        }

        public IEnumerable<TodoItem> GetFriends(TodoItem task)
        {
            if (task == null)
            {
                return null;
            }

            var relatedTo = new List<TodoItem>();
            var lookup = task.RelatedTo;
            if (lookup != null)
            {
                _importantTodo.Where(h => lookup.Contains(h.Id)).Apply(relatedTo.Add);
                _secondaryTodos.Where(d => lookup.Contains(d.Id)).Apply(relatedTo.Add);
            }
            return relatedTo;
        }

        public Task<ImportantTodo> GetImportantTodoByIdAsync(string id)
        {
            return Task.FromResult(_importantTodo.FirstOrDefault(h => h.Id == id));
        }

        public Task<SecondaryTodo> GetSecondaryTodoByIdAsync(string id)
        {
            return Task.FromResult(_secondaryTodos.FirstOrDefault(h => h.Id == id));
        }

        public ImportantTodo AddImportantTodo(ImportantTodo task)
        {
            task.Id = Guid.NewGuid().ToString();
            _importantTodo.Add(task);
            return task;
        }
    }
}
