using System;
using System.Threading;
using System.Threading.Tasks;
using Foundatio.Queues;
using StackExchange.Redis;
namespace ConsoleApp1
{
    public class QueueTest
    {
        public async void Start1()
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("47.94.140.80:6379");

            //ISubscriber subscriber = connectionMultiplexer.GetSubscriber();


            IQueue<SimpleWorkItem> queue = new RedisQueue<SimpleWorkItem>(new RedisQueueOptions<SimpleWorkItem>()
            {
                ConnectionMultiplexer = (ConnectionMultiplexer)connectionMultiplexer
            });//Queue<SimpleWorkItem>(new InMemoryQueueOptions<SimpleWorkItem>());

            for (int i = 0; i < 100; i++)
            {
                await queue.EnqueueAsync(new SimpleWorkItem
                {
                    Data = $"Hello   {i}       " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                });
            }

        }


        //var workItem = await queue.DequeueAsync();

        //Console.WriteLine($"queue:{workItem.Value.Data}");

        public async void Start2()
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("47.94.140.80:6379");

            //ISubscriber subscriber = connectionMultiplexer.GetSubscriber();


            IQueue<SimpleWorkItem> queue = new RedisQueue<SimpleWorkItem>(new RedisQueueOptions<SimpleWorkItem>()
            {
                ConnectionMultiplexer = (ConnectionMultiplexer)connectionMultiplexer
            });//Queue<SimpleWorkItem>(new InMemoryQueueOptions<SimpleWorkItem>());

            // var DeadletterItems= await queue.GetDeadletterItemsAsync();
            // var workItem = await queue.DequeueAsync();
           


            //Task.Factory.StartNew( async () =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"is work complete? :{workItem.IsCompleted}");
            //    Console.WriteLine($"queue222:{workItem.Value.Data}");
            //    await workItem.CompleteAsync();
            //});

            for (int i = 0; i < 10; i++)
            {
              
                    var workItem2 = await queue.DequeueAsync();
                if (workItem2 != null)
                {
                    Console.WriteLine($"queue333:{workItem2.Value.Data}");
                }
                    
            }

            Console.WriteLine($" end of this time");



        }



    }

    public class SimpleWorkItem
    {
        public string Data { get; set; }
    }
}