using Domain.Abstractions;
using Domain.Models;
using Newtonsoft.Json;

namespace Infrastructure.Repository
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly string _filePath = "Enterprises.json";

        public async Task<IEnumerable<Enterprise>> GetAllAsync()
        {
            if (!File.Exists(_filePath)) return new List<Enterprise>();
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<Enterprise>>(jsonData) ?? new List<Enterprise>();
        }

        public async Task<Enterprise> GetByIdAsync(string idno) => (await GetAllAsync()).FirstOrDefault(e => e.IDNO == idno);

        public async Task AddAsync(Enterprise enterprise)
        {
            var enterprises = (await GetAllAsync()).ToList();
            enterprises.Add(enterprise);
            await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(enterprises));
        }

        public async Task UpdateAsync(Enterprise enterprise)
        {
            var enterprises = (await GetAllAsync()).ToList();
            var index = enterprises.FindIndex(e => e.IDNO == enterprise.IDNO);
            if (index >= 0)
            {
                enterprises[index] = enterprise;
                await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(enterprises));
            }
        }

        public async Task DeleteAsync(string idno)
        {
            var enterprises = (await GetAllAsync()).ToList();
            enterprises.RemoveAll(e => e.IDNO == idno);
            await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(enterprises));
        }
    }
}
