using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaySharp.API.Dal;
using PaySharp.API.Models;
using PaySharp.API.Services.Contracts;
using PaySharp.API.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySharp.API.Services
{
    public class UserService : IUserService
    {
        private readonly PaySharpDBContext context;
        private readonly IPasswordHasher passwordHasher;
        private readonly IConfiguration config;

        public UserService(PaySharpDBContext context, IPasswordHasher passwordHasher, IConfiguration config)

        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        //public async Task<UserDTO> AddUserAsync(string name, string userName, string password)
        //{
        //    if (context.Users.Any(x => x.UserName == userName))
        //    {
        //        throw new EntityAlreadyExistsException(config.GetSection("GlobalConstants:USER_EXISTS").Value);
        //    }

        //    var hashedPassword = passwordHasher.GetHashString(password);

        //    var user = new User()
        //    {
        //        Name = name,
        //        UserName = userName,
        //        Password = hashedPassword,
        //        RoleId = 2
        //    };

        //    context.Users.Add(user);

        //    await context.SaveChangesAsync();

        //    return userMapper.MapFrom(user);
        //}

        public async Task<UserLoginModel> GetLoginUserAsync(string username, string password)
        {
            var user = await (from us in context.Users
                              join r in context.Roles on us.RoleId equals r.Id
                              where us.UserName == username
                              select new UserLoginModel
                              {
                                  UserId = us.Id.ToString(),
                                  UserName = us.UserName,
                                  Role = r.Name,
                                  Password = us.Password
                              }).SingleOrDefaultAsync();

            if (user == null)
            {
                throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
            }
            var hashedPassword = passwordHasher.GetHashString(password);

            if (user.Password != hashedPassword)
            {
                throw new EntityNotFoundException(config.GetSection("GlobalConstants:INCORRECT_PASSWORD").Value);
            }

            return user;
        }


        //public async Task<AdminDTO> GetAdminAsync(string username, string password)
        //{
        //    var admin = await context.Admins.Include(c => c.Role)
        //        .SingleOrDefaultAsync(x => x.UserName == username);

        //    if (admin == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
        //    }
        //    var hashedPassword = passwordHasher.GetHashString(password);

        //    if (admin.Password != hashedPassword)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:INCORRECT_PASSWORD").Value);
        //    }

        //    return adminMapper.MapFrom(admin);
        //}

        //public async Task<UserDTO> AddUserToClientAsync(long userId, string clientName)
        //{
        //    var user = await context.Users.Include(c => c.Role)
        //        .SingleOrDefaultAsync(x => x.Id == userId);
        //    var client = await context.Clients
        //       .SingleOrDefaultAsync(x => x.Name == clientName);
        //    if (user == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
        //    }
        //    if (client == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_CLIENT").Value);
        //    }
        //    var userClientExists = await context.UsersClients.SingleOrDefaultAsync(uc => uc.ClientId == client.Id && uc.UserId == userId);
        //    if (userClientExists != null)
        //    {
        //        throw new EntityAlreadyExistsException(config.GetSection("GlobalConstants:USER_CLIENT").Value);
        //    }
        //    var userClient = new UsersClients() { ClientId = client.Id, UserId = userId };

        //    context.UsersClients.Add(userClient);
        //    await context.SaveChangesAsync();

        //    return userMapper.MapFrom(user);
        //}

        //public async Task<UserDTO> AddUserToClientAsync(long userId, long clientId)
        //{
        //    var user = await context.Users.Include(c => c.Role)
        //        .SingleOrDefaultAsync(x => x.Id == userId);
        //    var client = await context.Clients
        //       .SingleOrDefaultAsync(x => x.Id == clientId);
        //    if (user == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
        //    }
        //    if (client == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_CLIENT").Value);
        //    }
        //    var userClientExists = await context.UsersClients.SingleOrDefaultAsync(uc => uc.ClientId == client.Id && uc.UserId == userId);
        //    if (userClientExists != null)
        //    {
        //        throw new EntityAlreadyExistsException(config.GetSection("GlobalConstants:USER_CLIENT").Value);
        //    }
        //    var userClient = new UsersClients() { ClientId = clientId, UserId = userId };
        //    context.UsersClients.Add(userClient);
        //    await context.SaveChangesAsync();

        //    return userMapper.MapFrom(user);
        //}

        //public async Task<UserDTO> GetUserAsync(long userId)
        //{
        //    var user = await context.Users.Include(c => c.Role)
        //         .Include(u => u.UsersAccounts)
        //        .ThenInclude(ua => ua.Account)
        //        .Include(u => u.UsersClients)
        //        .ThenInclude(uc => uc.Client)
        //        .SingleOrDefaultAsync(x => x.Id == userId);

        //    if (user == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
        //    }

        //    var userDTO = new UserDTO()
        //    {
        //        UserId = user.Id,
        //        Name = user.Name,
        //        UserName = user.UserName,
        //        Accounts = user.UsersAccounts.Select(ua => accountMapper.MapFrom(ua.Account)).ToList(),
        //        Clients = user.UsersClients.Select(uc => clientMapper.MapFrom(uc.Client)).ToList()
        //    };

        //    return userDTO;
        //}

        //public async Task<List<UserDTO>> TakeNumberOfUsersAsync(int currentPage, int pageSize = 5)
        //{
        //    var users = await context.Users
        //         .OrderByDescending(c => c.Id)
        //         .Skip((currentPage - 1) * pageSize)
        //         .Take(pageSize)
        //         .ToListAsync();
        //    var userDTO = users.Select(c => userMapper.MapFrom(c)).ToList();

        //    return userDTO;
        //}

        //public async Task<long> GetAllUsersCountAsync()
        //{
        //    var users = await context.Users.CountAsync();

        //    return users;
        //}
        //public async Task<UserDTO> GetUserAsync(string searchName)
        //{
        //    var user = await context.Users.Include(u => u.UsersAccounts)
        //        .ThenInclude(ua => ua.Account)
        //        .Include(u => u.UsersClients)
        //        .ThenInclude(uc => uc.Client)
        //        .SingleOrDefaultAsync(x => x.UserName == searchName);

        //    if (user == null)
        //    {
        //        throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_USER").Value);
        //    }
        //    var userDTO = new UserDTO()
        //    {
        //        UserId = user.Id,
        //        Name = user.Name,
        //        UserName = user.UserName,
        //        Accounts = user.UsersAccounts.Select(ua => accountMapper.MapFrom(ua.Account)).ToList(),
        //        Clients = user.UsersClients.Select(uc => clientMapper.MapFrom(uc.Client)).ToList()
        //    };

        //    return userDTO;
        //}

        //public async Task<IList<string>> FindUserContainingAsync(string searchString)
        //{
        //    var usersNames = await context.Users.Where(x => x.UserName.Contains(searchString))
        //        .Select(x => x.UserName)
        //        .Take(5).ToListAsync();

        //    return usersNames;
        //}
    }
}
