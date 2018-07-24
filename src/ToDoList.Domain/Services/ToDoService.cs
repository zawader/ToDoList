using ToDoList.Domain.Entities;
using ToDoList.Domain.Interface.Repositories;
using ToDoList.Domain.Interface.Services;

namespace ToDoList.Domain.Services
{
    public class ToDoService : ServiceBase<ToDo>, IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository) 
            : base(toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
    }
}
