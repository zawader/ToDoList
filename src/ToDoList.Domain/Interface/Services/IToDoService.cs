using System;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interface.Services
{
    interface IToDoService : IServiceBase<ToDo>, IDisposable
    {
    }
}
