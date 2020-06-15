using ProjectEuler.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._51_60
{
    public class Problem059 : IProblem
    {
        public async Task<string> CalculateAsync(string[] args)
        {
            var textFile = await File.ReadAllTextAsync("Problems/001-100/51-60/Problem059_cipher.txt");
            var codes = textFile.Split(",").Select(x => int.Parse(x)).ToArray();

            var possiblePasswords = PossiblePasswords();

            string password = "";
            string text = "";
            foreach (var possiblePassword in possiblePasswords)
            {
                var passwordAsInts = possiblePassword.Select(x => (int)x).ToArray();
                var output = Decrypt(codes, passwordAsInts).Select(x => (char)x);
                var decrypted = output.Concat();
                if (Regex.IsMatch(decrypted, @"^[a-zA-Z\d\s\.\,\'\?\!\;\(\)\+\-\*\/""\:\[\]]*$"))
                {
                    password = possiblePassword;
                    text = decrypted;
                    break;
                }
            }

            return text.Select(x => (int)x).Sum().ToString();
        }

        public IEnumerable<string> PossiblePasswords()
        {
            var alphabet = StringHelper.AlphabetLowercase;
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    for (int k = 0; k < alphabet.Length; k++)
                    {
                        yield return $"{alphabet[i]}{alphabet[j]}{alphabet[k]}";
                    }
                }
            }
        }

        public int[] Decrypt(int[] code, int[] password)
        {
            var output = new int[code.Length];
            var rest = code.Length % password.Length;
            var length = code.Length - rest;
            for (int i = 0; i < length; i += password.Length)
            {
                for (int j = 0; j < password.Length; j++)
                {
                    var index = i + j;
                    output[index] = code[index] ^ password[j];
                }
            }
            for (int i = 0; i < rest; i++)
            {
                output[length + i] = code[length + i] ^ password[i];
            }
            return output;
        }
    }
}
