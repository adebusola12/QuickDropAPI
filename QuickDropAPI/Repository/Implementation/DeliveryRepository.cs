using Microsoft.EntityFrameworkCore;
using QuickDropAPI.Data;
using QuickDropAPI.Models;
using QuickDropAPI.Repository.Interface;
namespace QuickDropAPI.Repository.Implementation
{
    public class DeliveryRepository: IDeliveryRepository
    {
        private readonly ApplicationDbContext _context;

        public DeliveryRepository (ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Delivery> AddAsync(Delivery delivery)
        {
            await _context.Deliveries.AddAsync(delivery);

            return delivery;
        }

        public async Task<Delivery> GetByIdAsync(int id)
        {
            return await _context.Deliveries
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Delivery>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Deliveries
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
        }

        public async Task DeleteAsync(Delivery delivery)
        {
            _context.Deliveries.Remove(delivery);

            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
