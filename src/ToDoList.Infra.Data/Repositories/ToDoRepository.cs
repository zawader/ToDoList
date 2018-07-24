using ToDoList.Domain.Entities;
using ToDoList.Domain.Interface.Repositories;

namespace ToDoList.Infra.Data.Repositories
{
    public class ToDoRepository : RepositoryBase<ToDo> ,IToDoRepository
    {
    }
}
