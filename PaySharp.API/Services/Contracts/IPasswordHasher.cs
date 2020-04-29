namespace PaySharp.API.Services.Contracts
{
    public interface IPasswordHasher
    {
        string GetHashString(string inputString);
    }
}
