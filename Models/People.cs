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
     public   int id { get; set; }
     public   string first_name { get; set; }
        public   string last_name { get; set; }
        public   string secret_code { get; set; }
        public   PersonType type_poeple { get; set; }
        public int num_reports { get; set; } = 0;
        public int num_mentions { get; set; } = 0;

        public People(string first_name, string last_name, string secret_code)
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
        public People()
        {
            
        }
        public void CreateSecretCode(string firstName)
        {
            string newSecretCode  = GenretrRandom.GenerateCode(8,firstName);
            secret_code = newSecretCode;
        }
        public override string ToString()
        {
            return $"id: {id}, first_name: {first_name}, last_name: {last_name}, type_poeple: {type_poeple}, secret_code: {secret_code}, num_reports {num_reports}, num_mentions: {num_mentions} ";
        }

    }
}
