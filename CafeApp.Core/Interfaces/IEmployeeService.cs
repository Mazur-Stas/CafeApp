using CafeApp.Core.DTOs.Inputs;
using CafeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Core.Interfaces
{
        public interface IEmployeeService
        {
        Task<IEnumerable<Employee>> GetAsync();
        Task<Employee> AddEmployeeAsync(Employee employee, CancellationToken cancellationToken);
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<Employee> UpdateEmployeeAsync(int id,Employee employee);
        Task<Employee> RemoveEmployeeAsync(int id,CancellationToken cancellationToken);
         }
    
}
