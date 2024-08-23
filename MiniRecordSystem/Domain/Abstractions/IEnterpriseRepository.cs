using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Abstractions
{
    public interface IEnterpriseRepository
    {
        Task<IEnumerable<Enterprise>> GetAllAsync();
        Task<Enterprise> GetByIdAsync(string idno);
        Task AddAsync(Enterprise enterprise);
        Task UpdateAsync(Enterprise enterprise);
        Task DeleteAsync(string idno);
    }
}
