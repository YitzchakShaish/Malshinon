using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    //public enum PersonType
    //{
    //    Reporter,
    //    Target,
    //    Both,
    //    PotentialAgent
    //}
    internal class People
    {
     public   int id;
     public   string first_name;
     public   string last_name;
     public   string secret_code;
     public   string type_poeple;
     public   int num_reports = 0;
     public   int num_mentions = 0;
    
    public People(string first_name,string last_name, string secret_code)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.secret_code = secret_code;
            
            //if (!Enum.TryParse<PersonType>(type_poeple, true, out var parsedType))
            //{
            //    throw new ArgumentException("Invalid person type");
            //}

            //this.type_poeple = parsedType;
        }

        public People(string first_name, string last_name)
        {
            this.first_name = first_name;
            this.last_name = last_name;
        }



        public override string ToString()
        {
            return $"id: {id}, first_name: {first_name}, last_name: {last_name}, type_poeple: {type_poeple}, secret_code: {secret_code}, num_reports {num_reports}, num_mentions: {num_mentions} ";
        }

    }
}
