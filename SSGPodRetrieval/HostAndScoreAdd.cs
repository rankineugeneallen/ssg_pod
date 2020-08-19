using SSGPodRetrieval.constant;
using SSGPodRetrieval.model;
using System;
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
    public partial class HostAndScoreAdd : Form
    {
        public Rating rating { get; private set; }
        private List<Rating> hostsInList;
        private Rating editRating;

        public Rating GetRating()
        {
            return rating;
        }

        public HostAndScoreAdd(List<Rating> hostsInList)
        {
            InitializeComponent();

            this.hostsInList = hostsInList;
            
            loadHosts();
            removeAlreadySelectedHosts();
        }
        
        public HostAndScoreAdd(Rating editRating)
        {
            InitializeComponent();

            this.editRating = editRating;
            
            loadHosts();
            loadRating();
        }

        private void loadHosts()
        {
            hostLB.Items.Clear();

            Host[] hostArr = (Host[])TableData.Instance.getHosts().ToArray(typeof(Host));

            for (int i = 0; i < hostArr.Length; i++)
                hostLB.Items.Add(hostArr[i]);
        }

        private void removeAlreadySelectedHosts()
        {
            for (int i = 0; i < hostLB.Items.Count; i++)
            {
                foreach(Rating rating in hostsInList)
                {
                    if(rating.host.id == ((Host)hostLB.Items[i]).id){
                        hostLB.Items.RemoveAt(i);
                    }
                }
            }
        }

        private bool hostIsAdded(int hostId)
        {
            foreach(Rating rating in hostsInList)
            {
                if (rating.host.id == hostId) 
                    return true;
            }

            return false;
        }


        private void loadRating()
        {
            //select host
            for(int i = 0; i < hostLB.Items.Count; i++)
            {
                if(editRating.host.id == ((Host)hostLB.Items[i]).id)
                {
                    hostLB.SelectedIndex = i;
                    break;
                }
            }

            //select rating
            if(string.IsNullOrEmpty(editRating.rating))
                hostRateCB.SelectedIndex = 0;
            else
            {
                int index = -1;
                switch (editRating.rating)
                {
                    case "-":
                        index = 2;
                        break;
                    case "1":
                        index = 3;
                        break;
                    case "2":
                        index = 4;
                        break;
                    case "3":
                        index = 5;
                        break;
                    case "4":
                        index = 6;
                        break;
                    case "5":
                        index = 7;
                        break;
                    case "6":
                        index = 8;
                        break;
                    case "7":
                        index = 9;
                        break;
                    case "8":
                        index = 10;
                        break;
                    case "9":
                        index = 11;
                        break;
                    case "10":
                        index = 12;
                        break;
                    case "11":
                        index = 13;
                        break;
                    default:
                        index = 0;
                        break;
                }
                hostRateCB.SelectedIndex = index;

                if(hostRateCB.SelectedIndex == 0)
                {
                    hostRecoCB.SelectedIndex = 0;
                } 
                else
                {
                    if (editRating.recommend)
                    {
                        hostRecoCB.SelectedIndex = 1;
                    }
                    else
                    {
                        hostRecoCB.SelectedIndex = 2;
                    }
                }
            }
                
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            
            if(hostRateCB.SelectedIndex > 0 && !(hostRecoCB.SelectedIndex > 0))
            {
                dynLabel.Text = "A recommendation must be set.";
            }
            else if (!(hostRateCB.SelectedIndex > 0) && hostRecoCB.SelectedIndex > 0)
            {
                dynLabel.Text = "A rating must be set.";
            }
            else if (hostLB.SelectedItem != null)
            {
                dynLabel.Text = "";
                rating = new Rating();
                rating.host = (Host)hostLB.SelectedItem;

                if (hostRateCB.SelectedIndex == -1 || hostRateCB.SelectedIndex == 0)
                    rating.rating = "";
                else
                    rating.rating = (string)hostRateCB.Items[hostRateCB.SelectedIndex];

                if (hostRecoCB.SelectedIndex == 1) rating.recommend = true;
                else rating.recommend = false;

                if(editRating != null)
                {
                    rating.tempId = editRating.tempId;
                }

                if(editRating != null)
                {
                    if (editRating.id != 0)
                        rating.id = editRating.id;
                    if(editRating.podcastId == null)
                        rating.podcastId = editRating.podcastId;

                }


                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                dynSSLabel.Visible = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void HostAndScoreAdd_Load(object sender, EventArgs e)
        {

        }

        private void hostRateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (hostRateCB.SelectedIndex)
            {
                case 0: //blank
                    hostRecoCB.SelectedIndex = 0; //false
                    break;
                case 1: //-
                case 2: //0
                case 3: //1
                case 4: //2
                case 5: //3
                case 6: //4
                case 7: //5
                    hostRecoCB.SelectedIndex = 2; //false
                    break;
                case 8: //6
                case 9: //7
                case 10: //8
                case 11: //9
                case 12: //10
                case 13: //11
                    hostRecoCB.SelectedIndex = 1; //true
                    break;
                default:
                    break;
                    
            }
        }

        private void hostRecoCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(hostRecoCB.SelectedIndex == 0 ||
                hostRecoCB.SelectedIndex == -1)
                hostRateCB.SelectedIndex = 0;
        }
    }
}
