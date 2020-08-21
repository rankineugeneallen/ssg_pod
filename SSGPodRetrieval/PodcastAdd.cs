using SSGPodRetrieval.constant;
using SSGPodRetrieval.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSGPodRetrieval
{
    public partial class PodcastAdd : Form
    {
        TableData tableData = TableData.Instance;
        List<Rating> newRatings = new List<Rating>();
        ProdCodeManager PCM;
        Podcast retPod;
        Podcast podEdit;
        private int tempId = 0;
        private bool retroPodAddEdit = false;

        public PodcastAdd()
        {
            InitializeComponent();
            
            loadPodTypes();
            loadRetrospectives();
        }

        public PodcastAdd(bool retroPodAddEdit)
        {
            InitializeComponent();

            this.retroPodAddEdit = retroPodAddEdit;

            loadPodTypes();
            retroComboBox.Enabled = false;
        }
        
        public PodcastAdd(Podcast podEdit)
        {
            InitializeComponent();

            this.podEdit = podEdit;

            loadPodTypes();
            retroComboBox.Enabled = false;
            retroPodAddEdit = true;


            setPodInfo(podEdit);
        }

        private void setPodInfo(Podcast pod)
        {
            DateTime badDate = new DateTime(2001, 1, 1);
            longTitleTB.Text = pod.title;
            shortNameTB.Text = pod.shortName;
            podProdCodeTB.Text = pod.track;
            editorTB.Text = pod.editor;
            runtimeTB.Text = pod.runtime;
            podUrlTB.Text = pod.url;

            //set type
            for (int i = 0; i < podTypeCB.Items.Count; i++)
            {
                if(((PodType)podTypeCB.Items[i]).id == pod.typeId)
                {
                    podTypeCB.SelectedIndex = i;
                    break;
                }
            }

            //set retro
            if (!retroPodAddEdit)
            {
                for(int i = 0; i < retroComboBox.Items.Count; i++)
                {
                    if (((Retrospective)retroComboBox.Items[i]).id == pod.retroId)
                    {
                        retroComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            //set dates
            if(!(pod.dateRecDate == badDate))
            {
                dateRecDP.Value = pod.dateRecDate;
                dateRecCKBX.Checked = true;
            }
            
            if(!(pod.dateRelDate == badDate))
            {
                dateRelDP.Value = pod.dateRelDate;
                dateRelCKBX.Checked = true;
            }

            //set ratings
            for(int i = 0; i < pod.ratings.Count; i++)
            {
                ((Rating)pod.ratings[i]).tempId = i;
            }
            
            newRatings = pod.ratings.Cast<Rating>().ToList();
            writeRatings();
        }

        public Podcast GetPodcast()
        {
            return retPod;
        }

        private void loadRetrospectives()
        {
            Retrospective[] retroArr;
            
            retroComboBox.Items.Clear();

            retroArr = (Retrospective[])tableData.getRetrospectives().ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
                retroComboBox.Items.Add(retroArr[i]);
        }

        //private void loadHosts()
        //{
        //    hostCLB.Items.Clear();

        //    Host[] hostArr = (Host[])tableData.getHosts().ToArray(typeof(Host));

        //    for (int i = 0; i < hostArr.Length; i++)
        //        hostCLB.Items.Add(hostArr[i]);
        //}

        private void loadPodTypes()
        {
            podTypeCB.Items.Clear();

            PodType[] podTypeArr = (PodType[])tableData.getPodTypes().ToArray(typeof(PodType));

            for (int i = 0; i < podTypeArr.Length; i++)
                podTypeCB.Items.Add(podTypeArr[i]);
        }

        private void writeRatings()
        {
            ratingsLB.Items.Clear();

            Rating[] newRatingsArr = (Rating[])newRatings.ToArray();

            for (int i = 0; i < newRatingsArr.Length; i++)
                ratingsLB.Items.Add(newRatingsArr[i]);
        }


        private string getHostsFirstNamesFromCLB()
        {

            string hostStr = "";

            for(int i = 0; i < newRatings.Count; i++)
            {
                hostStr += newRatings[i].host.id;
                
                if (!(i + 1 >= newRatings.Count))
                    hostStr += ",";
            }

            return hostStr;
            //string hostStr = "";
            //ArrayList checkedHosts = new ArrayList();

            //for(int i = 0; i < hostCLB.CheckedItems.Count; i++)
            //{
            //    checkedHosts.Add((Host)hostCLB.CheckedItems[i]);
            //}
            
            
            //for(int i = 0; i < checkedHosts.Count; i++)
            //{
            //    hostStr += ((Host)checkedHosts[i]).firstName + " ";
            //    if (!(i + 1 >= checkedHosts.Count)) hostStr += ", ";
            //}

            //return hostStr;
        }

        private int getAndIncTempId()
        {
            return tempId++;
        }

        private void dateRecCKBX_CheckedChanged(object sender, EventArgs e)
        {
            if (dateRecCKBX.Checked)
                dateRecDP.Enabled = true;
            else
                dateRecDP.Enabled = false;
        }

        private void dateRelCKBX_CheckedChanged(object sender, EventArgs e)
        {
            if (dateRelCKBX.Enabled)
                dateRelDP.Enabled = true;
            else
                dateRelDP.Enabled = false;

        }

        private void podAddBtn_Click(object sender, EventArgs e)
        {
            List<Rating> errorRatings = new List<Rating>();
            Podcast returnPod = new Podcast();

            if (!string.IsNullOrEmpty(shortNameTB.Text) &&
            podTypeCB.SelectedItem != null &&
            (retroComboBox.SelectedItem != null || retroPodAddEdit) &&
            ratingsLB.Items.Count > 0)
            {
                Podcast pod = new Podcast();
                List<Rating> ratings = new List<Rating>();
                DateTime badDate = new DateTime(0001, 1, 1);

                pod.shortName = shortNameTB.Text;
                pod.title = longTitleTB.Text;
                pod.runtime = runtimeTB.Text;
                pod.typeId = ((PodType)podTypeCB.SelectedItem).id;
                pod.editor = editorTB.Text;
                pod.url = podUrlTB.Text;
                pod.track = podProdCodeTB.Text;

                if(!retroPodAddEdit)
                    pod.retroId = ((Retrospective)retroComboBox.SelectedItem).id;
                
                
                if (!dateRecCKBX.Checked || dateRecDP.Value == badDate)
                {
                    pod.dateRecDate = new DateTime(2001, 1, 1);
                }
                else
                {
                    pod.dateRecDate = dateRecDP.Value;
                }


                if (!dateRelCKBX.Checked || dateRelDP.Value == badDate)
                {
                    pod.dateRelDate = new DateTime(2001, 1, 1);
                }
                else
                {
                    pod.dateRelDate = dateRelDP.Value;
                }

                
                //setup assigned ratings
                int rateId = tableData.getNextRatingId();
                Rating tempRating;
                for(int i = 0; i < ratingsLB.Items.Count; i++)
                {
                    tempRating = (Rating)ratingsLB.Items[i];
                    tempRating.id = rateId++; //assign ID
                    ratings.Add(tempRating);
                }

                if (retroPodAddEdit)
                {
                    pod.ratings = new ArrayList(ratings);
                    retPod = pod;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                } 
                else
                {
                    //insert pod first, then ratings. Error if all is not good. 
                    returnPod = tableData.addPod(pod);
                
                    if (returnPod != null)
                    {
                        foreach(Rating newRating in newRatings)
                        {
                            newRating.podcastId = returnPod.id;
                            if(tableData.addRating(newRating) == null)
                            {
                                errorRatings.Add(newRating);
                            }
                        }
                    }

                    //handle errors
                    if(errorRatings.Count > 0)
                    {
                        MessageBox.Show(getRatingErrorMessage(errorRatings), "Error adding Rating(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if(returnPod == null)
                    {
                        MessageBox.Show("Could not add podcast", "Error adding podcast", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //all is good, now add the ratings.
                    if(errorRatings.Count == 0 && returnPod != null)
                    {
                        if (MessageBox.Show("Podcast Added Successfully", "Sucess!",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            this.Close();
                        }
                        this.Close();
                    }
                    else
                    {
                        reqFieldsLabel.Visible = true;
                    }
                }
            }
        }

        private string configureProdCode(Podcast pod)
        {
            PCM = new ProdCodeManager(pod, (Retrospective)retroComboBox.SelectedItem);
            return PCM.contructProdCode();
        }

        private string getRatingErrorMessage(List<Rating> errorRatings)
        {
            string retStr = "Error adding the following ratings: \n\n";

            foreach(Rating rating in errorRatings)
            {
                retStr += "Host: " + rating.host.id + " - " + rating.host.firstName + "\nRating:\n\tID:" + rating.id +
                    "\n\tScore: " + rating.rating + "\n\tRecommend: " + rating.recommend + "\n\n\n";
            }

            return retStr;
        }

        private void podCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hostAddBtn_Click(object sender, EventArgs e)
        {
            Rating rating = null;

            using(HostAndScoreAdd hostAndScoreAdd = new HostAndScoreAdd(newRatings))
            {
                if(hostAndScoreAdd.ShowDialog() == DialogResult.OK)
                {
                    rating = hostAndScoreAdd.GetRating();
                    rating.tempId = getAndIncTempId();
                    newRatings.Add(rating);
                    writeRatings();
                }
            }
        }

        private void PodcastAdd_Load(object sender, EventArgs e)
        {

        }


        private void hostRemBtn_Click(object sender, EventArgs e)
        {
            newRatings.Remove((Rating)ratingsLB.SelectedItem);
            ratingsLB.Items.RemoveAt(ratingsLB.SelectedIndex);
            writeRatings();
        }

        private void ratingsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ratingsLB.SelectedItem != null)
            {
                hostRemBtn.Enabled = true;
                hostEditBtn.Enabled = true;
            }
            else
            {
                hostRemBtn.Enabled = false;
                hostEditBtn.Enabled = true;
            }
        }

        private void hostEditBtn_Click(object sender, EventArgs e)
        {
            if(ratingsLB.SelectedItem != null)
            {
                Rating updRate = (Rating)ratingsLB.SelectedItem;

                using (HostAndScoreAdd hostAndScoreAdd = new HostAndScoreAdd(updRate))
                {
                    if (hostAndScoreAdd.ShowDialog() == DialogResult.OK)
                    {
                        updRate = hostAndScoreAdd.GetRating();

                        //once it comes back, update it
                        for (int i = 0; i < newRatings.Count; i++)
                        {
                            if(newRatings[i].tempId == updRate.tempId)
                            {
                                newRatings[i] = updRate;
                            }
                        }
                        writeRatings();
                    }
                }
            }
        }

        private void dateRecDP_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
