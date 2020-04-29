using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PaySharp.API.Dal.Models;
using System.IO;

namespace PaySharp.API.Dal
{
    public class PaySharpDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersAccounts> UsersAccounts { get; set; }
        public DbSet<UsersClients> UsersClients { get; set; }

        public IConfiguration Configuration { get; }

        public PaySharpDBContext(DbContextOptions<PaySharpDBContext> options)
           : base(options)
        {

        }

        public PaySharpDBContext(DbContextOptions<PaySharpDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }
        private void LoadJson(ModelBuilder builder)
        {
            //if (File.Exists(@"..\PaySharp.API\Dal\JsonFiles\Users.json")
            //    && File.Exists(@"..\PaySharp.API\Dal\JsonFiles\Roles.json")
            //    && File.Exists(@"..\PaySharp.API\Dal\JsonFiles\Admins.json")
            //    && File.Exists(@"..\PaySharp.API\Dal\JsonFiles\Clients.json")
            //    && File.Exists(@"..\PaySharp.API\Dal\JsonFiles\Accounts.json")
            //    && File.Exists(@"..\PaySharp.API\Dal\JsonFiles\Status.json")
            //    && File.Exists(@"..\PaySharp.API\Dal\JsonFiles\UsersAccounts.json")
            //    && File.Exists(@"..\PaySharp.API\Dal\JsonFiles\UsersClients.json"))
            //{
            //    var roles = JsonConvert.DeserializeObject<Role[]>
            //       (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\Roles.json"));
            //    var users = JsonConvert.DeserializeObject<User[]>
            //        (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\Users.json"));
            //    var admins = JsonConvert.DeserializeObject<Admin[]>
            //        (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\Admins.json"));
            //    var clients = JsonConvert.DeserializeObject<Client[]>
            //       (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\Clients.json"));
            //    var accounts = JsonConvert.DeserializeObject<Account[]>
            //       (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\Accounts.json"));
            //    var statuses = JsonConvert.DeserializeObject<Status[]>
            //       (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\Status.json"));
            //    var usersClients = JsonConvert.DeserializeObject<UsersClients[]>
            //     (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\UsersClients.json"));
            //    var usersAccounts = JsonConvert.DeserializeObject<UsersAccounts[]>
            //       (File.ReadAllText(@"..\PaySharp.API\Dal\JsonFiles\UsersAccounts.json"));

            //    builder.Entity<Role>().HasData(roles);
            //    builder.Entity<User>().HasData(users);
            //    builder.Entity<Admin>().HasData(admins);
            //    builder.Entity<Client>().HasData(clients);
            //    builder.Entity<Account>().HasData(accounts);
            //    builder.Entity<Status>().HasData(statuses);
            //    builder.Entity<UsersClients>().HasData(usersClients);
            //    builder.Entity<UsersAccounts>().HasData(usersAccounts);
            //}
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            LoadJson(builder);

            //Many to many relations Users and Accounts
            builder.Entity<UsersAccounts>()
            .HasKey(u => new { u.UserId, u.AccountId });

            builder.Entity<UsersAccounts>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UsersAccounts)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<UsersAccounts>()
                .HasOne(ua => ua.Account)
                .WithMany(a => a.UsersAccounts)
                .HasForeignKey(ua => ua.AccountId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            //Many to many relations Users and Clients
            builder.Entity<UsersClients>()
            .HasKey(u => new { u.UserId, u.ClientId });

            builder.Entity<UsersClients>()
               .HasOne(uc => uc.User)
               .WithMany(u => u.UsersClients)
               .HasForeignKey(uc => uc.UserId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.Entity<UsersClients>()
                .HasOne(uc => uc.Client)
                .WithMany(c => c.UsersClients)
                .HasForeignKey(uc => uc.ClientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<Transaction>()
                 .HasOne(tr => tr.SenderAccount)
                 .WithMany(a => a.SenderAccounts)
                 .HasForeignKey(tr => tr.SenderAccountID)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired();

            builder.Entity<Transaction>()
                .HasOne(tr => tr.ReceiverAccount)
                .WithMany(a => a.ReceiverAccounts)
                .HasForeignKey(tr => tr.ReceiverAccountID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
