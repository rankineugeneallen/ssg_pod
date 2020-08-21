using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    public class RetroType
    {
        public RetroType() { } 
        public RetroType(int id, string title, string code) 
        {
            this.id = id;
            this.title = title;
            this.code = code; 
        } 

        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }

        public override string ToString()
        {
            return title;
        }
    }
}
