using SSGPodRetrieval.constant;
using SSGPodRetrieval.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval
{
    public sealed class ProdCodeManager
    {
        private readonly string PREFIX = "SSG";
        TableData tableData = TableData.Instance;
        private Podcast pod;
        private Retrospective retro;

        public ProdCodeManager(Podcast pod, Retrospective retro)
        {
            this.pod = pod;
            this.retro = retro;
        }

        //SSG-RFS-19-2-121
        //{PREFIX}-{TYPE_REF}-{POD_COMBO}
        //{PREFIX}-{POD_TYPE}{RETRO_TYPE}-{RETRO_ID}-{TRACK}-{POD_ID}
        public string contructProdCode()
        {
            string pod_type_code = tableData.getPodTypeCode(pod.typeId);
            string retro_type_code = tableData.getRetroTypeCode(retro.typeId);
            string retro_id = retro.id.ToString();
            string pod_id = pod.id.ToString();
            string track = "";

            if (string.IsNullOrEmpty(pod.track))
            {
                track = getNextTrack();
            }
            else
            {
                track = pod.track;
            }

            return constructProdCode(pod_type_code, retro_type_code, retro_id, track, pod_id);
        }

        private string getNextTrack()
        {
            int nextTrack = 0;
            int currTrack = 0;
            foreach (Podcast podcast in retro.podcasts)
            {
                try
                {
                    currTrack = int.Parse(podcast.track);
                    if (currTrack > nextTrack) nextTrack = currTrack;

                }
                catch (FormatException) { }
                catch (ArgumentNullException) { }
            }

            ++nextTrack;
            return nextTrack.ToString();
        }

        private string constructProdCode(string pod_type_code, string retro_type_code, string retro_id, string track, string pod_id)
        {
            string TYPE_REF = "";
            string POD_COMBO = "";

            TYPE_REF = constructTypeRef(pod_type_code, retro_type_code);
            POD_COMBO = constructPodCombo(retro_id, track, pod_id);

            return PREFIX + "-" + TYPE_REF + "-" + POD_COMBO;
        }

        private string constructProdCode(string TYPE_REF, string POD_COMBO)
        {
            return PREFIX + "-" + TYPE_REF + "-" + POD_COMBO;
        }

        private string constructTypeRef(string pod_type, string retro_type)
        {
            return pod_type + retro_type;
        }

        private string constructPodCombo(string retro_id, string track, string pod_id)
        {
            return retro_id + "-" + track + "-" + pod_id;
        }

        //{PREFIX}-{POD_TYPE}{RETRO_TYPE}-{RETRO_ID}-{TRACK}-{POD_ID}
        public ProductionCode deconstructProdCode(string prodCodeStr)
        {
            ProductionCode prodCode = new ProductionCode();
            
            string[] prodCodeArr = prodCodeStr.Split('-');

            if (prodCodeArr.Length == 5)
            {
                prodCode.PREFIX = prodCodeArr[0];
                prodCode.retro_id = int.Parse(prodCodeArr[2]);
                prodCode.track = int.Parse(prodCodeArr[3]);
                prodCode.pod_id= int.Parse(prodCodeArr[4]);

                //deconstruct type reference 
                if(prodCodeArr[1].Length == 2)
                {
                    prodCode.pod_type = prodCodeArr[1][0].ToString();
                    prodCode.retro_type = prodCodeArr[1][1].ToString();
                }
                else
                {
                    prodCode.pod_type = prodCodeArr[1].Substring(0, 2);
                    prodCode.retro_type = prodCodeArr[1][2].ToString();
                }

                return prodCode;

            }

            return null;

        }

        public string incTrackFromProdCode(string prodCodeStr)
        {
            ProductionCode prodCode = deconstructProdCode(prodCodeStr);

            int track = -1;
            try
            {
                ++prodCode.track;
                return prodCode.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string assignNewPodType(string prodCodeStr, string newPodTypeCode)
        {

            ProductionCode prodCode = new ProductionCode();
            prodCode = deconstructProdCode(prodCodeStr);

            prodCode.pod_type = newPodTypeCode;

            return prodCode.ToString();
        }

        public string assignNewRetroType(string prodCodeStr, string newRetroTypeCode)
        {

            ProductionCode prodCode = new ProductionCode();
            prodCode = deconstructProdCode(prodCodeStr);

            prodCode.retro_type = newRetroTypeCode;

            return prodCode.ToString();
        }


        public string assignNewRetroId(string prodCodeStr, int newRetroId)
        {

            ProductionCode prodCode = new ProductionCode();
            prodCode = deconstructProdCode(prodCodeStr);

            prodCode.retro_id = newRetroId;

            return prodCode.ToString();
        }

        public string assignNewTrack(string prodCodeStr, int newTrack)
        {

            ProductionCode prodCode = new ProductionCode();
            prodCode = deconstructProdCode(prodCodeStr);

            prodCode.track = newTrack;

            return prodCode.ToString();
        }


        //{PREFIX}-{POD_TYPE}{RETRO_TYPE}-{RETRO_ID}-{TRACK}-{POD_ID}
        public string assignNewPodId(string prodCodeStr, int newPodId)
        {

            ProductionCode prodCode = new ProductionCode();
            prodCode = deconstructProdCode(prodCodeStr);

            prodCode.pod_id = newPodId;

            return prodCode.ToString();
        }


        //SSG-RFS-19-2-121
        //{PREFIX}-{TYPE_REF}-{POD_COMBO}
        //{PREFIX}-{POD_TYPE}{RETRO_TYPE}-{RETRO_ID}-{TRACK}-{POD_ID}
        

        public sealed class ProductionCode
        {
            public string PREFIX { get; set; }
            public string pod_type { get; set; }
            public string retro_type { get; set; }
            public int retro_id { get; set; }
            public int track { get; set; }
            public int pod_id { get; set; }

            public string getTypeRef()
            {
                return pod_type + retro_type;
            }

            public string getPodCombo()
            {
                return retro_id + "-" + track + "-" + pod_id;
            }

            public override string ToString()
            {
                return PREFIX + "-" + getTypeRef() + "-" + getPodCombo();
            }

        }
    }

}
