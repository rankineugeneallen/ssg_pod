using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    class RetroItem
    {
        public string shortName { get; set; }
        public string prodCode { get; set; }
        public string runtime { get; set; }
        public string dateRec { get; set; }
        public string dateRel { get; set; }
        public string hosts { get; set; }
        public string editor { get; set; }
        public string podType { get; set; }

        public override string ToString()
        {
            return shortName;
        }
    }
}
