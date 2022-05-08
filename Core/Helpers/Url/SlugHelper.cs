namespace Core.Helpers.Url;

public static class SlugHelper
{
    private static Random _random = new Random();

    public static string Generate()
    {
        const string charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string charsLower = "abcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";
        const string chars = charsLower + charsUpper + numbers;
        return new string(Enumerable.Repeat(chars, 16).Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}
