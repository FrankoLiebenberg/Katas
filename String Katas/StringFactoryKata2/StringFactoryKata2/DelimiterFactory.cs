using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFactoryKata2
{
    public abstract class DelimiterFactory
    {
        public abstract IDelimiter GetDelimiter(string numbers);
    }
}
