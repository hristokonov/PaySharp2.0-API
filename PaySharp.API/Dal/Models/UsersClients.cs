namespace PaySharp.API.Dal.Models
{
    public class UsersClients
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long ClientId { get; set; }
        public Client Client { get; set; }
    }
}
