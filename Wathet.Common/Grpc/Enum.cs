using System;
using System.Collections.Generic;
using System.Text;

namespace Wathet.Common.Grpc
{
    public enum PoolState
    {
        UnInitialize = 0,
        Initialize,
        Run,
        Stop
    }
}
