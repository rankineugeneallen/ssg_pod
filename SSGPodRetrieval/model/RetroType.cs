using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    class RetroType
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }

        public override string ToString()
        {
            return title;
        }
    }
}
