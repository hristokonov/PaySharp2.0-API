namespace PaySharp.API.Utilities.RandomGenerator
{
    public interface IRandomGenerator
    {
        string GenerateNumber(int min, int max, int amount);

    }
}
