using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockFreeBuilder
{
    public class Director
    {
        private readonly ThreadObject _result;

        public Director(IBuilder builder, string content)
        {
            _result = builder.CreateAndGetResults(content);
        }

        public ThreadObject Result => _result;
    }
}
