using SSGPodRetrieval.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSGPodRetrieval.constant
{
    public sealed class TableData
    {
        private static TableData instance = null;

        QueryDaoImpl query = new QueryDaoImpl();
        //Dictionary<Retrospective, List<Podcast>> retrospectivePool = new Dictionary<Retrospective, List<Podcast>>();
        ProdCodeManager PCM;
        ArrayList retrospectives = new ArrayList();
        ArrayList podTypes = new ArrayList();
        ArrayList retroTypes = new ArrayList();
        ArrayList hosts = new ArrayList();
        ArrayList ratings = new ArrayList();
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
            loadRatings();

            setRetroTypes();
            setPodTypes();
            setHostRatings();
            setPodcastRatings();

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
                        podcast.podType = new PodType(podType.id, podType.type, podType.code);
                        break;
                    }
                }
            }
        }

        public ArrayList getPodTypes()
        {
            return podTypes;
        }

        public int getNextPodTypeId()
        {
            int newId = -1;

            foreach (PodType podType in podTypes)
                if (podType.id > newId) newId = podType.id;

            return ++newId;
        }

        public string getPodTypeCode(int inId)
        {
            foreach(PodType type in podTypes)
            {
                if(type.id == inId)
                {
                    return type.code;
                }
            }
            return "";
        }

        #endregion


        #region Retrospective Types
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
                        retrospective.retroType = new RetroType(retroType.id, retroType.title, retroType.code);
                        break;
                    }
                }
            }
        }

        public ArrayList getRetroTypes()
        {
            return retroTypes;
        }


        public int getNextRetroTypeId()
        {
            int newId = -1;

            foreach (RetroType retroType in retroTypes)
                if (retroType.id > newId) newId = retroType.id;

            return ++newId;
        }

        public string getRetroTypeCode(int inId)
        {
            foreach (RetroType type in retroTypes)
            {
                if (type.id == inId)
                {
                    return type.code;
                }
            }
            return "";
        }


        public int updateRetroType(RetroType updRetroType)
        {
            int ret = query.updateRetroType(updRetroType);

            if(ret > 0)
            {
                for(int i = 0; i < retroTypes.Count; i++)
                {
                    if(((RetroType)retroTypes[i]).id == updRetroType.id)
                    {
                        retroTypes[i] = updRetroType;
                    }
                }

            }
            return ret;
        }

        public RetroType addRetroType(RetroType retroType)
        {
            retroType.id = getNextRetroTypeId();
            
            int ret = query.insertRetroType(retroType);

            if(ret > 0)
            {
                retroTypes.Add(retroType);
                return retroType; 
            }
            return null;
        }


        public int removeRetroType(RetroType retroType)
        {
            int ret = query.deleteRetroType(retroType);

            if(ret > 0)
            {
                retroTypes.Remove(retroType);    
            }

            return ret;
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

        public ArrayList getRetrosOfType(int typeId)
        {
            ArrayList retRetros = new ArrayList();
            foreach(Retrospective retro in retrospectives)
            {
                if(retro.typeId == typeId)
                {
                    retRetros.Add(retro);
                }
            }
            
            return retRetros;
        }

        public Retrospective getRetrospective(int id)
        {
            foreach(Retrospective retro in retrospectives)
            {
                if(retro.id == id)
                {
                    return retro;
                }
            }
            return null;
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

        public bool checkCodeExists(string code)
        {
            foreach(Retrospective retro in retrospectives)
            {
                if(retro.code == code)
                {
                    return true;
                }
            }
            return false;
        }

        private Retrospective getRetroFromRetroId(int id)
        {
            foreach(Retrospective retro in retrospectives)
            {
                if (retro.id == id) return retro;
            }

            return null;
        }

        public void addPodToRetro(Podcast pod)
        {
            foreach(Retrospective retro in retrospectives)
            {
                if(retro.id == pod.retroId)
                {
                    retro.podcasts.Add(pod);
                }
            }
            
            //List<Podcast> tempList = new List<Podcast>();
            //tempList.Add(pod);
            //retrospectivePool.Add(getRetroFromRetroId(pod.retroId), tempList);
        }

        public void removePodFromRetro(Podcast pod)
        {
            foreach (Retrospective retro in retrospectives)
            {
                if (retro.id == pod.retroId)
                {
                    retro.podcasts.Remove(pod);
                }
            }

            //List<Podcast> tempList = new List<Podcast>();
            //tempList.Add(pod);
            //retrospectivePool.Add(getRetroFromRetroId(pod.retroId), tempList);
        }


        public Retrospective addRetro(Retrospective newRetro)
        {
            newRetro.id = getNextRetroId();

            int ret = query.insertRetro(newRetro);

            if (ret > 0)
            {
                retrospectives.Add(newRetro);

                return newRetro;
            }

            return null;
        }


        public int updateRetro(Retrospective updRetro)
        {
            int ret = query.updateRetro(updRetro);

            if(ret > 0)
            {
                for(int i = 0; i < retrospectives.Count; i++)
                {
                    if(((Retrospective)retrospectives[i]).id == updRetro.id)
                    {
                        retrospectives[i] = updRetro;
                        break;
                    }
                }
            }
            
            return ret;
        }

        public void updateRetrospectiveList(Podcast updPod)
        {
            foreach (Retrospective retro in retrospectives)
            {
                if (retro.id == updPod.retroId)
                {
                    for (int i = 0; i < retro.podcasts.Count; i++)
                    {
                        if (((Podcast)retro.podcasts[i]).id == updPod.id)
                        {
                            retro.podcasts[i] = updPod;
                        }
                    }
                }
            }
            //update pods
            //for (int i = 0; i < podcasts.Count; i++)
            //{
            //    if (((Podcast)podcasts[i]).id == updPod.id)
            //    {
            //        podcasts[i] = updPod;
            //    }
            //}
        }

        public int getNextRetroId()
        {
            int newId = -1;

            foreach (Retrospective retro in retrospectives)
                if (retro.id > newId) newId = retro.id;

            return ++newId;
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

        public void updatePodcastsList(Podcast updPod)
        {
            for (int i = 0; i < podcasts.Count; i++)
            {
                if (((Podcast)podcasts[i]).id == updPod.id)
                {
                    podcasts[i] = updPod;
                }
            }

        }

        public int updatePodcast(Podcast updPod)
        {
            //return query.updatePod(pod);
            
            int ret = query.updatePod(updPod);

            if(ret > 0)
            {
                updatePodcastsList(updPod);
            }

            return ret;
        }


        //public int updatePodProdCode(Podcast updPod)
        //{
        //    int ret = query.updatePodProdCode(updPod);

        //    if(ret > 0)
        //    {
        //        updatePodcastsList(updPod);
        //    }

        //    return ret;
        //}

        public int updatePodTypeId(Podcast updPod)
        {
            int ret = query.updatePodType(updPod);

            if(ret > 0)
            {
                updatePodcastsList(updPod);
            }

            return ret;
        }


        public int updatePodProdCodeAndTypeId(Podcast updPod)
        {
            int ret = query.updatePodProdCodeAndType(updPod);

            if (ret > 0)
            {
                updatePodcastsList(updPod);
            }

            return ret;
        }

        public int getNextPodId()
        {
            int newId = -1;

            foreach (Podcast pod in podcasts)
                if (pod.id > newId) newId = pod.id;

            return ++newId;
        }



        public Podcast addPod(Podcast newPod)
        {
            newPod.id = getNextPodId();
            PCM = new ProdCodeManager(newPod, getRetrospective(newPod.retroId));
            
            newPod.prodCode = PCM.contructProdCode();
            MessageBox.Show("New Production Code: " + newPod.prodCode, "Podcast Production Code", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int ret = query.insertPodcast(newPod);

            if(ret > 0)
            {
                podcasts.Add(newPod);

                addPodToRetro(newPod);

                return newPod;
            }

            return null;
        }

        //TODO - make retro and pod updates seperate function 
        public int updatePodProdCode(Podcast updPod)
        {
            int ret = query.updatePodProdCode(updPod);

            if(ret > 0)
            {
                // update retro first
                updateRetrospectiveList(updPod);

                updatePodcastsList(updPod);
            }

            return ret;
        }

        public int removePodcast(Podcast pod)
        {
            int ret = query.deletePod(pod);

            if(ret > 0)
            {
                podcasts.Remove(pod);

                removePodFromRetro(pod);
            }

            return ret;
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

        public ArrayList getHosts(ArrayList hostIds)
        {
            ArrayList retHosts = new ArrayList();

            for(int i = 0; i < hostIds.Count; i++)
            {
                for(int j = 0; j < hosts.Count; j++)
                {
                    if ((int)hostIds[i] == ((Host)hosts[j]).id)
                        retHosts.Add(hosts[j]);
                }
            }

            return retHosts;
        }


        public Host addHost(Host host)
        {
            host.id = getNextHostId();
            
            int ret = query.insertHost(host);

            if (ret > 0)
            {
                hosts.Add(host);
                return host;
            }
            
            return null;
        }


        public int getNextHostId()
        {
            int newId = -1;

            foreach (Host host in hosts)
                if (host.id > newId) newId = host.id;

            return ++newId;
        }

        public int updateHost(Host updHost)
        {
            for (int i = 0; i < hosts.Count; i++)
            {
                if (((Host)hosts[i]).id == updHost.id)
                {
                    hosts[i] = updHost;
                    return query.updateHost(updHost);
                }
            }


            return 0;
        }


        #endregion


        #region Ratings
        private void loadRatings()
        {
            ratings = query.getAllRatings();
        }

        private void setHostRatings()
        {
            foreach(Host host in hosts)
            {
                foreach(Rating rating in ratings)
                {
                    if(rating.hostId == host.id)
                    {
                        rating.host = host;
                    }
                }
            }
        }

        private void setPodcastRatings()
        {
            foreach(Podcast pod in podcasts)
            {
                foreach(Rating rating in ratings)
                {
                    if(rating.podcastId == pod.id)
                    {
                        pod.ratings.Add(rating);
                    }
                }
            }
        }

        public int getNextRatingId()
        {
            int newId = -1;

            foreach (Rating rating in ratings)
                if (rating.id > newId) newId = rating.id;

            return ++newId;
        }


        public int updateRating(Rating updRating)
        {
            for(int i = 0; i < ratings.Count; i++)
            {
                if(((Rating)ratings[i]).id == updRating.id)
                {
                    ratings[i] = updRating;
                }
            }

            //return query.updateRating(updRating);

            return 0;
        }


        public List<int> updateOrAddRatings(List<Rating> newOrUpdatedRates)
        {
            List<Rating> updateRates = new List<Rating>();
            List<Rating> newRates = new List<Rating>();

            foreach(Rating rating in newOrUpdatedRates)
            {
                foreach(Rating exRates in ratings)
                {
                    if(rating.id == exRates.id)
                    {
                        updateRates.Add(rating);
                    }
                    else
                    {
                        newRates.Add(rating);
                    }
                }
            }


            //assign ids to ratings 
            int nextId = getNextRatingId();
            foreach(Rating newRate in newRates)
            {
                newRate.id = nextId;
                nextId++;
            }

            List<int> multiRatingRet = query.insertMultiRatings(newRates);
            multiRatingRet.AddRange(query.updateMultiRatings(updateRates));

            //in future, i wanna be able to identify what went wrong somewhere...but for now its fine. 


            return multiRatingRet;
        }

        public Rating addOrUpdateRating(Rating rating)
        {
            Rating tempRate;

            if(rating.id == 0)
            {
                rating.id = getNextRatingId();
            }
            
            if (query.updateOrAddRating(rating) > 0)
            {
                for(int i = 0; i < ratings.Count; i++)
                {
                    //if rating already exists, then update it
                    tempRate = (Rating)ratings[i];

                    if(tempRate.id == rating.id)
                    {
                        ratings[i] = rating;
                        return (Rating)ratings[i];
                    }
                }
                //if not then add it 
                ratings.Add(rating);
                return rating;
            }

            return null;
        }


        public Rating addRating(Rating rating)
        {
            rating.id = getNextRatingId();

            int ret = query.insertRating(rating);
            if(ret > 0)
            {
                ratings.Add(rating);
                assignNewRatingToPod(rating);
                return rating;
            }

            return null;
        }


        private void assignNewRatingToPod(Rating rating)
        {
            int retroId = -1;
            int podId = -1;
            foreach(Podcast pod in podcasts)
            {
                if (pod.id == rating.podcastId)
                {
                    pod.ratings.Add(rating);
                    retroId = pod.retroId;
                    podId = pod.id;
                }
            }

            foreach(Retrospective retro in retrospectives)
            {
                if(retro.id == retroId)
                {
                    foreach(Podcast pod in retro.podcasts)
                    {
                        if(pod.id == podId)
                        {
                            pod.ratings.Add(rating);
                        }
                    }
                }
            }
        }

        private void assignUpdatedRatingToPod(Rating rating)
        {
            int retroId = -1;
            int podId = -1;
            foreach(Podcast pod in podcasts)
            {
                if (pod.id == rating.podcastId)
                {
                    for(int i = 0; i < pod.ratings.Count; i++)
                    {
                        if(((Rating)pod.ratings[i]).id == rating.id)
                        {
                            pod.ratings[i] = rating;
                            retroId = pod.retroId;
                            podId = pod.id;
                        }
                    }
                }
            }

            foreach(Retrospective retro in retrospectives)
            {
                if(retro.id == retroId)
                {
                    foreach(Podcast pod in retro.podcasts)
                    {
                        if(pod.id == podId)
                        {
                            //pod.ratings.Add(rating);
                            for (int i = 0; i < pod.ratings.Count; i++)
                            {
                                if (((Rating)pod.ratings[i]).id == rating.id)
                                {
                                    pod.ratings[i] = rating;
                                    retroId = pod.retroId;
                                    podId = pod.id;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion


        public int shakeBaby()
        {
            ArrayList pods = getPodcasts();
            List<Rating> ratingsList = new List<Rating>();
            Rating tempRating;
            Host tempAllen = new Host();
            Host tempCorbin = new Host();
            Host tempTommy = new Host();
            Host tempCurtis = new Host();
            Host tempJacob = new Host();
            Host tempBrad = new Host();

            tempAllen.id = 2;
            tempCorbin.id = 1;
            tempTommy.id = 3;
            tempCurtis.id = 4;
            tempJacob.id = 5;
            tempBrad.id = 6;
            
            tempRating = new Rating();
            tempRating.id = 0;
            int lastId = tempRating.id;

            foreach (Podcast pod in pods)
            {
                if (pod.shortName == "Test") continue;
                //corbin
                if (pod.hostIds.Contains(1))
                {
                    tempRating.id = ++lastId;
                    tempRating.podcastId = pod.id;
                    tempRating.host = tempCorbin;


                    if (string.IsNullOrEmpty(pod.corbinRating))
                        tempRating.recommend = false;
                    else
                        tempRating.recommend = pod.corbinRecommend;

                    tempRating.rating = pod.corbinRating;

                    query.insertRating(tempRating);
                    addRating(tempRating);
                    Console.WriteLine("Adding Corbin's rating to " + pod.shortName + "\n" +
                        "\tRating ID: " + tempRating.id + "\n" +
                        "\tPodcast ID: " + pod.id + "\n" +
                        "\tHost: Corbin\n" +
                        "\tRating: " + pod.corbinRating + "\n" +
                        "\tRecommend: " + pod.corbinRecommend.ToString() + ".\n\n");
                }

                //allen
                if (pod.hostIds.Contains(2))
                {
                    tempRating = new Rating();
                    tempRating.id = ++lastId;
                    tempRating.podcastId = pod.id;
                    tempRating.host = tempAllen;
                
                    if (string.IsNullOrEmpty(pod.allenRating))
                        tempRating.recommend = false;
                    else
                        tempRating.recommend = pod.allenRecommend;

                    tempRating.rating = pod.allenRating;
                
                    query.insertRating(tempRating);
                    addRating(tempRating);
                    Console.WriteLine("Adding Allen's rating to " + pod.shortName + "\n" +
                        "\tRating ID: " + tempRating.id + "\n" +
                        "\tPodcast ID: " + pod.id + "\n" +
                        "\tHost: Allen\n" +
                        "\tRating: " + pod.allenRating + "\n" +
                        "\tRecommend: " + pod.allenRecommend.ToString() + ".\n\n\n");
                }
                
                //tommy
                if (pod.hostIds.Contains(3))
                {
                    tempRating = new Rating();
                    tempRating.id = ++lastId;
                    tempRating.podcastId = pod.id;
                    tempRating.host = tempTommy;
                
                    tempRating.recommend = false;
                    tempRating.rating = "";
                
                    query.insertRating(tempRating);
                    addRating(tempRating);
                    Console.WriteLine("Adding Tommy to " + pod.shortName + "\n" +
                        "\tRating ID: " + tempRating.id + "\n" +
                        "\tPodcast ID: " + pod.id + "\n" +
                        "\tHost: Tommy.\n\n\n");
                }
                
                //curtis
                if (pod.hostIds.Contains(4))
                {
                    tempRating = new Rating();
                    tempRating.id = ++lastId;
                    tempRating.podcastId = pod.id;
                    tempRating.host = tempCurtis;
                
                    tempRating.recommend = false;
                    tempRating.rating = "";
                
                    query.insertRating(tempRating);
                    addRating(tempRating);
                    Console.WriteLine("Adding Curtis to " + pod.shortName + "\n" +
                        "\tRating ID: " + tempRating.id + "\n" +
                        "\tPodcast ID: " + pod.id + "\n" +
                        "\tHost: Curtis.\n\n\n");
                }

                //jacob
                if (pod.hostIds.Contains(5))
                {
                    tempRating = new Rating();
                    tempRating.id = ++lastId;
                    tempRating.podcastId = pod.id;
                    tempRating.host = tempJacob;
                
                    tempRating.recommend = false;
                    tempRating.rating = "";
                
                    query.insertRating(tempRating);
                    addRating(tempRating);
                    Console.WriteLine("Adding Jacob to " + pod.shortName + "\n" +
                        "\tRating ID: " + tempRating.id + "\n" +
                        "\tPodcast ID: " + pod.id + "\n" +
                        "\tHost: Jacob.\n\n\n");
                }

                //brad
                if (pod.hostIds.Contains(6))
                {
                    tempRating = new Rating();
                    tempRating.id = ++lastId;
                    tempRating.podcastId = pod.id;
                    tempRating.host = tempJacob;
                
                    tempRating.recommend = false;
                    tempRating.rating = "";
                
                    query.insertRating(tempRating);
                    addRating(tempRating);
                    Console.WriteLine("Adding Brad to " + pod.shortName + "\n" +
                        "\tRating ID: " + tempRating.id + "\n" +
                        "\tPodcast ID: " + pod.id + "\n" +
                        "\tHost: Brad.\n\n\n");
                }

            }
                //}
            return -1;
        }
    }

}
