using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriber
{
    class Publisher
    {
        #region Variables
        private string id;

        private int start = 0;

        private int additions = 0;

        private BlockingCollection<long> publisherCollection;
        #endregion

        #region Constructor
        public Publisher()
        {
            id = this.Id;
            start = this.Start;
            additions = this.Additions;
        }
        #endregion Constructor

        #region Setters And Getters
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int Start
        {
            get
            {
                return start;
            }
        }

        public int Additions
        {
            get
            {
                return additions;
            }
            set
            {
                additions = value;
            }
        }

        public BlockingCollection<long> PublisherCollection
        {
            get
            {
                if (publisherCollection == null)
                {
                    return publisherCollection = new BlockingCollection<long>(100);
                }
                else
                {
                    return publisherCollection;
                }

            }
        }
        #endregion 
    }
}
