using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval
{
    class Average
    {
        public List<int> overallRatings { get; set; }
        public List<int> corbinsRatings { get; set; }
        public List<int> allensRatings { get; set; }
        public List<bool> overallRecommends { get; set; }
        public List<bool> corbinsRecommends { get; set; }
        public List<bool> allensRecommends { get; set; }
        public int tempRate { get; set; }
        public double overallAvgRate { get; set; }
        public double corbinAvgRate { get; set; }
        public double allenAvgRate { get; set; }
        public double overallRecommendPerc { get; set; }
        public double corbinRecommendPerc { get; set; }
        public double allenRecommendPerc { get; set; }
    }
}
