using CafeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Core.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<Customer?> GetByLoginAsync(string login, CancellationToken cancellationToken);
        Task AddAsync(Customer customer, CancellationToken cancellationToken);
    }
}
