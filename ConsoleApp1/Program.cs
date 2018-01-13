using System;
using StackExchange.Redis;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                QueueTest queueTest = new QueueTest();
                queueTest.Start1();
                queueTest.Start2();
                CacheTest cacheTest = new CacheTest();
                cacheTest.Start1();
                Console.WriteLine("Hello World!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        
        
        
       
    }
}