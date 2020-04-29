using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaySharp.API.Dal;
using PaySharp.API.Dal.Models;
using PaySharp.API.Services.Contracts;
using PaySharp.API.Utilities.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaySharp.API.Services.Exceptions;
using PaySharp.API.Models;

namespace PaySharp.API.Services
{
    public class AccountService : IAccountService
    {
            private readonly PaySharpDBContext context;
            private readonly IConfiguration config;
            private readonly IRandomGenerator randomGenerator;

        public AccountService(PaySharpDBContext context, IConfiguration config,
             IRandomGenerator randomGenerator)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.config = config ?? throw new ArgumentNullException(nameof(context));
            this.randomGenerator = randomGenerator ?? throw new ArgumentNullException(nameof(randomGenerator));
        }

        //    public async Task<bool> CheckAccountNumberAsync(string number)
        //    {
        //        var numberExist = await context.Accounts.SingleOrDefaultAsync(a => a.AccountNumber == number);
        //        if (numberExist == null)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }

        //    public async Task<Account> GetAccountAsync(string accountNumber)
        //    {
        //        var account = await context.Accounts
        //            .Include(a => a.Client)
        //            .SingleOrDefaultAsync(ac => ac.AccountNumber == accountNumber);

        //        return account;
        //    }
        //    public async Task<Account> GetAccountByIdAsync(long accountId)
        //    {
        //        var account = await context.Accounts
        //            .Include(a => a.Client)
        //            .SingleOrDefaultAsync(ac => ac.Id == accountId);

        //        return account;
        //    }

        //    public async Task<AccountDTO> GetAccountAsync(long accountId)
        //    {
        //        var account = await context.Accounts
        //            .Include(a => a.Client)
        //            .SingleOrDefaultAsync(ac => ac.Id == accountId);
        //        if (account == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //        }
        //        var accountDTO = accountMapper.MapFrom(account);
        //        return accountDTO;
        //    }

        //    public async Task<AccountDTO> CreateAccountAsync(long clientId)
        //    {
        //        var randomAccountNumber = string.Empty;
        //        while (true)
        //        {
        //            randomAccountNumber = randomGenerator.GenerateNumber(0, 9, 10);
        //            var accountExists = await GetAccountAsync(randomAccountNumber);
        //            if (accountExists == null)
        //            {
        //                break;
        //            }
        //        }
        //        var balance = decimal.Parse(config.GetSection("GlobalConstants:Balance").Value);
        //        var account = new Account()
        //        {
        //            AccountNumber = randomAccountNumber,
        //            NickName = randomAccountNumber,
        //            Balance = balance,
        //            ClientId = clientId
        //        };

        //        context.Accounts.Add(account);
        //        await context.SaveChangesAsync();

        //        return accountMapper.MapFrom(account);
        //    }

        //    public async Task<bool> AddAccountToUserAsync(long userId, long accountId)
        //    {
        //        var account = await context.Accounts.Include(ac => ac.UsersAccounts).SingleOrDefaultAsync(ac => ac.Id == accountId);
        //        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);

        //        if (account == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //        }

        //        if (user == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
        //        }
        //        var userAccountExists = await context.UsersAccounts.SingleOrDefaultAsync(uc => uc.AccountId == accountId && uc.UserId == userId);
        //        if (userAccountExists != null)
        //        {
        //            throw new EntityAlreadyExistsException(config.GetSection("GlobalConstants:USER_ACCOUNT").Value);
        //        }
        //        var usersAccounts = new UsersAccounts()
        //        {
        //            UserId = userId,
        //            AccountId = accountId
        //        };

        //        account.UsersAccounts.Add(usersAccounts);
        //        await context.SaveChangesAsync();
        //        return true;
        //    }

        //    public async Task<bool> RemoveAccountFromUserAsync(long userId, long accountId)
        //    {
        //        var account = await context.Accounts.Include(ac => ac.UsersAccounts).SingleOrDefaultAsync(ac => ac.Id == accountId);
        //        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);

        //        if (account == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //        }
        //        if (user == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
        //        }
        //        var userAccountExists = await context.UsersAccounts.SingleOrDefaultAsync(uc => uc.AccountId == accountId && uc.UserId == userId);
        //        if (userAccountExists == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:USER_NO_ACCOUNT").Value);
        //        }
        //        foreach (var userAccount in account.UsersAccounts.Where(ua => ua.AccountId == accountId).ToList())
        //        {
        //            account.UsersAccounts.Remove(userAccount);
        //        }

        //        await context.SaveChangesAsync();
        //        return true;

        //    }

        //    public async Task<List<AccountDTO>> GetUserClientsAccountsAsync(long userId)
        //    {
        //        var clientsUser = await context.UsersClients.Where(uc => uc.UserId == userId).ToListAsync();
        //        var accounts = new List<AccountDTO>();
        //        foreach (var client in clientsUser)
        //        {
        //            var clientAcc = await GetClientAccountsAsync(client.ClientId);
        //            accounts.AddRange(clientAcc);
        //        }
        //        var userAccounts = await GetUserAccountsAsync(userId);
        //        for (int i = 0; i < userAccounts.Count; i++)
        //        {
        //            for (int j = 0; j < accounts.Count; j++)
        //            {
        //                if (userAccounts[i].AccountNumber == accounts[j].AccountNumber)
        //                {
        //                    accounts[j].IsAddedToUser = true;
        //                }
        //            }
        //        }
        //        return accounts;
        //    }

        //    public async Task<IEnumerable<AccountDTO>> GetClientAccountsAsync(long clientId)
        //    {
        //        var accounts = await context.Accounts.Include(c => c.Client)
        //            .Where(a => a.ClientId == clientId)
        //            .ToListAsync();
        //        var accountsDTO = accounts.Select(a => accountMapper.MapFrom(a));
        //        return accountsDTO;
        //    }

        public async Task<List<AccountResponseModel>> GetUserAccountsAsync(long userId)
        {
            var accounts = await ( from ac in context.Accounts
                       join ua in context.UsersAccounts on ac.Id equals ua.AccountId
                       join cl in context.Clients on ac.ClientId equals cl.Id
                       where ua.UserId == userId
                       select new AccountResponseModel
                       {
                           Id = ac.Id,
                           AccountNumber = ac.AccountNumber,
                           Balance = ac.Balance,
                           ClientName = cl.Name,
                           ClientId = cl.Id,
                           NickName = ac.NickName,
                           UserId = userId
                       }).ToListAsync();

            return accounts;
        }

        //    public async Task<IEnumerable<long>> GetUserAccountsIdsAsync(long userId)
        //    {
        //        var userAccounts = await context.UsersAccounts.Where(ua => ua.UserId == userId).ToListAsync();
        //        var accountsIds = new List<long>();
        //        foreach (var account in userAccounts)
        //        {
        //            accountsIds.Add(account.AccountId);
        //        }

        //        return accountsIds;
        //    }

        //    public async Task<AccountDTO> RenameAccountAsync(long accountId, string newNickName)
        //    {
        //        var account = await context.Accounts
        //            .Include(a => a.Client)
        //            .SingleOrDefaultAsync(ac => ac.Id == accountId);
        //        account.NickName = newNickName;
        //        await context.SaveChangesAsync();
        //        var accountDTO = accountMapper.MapFrom(account);
        //        return accountDTO;
        //    }

        //    public async Task<IList<AccountDTO>> FindAccountsContainingAsync(string searchString)
        //    {
        //        var accounts = await context.Accounts.Include(x => x.Client)
        //            .Where(x => x.AccountNumber.Contains(searchString)).Take(5).ToListAsync();

        //        return accounts.Select(a => accountMapper.MapFrom(a)).ToList();
        //    }

    }
}
