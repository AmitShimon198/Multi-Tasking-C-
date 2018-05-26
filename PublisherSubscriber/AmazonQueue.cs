using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Collections;

namespace PublisherSubscriber
{
    class AmazonQueue
    {
        #region Variables Setters And Getters

        private Queue producerQueue = new Queue();

        private Queue consumerQueue = new Queue();

        private Queue queue = new Queue();

        const int upperLimit = 100;

        const int itemsToProduce = 100;

        static BlockingCollection<long> collection = new BlockingCollection<long>(upperLimit);

        static int totalAdditions = 0;

        static int subtractions = 0;

        #endregion Variables And Setters And Getters

        #region Methods

        /// <summary>
        /// Method Thread saffty every invoketion one task 
        /// injects ten items in to the static collection 
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns></returns>
        public Publisher RunProducer(Publisher publisher)
        {
            Monitor.Enter(producerQueue);
            try
            {
                for (int i = publisher.Start; i < 10; i++)
                {
                  
                    if (!collection.IsAddingCompleted)
                    {
                        collection.Add(totalAdditions);
                    }

                    totalAdditions++;
                    publisher.Additions = totalAdditions;
                    QueueMonitoring("P", publisher.Id);
                    while (collection.IsAddingCompleted)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(.3));
                return publisher;
            }
            catch (Exception ex)
            {
                Console.WriteLine("RunProducer=====> {0}", ex.Message);
            }
            finally
            {
                Monitor.Exit(producerQueue);
            }
            return publisher;
        }

        /// <summary>
        /// Method Thread saffty every invoketion one task 
        /// takes five items from the static collection 
        /// </summary>
        /// <param name="publishe"></param>
        /// <returns></returns>
        public void RunConsumer(Subscriber subscriber)
        {
            Monitor.Enter(consumerQueue);
            try
            {
                int exist = 0;
                foreach (var item in collection.GetConsumingEnumerable())
                {
                    exist++;
                    subtractions++;
                    subscriber.CunsmerCollection.Add(item);
                    QueueMonitoring("C", subscriber.Id);
                    while (collection.Count == 0 && subtractions < 5)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }

                    if (exist == 5 || subscriber.CunsmerCollection.Count >= 100)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("RunConsumer=====> {0}", ex.Message);
            }
            finally
            {
                Monitor.Exit(consumerQueue);
            }
        }

        /// <summary>
        /// monitoring the order of the
        /// actions on the collection
        /// </summary>
        /// <param name="from"></param>
        /// <param name="id"></param>
        public  void QueueMonitoring(string from, string id)
        {
            var list = new List<string>();
            Monitor.Enter(queue);
            try {
                if (from.Equals("p", StringComparison.InvariantCultureIgnoreCase))
                {
                    list.Add("Publish item number :" + totalAdditions.ToString() + " Id: " + id);
                }
                else if (from.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                {
                    list.Add("Subscriber item number :" + subtractions + " Id: " + id);
                }
                foreach (var element in list)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine(element);
                }
            }
            finally
            {
                Monitor.Exit(queue);
            }
            
        }
        #endregion Methods
    }
}


