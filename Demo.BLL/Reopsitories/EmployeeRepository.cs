using Demo.BLL.Interfaces;
using Demo.DAL.Data.Context;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Reopsitories
{
    public class EmployeeRepository : GenaricRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public IQueryable<Employee> GetEmpByAddress(string address)
        {
            return _dbcontext.Employees.Where(E => E.Address.ToLower().Contains(address.ToLower()));
        }

        public IQueryable<Employee> SearchByName(string name)
         => _dbcontext.Employees.Where(E => E.Name.ToLower().Contains(name));
       
    }
}
