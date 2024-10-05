using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingStrings
{

    interface StringGenerator
    {
        string Concatenate(List<LocalPerson> persons);
    }

    internal class GeneratorBuilder : StringGenerator
    {
        public string Concatenate(List<LocalPerson> persons)
        {
            var sb = new StringBuilder();
            foreach (var person in persons)
            {
                sb.AppendLine(person.ToString());
            }
            return sb.ToString();
        }
    }

    internal class GeneratorString : StringGenerator
    {
        public string Concatenate(List<LocalPerson> persons)
        {
            var result = "";
            foreach (var person in persons)
            {
                result += $"{person}\r\n";
            }
            return result;
        }
    }
}
