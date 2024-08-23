using Domain.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class IndividualService
    {
        private readonly IIndividualRepository _individualRepository;

        public IndividualService(IIndividualRepository individualRepository)
        {
            _individualRepository = individualRepository;
        }

        public Task<IEnumerable<Individual>> GetIndividualsAsync() => _individualRepository.GetAllAsync();
        public Task<Individual> GetIndividualByIdAsync(string idnp) => _individualRepository.GetByIdAsync(idnp);
        public Task AddIndividualAsync(Individual individual) => _individualRepository.AddAsync(individual);
        public Task UpdateIndividualAsync(Individual individual) => _individualRepository.UpdateAsync(individual);
        public Task DeleteIndividualAsync(string idnp) => _individualRepository.DeleteAsync(idnp);
    }
}
