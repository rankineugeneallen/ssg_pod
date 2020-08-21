using MySql.Data.MySqlClient;
using SSGPodRetrieval.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval
{
    class QueryDaoImpl
    {
        static string username = Properties.Settings.Default.username;
        static string password = Properties.Settings.Default.password;
        static string ip = Properties.Settings.Default.ip;
        MySqlConnection conn2 = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";");

        public QueryDaoImpl()
        {

        }


        #region QUERIES        
        public ArrayList getAllPodTypes()
        {
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using(var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * from Podcast_Type;";
                ArrayList podTypes = new ArrayList();
                PodType podType;

                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        podType = new PodType();

                        podType.id = int.Parse(reader[0].ToString());
                        podType.type = reader[1].ToString();
                        podType.code = reader[2].ToString();

                        podTypes.Add(podType);
                    }

                }

                return podTypes;

            }
        }


        public ArrayList getAllRetroTypes()
        {
            RetroType retroType;
            ArrayList retroTypes = new ArrayList();
            
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {

                command.CommandText = "SELECT * from Retrospective_Type;";
                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retroType = new RetroType();

                        retroType.id = int.Parse(reader[0].ToString());
                        retroType.title = reader[1].ToString();
                        retroType.code = reader[2].ToString();

                        retroTypes.Add(retroType);
                    }

                }
            }

            return retroTypes;
        }

        public ArrayList getAllPodcasts()
        {

            string year;
            ArrayList podcasts = new ArrayList();
            Podcast pod;

            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {

                command.CommandText = "SELECT * FROM Podcast;";
                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pod = new Podcast();
                        ArrayList hostIds = new ArrayList();

                        pod.id = int.Parse(reader[0].ToString());
                        pod.shortName = reader[1].ToString();
                        pod.prodCode = reader[2].ToString();
                        pod.title = reader[3].ToString();
                        pod.typeId = int.Parse(reader[5].ToString());
                        pod.retroId = int.Parse(reader[8].ToString());
                        pod.runtime = reader[6].ToString();
                        pod.editor = reader[9].ToString();
                        //pod.hosts = reader[10].ToString();
                        pod.url = reader[11].ToString();
                        pod.corbinRating = reader[12].ToString();
                        pod.allenRating = reader[14].ToString();
                        try
                        {
                            string[] prodCodeArr = reader[2].ToString().Split('-');
                            pod.track = prodCodeArr[3];

                        }
                        catch (IndexOutOfRangeException) { }

                        //set hosts (convert string array to int array)
                        try
                        {
                            if (reader[10].ToString().Contains(','))
                            {
                                //int[] boi = Array.ConvertAll((reader[10].ToString().Split(',')), s => int.Parse(s));
                                hostIds.AddRange(Array.ConvertAll((reader[10].ToString().Split(',')), s => int.Parse(s)));
                            }
                            else
                                hostIds.Add(int.Parse(reader[10].ToString()));

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("UHOH");
                            hostIds.AddRange(reader[10].ToString().Split(','));
                        }

                        pod.hostIds = hostIds;


                        //set recommend
                        if (reader[13].ToString() == "TRUE") pod.corbinRecommend = true;
                        else pod.corbinRecommend = false;

                        if (reader[15].ToString() == "TRUE") pod.allenRecommend = true;
                        else pod.allenRecommend = false;

                        try
                        {
                            pod.dateRecDate = DateTime.Parse(reader[4].ToString());
                        }
                        catch (FormatException) { }

                        try
                        {
                            pod.dateRelDate = DateTime.Parse(reader[7].ToString());
                        }
                        catch (FormatException) { }
                        catch (ArgumentNullException) { }

                        //set url (remove # at start and end)
                        if (pod.url.Length > 1)
                        {
                            pod.url = pod.url.Substring(1, pod.url.Length - 2);
                        }

                        //set film release year (if it exists)
                        try
                        {
                            year = pod.shortName.Substring(pod.shortName.Length - 5).Substring(0, 4);

                            if (year.Length == 4)
                                pod.filmRelYear = int.Parse(year);
                            else
                                pod.filmRelYear = 0;
                        }
                        catch (ArgumentOutOfRangeException) { }
                        catch (FormatException) { }


                        podcasts.Add(pod);
                    }
                }
            }

            return podcasts;
        }

        public ArrayList getAllRetros()
        {
            ArrayList retrospectives = new ArrayList();
            Retrospective retro;

            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {

                command.CommandText = "SELECT * FROM Retrospective;";
                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retro = new Retrospective();

                        retro.id = int.Parse(reader[0].ToString());
                        retro.title = reader[1].ToString();
                        retro.typeId = int.Parse(reader[2].ToString());
                        retro.code = reader[3].ToString();

                        retrospectives.Add(retro);
                    }
                }

            }
            return retrospectives;
        }

        //TODO - convert to Using commands
        public ArrayList getPodsFromRetro(int retroId)
        {
            string query = "SELECT p.ShortName AS Podcasts, p.ProductionCode, "+
                "p.Runtime, p.DateRecorded, p.DateReleased, p.Hosts, p.Editor, pt.Type AS Podcast_Type "+
                "FROM Retrospective AS r, Podcast AS p, Podcast_Type AS pt "+
                "WHERE " + retroId.ToString() + " = r.ID AND "+ retroId.ToString() + " = p.RetrospectiveId AND p.TypeId = pt.ID "+
                "ORDER BY p.DateReleased;";
            int i = 0;
            RetroItem retroItem;
            ArrayList retrospective = new ArrayList();

            conn2.Open();
            MySqlCommand command = new MySqlCommand(query, conn2);
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                retroItem = new RetroItem();
                retroItem.shortName = reader[0].ToString();
                retroItem.prodCode = reader[1].ToString();
                retroItem.runtime = reader[2].ToString();
                retroItem.dateRec = reader[3].ToString();
                retroItem.dateRel = reader[4].ToString();
                retroItem.hosts = reader[5].ToString();
                retroItem.editor= reader[6].ToString();
                retroItem.podType = reader[7].ToString();

                retrospective.Add(retroItem);
            }

            conn2.Close();
            return retrospective;

        }

        public ArrayList getAllHosts()
        {
            ArrayList hosts = new ArrayList();
            Host host;
            
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Host;";
                conn.Open();

                //conn2.Open();
                //MySqlCommand command = new MySqlCommand(query, conn2);
                //MySqlDataReader reader = command.ExecuteReader();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        host = new Host();

                        host.id = int.Parse(reader[0].ToString());
                        host.firstName = reader[1].ToString();
                        host.lastName = reader[2].ToString();

                        hosts.Add(host);
                    }
                }
            }

            return hosts;
        }

        public ArrayList getAllRatings()
        {

            ArrayList ratings = new ArrayList();
            Rating rating;

            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Rating;";
                conn.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rating = new Rating();

                        rating.id = int.Parse(reader[0].ToString());
                        rating.podcastId = int.Parse(reader[1].ToString());
                        rating.hostId = int.Parse(reader[2].ToString());
                        rating.rating = reader[3].ToString();

                        if (reader[4].ToString() == "TRUE") rating.recommend = true;
                        else rating.recommend = false;


                        ratings.Add(rating);
                    }
                }
            }

            return ratings;
        }
        
        #endregion


        #region UPDATE COMMANDS

        public int updateRetroType(RetroType retroType)
        {
            int ret = -1;
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "UPDATE Retrospective_Type " +
                                      "SET Title = @title, Code = @code " +
                                      "WHERE ID=@id;";
                conn.Open();
                command.Parameters.AddWithValue("@title", retroType.title);
                command.Parameters.AddWithValue("@code", retroType.code);
                command.Parameters.AddWithValue("@id", retroType.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }
                conn.Close();
            }

            return ret;
        }

        //TODO - convert to Using commands
        public int updatePod(Podcast pod)
        {
            DateTime nullDate = new DateTime(2001, 1, 1);
            int ret = 0;
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            
            command.CommandText = "UPDATE Podcast " +
                                  "SET ShortName = @shortName,TypeId= @typeId,RetrospectiveId= @retroId,Runtime=@runtime," +
                                      "DateRecorded=@dateRec,DateReleased=@dateRel,Editor=@editor,Hosts=@hosts,URL=@url," +
                                      "CorbinRating=@corbinRate,CorbinRecommend=@corbinReco,AllenRating=@allenRate," +
                                      "AllenRecommend=@allenReco " +
                                  "WHERE ID = @podId";

            command.Parameters.AddWithValue("@shortName", pod.shortName);
            command.Parameters.AddWithValue("@typeId", pod.typeId);
            command.Parameters.AddWithValue("@retroId", pod.retroId);
            command.Parameters.AddWithValue("@runtime", pod.runtime);
            command.Parameters.AddWithValue("@dateRec", pod.dateRecDate);
            command.Parameters.AddWithValue("@dateRel", pod.dateRelDate);
            command.Parameters.AddWithValue("@editor", pod.editor);
            command.Parameters.AddWithValue("@hosts", pod.hosts);
            command.Parameters.AddWithValue("@url", pod.url);
            command.Parameters.AddWithValue("@corbinRate", pod.corbinRating);
            command.Parameters.AddWithValue("@corbinReco", pod.corbinRecommend);
            command.Parameters.AddWithValue("@allenRate", pod.allenRating);
            command.Parameters.AddWithValue("@allenReco", pod.allenRecommend);
            command.Parameters.AddWithValue("@podId", pod.id);


            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (InvalidOperationException)
            {
                ret = -1 ;
            }

            conn2.Close();
            return ret;
        }

        public int updatePodProdCode(Podcast pod)
        {
            int ret = -1;
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "UPDATE Podcast " +
                                      "SET ProductionCode = @prodCode " +
                                      "WHERE ID=@id;";
                conn.Open();
                command.Parameters.AddWithValue("@prodCode", pod.prodCode);
                command.Parameters.AddWithValue("@id", pod.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                } 
                catch (InvalidOperationException)
                {
                    ret = -1;
                }
                conn.Close();
            }

            return ret;
        }


        public int updatePodType(Podcast pod)
        {
            int ret = -1;
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "UPDATE Podcast " +
                                      "SET TypeId = @typeId" +
                                      "WHERE ID=@id;";
                conn.Open();
                command.Parameters.AddWithValue("@typeId", pod.typeId);
                command.Parameters.AddWithValue("@id", pod.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }
                conn.Close();
            }

            return ret;
        }
        
        public int updatePodProdCodeAndType(Podcast pod)
        {
            int ret = -1;
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "UPDATE Podcast " +
                                      "SET TypeId = @typeId, ProductionCode = @prodCode " +
                                      "WHERE ID=@id;";
                conn.Open();
                command.Parameters.AddWithValue("@typeId", pod.typeId);
                command.Parameters.AddWithValue("@prodCode", pod.prodCode);
                command.Parameters.AddWithValue("@id", pod.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }
                conn.Close();
            }

            return ret;
        }

        //TODO - convert to Using
        public int updateRetro(Retrospective retro)
        {
            MySqlCommand command = conn2.CreateCommand(); 
            conn2.Open();
            int ret = 0;

            command.CommandText = "UPDATE Retrospective " +
                                  "SET Title = @title,TypeId= @typeId,Code= @code " +
                                  "WHERE ID = @retroId";
            command.Parameters.AddWithValue("@title", retro.title);
            command.Parameters.AddWithValue("@typeId", retro.typeId);
            command.Parameters.AddWithValue("@code", retro.code);
            command.Parameters.AddWithValue("@retroId", retro.id);

            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public int updateRating(Rating rating)
        {
            MySqlCommand command = conn2.CreateCommand(); 
            conn2.Open();
            int ret = 0;
                
            command.CommandText = "UPDATE Rating" +
                                    "SET PodcastId = @podId,HostId= @hostId,Rating= @rating, Recommend=@reco " +
                                    "WHERE ID = @id";

            command.Parameters.AddWithValue("@podId", rating.podcastId);
            command.Parameters.AddWithValue("@hostId", rating.host.id);
            command.Parameters.AddWithValue("@rating", rating.rating);
            command.Parameters.AddWithValue("@reco", rating.recommend.ToString().ToUpper());
            command.Parameters.AddWithValue("@id", rating.id);

            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public int updateOrAddRating(Rating rating)
        {
            MySqlCommand command = conn2.CreateCommand(); 
            conn2.Open();
            int ret = 0;
                
            command.CommandText = "INSERT INTO Rating (ID, PodcastId, HostId, Rating, Recommend) " +
                                    "VALUES (@id, @podId, @hostId, @rating, @reco) " +
                                    "ON DUPLICATE KEY UPDATE PodcastId=Values(PodcastId), " +
                                                            "HostId=VALUES(HostId), " +
                                                            "Rating=VALUES(Rating), " +
                                                            "Recommend=VALUES(Recommend);";

            command.Parameters.AddWithValue("@podId", rating.podcastId);
            command.Parameters.AddWithValue("@hostId", rating.host.id);
            command.Parameters.AddWithValue("@rating", rating.rating);
            command.Parameters.AddWithValue("@reco", rating.recommend.ToString().ToUpper());
            command.Parameters.AddWithValue("@id", rating.id);

            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public List<int> updateMultiRatings(List<Rating> ratings)
        {
            List<int> rets = new List<int>();
            MySqlCommand command = conn2.CreateCommand(); 
            conn2.Open();
            int ret = 0;

            foreach(Rating rating in ratings)
            {
                command.CommandText = "UPDATE Rating" +
                                      "SET PodcastId = @podId,HostId= @hostId,Rating= @rating, Recommend=@reco " +
                                      "WHERE ID = @id";

                command.Parameters.AddWithValue("@podId", rating.podcastId);
                command.Parameters.AddWithValue("@hostId", rating.host.id);
                command.Parameters.AddWithValue("@rating", rating.rating);
                command.Parameters.AddWithValue("@reco", rating.recommend.ToString().ToUpper());
                command.Parameters.AddWithValue("@id", rating.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }


            }

            conn2.Close();

            return rets;
        }

        //TODO - convert to Using
        public int updateHost(Host host)
        {
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            int ret = 0;

            command.CommandText = "UPDATE Host" +
                                  "SET ID = @id ,FirstName= @firstName, LastName=@lastNae " +
                                  "WHERE ID = @id";

            command.Parameters.AddWithValue("@id", host.id);
            command.Parameters.AddWithValue("@firstName", host.firstName);
            command.Parameters.AddWithValue("@lastName", host.lastName);

            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        #endregion


        #region INSERT COMMANDS
        //TODO - convert to Using
        public int insertPodcast(Podcast pod)
        {
            int ret = -1;
            MySqlCommand command = conn2.CreateCommand();
            
            conn2.Open();
            command.CommandText = "INSERT INTO Podcast (ID, ShortName, ProductionCode, Title, DateRecorded, TypeId, Runtime, " +
                                                "DateReleased, RetrospectiveId, Editor, URL) " +
                                  "VALUES (@id,@shortName, @prodCode, @title, @dateRec, @typeId, @runtime," +
                                          " @dateRel, @retroId, @editor, @url);";
            
            command.Parameters.AddWithValue("@id", pod.id);
            command.Parameters.AddWithValue("@shortName", pod.shortName);
            command.Parameters.AddWithValue("@prodCode", pod.prodCode);
            command.Parameters.AddWithValue("@title", pod.title);
            command.Parameters.AddWithValue("@dateRec", pod.dateRecDate);
            command.Parameters.AddWithValue("@typeId", pod.typeId);
            command.Parameters.AddWithValue("@runtime", pod.runtime);
            command.Parameters.AddWithValue("@dateRel", pod.dateRelDate);
            command.Parameters.AddWithValue("@retroId", pod.retroId);
            command.Parameters.AddWithValue("@editor", pod.editor);
            command.Parameters.AddWithValue("@url", pod.url);


            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public int insertHost(Host host)
        {
            int ret = 0;
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            command.CommandText = "INSERT INTO Host " +
                            "VALUES (@id, @firstName, @lastName);";

            command.Parameters.AddWithValue("@id", host.id);
            command.Parameters.AddWithValue("@firstName", host.firstName);
            command.Parameters.AddWithValue("@lastName", host.lastName);
            
            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public int insertRetro(Retrospective retro)
        {
            int ret = 0;
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            command.CommandText = "INSERT INTO Retrospective " +
                                  "VALUES (@id, @title, @typeId, @code);";

            command.Parameters.AddWithValue("@id", retro.id);
            command.Parameters.AddWithValue("@title", retro.title);
            command.Parameters.AddWithValue("@typeId", retro.typeId);
            command.Parameters.AddWithValue("@code", retro.code);

            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public int insertPodType(PodType podType)
        {
            int ret = 0;
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            command.CommandText = "INSERT INTO Podcast_Type " +
                                  "VALUES (@id, @type, @code);";
            
            command.Parameters.AddWithValue("@id", podType.id);
            command.Parameters.AddWithValue("@title", podType.type);
            command.Parameters.AddWithValue("@typeId", podType.code);

            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public int insertRetroType(RetroType retroType)
        {
            int ret = 0;
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            command.CommandText = "INSERT INTO Retrospective_Type " +
                                  "VALUES (@id, @title, @code);";

            command.Parameters.AddWithValue("@id", retroType.id);
            command.Parameters.AddWithValue("@title", retroType.title);
            command.Parameters.AddWithValue("@code", retroType.code);

            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public int insertRating(Rating rating)
        {
            int ret = 0;
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            command.CommandText = "INSERT INTO Rating " +
                                  "VALUES (@id, @podId, @hostId, @rating, @reco);";
            
            command.Parameters.AddWithValue("@id", rating.id);
            command.Parameters.AddWithValue("@podId", rating.podcastId);
            command.Parameters.AddWithValue("@hostId", rating.host.id);
            command.Parameters.AddWithValue("@rating", rating.rating);
            command.Parameters.AddWithValue("@reco", rating.recommend.ToString().ToUpper());

            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn2.Close();

            return ret;
        }

        //TODO - convert to Using
        public List<int> insertMultiRatings(List<Rating> ratings)
        {
            int ret = 0;
            List<int> rets = new List<int>();
            MySqlCommand command = conn2.CreateCommand();
            conn2.Open();
            
            foreach(Rating rating in ratings)
            {
                command.CommandText = "INSERT INTO Rating " +
                                      "VALUES (@id, @podId, @hostId, @rating, @reco);";
            
                command.Parameters.AddWithValue("@id", rating.id);
                command.Parameters.AddWithValue("@podId", rating.podcastId);
                command.Parameters.AddWithValue("@hostId", rating.host.id);
                command.Parameters.AddWithValue("@rating", rating.rating);
                command.Parameters.AddWithValue("@reco", rating.recommend.ToString().ToUpper());

                try
                {
                    ret = command.ExecuteNonQuery();

                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }

                conn2.Close();

            }
            

            return rets;
        }

        #endregion


        #region DELETE COMMANDS
        public int deletePod(Podcast pod)
        {
            return -1;
        }


        public int deleteRetroType(RetroType retroType)
        {
            int ret = -1;
            
            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {
                
                command.CommandText = "DELETE FROM Retrospective_Type " +
                                      "WHERE ID = @id;";
                conn.Open();
                command.Parameters.AddWithValue("@id", retroType.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }
                conn.Close();
            }

            return ret;
        }

        public int deletePodType(PodType podType)
        {
            int ret = -1;

            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {

                command.CommandText = "DELETE FROM Podcast_Type " +
                                      "WHERE ID = @id;";
                conn.Open();
                command.Parameters.AddWithValue("@id", podType.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }
                conn.Close();
            }

            return ret;
        }


        public int deleteHost(Host host)
        {
            int ret = -1;

            using (var conn = new MySqlConnection("server=" + ip + ";database=SSG_POD;userid=" + username + ";password=" + password + ";"))
            using (var command = conn.CreateCommand())
            {

                command.CommandText = "DELETE FROM Host " +
                                      "WHERE ID = @id;";
                conn.Open();
                command.Parameters.AddWithValue("@id", host.id);

                try
                {
                    ret = command.ExecuteNonQuery();
                }
                catch (InvalidOperationException)
                {
                    ret = -1;
                }
                conn.Close();
            }

            return ret;
        }

        #endregion

    }
}
