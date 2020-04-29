namespace PaySharp.API.Services.Contracts
{
    public interface IAuthorizationManager
    {
        void CheckIfLogged(string tokenValue);
        long GetLoggedUserId(string tokenValue);
        void CheckForRole(string tokenValue, string roleToCheckFor);
    }
}
