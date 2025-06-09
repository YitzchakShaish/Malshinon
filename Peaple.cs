using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public enum PersonType
    {
        Reporter,
        Target,
        Both,
        PotentialAgent
    }
    internal class People
    {
        int id;
        string first_name;
        string last_name;
        int secret_cod;
        PersonType type_poeple;
        int num_reports = 0;
        int num_mentions = 0;
    
    public People(string first_name,string last_name,int secret_cod,string type_poeple)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.secret_cod = secret_cod;
            if (!Enum.TryParse<PersonType>(type_poeple, true, out var parsedType))
            {
                throw new ArgumentException("Invalid person type");
            }

            this.type_poeple = parsedType;
        }

        public override string ToString()
        {
            return $"id: {id}, first_name: {first_name}, last_name: {last_name}, type_poeple: {type_poeple}, secret_code: {secret_cod}, num_reports {num_reports}, num_mentions: {num_mentions} ";
        }

    }
}
