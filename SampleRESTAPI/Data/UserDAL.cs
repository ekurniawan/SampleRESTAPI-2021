using Microsoft.AspNetCore.Identity;
using SampleRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public class UserDAL : IUser
    {
        private UserManager<IdentityUser> _userManager;
        public UserDAL(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public Task AddRole(string rolename)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUserToRole(string username, string role)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<string>> GetRolesFromUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public async Task Registration(User user)
        {
            try
            {
                var newUser = new IdentityUser
                {
                    UserName = user.Username,Email=user.Username
                };
                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (!result.Succeeded)
                    throw new System.Exception("Gagal menambahkan user");
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Error: {ex.Message}");
            }
        }
    }
}
