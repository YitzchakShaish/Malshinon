using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    static class GenretrRandom
    {
        public static string GenerateCode(int l, string firstName)
        {
            string lettersAndDigits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string lettersAndName = lettersAndDigits + firstName;

            Random rnd = new Random();
            char[] code = new char[l];

            for (int i = 0; i < l; i++)
            {

                code[i] = lettersAndName[rnd.Next(lettersAndName.Length)];
            }

            return new string(code);
        }
    }
}
