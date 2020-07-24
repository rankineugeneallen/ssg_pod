using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    class PodType
    {
        public int id { get; set; }
        public string type { get; set; }
        public string code { get; set; }

        public override string ToString()
        {
            return type;
        }
    }
}
