using PaySharp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaySharp.API.Services.Contracts
{
    public interface IUserService
    {
        Task<UserLoginModel> GetLoginUserAsync(string username, string password);
        //Task<UserDTO> GetUserAsync(string searchName);
        //Task<UserDTO> GetUserAsync(long userId);
        //Task<UserDTO> AddUserAsync(string name, string userName, string password);
        //Task<AdminDTO> GetAdminAsync(string username, string password);
        //Task<UserDTO> AddUserToClientAsync(long userId, string clientName);
        //Task<List<UserDTO>> TakeNumberOfUsersAsync(int currentPage, int pageSize = 5);
        //Task<UserDTO> AddUserToClientAsync(long userId, long clientId);
        //Task<long> GetAllUsersCountAsync();
        //Task<IList<string>> FindUserContainingAsync(string searchString);
    }
}
