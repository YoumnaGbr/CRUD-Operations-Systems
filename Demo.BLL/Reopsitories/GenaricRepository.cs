using Demo.BLL.Interfaces;
using Demo.DAL.Data.Context;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Reopsitories
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : ModelBase
    {
        private protected readonly AppDbContext _dbcontext;

        public GenaricRepository(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public void Add(T entity)
        {
            _dbcontext.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbcontext.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbcontext.Update(entity);
        }

        public T Get(int id)
        {
            return _dbcontext.Find<T>(id);

        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
                return (IEnumerable<T>)_dbcontext.Employees.Include(E => E.Department).AsNoTracking().ToList();
            else
                return _dbcontext.Set<T>().AsNoTracking().ToList();

        }


    }
}
