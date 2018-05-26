using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace PublisherSubscriber
{
    class Subscriber
    {
        #region Variables
        const int upperLimit = 100;

        private BlockingCollection<long> cunsmerCollection;

        private string id;
        #endregion

        #region Getters And Setters

        public Subscriber()
        {
            this.id = Id;
            this.cunsmerCollection = this.CunsmerCollection;
        }

        public BlockingCollection<long> CunsmerCollection
        {
            get
            {
                return cunsmerCollection = new BlockingCollection<long>(upperLimit);
            }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}

