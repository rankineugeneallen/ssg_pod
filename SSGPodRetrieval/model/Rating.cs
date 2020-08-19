using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    public class Rating
    {
        public int id { get; set; }
        public int tempId { get; set; }
        public int podcastId { get; set; }
        public int hostId { get; set; }
        public Host host { get; set; }
        public string rating { get; set; }
        public bool recommend { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(rating))
                return host.firstName;
            return host.firstName + "\t" + rating + "\t" + recommend.ToString();
        }
    }
}
