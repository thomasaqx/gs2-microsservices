using PromptApi.Data;
using PromptApi.Models;

namespace PromptApi.Services
{
    public class PromptService : IPromptService
    {
        private readonly PromptRepository _repository;

        public PromptService(PromptRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(Prompt prompt)
        {
            return await _repository.InsertAsync(prompt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted > 0;
        }

        public async Task<IEnumerable<Prompt>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Prompt?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Prompt prompt)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing is null) return false;
            
            prompt.Id = id; 
            var updated = await _repository.UpdateAsync(prompt);
            return updated > 0;
        }
    }
}