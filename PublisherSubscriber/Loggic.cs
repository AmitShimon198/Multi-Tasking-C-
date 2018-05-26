using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections;

namespace PublisherSubscriber
{
    class Loggic
    {

        #region Variables
        private AmazonQueue queue;

        public AmazonQueue AmazonQueue
        {
            get
            {
                if (queue != null)
                {
                    return queue;
                }
                else
                {
                    return queue = new AmazonQueue();
                }
            }

        }

        #endregion Variables

        #region Methods

        /// <summary>
        /// Method create tasks and send it to
        /// RunConsumer method in AmazonQueue Class 
        /// </summary>
        /// <param name="subscriber"></param>
        public void CreateConsumerTask(Subscriber subscriber)
        {
            try
            {
                for (int i = 0; i <= 20; i++)
                {
                    AmazonQueue.RunConsumer(subscriber);
                    Thread.Sleep(TimeSpan.FromSeconds(.3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateConsumerTask =====>", ex.Message);
            }
        }

        /// <summary>
        /// Send the publisher to ingect data to the static collection
        /// in AmazonQueue Class
        /// </summary>
        /// <param name="publisher"></param>
        public void CreateProducerTask(Publisher publisher)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    AmazonQueue.RunProducer(publisher);
                    Thread.Sleep(TimeSpan.FromSeconds(.3));
                }
                publisher.PublisherCollection.CompleteAdding();
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateProducerTask ======>", ex.Message);
            }
        }
        #endregion Methods
    }
}







