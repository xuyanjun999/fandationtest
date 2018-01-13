using System;
using Foundatio.Caching;
using StackExchange.Redis;

namespace ConsoleApp1
{
    public class CacheTest
    {
        public async void Start1()
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("47.94.140.80:6379");
            
            //ISubscriber subscriber = connectionMultiplexer.GetSubscriber();
            ICacheClient cacheClient=new RedisCacheClient(new RedisCacheClientOptions()
            {
                 ConnectionMultiplexer =   (ConnectionMultiplexer)connectionMultiplexer
            });

           await cacheClient.SetAsync<MyCache>("key", new MyCache(){Data = "嘿嘿"});

           var r= await cacheClient.GetAsync<MyCache>("key");
            
           
            //var workItem = await queue.DequeueAsync();

            Console.WriteLine($"cache:{r.Value.Data}");
        }
    }

    class MyCache
    {
        public  string Data { get; set; }
    }
}