using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// XOR decryption
/// https://projecteuler.net/problem=59
/// </summary>
public partial class Problem059(ILogger<Problem059> logger) : IProblem
{
    private readonly ILogger<Problem059> logger = logger;

    public async Task<string> CalculateAsync(string[] args)
    {
        var textFile = await File.ReadAllTextAsync("Problems/001-100/51-60/Problem059_cipher.txt");
        var encryptedText = string.Concat(textFile.Split(",").Select(x => (char)int.Parse(x)));

        var possiblePasswords = PossiblePasswords();

        var password = string.Empty;
        var text = string.Empty;
        foreach (var possiblePassword in possiblePasswords)
        {
            var decrypted = Decrypt(encryptedText, possiblePassword);

            this.logger.LogDebug("{decrypted}", decrypted);

            if (WordsRegex().IsMatch(decrypted))
            {
                password = possiblePassword;
                text = decrypted;
                break;
            }
        }

        this.logger.LogInformation("The password is '{password}'", password);

        return text.Select(x => (int)x).Sum().ToString();
    }

    private static IEnumerable<string> PossiblePasswords()
    {
        var alphabet = StringHelper.AlphabetLowercase;
        foreach (var i in alphabet)
        {
            foreach (var j in alphabet)
            {
                foreach (var k in alphabet)
                {
                    yield return $"{i}{j}{k}";
                }
            }
        }
    }

    private static string Decrypt(string code, string password)
    {
        var sb = new StringBuilder();
        var keyIndex = 0;

        foreach (var c in code)
        {
            var r = (char)(c ^ password[keyIndex]);
            sb.Append(r);

            keyIndex++;
            if (keyIndex == password.Length)
            {
                keyIndex = 0;
            }
        }

        return sb.ToString();
    }

    [GeneratedRegex(@"^[\w\s\.\,\'\?\!\;\(\)\+\-\*\/""\:\[\]]*$")]
    private static partial Regex WordsRegex();
}
