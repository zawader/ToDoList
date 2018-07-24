using System;
using System.Collections.Generic;
using ToDoList.Domain.Interface.Repositories;
using ToDoList.Domain.Interface.Services;

namespace ToDoList.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void RemoveById(int id)
        {
            _repository.RemoveById(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
