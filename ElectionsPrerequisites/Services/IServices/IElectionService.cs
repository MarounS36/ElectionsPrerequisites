using ElectionsPrerequisites.Models.Dto;

namespace ElectionsPrerequisites.Services.IServices
{
    public interface IElectionService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(ElectionCreateDTO dto);
        Task<T> UpdateAsync<T>(ElectionUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
