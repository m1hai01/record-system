using Domain.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnterpriseService
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseService(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public Task<IEnumerable<Enterprise>> GetEnterprisesAsync() => _enterpriseRepository.GetAllAsync();
        public Task<Enterprise> GetEnterpriseByIdAsync(string idno) => _enterpriseRepository.GetByIdAsync(idno);
        public Task AddEnterpriseAsync(Enterprise enterprise) => _enterpriseRepository.AddAsync(enterprise);
        public Task UpdateEnterpriseAsync(Enterprise enterprise) => _enterpriseRepository.UpdateAsync(enterprise);
        public Task DeleteEnterpriseAsync(string idno) => _enterpriseRepository.DeleteAsync(idno);
    }
}
