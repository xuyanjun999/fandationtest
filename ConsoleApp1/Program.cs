﻿using System;
using System.Collections.Concurrent;
using StackExchange.Redis;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //System.Collections.Concurrent.
                //QueueTest queueTest = new QueueTest();

                //queueTest.Start1();
                //queueTest.Start2();

                //CacheTest cacheTest = new CacheTest();
                //cacheTest.Start1();

                //MessageTest messageTest=new MessageTest();
                //messageTest.Start1();
                //messageTest.Start2();
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