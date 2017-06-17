using System;
using System.Collections;
using System.Collections.Generic;

namespace TrainerWebApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> Get(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        T Add(T item);
        T Remove(T item);
        void Update(T item);
    }
}