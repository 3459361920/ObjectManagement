using AngleSharp.Html;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Wathet.Common.Grpc
{

    public class GrpcChannelPool
    {
        const int MAX_CHANNEL_CAPCITY = 200;
        private static readonly GrpcChannelPool _instance = new GrpcChannelPool();
        private GrpcChannelPool() { }

        private Dictionary<string, string> ServicePoolDefSet;
        private Dictionary<string, List<GrpcChannel>> ServicePoolSet;
        private Dictionary<string, int> ServicePoolCurrentIndex;
        public static GrpcChannelPool Instacne
        {
            get
            {
                return _instance;
            }
        }
        //private List<GrpcChannel> ServiceList;
        //private int CurrentIndex;

        public static void Init()
        {
            _instance.ServicePoolDefSet = new Dictionary<string, string>();
            _instance.ServicePoolSet = new Dictionary<string, List<GrpcChannel>>();
            _instance.ServicePoolCurrentIndex = new Dictionary<string, int>();
            _instance.ServicePoolDefSet.Add("Azure", ConfigurationManager.AppSettings["APIMConfig:gRPCServiceUrl"]);
            _instance.ServicePoolDefSet.Add("Yapi", ConfigurationManager.AppSettings["YAPIConfig:gRPCServiceUrl"]);

            //_instance.ServiceList = new List<GrpcChannel>(MAX_CHANNEL_CAPCITY);
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            foreach (var service in _instance.ServicePoolDefSet)
            {
                List<GrpcChannel> serviceList = new List<GrpcChannel>();
                for (int i = 0; i < MAX_CHANNEL_CAPCITY; i++)
                { 
                    serviceList.Add(GrpcChannel.ForAddress(service.Value));
                }
                _instance.ServicePoolSet.Add(service.Key, serviceList);
                _instance.ServicePoolCurrentIndex.Add(service.Key, 0);
            }
        }

        public GrpcChannel GetChannel(string key)
        {
            lock (_instance.ServicePoolCurrentIndex)
            {
                int currentIndex = _instance.ServicePoolCurrentIndex[key];
                var serviceList = _instance.ServicePoolSet[key];

                var currentChannel = serviceList[currentIndex];

                currentIndex = Interlocked.Increment(ref currentIndex);
                if (currentIndex >= MAX_CHANNEL_CAPCITY)
                {
                    currentIndex = 0;
                }
                _instance.ServicePoolCurrentIndex[key] = currentIndex;
                return currentChannel;
            }
        }

    }
}
 