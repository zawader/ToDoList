using ToDoList.App.Interface;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Services;

namespace ToDoList.App.AppServices
{
    public class ToDoAppService : AppServiceBase<ToDo>, IToDoAppService
    {
        private readonly ToDoService _toDoService;

        public ToDoAppService(ToDoService toDoService)
            : base(toDoService)
        {
            _toDoService = toDoService;
        }
    }
}
