using PaySharp.API.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySharp.API.Services
{
    public class TransactionService : ITransactionService
    {
        //private readonly PaySharpDBContext context;
        //private readonly IConfiguration config;
        //private readonly IDtoMapper<Data.Entities.Transaction, TransactionDTO> transactionMapper;
        //private readonly IAccountService accountService;
        //private readonly IDateWrapper dateWrapper;
        //private readonly IDtoMapper<Account, AccountDTO> accountMapper;

        //public TransactionService(PaySharpDBContext context, IConfiguration config,
        //    IDtoMapper<Data.Entities.Transaction, TransactionDTO> transactionMapper
        //    , IAccountService accountService, IDateWrapper dateWrapper,
        //      IDtoMapper<Account, AccountDTO> accountMapper)
        //{
        //    this.context = context ?? throw new ArgumentNullException(nameof(context));
        //    this.config = config ?? throw new ArgumentNullException(nameof(config));
        //    this.transactionMapper = transactionMapper ?? throw new ArgumentNullException(nameof(transactionMapper));
        //    this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        //    this.dateWrapper = dateWrapper ?? throw new ArgumentNullException(nameof(dateWrapper));
        //    this.accountMapper = accountMapper ?? throw new ArgumentNullException(nameof(accountMapper));
        //}
        //public async Task<TransactionDTO> SendTransactionAsync(string senderAccountNumber, string recieverAccountNumber
        //    , string description, decimal amount)
        //{
        //    var transactionDTO = new TransactionDTO();
        //    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        var date = dateWrapper.Now();
        //        var senderAccount = await accountService.GetAccountAsync(senderAccountNumber);
        //        if (senderAccount == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //        }
        //        var receiverAccount = await accountService.GetAccountAsync(recieverAccountNumber);
        //        if (receiverAccount == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //        }
        //        if (receiverAccount.AccountNumber == senderAccount.AccountNumber)
        //        {
        //            throw new EntityAlreadyExistsException(config.GetSection("GlobalConstants:SAME_ACCOUNT").Value);
        //        }
        //        if (senderAccount.Balance < amount)
        //        {
        //            throw new InsufficientFundsException(config.GetSection("GlobalConstants:NOT_ENOUGH").Value);
        //        }
        //        var transaction = new Data.Entities.Transaction()
        //        {
        //            Amount = amount,
        //            SenderAccountID = senderAccount.Id,
        //            ReceiverAccountID = receiverAccount.Id,
        //            Description = description,
        //            StatusId = 1,
        //            TimeStamp = date
        //        };
        //        senderAccount.Balance -= amount;
        //        receiverAccount.Balance += amount;
        //        context.Transactions.Add(transaction);
        //        await context.SaveChangesAsync();
        //        transactionDTO = transactionMapper.MapFrom(transaction);
        //        scope.Complete();
        //    }

        //    return transactionDTO;
        //}
        //public async Task<TransactionDTO> SaveTransactionAsync(string senderAccountNumber, string recieverAccountNumber, string description, decimal amount)
        //{
        //    var date = dateWrapper.Now();
        //    var senderAccount = await accountService.GetAccountAsync(senderAccountNumber);
        //    if (senderAccount == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //    }
        //    var recieverAccount = await accountService.GetAccountAsync(recieverAccountNumber);
        //    if (recieverAccount == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //    }
        //    if (recieverAccount.AccountNumber == senderAccount.AccountNumber)
        //    {
        //        throw new EntityAlreadyExistsException(config.GetSection("GlobalConstants:SAME_ACCOUNT").Value);
        //    }

        //    var transaction = new Data.Entities.Transaction()
        //    {
        //        Amount = amount,
        //        SenderAccountID = senderAccount.Id,
        //        ReceiverAccountID = recieverAccount.Id,
        //        Description = description,
        //        StatusId = 2,
        //        TimeStamp = date
        //    };
        //    context.Transactions.Add(transaction);
        //    await context.SaveChangesAsync();
        //    var transactionDTO = transactionMapper.MapFrom(transaction);
        //    return transactionDTO;
        //}

        ////public async Task<List<TransactionDTO>> GetUserTransactionsByAccount(long accountId, long userId, int currentPage, int pageSize = 5)
        ////{
        ////    var usersAccounts = await context.UsersAccounts
        ////                        .SingleOrDefaultAsync(x => x.AccountId == accountId && x.UserId == userId);

        ////    if (usersAccounts == null)
        ////    {
        ////        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        ////    }
        ////    //TODOtransaction querable
        ////    var transactions = await context.Transactions
        ////                              .Include(x => x.Status)
        ////                              .Include(t => t.SenderAccount).ThenInclude(a => a.Client)
        ////                              .Include(t => t.SenderAccount).ThenInclude(a => a.UsersAccounts)
        ////                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.Client)
        ////                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.UsersAccounts)
        ////                              .Where(x => x.SenderAccountID == accountId
        ////                              || (x.ReceiverAccountID == accountId && x.StatusId == 1))
        ////                              .OrderByDescending(x => x.TimeStamp)
        ////                              .Skip((currentPage - 1) * pageSize).Take(pageSize)
        ////                              .ToListAsync();
        ////    var transactionsDTO = transactions.Select(t => transactionMapper.MapFrom(t)).ToList();
        ////    foreach (var transac in transactionsDTO)
        ////    {

        ////        var sender = transac.SenderAccount.UsersAccounts.Where(ua => ua.UserId == userId);
        ////        if (sender.Count() != 0)
        ////        {
        ////            transac.IsSend = true;
        ////        }
        ////        var receiver = transac.ReceiverAccount.UsersAccounts.Where(ua => ua.UserId == userId);
        ////        if (receiver.Count() != 0)
        ////        {
        ////            transac.IsRecieved = true;
        ////        }

        ////    }
        ////    return transactionsDTO;
        ////}
        ////public async Task<List<TransactionDTO>> GetAllUserTransactions(long userId, int currentPage, int pageSize = 5)
        ////{
        ////    var accountsIds = await accountService.GetUserAccountsIdsAsync(userId);

        ////    var transactions = await context.Transactions
        ////                              .Include(t => t.Status)
        ////                              .Include(t => t.SenderAccount).ThenInclude(a => a.Client)
        ////                              .Include(t => t.SenderAccount).ThenInclude(a => a.UsersAccounts)
        ////                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.Client)
        ////                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.UsersAccounts)
        ////                              .Where(t => accountsIds.Contains(t.SenderAccountID)
        ////                              || (accountsIds.Contains(t.ReceiverAccountID) && t.StatusId == 1))
        ////                              .OrderByDescending(t => t.TimeStamp)
        ////                              .Skip((currentPage - 1) * pageSize).Take(pageSize)
        ////                              .ToListAsync();

        ////    var transactionsDTO = transactions.Select(t => transactionMapper.MapFrom(t)).ToList();
        ////    foreach (var transac in transactionsDTO)
        ////    {

        ////        var sender = transac.SenderAccount.UsersAccounts.Where(ua => ua.UserId == userId);
        ////        if (sender.Count() != 0)
        ////        {
        ////            transac.IsSend = true;
        ////        }
        ////        var receiver = transac.ReceiverAccount.UsersAccounts.Where(ua => ua.UserId == userId);
        ////        if (receiver.Count() != 0)
        ////        {
        ////            transac.IsRecieved = true;
        ////        }

        ////    }

        ////    return transactionsDTO;

        ////}
        //public async Task<List<TransactionDTO>> GetUserTransactionsByAccount(long accountId, long userId, int currentPage, int pageSize = 5)
        //{
        //    var usersAccounts = await context.UsersAccounts
        //                        .SingleOrDefaultAsync(x => x.AccountId == accountId && x.UserId == userId);

        //    if (usersAccounts == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //    }
        //    var transactionsSender = context.Transactions
        //                             .Include(t => t.Status)
        //                             .Include(t => t.SenderAccount).ThenInclude(a => a.Client)
        //                             .Include(t => t.SenderAccount).ThenInclude(a => a.UsersAccounts)
        //                             .Include(t => t.ReceiverAccount).ThenInclude(a => a.Client)
        //                             .Include(t => t.ReceiverAccount).ThenInclude(a => a.UsersAccounts)
        //                             .Where(t => t.SenderAccountID == accountId)
        //                             .Select(t => new TransactionDTO()
        //                             {
        //                                 Id = t.Id,
        //                                 SenderAccountID = t.SenderAccountID,
        //                                 ReceiverAccountID = t.ReceiverAccountID,
        //                                 Amount = t.Amount,
        //                                 Description = t.Description,
        //                                 TimeStamp = t.TimeStamp,
        //                                 Status = t.Status.StatusName,
        //                                 StatusId = t.StatusId,
        //                                 SenderAccount = accountMapper.MapFrom(t.SenderAccount),
        //                                 ReceiverAccount = accountMapper.MapFrom(t.ReceiverAccount),
        //                                 IsSend = true

        //                             });
        //    var transactionsRecieved = context.Transactions
        //                            .Include(t => t.Status)
        //                            .Include(t => t.SenderAccount).ThenInclude(a => a.Client)
        //                            .Include(t => t.SenderAccount).ThenInclude(a => a.UsersAccounts)
        //                            .Include(t => t.ReceiverAccount).ThenInclude(a => a.Client)
        //                            .Include(t => t.ReceiverAccount).ThenInclude(a => a.UsersAccounts)
        //                            .Where(t => t.ReceiverAccountID == accountId && t.StatusId == 1)
        //                            .Select(t => new TransactionDTO()
        //                            {
        //                                Id = t.Id,
        //                                SenderAccountID = t.SenderAccountID,
        //                                ReceiverAccountID = t.ReceiverAccountID,
        //                                Amount = t.Amount,
        //                                Description = t.Description,
        //                                TimeStamp = t.TimeStamp,
        //                                Status = t.Status.StatusName,
        //                                StatusId = t.StatusId,
        //                                SenderAccount = accountMapper.MapFrom(t.SenderAccount),
        //                                ReceiverAccount = accountMapper.MapFrom(t.ReceiverAccount),
        //                                IsRecieved = true
        //                            });
        //    var transactionsDTO = await transactionsSender.Concat(transactionsRecieved)
        //         .OrderByDescending(t => t.TimeStamp)
        //         .Skip((currentPage - 1) * pageSize).Take(pageSize)
        //         .ToListAsync();

        //    return transactionsDTO;
        //}
        //public async Task<List<TransactionDTO>> GetAllUserTransactions(long userId, int currentPage, int pageSize = 5)
        //{
        //    var accountsIds = await accountService.GetUserAccountsIdsAsync(userId);

        //    var transactionsSender = context.Transactions
        //                              .Include(t => t.Status)
        //                              .Include(t => t.SenderAccount).ThenInclude(a => a.Client)
        //                              .Include(t => t.SenderAccount).ThenInclude(a => a.UsersAccounts)
        //                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.Client)
        //                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.UsersAccounts)
        //                              .Where(t => accountsIds.Contains(t.SenderAccountID))
        //                              .Select(t => new TransactionDTO()
        //                              {
        //                                  Id = t.Id,
        //                                  SenderAccountID = t.SenderAccountID,
        //                                  ReceiverAccountID = t.ReceiverAccountID,
        //                                  Amount = t.Amount,
        //                                  Description = t.Description,
        //                                  TimeStamp = t.TimeStamp,
        //                                  Status = t.Status.StatusName,
        //                                  StatusId = t.StatusId,
        //                                  SenderAccount = accountMapper.MapFrom(t.SenderAccount),
        //                                  ReceiverAccount = accountMapper.MapFrom(t.ReceiverAccount),
        //                                  IsSend = true

        //                              });

        //    var transactionsRecieved = context.Transactions
        //                              .Include(t => t.Status)
        //                              .Include(t => t.SenderAccount).ThenInclude(a => a.Client)
        //                              .Include(t => t.SenderAccount).ThenInclude(a => a.UsersAccounts)
        //                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.Client)
        //                              .Include(t => t.ReceiverAccount).ThenInclude(a => a.UsersAccounts)
        //                              .Where(t => (accountsIds.Contains(t.ReceiverAccountID) && t.StatusId == 1))
        //                              .Select(t => new TransactionDTO()
        //                              {
        //                                  Id = t.Id,
        //                                  SenderAccountID = t.SenderAccountID,
        //                                  ReceiverAccountID = t.ReceiverAccountID,
        //                                  Amount = t.Amount,
        //                                  Description = t.Description,
        //                                  TimeStamp = t.TimeStamp,
        //                                  Status = t.Status.StatusName,
        //                                  StatusId = t.StatusId,
        //                                  SenderAccount = accountMapper.MapFrom(t.SenderAccount),
        //                                  ReceiverAccount = accountMapper.MapFrom(t.ReceiverAccount),
        //                                  IsRecieved = true
        //                              });


        //    var transactionsDTO = await transactionsSender.Concat(transactionsRecieved)
        //         .OrderByDescending(t => t.TimeStamp)
        //         .Skip((currentPage - 1) * pageSize).Take(pageSize)
        //         .ToListAsync();

        //    return transactionsDTO;
        //}
        //public async Task<long> GetTransactionsCount(long userId, long? accountId)
        //{
        //    if (accountId == null)
        //    {
        //        var accountsIds = await accountService.GetUserAccountsIdsAsync(userId);
        //        var transactionsSenderCount = await context.Transactions
        //                              .Include(t => t.Status)
        //                              .Include(t => t.SenderAccount)
        //                              .Include(t => t.ReceiverAccount)
        //                              .Where(t => accountsIds.Contains(t.SenderAccountID))
        //                              .CountAsync();
        //        var transactionsRecieverCount = await context.Transactions
        //                             .Include(t => t.Status)
        //                             .Include(t => t.SenderAccount)
        //                             .Include(t => t.ReceiverAccount)
        //                             .Where(t => (accountsIds.Contains(t.ReceiverAccountID) && t.StatusId == 1))
        //                             .CountAsync();

        //        return transactionsRecieverCount + transactionsSenderCount;
        //    }
        //    else
        //    {
        //        var accountTransactionsCount = await context.Transactions
        //                             .Include(x => x.Status)
        //                             .Include(x => x.SenderAccount)
        //                             .Include(x => x.ReceiverAccount)
        //                             .Where(t => t.SenderAccountID == accountId
        //                             || (t.ReceiverAccountID == accountId && t.StatusId == 1)).CountAsync();

        //        return accountTransactionsCount;
        //    }
        //}

        //public async Task<TransactionDTO> SendSavedTransactionAsync(long transactionId)
        //{
        //    var transactionDTO = new TransactionDTO();
        //    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        var transaction = await context.Transactions
        //            .Include(t => t.SenderAccount)
        //            .Include(t => t.ReceiverAccount)
        //            .SingleOrDefaultAsync(t => t.Id == transactionId);
        //        if (transaction == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_TRANSACTION").Value);
        //        }
        //        var date = dateWrapper.Now();
        //        var senderAccount = await accountService.GetAccountByIdAsync(transaction.SenderAccount.Id);
        //        if (senderAccount == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //        }
        //        var recieverAccount = await accountService.GetAccountByIdAsync(transaction.ReceiverAccount.Id);
        //        if (recieverAccount == null)
        //        {
        //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //        }

        //        if (senderAccount.Balance < transaction.Amount)
        //        {
        //            throw new InsufficientFundsException(config.GetSection("GlobalConstants:NOT_ENOUGH").Value);
        //        }
        //        transaction.StatusId = 1;
        //        transaction.TimeStamp = date;
        //        senderAccount.Balance -= transaction.Amount;
        //        recieverAccount.Balance += transaction.Amount;
        //        await context.SaveChangesAsync();
        //        transactionDTO = transactionMapper.MapFrom(transaction);
        //        scope.Complete();
        //    }

        //    return transactionDTO;


        //}

        //public async Task<TransactionDTO> EditTransactionAsync(string senderAccountNumber,
        //    string receiverAccountNumber, string description, decimal amount, long transactionId)
        //{
        //    var transaction = await context.Transactions
        //             .SingleOrDefaultAsync(t => t.Id == transactionId);
        //    if (transaction == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_TRANSACTION").Value);
        //    }
        //    var senderAccount = await accountService.GetAccountAsync(senderAccountNumber);
        //    if (senderAccount == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //    }
        //    var recieverAccount = await accountService.GetAccountAsync(receiverAccountNumber);
        //    if (recieverAccount == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_ACCOUNT").Value);
        //    }
        //    var date = dateWrapper.Now();
        //    transaction.TimeStamp = date;
        //    transaction.SenderAccountID = senderAccount.Id;
        //    transaction.ReceiverAccountID = recieverAccount.Id;
        //    transaction.Description = description;
        //    transaction.Amount = amount;
        //    await context.SaveChangesAsync();
        //    var transactionDTO = transactionMapper.MapFrom(transaction);
        //    return transactionDTO;
        //}
    }
}
