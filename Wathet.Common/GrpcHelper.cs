using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Wathet.Common.Grpc;

namespace Wathet.Common
{
    public class GrpcHelper
    {

        public static GrpcChannel GetChannel(string key)
        {

            GrpcChannelPool grpcChannelPool = GrpcChannelPool.Instacne;

            
            var channel = grpcChannelPool.GetChannel(key); //GrpcChannel.ForAddress("https://192.168.1.6:4441");

            return channel;
        }
    }
}
