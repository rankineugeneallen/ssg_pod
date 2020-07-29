using SSGPodRetrieval.model;
using SSGPodRetrieval.constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSGPodRetrieval
{
    public partial class RetroQuery : Form
    {
        TableData tableData = TableData.Instance;

        public RetroQuery()
        {
            InitializeComponent();
        }

        private void RetroQuery_Load(object sender, EventArgs e)
        {
            loadRetrospectives();
        }


        private void loadRetrospectives()
        {
            Retrospective[] retroArr;

            retroCLB.Items.Clear();

            retroArr = (Retrospective[])tableData.getRetrospectives().ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
                retroCLB.Items.Add(retroArr[i]);
        }

        private void writeAverages(Average average)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat; //used for converting double to %

            if(average != null)
            {
                retroQuOverallAvgRateTB.Text = average.overallAvgRate.ToString("0.##");
                retroQuCorbinAvglRateTB.Text = average.corbinAvgRate.ToString("0.##");
                retroQuAllenAvgRateTB.Text = average.allenAvgRate.ToString("0.##");
                retroQuOverallRecoTB.Text = average.overallRecommendPerc.ToString("P", nfi);
                retroQuCorbinAvgRecoTB.Text = average.corbinRecommendPerc.ToString("P", nfi);
                retroQuAllenAvgRecoTB.Text = average.allenRecommendPerc.ToString("P", nfi);
            }
        }

        private Average calcAverages()
        {
            
            List<Retrospective> selItems = retroCLB.CheckedItems.Cast<Retrospective>().ToList();
            
            if(selItems.Count > 0)
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

                //TODO - finish making averages between selected retros
                foreach (Retrospective retro in selItems)
                {
                    average = retro.average;
                    if (retro.average != null)
                    {
                        overallRatings.AddRange(average.overallRatings);
                        corbinsRatings.AddRange(average.corbinsRatings);
                        allensRatings.AddRange(average.allensRatings);

                        overallRecommends.AddRange(average.overallRecommends);
                        corbinsRecommends.AddRange(average.corbinsRecommends);
                        allensRecommends.AddRange(average.allensRecommends);
                    }
                }

                if (overallRatings.Count > 0)
                {
                    average = new Average(); //start fresh 
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

        private void runQuBtn_Click(object sender, EventArgs e)
        {
            writeAverages(calcAverages());
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            retroQuOverallAvgRateTB.Clear();
            retroQuCorbinAvglRateTB.Clear();
            retroQuAllenAvgRateTB.Clear();
            retroQuOverallRecoTB.Clear();
            retroQuCorbinAvgRecoTB.Clear();
            retroQuAllenAvgRecoTB.Clear();

            for(int i = 0; i < retroCLB.Items.Count; i++)
            {
                retroCLB.SetItemChecked(i, false);
            }
        }
    }
}
