using SSGPodRetrieval.model;
using SSGPodRetrieval.constant;
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
    public partial class RetroCreator : Form
    {
        //ArrayList retrospectives = new ArrayList();
        TableData tableData = TableData.Instance;
        List<Podcast> newPods = new List<Podcast>();

        public RetroCreator()
        {
            InitializeComponent();

            loadRetroTypes();
        }

        private void loadRetroTypes()
        {
            retroTypeCB.Items.Clear();

            RetroType[] retroTypeArr = (RetroType[])tableData.getRetroTypes().ToArray(typeof(RetroType));

            for (int i = 0; i < retroTypeArr.Length; i++)
                retroTypeCB.Items.Add(retroTypeArr[i]);
        }

        private void addRetroBtn_Click(object sender, EventArgs e)
        {
            Podcast pod = null;

            using (PodcastAdd podAdd = new PodcastAdd(true))
            {
                if (podAdd.ShowDialog() == DialogResult.OK)
                {
                    newPods.Add(podAdd.GetPodcast());
                }
                loadPods();
            }


        }

        private void removeRetroBtn_Click(object sender, EventArgs e)
        {
            Podcast remPod = (Podcast)retroListBox.SelectedItem;

            newPods.Remove(remPod);

            loadPods();
            toggleEditRemBtns();
        }

        private void loadPods()
        {
            retroListBox.Items.Clear();

            Podcast[] podArr = (Podcast[])newPods.ToArray();

            for (int i = 0; i < podArr.Length; i++)
            {
                retroListBox.Items.Add(podArr[i]);
            }
        }


        private void RetroCreator_Load(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Podcast podEdit = (Podcast)retroListBox.SelectedItem;
            Podcast podRet;

            using (PodcastAdd podAdd = new PodcastAdd(podEdit))
            {
                if (podAdd.ShowDialog() == DialogResult.OK)
                {
                    podRet = podAdd.GetPodcast();


                    for(int i = 0; i < newPods.Count; i++)
                    {
                        if ((Podcast)newPods[i] == podEdit)
                            newPods[i] = podRet;
                    }
                    
                    //newPods.Add(podAdd.GetPodcast());
                }
                loadPods();
            }


        }

        //TODO - click and drag reorder
        //TODO - always organize by track #
        //TODO - reodering checks release dates so the tracks are layed out in right order. 
        private void retroListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleEditRemBtns();

            if(retroListBox.SelectedIndex != -1)
            {
                dateRecLabel.Text = ((Podcast)retroListBox.SelectedItem).dateRecDate.ToString("MM/dd/yyyy");
                dateRelLabel.Text = ((Podcast)retroListBox.SelectedItem).dateRelDate.ToString("MM/dd/yyyy");
            }
        }


        private void toggleEditRemBtns()
        {
            if(retroListBox.SelectedItem != null)
            {
                editPodBtn.Enabled = true;
                remPodBtn.Enabled = true;
            }
            else
            {
                editPodBtn.Enabled = false;
                remPodBtn.Enabled = false;
            }
        }

        private void cancelRetroBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void retroAddBtn_Click(object sender, EventArgs e)
        {
            bool codeExists = true;

            if (!string.IsNullOrEmpty(retroTitleTB.Text) &&
               !string.IsNullOrEmpty(retroCodeTB.Text) &&
               retroTypeCB.SelectedIndex != -1)
            {
                //make sure code is not a duplicate
                codeExists = tableData.checkCodeExists(retroCodeTB.Text);
                if (codeExists)
                {
                    error("Code already exists", "Code Error");
                }
               
                //if these are good, then add retro
                if (!codeExists)
                {

                    //if added alright, add pods and ratings
                }
            }
        }


        private void message(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void error(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void codeLabelUpd(string message, string color)
        {
            codeDynLabel.Text = message;

            switch (color.ToLower())
            {
                case "red":
                    codeDynLabel.ForeColor = System.Drawing.Color.Red;
                    break;
                case "green":
                    codeDynLabel.ForeColor = System.Drawing.Color.Green;
                    break;
                default:
                    codeDynLabel.ForeColor = System.Drawing.Color.Black;
                    break;
            }
        }

        private void retroCodeTB_TextChanged(object sender, EventArgs e)
        {
            if(retroCodeTB.Text.Length == 3)
            {
                if (tableData.checkCodeExists(retroCodeTB.Text))
                    codeLabelUpd("Code already exists", "red");
                else
                    codeLabelUpd("Code is good", "green");
            }
            else
            {
                codeLabelUpd("", "");
            }
        }
    }
}
