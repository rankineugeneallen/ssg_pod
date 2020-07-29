using SSGPodRetrieval.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.constant
{
    public sealed class TableData
    {
        private static TableData instance = null;

        QueryDaoImpl query = new QueryDaoImpl();
        Dictionary<Retrospective, List<Podcast>> retrospectivePool = new Dictionary<Retrospective, List<Podcast>>();
        ArrayList retrospectives = new ArrayList();
        ArrayList podTypes = new ArrayList();
        ArrayList retroTypes = new ArrayList();
        ArrayList hosts = new ArrayList();
        ArrayList podcasts = new ArrayList();

        private TableData() { loadData(); }
        
        public static TableData Instance
        {
            get{
                if (instance == null)
                    instance = new TableData();
                return instance;
            }
        }


        private void loadData()
        {
            loadPodTypes();
            loadRetroTypes();
            loadRetrospectives();
            loadPodcasts();
            loadHosts();

            setRetroTypes();
            setPodTypes();

            buildRetroPool();
            buildAverages();
        }

        public void reload()
        {
            loadData();
        }


        public void reloadPodcasts()
        {
            loadPodcasts();
            setPodTypes();
        }


        #region Podcast Types
        private void loadPodTypes()
        {
            podTypes = query.getAllPodTypes();
        }


        private void setPodTypes()
        {
            foreach (Podcast podcast in podcasts)
            {
                foreach (PodType podType in podTypes)
                {
                    if (podcast.typeId == podType.id)
                    {
                        podcast.type = podType.type;
                    }
                }
            }
        }

        public ArrayList getPodTypes()
        {
            return podTypes;
        }
        #endregion


        #region PodTypes
        private void loadRetroTypes()
        {
            retroTypes = query.getAllRetroTypes();
        }

        private void setRetroTypes()
        {
            foreach (Retrospective retrospective in retrospectives)
            {
                foreach (RetroType retroType in retroTypes)
                {
                    if (retrospective.typeId == retroType.id)
                    {
                        retrospective.type = retroType.title;
                    }
                }
            }
        }

        public ArrayList getRetroTypes()
        {
            return retroTypes;
        }
        #endregion


        #region Retrospectives
        private void loadRetrospectives()
        {
            retrospectives = query.getAllRetros();
        }

        public ArrayList getRetrospectives()
        {
            return retrospectives;
        }

        public void buildRetroPool()
        {
            foreach(Podcast pod in podcasts)
            {
                foreach(Retrospective retro in retrospectives)
                {
                    if(pod.retroId == retro.id)
                    {
                        retro.podcasts.Add(pod);
                    }
                }
            }
        }

        public void buildAverages()
        {
            foreach(Retrospective retro in retrospectives)
            {
                retro.average = calcRetroAverages(retro);
            }
        }

        private Average calcRetroAverages(Retrospective retro)
        {
            Average average = new Average();
            List<int> overallRatings = new List<int>();
            List<int> corbinsRatings = new List<int>();
            List<int> allensRatings = new List<int>();
            List<bool> overallRecommends = new List<bool>();
            List<bool> corbinsRecommends = new List<bool>();
            List<bool> allensRecommends = new List<bool>();
            int tempRate = -2; //default state is 2
            double overallAvgRate = 0.0;
            double corbinAvgRate = 0.0;
            double allenAvgRate = 0.0;
            double overallRecommendPerc = 0.0;
            double corbinRecommendPerc = 0.0;
            double allenRecommendPerc = 0.0;

            //gather ratings
            foreach (Podcast pod in retro.podcasts)
            {
                //tempPod = (Podcast)retroItems[i];

                //must be Review(Film) type
                if (pod.typeId == 1)
                {

                    tempRate = calcRating(pod.corbinRating);
                    if (tempRate > -2)
                    {
                        corbinsRatings.Add(tempRate);
                        overallRatings.Add(tempRate);
                    }

                    tempRate = calcRating(pod.allenRating);
                    if (tempRate > -2)
                    {
                        allensRatings.Add(tempRate);
                        overallRatings.Add(tempRate);
                    }

                    corbinsRecommends.Add(pod.corbinRecommend);
                    allensRecommends.Add(pod.allenRecommend);
                    overallRecommends.Add(pod.corbinRecommend);
                    overallRecommends.Add(pod.allenRecommend);

                    tempRate = -2;
                }
            }

            if (overallRatings.Count > 0)
            {
                //calc score averages
                if (overallRatings.Count > 0) overallAvgRate = Queryable.Average(overallRatings.ToArray().AsQueryable());
                if (corbinsRatings.Count > 0) corbinAvgRate = Queryable.Average(corbinsRatings.ToArray().AsQueryable());
                if (allensRatings.Count > 0) allenAvgRate = Queryable.Average(allensRatings.ToArray().AsQueryable());

                //calc recommend averages
                overallRecommendPerc = calcRecommendScore(overallRecommends);
                corbinRecommendPerc = calcRecommendScore(corbinsRecommends);
                allenRecommendPerc = calcRecommendScore(allensRecommends);

                average.overallRatings = overallRatings;
                average.corbinsRatings = corbinsRatings;
                average.allensRatings = allensRatings;
                average.overallRecommends = overallRecommends;
                average.corbinsRecommends = corbinsRecommends;
                average.allensRecommends = allensRecommends;
                average.overallAvgRate = overallAvgRate;
                average.corbinAvgRate = corbinAvgRate;
                average.allenAvgRate = allenAvgRate;
                average.overallRecommendPerc = overallRecommendPerc;
                average.corbinRecommendPerc = corbinRecommendPerc;
                average.allenRecommendPerc = allenRecommendPerc;

                return average;
            }
            

            return null;
        }

        private double calcRecommendScore(List<bool> recommends)
        {
            List<int> recommendPool = new List<int>();
            double recommendScore = 0.0;

            foreach (bool rating in recommends)
            {
                if (rating == true) recommendPool.Add(1);
                else recommendPool.Add(0);
            }

            recommendScore = Queryable.Average(recommendPool.ToArray().AsQueryable());

            return recommendScore;
        }

        /*
         -1 <-- dropped
         -2 <-- do not count (default)
        */
        private int calcRating(string rating)
        {
            switch (rating)
            {
                case "-":
                    return -1;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "11":
                    return int.Parse(rating);
                default:
                    return -2;
            }
        }
        #endregion


        #region Podcasts
        public void loadPodcasts()
        {
            podcasts = query.getAllPodcasts();
        }

        public ArrayList getPodcasts()
        {
            return podcasts;
        }

        public int updatePodcast(Podcast pod)
        {
            return query.updatePod(pod);
        }

        #endregion


        #region Hosts
        private void loadHosts()
        {
            hosts = query.getAllHosts();
        }

        public ArrayList getHosts()
        {
            return hosts;
        }

        #endregion

    }
}
