using CafeApp.Core.Interfaces;
using CafeApp.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace CafeApp.Storage.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CafeAppContext _context;

        public EmployeeRepository(CafeAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            return await _context.Employees
                .Include(e => e.Admin)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Admin)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee,CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> RemoveEmployeeAsync(int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}

