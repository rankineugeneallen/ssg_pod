using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSG_Pod_Retrieval.model
{
    class Podcast
    {
        public int id { get; set; }
        public string shortName { get; set; }
        public string prodCode { get; set; }
        public string title { get; set; }
        public int typeId { get; set; }
        public string type { get; set; }
        public int retroId { get; set; }
        public string retro { get; set; }
        public string runtime { get; set; }
        public string dateRec { get; set; }
        public DateTime dateRecDate { get; set; }
        public string dateRel { get; set; }
        public DateTime dateRelDate { get; set; }
        public int filmRelYear { get; set; }
        public string editor { get; set; }
        public string hosts { get; set; }
        public string url { get; set; }
        public string corbinRating {get; set;}
        public string corbinRecommend { get; set; }
        public string allenRating { get; set; }
        public string allenRecommend { get; set; }

        public override string ToString()
        {
            return shortName;
        }

    }
}
