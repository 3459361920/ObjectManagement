using System;
using System.Collections.Generic;
using System.Text;

namespace Wathet.Common.MyException
{
    public class BlockException : SystemException
    {
        public BlockException() { }
        public BlockException(string message) : base(message) { }
        public BlockException(string message, Exception inner)
            : base(message, inner) { }
    }
}
