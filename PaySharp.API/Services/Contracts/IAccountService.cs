using PaySharp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaySharp.API.Services.Contracts
{
    public interface IAccountService
    {
        //Task<bool> AddAccountToUserAsync(long userId, long accountId);
        //Task<bool> RemoveAccountFromUserAsync(long userId, long accountId);
        //Task<AccountDTO> CreateAccountAsync(long clientId);
        //Task<Account> GetAccountAsync(string accountNumber);
        //Task<List<AccountDTO>> GetUserClientsAccountsAsync(long userId);
        //Task<AccountDTO> GetAccountAsync(long accountId);
        Task<List<AccountResponseModel>> GetUserAccountsAsync(long userId);
        //Task<IEnumerable<AccountDTO>> GetClientAccountsAsync(long clientId);
        //Task<AccountDTO> RenameAccountAsync(long accountId, string newNickName);
        //Task<IList<AccountDTO>> FindAccountsContainingAsync(string searchString);
        //Task<IEnumerable<long>> GetUserAccountsIdsAsync(long userId);
        //Task<Account> GetAccountByIdAsync(long accountId);
    }
}
