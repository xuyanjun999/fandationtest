using System;
using StackExchange.Redis;

namespace ConsoleApp1
{
    public class MessageTest
    {
       public  void Start1()
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("47.94.140.80:6379");
            ISubscriber subscriber = connectionMultiplexer.GetSubscriber();
          
            subscriber.Subscribe("message", (x, y) =>
            {
                Console.Write(y);
            });
            
            /*
            ISubscriber subscriber2 = connectionMultiplexer.GetSubscriber();
            subscriber2.Subscribe("message1", (x, y) =>
            {
                Console.Write(y);
            });
            
            subscriber.Publish("message", "123");
            */
        }
        
       public  void Start2()
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("47.94.140.80:6379");
            ISubscriber subscriber = connectionMultiplexer.GetSubscriber();
            /*
              subscriber.Subscribe("message", (x, y) =>
              {
                  Console.Write(y);
              });
              
              ISubscriber subscriber2 = connectionMultiplexer.GetSubscriber();
              subscriber2.Subscribe("message1", (x, y) =>
              {
                  Console.Write(y);
              });
              */
            
            subscriber.Publish("message", "123");
        }
    }
}