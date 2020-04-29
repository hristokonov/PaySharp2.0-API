namespace PaySharp.API.Dal.Models
{
    public class UsersAccounts
    {

        public long UserId { get; set; }
        public User User { get; set; }


        public long AccountId { get; set; }
        public Account Account { get; set; }
    }
}
