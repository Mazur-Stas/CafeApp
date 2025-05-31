using CafeApp.Core.Interfaces;
using CafeApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Storage.Repositories
{
    class UserAuthRepository : IUserAuthRepository
    {
        private readonly CafeAppContext _context;

        public UserAuthRepository(CafeAppContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByLoginAsync(string login, CancellationToken cancellationToken)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(u => u.Login == login, cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
