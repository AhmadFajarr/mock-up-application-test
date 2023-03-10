
using MockUp.Application.Models;

namespace MockUp.Application.Services.Interfaces
{
    public interface IUserServices
    {
        Task<bool> CreateUser(Users user);
        Task<List<Users>> GetUserList(string userId);
        Task<bool> DeleteUser(int userId);
    }
}
