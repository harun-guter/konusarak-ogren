using System.Security.Cryptography;
using System.Text;

namespace Core.Helpers.Security;

public class HashHelper
{
    public static string Hash(string password)
    {
        var hash = MD5.Create();
        byte[] array = Encoding.UTF8.GetBytes(password);
        array = hash.ComputeHash(array);
        var stringBuilder = new StringBuilder();
        foreach (var item in array) stringBuilder.Append(item.ToString("x2"));
        return stringBuilder.ToString();
    }
}
