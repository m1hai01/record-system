using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Abstractions
{
    public interface IIndividualRepository
    {
        Task<IEnumerable<Individual>> GetAllAsync();
        Task<Individual> GetByIdAsync(string idnp);
        Task AddAsync(Individual individual);
        Task UpdateAsync(Individual individual);
        Task DeleteAsync(string idnp);
    }
}
