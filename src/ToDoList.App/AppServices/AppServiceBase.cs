using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.App.Interface;
using ToDoList.Domain.Interface.Services;

namespace ToDoList.App.AppServices
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Add(TEntity obj)
        {
            _service.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _service.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _service.Remove(obj);
        }

        public void RemoveById(int id)
        {
            _service.RemoveById(id);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
