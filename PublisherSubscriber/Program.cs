using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using System.Timers;
using System.Diagnostics;

namespace PublisherSubscriber
{
    class Program
    {
        #region Variables
        private bool lockWasTakenProducer = false;

        private bool lockWasTakenConsumer = false;

        private static Loggic loggic = new Loggic();

        private Subscriber subscriber;

        private Publisher publisher;

        private Queue publisherQueue = new Queue();

        private Queue consumerQueue = new Queue();
        #endregion Variables

        #region MainProgramEntry
        static void Main()
        {
            try
            {
                var p = new Program();

                p.CreatePublisherTask();

                p.CreateConsumerTask();

                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main ===>{0}", ex.Message.ToString());
            }
        }
        #endregion

        #region Private Method
        private void CreateConsumerTask()
        {
            for (int i = 0; i < 2; i++)
            {

                Thread.Sleep(TimeSpan.FromSeconds(3));
                Monitor.Enter(consumerQueue, ref lockWasTakenConsumer);
                try
                {
                    Parallel.Invoke(() =>
                    {

                        var consumers = Task.Factory.StartNew(() =>
                        {
                            subscriber = new Subscriber();
                            subscriber.Id = Task.CurrentId.ToString();
                            Console.WriteLine("Create {0} Consumer with id {1}", i, subscriber.Id);
                            loggic.CreateConsumerTask(subscriber); ;
                        });
                    });
                }
                finally
                {
                    if (lockWasTakenConsumer)
                    {
                        Monitor.Exit(consumerQueue);
                        lockWasTakenConsumer = false;
                    }
                }
            }
        }

        public void CreatePublisherTask()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Monitor.Enter(publisherQueue, ref lockWasTakenProducer);
                try
                {
                    Parallel.Invoke(() =>
                    {
                        var producers = Task.Factory.StartNew(() =>
                        {
                            publisher = new Publisher();
                            publisher.Id = Task.CurrentId.ToString();
                            Console.WriteLine("Create {0} Publisher with id {1}", i, publisher.Id);
                            loggic.CreateProducerTask(publisher);
                        });
                    });
                }
                finally
                {
                    if (lockWasTakenProducer)
                    {
                        Monitor.Exit(publisherQueue);
                        lockWasTakenProducer = false;
                    }

                }
            }
        }
        #endregion Private Method
    }
}

