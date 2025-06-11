using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public enum PersonType
    {
        reporter,
        target,
        both,
        potential_agent
    }
    internal class People
    {
     public   int id;
     public   string first_name;
     public   string last_name;
     public   string secret_code;
     public   PersonType type_poeple;
     public   int num_reports = 0;
     public   int num_mentions = 0;
    
    public People(string first_name,string last_name, string secret_code)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.secret_code = secret_code;
        }

        public People(string first_name, string last_name)
        {
            this.first_name = first_name;
            this.last_name = last_name;
        }
        public void CreateSecretCode(string firstName)
        {
            string newSecretCode  = GenretrRandom.GenerateCode(8,firstName);
            Console.WriteLine("secret_code=: " + secret_code);
            secret_code = newSecretCode;
        }
        public override string ToString()
        {
            return $"id: {id}, first_name: {first_name}, last_name: {last_name}, type_poeple: {type_poeple}, secret_code: {secret_code}, num_reports {num_reports}, num_mentions: {num_mentions} ";
        }

    }
}
