using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockFreeBuilder
{
    public interface IBuilder
    {
         ThreadObject CreateAndGetResults(string content);
    }
}
