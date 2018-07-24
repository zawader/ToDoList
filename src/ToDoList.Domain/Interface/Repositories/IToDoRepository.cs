using System;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interface.Repositories
{
    public interface IToDoRepository : IRepositoryBase<ToDo>, IDisposable
    {
    }
}
