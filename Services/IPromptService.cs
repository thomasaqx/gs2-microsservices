using PromptApi.Models;

namespace PromptApi.Services
{
    public interface IPromptService
    {
        Task<int> CreateAsync(Prompt prompt);
        Task<bool> UpdateAsync(int id, Prompt prompt);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Prompt>> GetAllAsync();
        Task<Prompt?> GetByIdAsync(int id);
    }
}