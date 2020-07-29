using SSGPodRetrieval;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    class Retrospective
    {
        public int id { get; set; }
        public string title { get; set; }
        public int typeId { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public Average average { get; set; }
        public List<Podcast> podcasts = new List<Podcast>();

        public override string ToString()
        {
            return title;
        }
    }
}
