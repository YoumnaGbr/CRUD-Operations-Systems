using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenaricRepository<Employee>
    {
        IQueryable<Employee> GetEmpByAddress(string address);
        IQueryable<Employee> SearchByName(string name);
    }
}
