using SSG_Pod_Retrieval.model;
using SSGPodRetrieval.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval
{
    class QueryDaoImpl
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\SSG_POD\\SSG_POD.accdb;");

        public QueryDaoImpl()
        {
            //openConn();
        }

        public void openConn()
        {
            conn.Open();
        }

        public void closeConn()
        {
            conn.Close();
        }

        //public List<PodType> loadPodTypes()
        public ArrayList loadPodTypes()
        {
            string query = "SELECT * from Podcast_Type;";
            ArrayList podTypes = new ArrayList();
            //List<PodType> podTypes = new List<PodType>();
            PodType podType;

            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                podType = new PodType();

                podType.id = int.Parse(reader[0].ToString());
                podType.type = reader[1].ToString();
                podType.code = reader[2].ToString();

                podTypes.Add(podType);
            }

            conn.Close();
            return podTypes;
        }


        public ArrayList loadRetroTypes()
        {
            string query = "SELECT * from Retrospective_Type;";
            ArrayList retroTypes = new ArrayList();
            RetroType retroType;
            
            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                retroType = new RetroType();

                retroType.id = int.Parse(reader[0].ToString());
                retroType.title = reader[1].ToString();
                retroType.code = reader[2].ToString();

                retroTypes.Add(retroType);
            }

            conn.Close();
            return retroTypes;
        }

        public List<Podcast> getAllPodcasts()
        {
            string query = "SELECT * FROM Podcast;";
            List<Podcast> podcasts = new List<Podcast>();
            Podcast pod;
            string year;

            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                pod = new Podcast();

                pod.id = int.Parse(reader[0].ToString());
                pod.shortName = reader[1].ToString();
                pod.prodCode= reader[2].ToString();
                pod.title = reader[3].ToString();
                pod.typeId = int.Parse(reader[5].ToString());
                pod.retroId = int.Parse(reader[8].ToString());
                pod.runtime = reader[6].ToString();
                pod.editor= reader[9].ToString();
                pod.hosts= reader[10].ToString();
                pod.url = reader[11].ToString();
                pod.corbinRating = reader[11].ToString();
                pod.corbinRecommend= reader[12].ToString();
                pod.allenRating= reader[12].ToString();
                pod.allenRecommend= reader[13].ToString();


                //set date
                pod.dateRel = (reader[7].ToString());//DateTime.Parse(reader[7].ToString());
                pod.dateRec = (reader[4].ToString());//DateTime.Parse(reader[4].ToString()); 
                
                try
                {
                    pod.dateRecDate = DateTime.Parse(pod.dateRec);
                }
                catch (FormatException)
                { }

                try
                {
                    pod.dateRelDate = DateTime.Parse(pod.dateRel);
                }
                catch (FormatException)
                { }
                catch (ArgumentNullException)
                { }

                //set url (remove # at start and end)
                if(pod.url.Length > 1)
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
                catch (ArgumentOutOfRangeException)
                { }
                catch (FormatException) 
                { }


                podcasts.Add(pod);
            }

            conn.Close();
            return podcasts;

        }


        public void getTotalMLPods()
        {
            string query = "SELECT count(*) FROM Podcast WHERE TypeId = 1;";
            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);            
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
            }

            conn.Close();
            //reader.Close();
        }

        public ArrayList getAllRetros()
        {
            string query = "SELECT * FROM Retrospective;";
            ArrayList retrospectives = new ArrayList();
            Retrospective retro;
            
            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                retro = new Retrospective();

                retro.id = int.Parse(reader[0].ToString());
                retro.title = reader[1].ToString();
                retro.typeId = int.Parse(reader[2].ToString());
                retro.code = reader[3].ToString();

                retrospectives.Add(retro);
            }

            conn.Close();
            return retrospectives;
        }


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

            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();


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

            conn.Close();
            return retrospective;

        }

        public int updatePod(Podcast pod)
        {
            string query = "UPDATE Podcast "+
                            "SET ShortName = @shortName,TypeId= @typeId,RetrospectiveId= @retroId,Runtime=@runtime,"+
                                "DateRecorded=@dateRec,DateReleased=@dateRel,Editor=@editor,Hosts=@hosts,URL=@url "+
                            "WHERE ID = @podId";

            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            int ret = 0;
            
            command.Parameters.Add("@shortName", pod.shortName);
            command.Parameters.Add("@typeId", pod.typeId);
            command.Parameters.Add("@retroId", pod.retroId);
            command.Parameters.Add("@runtime", pod.runtime);
            command.Parameters.Add("@dateRec", pod.dateRecDate);
            command.Parameters.Add("@dateRel", pod.dateRelDate);
            command.Parameters.Add("@editor", pod.editor);
            command.Parameters.Add("@hosts", pod.hosts);
            command.Parameters.Add("@url", pod.url);
            command.Parameters.Add("@podId", pod.id);

            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1 ;
            }

            conn.Close();
            return ret;
        }

        public int updateRetro(Retrospective retro)
        {

            string query = "UPDATE Retrospective " +
                            "SET Title = @title,TypeId= @typeId,Code= @code " +
                            "WHERE ID = @retroId";

            conn.Open();
            OleDbCommand command = new OleDbCommand(query, conn);
            int ret = 0;

            command.Parameters.Add("@title", retro.title);
            command.Parameters.Add("@typeId", retro.typeId);
            command.Parameters.Add("@code", retro.code);
            command.Parameters.Add("@retroId", retro.id);

            try
            {
                ret = command.ExecuteNonQuery();

            }
            catch (InvalidOperationException)
            {
                ret = -1;
            }

            conn.Close();

            return ret;
        }

    }
}
