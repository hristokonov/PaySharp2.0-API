namespace PaySharp.API.Services.Contracts
{
    public interface ICookieManager
    {
        void AddSessionCookieForToken(string token, string userName);

        void DeleteSessionCookies();
    }
}
