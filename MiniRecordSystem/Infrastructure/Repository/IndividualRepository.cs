using Domain.Abstractions;
using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class IndividualRepository : IIndividualRepository
    {
        private readonly string _filePath = "Individuals.json";

        public async Task<IEnumerable<Individual>> GetAllAsync()
        {
            if (!File.Exists(_filePath)) return new List<Individual>();
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<Individual>>(jsonData) ?? new List<Individual>();
        }

        public async Task<Individual> GetByIdAsync(string idnp) => (await GetAllAsync()).FirstOrDefault(i => i.IDNP == idnp);

        public async Task AddAsync(Individual individual)
        {
            var individuals = (await GetAllAsync()).ToList();
            individuals.Add(individual);
            await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(individuals));
        }

        public async Task UpdateAsync(Individual individual)
        {
            var individuals = (await GetAllAsync()).ToList();
            var index = individuals.FindIndex(i => i.IDNP == individual.IDNP);
            if (index >= 0)
            {
                individuals[index] = individual;
                await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(individuals));
            }
        }

        public async Task DeleteAsync(string idnp)
        {
            var individuals = (await GetAllAsync()).ToList();
            individuals.RemoveAll(i => i.IDNP == idnp);
            await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(individuals));
        }
    }
}
