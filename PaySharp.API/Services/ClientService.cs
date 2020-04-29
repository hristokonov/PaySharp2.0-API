using PaySharp.API.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySharp.API.Services
{
    public class ClientService : IClientService
    {
    //    private readonly PaySharpDBContext context;
    //    private readonly IDtoMapper<Client, ClientDTO> clientMapper;
    //    private readonly IConfiguration config;

    //    public ClientService(PaySharpDBContext context, IDtoMapper<Client, ClientDTO> clientMapper,
    //        IConfiguration config)
    //    {
    //        this.context = context ?? throw new ArgumentNullException(nameof(context));
    //        this.clientMapper = clientMapper ?? throw new ArgumentNullException(nameof(clientMapper));
    //        this.config = config ?? throw new ArgumentNullException(nameof(config));
    //    }
    //    public async Task<Client> GetClientByNameAsync(string name)
    //    {
    //        var client = await context.Clients
    //            .SingleOrDefaultAsync(cl => cl.Name == name);

    //        return client;
    //    }

    //    public async Task<ClientDTO> GetClientAsync(long id)
    //    {
    //        var client = await context.Clients
    //            .Include(c => c.Accounts)
    //            .Include(c => c.UsersClients)
    //            .ThenInclude(uc => uc.User)
    //            .SingleOrDefaultAsync(cl => cl.Id == id);
    //        if (client == null)
    //        {
    //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_CLIENT").Value);
    //        }
    //        return clientMapper.MapFrom(client);
    //    }

    //    public async Task<ClientDTO> CreateClientAsync(string name)
    //    {
    //        var clientExists = await this.GetClientByNameAsync(name);

    //        if (clientExists != null)
    //        {
    //            throw new EntityAlreadyExistsException(config.GetSection("GlobalConstants:CLIENT_EXISTS").Value);
    //        }

    //        var client = new Client()
    //        {
    //            Name = name
    //        };

    //        context.Clients.Add(client);
    //        await context.SaveChangesAsync();
    //        var clientDTO = clientMapper.MapFrom(client);
    //        return clientDTO;
    //    }
    //    public async Task<ClientDTO> GetClientAsync(string name)
    //    {

    //        var client = await context.Clients
    //            .Include(c => c.Accounts)
    //            .Include(c => c.UsersClients)
    //            .ThenInclude(uc => uc.User)
    //            .SingleOrDefaultAsync(cl => cl.Name == name);
    //        if (client == null)
    //        {
    //            throw new EntityNotFoundException(config.GetSection("GlobalConstants:NO_CLIENT").Value);
    //        }
    //        var clientDTO = clientMapper.MapFrom(client);
    //        return clientDTO;
    //    }
    //    //TODO remove it ?
    //    //public async Task<List<ClientDTO>> GetAllClientsAsync()
    //    //{
    //    //    var clients = await context.Clients.Select(c => clientMapper.MapFrom(c))
    //    //        .OrderByDescending(c => c.ClientId).ToListAsync();

    //    //    return clients;
    //    //}

    //    public async Task<List<ClientDTO>> TakeNumberOfClientsAsync(int currentPage, int pageSize = 5)
    //    {
    //        var clients = await context.Clients
    //            .OrderByDescending(c => c.Id)
    //            .Skip((currentPage - 1) * pageSize)
    //            .Take(pageSize)
    //             .ToListAsync();
    //        var clientDTO = clients.Select(c => clientMapper.MapFrom(c)).ToList();

    //        return clientDTO;
    //    }
    //    public async Task<long> GetAllClientsCountAsync()
    //    {
    //        var clients = await context.Clients.CountAsync();

    //        return clients;
    //    }

    //    public async Task<IList<string>> FindClientContainingAsync(string searchString)
    //    {
    //        var clients = await context.Clients.Where(c => c.Name.Contains(searchString))
    //            .Select(c => c.Name)
    //            .Take(5).ToListAsync();

    //        return clients;
    //    }
    }
}
