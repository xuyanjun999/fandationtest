using System;
using System.Threading;
using System.Threading.Tasks;
using Foundatio.Queues;
using  StackExchange.Redis;
namespace ConsoleApp1
{
    public class QueuePersistenceTest
    {
        public async void Start1()
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("47.94.140.80:6379");
            
            //ISubscriber subscriber = connectionMultiplexer.GetSubscriber();
            
            
            IQueue<MyWorkItem> queue = new RedisQueue<MyWorkItem>(new RedisQueueOptions<MyWorkItem>()
            {
                 ConnectionMultiplexer = (ConnectionMultiplexer)connectionMultiplexer
            });//Queue<SimpleWorkItem>(new InMemoryQueueOptions<SimpleWorkItem>());

            await queue.EnqueueAsync(new MyWorkItem {
                Data = "Hello"
            });

            //var workItem = await queue.DequeueAsync();
            
            //Console.WriteLine($"queue:{workItem.Value.Data}");
        }
        public async void Start2()
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("47.94.140.80:6379");
            
            //ISubscriber subscriber = connectionMultiplexer.GetSubscriber();
            
            
            IQueue<MyWorkItem> queue = new RedisQueue<MyWorkItem>(new RedisQueueOptions<MyWorkItem>()
            {
                ConnectionMultiplexer = (ConnectionMultiplexer)connectionMultiplexer
            });//Queue<SimpleWorkItem>(new InMemoryQueueOptions<SimpleWorkItem>());

           
            var workItem2 = await queue.DequeueAsync();
            
            workItem2.MarkCompleted();
            
            Console.WriteLine($"queue333:{workItem2.Value.Data}");

        
        
        }
        
        
        
    }

  
}