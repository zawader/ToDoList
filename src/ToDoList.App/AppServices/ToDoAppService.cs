using System.Collections;
using System.Collections.Generic;
using ToDoList.App.Interface;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Services;
using System.Linq;
using System;

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

        public new IEnumerable<ToDo> GetAll()
        {
            return _toDoService.GetAll().Where(t => !t.DeleteDate.HasValue);
        }

        public new void Update(ToDo _toDo)
        {
            if (_toDo.IsCompleted)
            {
                if (!_toDo.CompletedDate.HasValue)
                    _toDo.CompletedDate = DateTime.Now;
            }
            else
            {
                _toDo.CompletedDate = null;
            }
                
            _toDoService.Update(_toDo);
        }
    }
}
