using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    static class GenretrRandom
    {
        public static string GenerateCode(int l)
        {
            string lettersAndDigits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


            Random rnd = new Random();
            char[] code = new char[l];

            for (int i = 0; i < l; i++)
            {

                code[i] = lettersAndDigits[rnd.Next(lettersAndDigits.Length)];
            }

            return new string(code);
        }
    }
}
