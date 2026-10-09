using QuickDropAPI.Models;
namespace QuickDropAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task <ApplicationUser> GetByEmailAsync(string email);
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task AddAsync(ApplicationUser user);
        Task SaveChangesAsync();

    }
}
