using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    public class PodType
    {
        public PodType() { }

        public PodType(int id, string type, string code)
        {
            this.id = id;
            this.type = type;
            this.code = code;
        }

        public int id { get; set; }
        public string type { get; set; }
        public string code { get; set; }

        public override string ToString()
        {
            return type;
        }
    }
}
