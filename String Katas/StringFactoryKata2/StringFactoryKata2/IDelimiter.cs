using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFactoryKata2
{
    public interface IDelimiter
    {
        List<string> GetDelimiters(string numbers);
    }
}
