using QuickDropAPI.Models;

namespace QuickDropAPI.Repository.Interface
{
    public interface IDeliveryRepository
    {
        Task<Delivery> AddAsync(Delivery delivery);

        Task<Delivery> GetByIdAsync(int id);

        Task<List<Delivery>> GetByUserIdAsync(Guid userId);

        Task UpdateAsync(Delivery delivery);

        Task DeleteAsync(Delivery delivery);

        Task SaveChangesAsync();
    }
}