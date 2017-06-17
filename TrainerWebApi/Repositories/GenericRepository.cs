using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TrainerWebApi.DAL;

namespace TrainerWebApi.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly TrainerContext _context;

        public GenericRepository(TrainerContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Add(T item)
        {
            var addedItem = _context.Set<T>().Add(item);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return addedItem;
        }

        public T Remove(T item)
        {
            var removedItem = _context.Set<T>().Remove(item);

            _context.SaveChanges();

            return removedItem;
        }

        public void Update(T item)
        {
            _context.Set<T>().AddOrUpdate(item);

            _context.SaveChanges();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}