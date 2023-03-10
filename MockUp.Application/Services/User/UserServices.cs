using MockUp.Application.Models;
using MockUp.Application.Services.Interfaces;
using System.Collections.Generic;

namespace MockUp.Application.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly IDbService _dbService;

        public UserServices(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateUser(Users user)
        {
            var result = await _dbService.EditData("INSERT INTO testing.users (userid, namalengkap, username, password, status) VALUES (@UserId, @NamaLengkap, @UserName, @Password, @Status)", user);
            return true;
        }
        public async Task<List<Users>> GetUserList(string userId)
        {
            var userList = new List< Users>();
            if (userId == "all")
            {
                userList = await _dbService.GetAll<Users>("SELECT * FROM testing.users", new { });

            }
            else {
                int id = Convert.ToInt32(userId);
                userList = await _dbService.GetAll<Users>("SELECT * FROM testing.users WHERE userid=@id", new { id });
            }
            return userList;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var deleteUser = await _dbService.EditData("DELETE FROM testing.users WHERE userid=@userId", new { userId });
            return true;
        }

        
    }
}
