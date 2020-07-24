using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSG_Pod_Retrieval.model
{
    class Retrospective
    {
        public int id { get; set; }
        public string title { get; set; }
        public int typeId { get; set; }
        public string type { get; set; }
        public string code { get; set; }

        public override string ToString()
        {
            return title;
        }
    }
}
