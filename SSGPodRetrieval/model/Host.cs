using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    public class Host
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
