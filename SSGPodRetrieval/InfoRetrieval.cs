using SSGPodRetrieval.constant;
using SSGPodRetrieval.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SSGPodRetrieval
{
    public partial class InfoRetrieval : Form
    {
        TableData tableData = null; //TableData.Instance;
        Podcast selPod;
        Podcast origPod;
        List<Rating> newRatings = new List<Rating>();
        List<Rating> updRatings = new List<Rating>();
        List<Rating> remRatings = new List<Rating>();
        int tempId = 0;

        public InfoRetrieval()
        {
            InitializeComponent();
            
            dynLabelSS.Text = "Loading...";

            //loadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           login();
        }

        private void login()
        {
            ConnectWin login = new ConnectWin();
            if(login.ShowDialog() == DialogResult.OK)
            {
                tableData = TableData.Instance;
                loadData();
            }
            else
            {
                this.Close();
            }
        }

        private void loadData()
        {
            loadPodTypes();
            loadRetroTypes();
            loadRetrospectives();

            dynLabelSS.Text = "Done!";
        }


        #region HELPER FUNCTIONS

        private void loadRetroItems(Retrospective retro)
        {
            Podcast[] podArr;
            
            retroItemListBox.Items.Clear();
            clearPodInfoTBs();
            clearAveragesTBs();
            
            writeRetroAverages(retro.average);
            
            podArr = (Podcast[])organizeRetroItems(retro.podcasts).ToArray(typeof(Podcast));

            for (int i = 0; i < podArr.Length; i++)
            {
                retroItemListBox.Items.Add(podArr[i]);
            }

        }

        private void loadPodTypes()
        {
            PodType[] podTypeArr = (PodType[])tableData.getPodTypes().ToArray(typeof(PodType));

            for (int i = 0; i < podTypeArr.Length; i++)
                podTypeCB.Items.Add(podTypeArr[i]);
        }

        private void loadRetroTypes()
        {   
            RetroType[] retroTypeArr = (RetroType[])tableData.getRetroTypes().ToArray(typeof(RetroType));

            for (int i = 0; i < retroTypeArr.Length; i++)
                retroTypeCB.Items.Add(retroTypeArr[i]);
        }

        private void loadRetrospectives()
          {
            Retrospective[] retroArr;
            
            retroItemListBox.Items.Clear();
            retroComboBox.Items.Clear();

            retroArr = (Retrospective[])tableData.getRetrospectives().ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
                retroComboBox.Items.Add(retroArr[i]);
        }

        private void writeRetroInfo(Retrospective retro)
        {
            retroTitleTB.Text = retro.title;
            retroIdTB.Text = retro.id.ToString();
            retroCodeTB.Text = retro.code;

            for(int i = 0; i < retroTypeCB.Items.Count; i++)
            {                
                if (((RetroType)retroTypeCB.Items[i]).id == retro.typeId)
                    retroTypeCB.SelectedIndex = i;
            }
        }


        private void writeRetroAverages(Average average)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat; //used for converting double to %

            if(average != null)
            {
                retroOverallAvgRateTB.Text = average.overallAvgRate.ToString("0.##");
                retroCorbinAvgRateTB.Text = average.corbinAvgRate.ToString("0.##");
                retroAllenAvgRateTB.Text = average.allenAvgRate.ToString("0.##");
                retroOverallRecoTB.Text = average.overallRecommendPerc.ToString("P", nfi);
                retroCorbinAvgRecoTB.Text = average.corbinRecommendPerc.ToString("P", nfi);
                retroAllenAvgRecoTB.Text = average.allenRecommendPerc.ToString("P", nfi);
            }
        }

        private void writePodInfo()
        {
            DateTime badDate = new DateTime(2001, 1, 1);
            podShortNameTB.Text = origPod.shortName;
            podProdCodeTB.Text = origPod.prodCode;
            podRuntimeTB.Text = origPod.runtime;
            podEditorTB.Text = origPod.editor;
            podURLLLabel.Text = origPod.url;
            podURLTB.Text = origPod.url;
            podTrackTB.Text = origPod.track;

            if (origPod.dateRecDate != badDate)
            {
                podDateRecDP.Value = origPod.dateRecDate;
                podDateRecDP.Format = DateTimePickerFormat.Short;
            }
            else
                podDateRecDP.Format = DateTimePickerFormat.Custom;

            if (origPod.dateRelDate != badDate)
            {
                podDateRelDP.Value = origPod.dateRelDate;
                podDateRelDP.Format = DateTimePickerFormat.Short;
            }
            else
                podDateRelDP.Format = DateTimePickerFormat.Custom;

            for (int i = 0; i < podTypeCB.Items.Count; i++)
            {
                if (((PodType)podTypeCB.Items[i]).id == origPod.typeId)
                    podTypeCB.SelectedIndex = i;
            }

            for(int i = 0; i < origPod.ratings.Count; i++)
            {
                ((Rating)origPod.ratings[i]).tempId = getAndIncTempId();
            }

            newRatings.Clear();
            updRatings.Clear();
            
            setHostRatings();
            
        }

        private void setHostRatings()
        {
            podHostRatingsLB.Items.Clear();

            foreach (Rating rating in selPod.ratings)
            {
                podHostRatingsLB.Items.Add(rating);
            }
        }

        private ArrayList organizeRetroItems(List<Podcast> retroItems)
        {
            ArrayList items = new ArrayList(retroItems);
            items = filterPodcasts(items);
            items = sortedPodcasts(items);
            
            return items;
        }
        private ArrayList filterPodcasts(ArrayList retroItems)
        {
            ArrayList filteredPods = new ArrayList();
            Podcast tempPod;

            
            if(filterSortChkBx.Checked && (filterMainLineTSMI.Checked || filterSuppTSMI.Checked))
            {
                for (int i = 0; i < retroItems.Count; i++)
                {
                    tempPod = (Podcast)retroItems[i];

                    if(tempPod.typeId == 1 && filterMainLineTSMI.Checked)
                        filteredPods.Add(tempPod);
                    if (tempPod.typeId == 6 && filterSuppTSMI.Checked)
                        filteredPods.Add(tempPod);
                }
            }
            else
            {
                filteredPods = retroItems;
            }


            return filteredPods;
        }

        private ArrayList sortedPodcasts(ArrayList retroItems)
        {
            List<Podcast> sortedPodcastList = new List<Podcast>();

            //do stuff to sort here
            //load stuff from Arraylist retroItems into List
            for(int i = 0; i < retroItems.Count; i++)
                sortedPodcastList.Add((Podcast)retroItems[i]);

            if (sortRelDateTSMI.Checked)
                sortedPodcastList.Sort((Podcast x, Podcast y) => DateTime.Compare(x.dateRelDate, y.dateRelDate));
            if (sortRecDateTSMI.Checked)
                sortedPodcastList.Sort((Podcast x, Podcast y) => DateTime.Compare(x.dateRecDate, y.dateRecDate));
            if (sortAlphaTSMI.Checked)
                 sortedPodcastList.Sort((Podcast x, Podcast y) => string.Compare(x.shortName, y.shortName));
            
            return new ArrayList(sortedPodcastList);
        }

        private void resetPodInfo()
        {
            selPod = origPod;
            writePodInfo();
        }


        private void toggleRetroInfoFields()
        {
            retroTitleTB.ReadOnly = !retroTitleTB.ReadOnly;
            //retroTypeCB.Enabled = !retroTypeCB.Enabled;
            retroTypeLockLabel.Enabled = !retroTypeLockLabel.Enabled;
            retroCodeTB.ReadOnly = !retroCodeTB.ReadOnly;

            retroEditDoneBtn.Enabled = !retroEditDoneBtn.Enabled;

            if (retroInfoEditBtn.Text == "Edit")
                retroInfoEditBtn.Text = "Cancel";
            else
            {
                retroInfoEditBtn.Text = "Edit";
                toggleRetroTypeToState(false);
            }
        }

        private void togglePodInfoFields()
        {
            podShortNameTB.ReadOnly = !podShortNameTB.ReadOnly;
            //podTypeCB.Enabled = !podTypeCB.Enabled;
            podTypeLockLabel.Enabled = !podTypeLockLabel.Enabled;
            podRuntimeTB.ReadOnly = !podRuntimeTB.ReadOnly;
            podEditorTB.ReadOnly = !podEditorTB.ReadOnly;
            podDateRecDP.Enabled = !podDateRecDP.Enabled;
            podDateRelDP.Enabled = !podDateRelDP.Enabled;
            podDateRecClearLabel.Enabled = !podDateRecClearLabel.Enabled;
            podDateRelClearLabel.Enabled = !podDateRelClearLabel.Enabled;
            podHostRatingsLB.Enabled = !podHostRatingsLB.Enabled;
            podHostRateAddBtn.Enabled = !podHostRateAddBtn.Enabled;
            podURLTB.Visible = !podURLTB.Visible;
            //podTrackTB.ReadOnly = !podTrackTB.ReadOnly;
            podURLLLabel.Text = podURLTB.Text;

            if (!podEditDoneBtn.Enabled)
            {
                podHostRateEditBtn.Enabled = false;
                podHostRateRemBtn.Enabled = false;
                podHostRatingsLB.SelectedIndex = -1;
            }

            podEditDoneBtn.Enabled = !podEditDoneBtn.Enabled;
            //podEditDoneBtn.Enabled = !podEditDoneBtn.Enabled;

            podResetLL.Enabled = !podResetLL.Enabled;

            if (podInfoEditBtn.Text == "Edit")
                podInfoEditBtn.Text = "Cancel";
            else
            {
                podInfoEditBtn.Text = "Edit";
                togglePodTypeToState(false);
                writePodInfo();
                //TODO - write origPod to these text boxes
            }
        }

        private void checkDateValues()
        {
            DateTime badDate = new DateTime(2001, 1, 1);

            if (podDateRecDP.Value == badDate)
                podDateRecDP.Format = DateTimePickerFormat.Custom;
            else
                podDateRecDP.Format = DateTimePickerFormat.Short;
            if (podDateRelDP.Value == badDate)
                podDateRelDP.Format = DateTimePickerFormat.Custom;
            else
                podDateRelDP.Format = DateTimePickerFormat.Short;
        }

        private int getAndIncTempId()
        {
            return tempId++;
        }

        private void errorMessageBox(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void clearAll()
        {
            clearAveragesTBs();
            clearRetroInfoTBs();
            clearPodInfoTBs();
        }

        private void clearAveragesTBs()
        {
            retroOverallAvgRateTB.Clear();
            retroOverallRecoTB.Clear();
            retroCorbinAvgRateTB.Clear();
            retroCorbinAvgRecoTB.Clear();
            retroAllenAvgRateTB.Clear();
            retroAllenAvgRecoTB.Clear();
        }

        private void clearRetroInfoTBs()
        {
            retroComboBox.Items.Clear();
            retroComboBox.SelectedIndex = -1;
            retroItemListBox.Items.Clear();
            retroTitleTB.Clear();
            retroIdTB.Clear();
            retroTypeCB.SelectedText = "";
            retroTypeCB.SelectedIndex = -1;
            retroCodeTB.Clear();
        }

        private void clearPodInfoTBs()
        {
            selPod = null;
            origPod = null;
            podShortNameTB.Clear();
            podProdCodeTB.Clear();
            podTypeCB.SelectedIndex = -1;
            podRuntimeTB.Clear();
            podEditorTB.Clear();
            podTrackTB.Clear();
            //podHostsTB.Clear();
            podHostRatingsLB.Items.Clear();
            podDateRecDP.Format = DateTimePickerFormat.Custom;
            podDateRelDP.Format = DateTimePickerFormat.Custom;
            podURLTB.Clear();
        }


        #endregion
        

        #region FORM ACTIONS

        private void retroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = retroComboBox.SelectedIndex;
            Retrospective selRetro = (Retrospective)retroComboBox.SelectedItem;

            clearAveragesTBs();
            clearPodInfoTBs();
            writeRetroInfo(selRetro);
            loadRetroItems(selRetro);
        }

        private void retroItemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selPod = (Podcast)retroItemListBox.SelectedItem;
            if (selPod != null) origPod = (Podcast)selPod.Clone();
            else origPod = null;

            if ((Podcast)retroItemListBox.SelectedItem != null)
            {
                writePodInfo();
                podInfoEditBtn.Enabled = true;
            }
            else
                podInfoEditBtn.Enabled = false;
        }

        private void filterSortChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (filterSortChkBx.Checked)
                filterSortChkBx.Text = "Filter/Sort - ON";
            else
                filterSortChkBx.Text = "Filter/Sort - OFF";
            
            if(retroComboBox.SelectedItem != null)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }

        private void filterMainLineTSMI_CheckedChanged(object sender, EventArgs e)
        {
            if (retroComboBox.SelectedItem != null && filterSortChkBx.Checked)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }

        private void filterSuppTSMI_CheckStateChanged(object sender, EventArgs e)
        {
            if (retroComboBox.SelectedItem != null && filterSortChkBx.Checked)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }

        private void sortAlphaTSMI_CheckStateChanged(object sender, EventArgs e)
        {
            if (sortAlphaTSMI.Checked)
            {
                sortRelDateTSMI.Checked = false;
                sortRecDateTSMI.Checked = false;
                sortFilmRelTSMI.Checked = false;
                sortRuntimeTSMI.Checked = false;
            }
            if (retroComboBox.SelectedItem != null && filterSortChkBx.Checked)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }
        private void sortRelDateTSMI_CheckStateChanged(object sender, EventArgs e)
        {
            if (sortRelDateTSMI.Checked)
            {
                sortAlphaTSMI.Checked = false;
                sortRecDateTSMI.Checked = false;
                sortFilmRelTSMI.Checked = false;
                sortRuntimeTSMI.Checked = false;
            }
            if (retroComboBox.SelectedItem != null && filterSortChkBx.Checked)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }

        private void sortRecDateTSMI_CheckStateChanged(object sender, EventArgs e)
        {
            if (sortRecDateTSMI.Checked)
            {
                sortAlphaTSMI.Checked = false;
                sortRelDateTSMI.Checked = false;
                sortFilmRelTSMI.Checked = false;
                sortRuntimeTSMI.Checked = false;
            }
            if (retroComboBox.SelectedItem != null && filterSortChkBx.Checked)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }

        private void sortFilmRelTSMI_CheckStateChanged(object sender, EventArgs e)
        {
            if (sortFilmRelTSMI.Checked)
            {
                sortAlphaTSMI.Checked = false;
                sortRecDateTSMI.Checked = false;
                sortRelDateTSMI.Checked = false;
                sortRuntimeTSMI.Checked = false;
            }
            if (retroComboBox.SelectedItem != null && filterSortChkBx.Checked)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }

        private void sortRuntimeTSMI_CheckStateChanged(object sender, EventArgs e)
        {
            if (sortRuntimeTSMI.Checked)
            {
                sortAlphaTSMI.Checked = false;
                sortRecDateTSMI.Checked = false;
                sortRelDateTSMI.Checked = false;
                sortFilmRelTSMI.Checked = false;
            }
            if (retroComboBox.SelectedItem != null && filterSortChkBx.Checked)
                loadRetroItems((Retrospective)retroComboBox.SelectedItem);
        }

        private void retroInfoEditBtn_Click(object sender, EventArgs e)
        {
            toggleRetroInfoFields();
        }

        //TODO - fix updateRetro so it talks to tableData and not query.
        private void retroEditDoneBtn_Click(object sender, EventArgs e)
        {
            Retrospective retroUpdated;
            if (retroEditDoneBtn.Enabled && retroComboBox.SelectedItem != null)
            {
                retroUpdated = (Retrospective)retroComboBox.SelectedItem;
                retroUpdated.title = retroTitleTB.Text;
                retroUpdated.typeId = ((RetroType)retroTypeCB.SelectedItem).id;
                retroUpdated.code = retroCodeTB.Text;

                if (tableData.updateRetro(retroUpdated) > 0)
                {
                    toggleRetroInfoFields();
                }
            }
        }

        private void podEditBtn_Click(object sender, EventArgs e)
        {
            togglePodInfoFields();
        }

        private void podEditDoneBtn_Click(object sender, EventArgs e)
        {
            Podcast podUpdated;

            if (podEditDoneBtn.Enabled && retroItemListBox.SelectedItem != null)
            {
                podUpdated = (Podcast)retroItemListBox.SelectedItem;
                podUpdated.shortName = podShortNameTB.Text;
                podUpdated.typeId = ((PodType)podTypeCB.SelectedItem).id;
                podUpdated.runtime = podRuntimeTB.Text;
                podUpdated.dateRecDate = podDateRecDP.Value;
                podUpdated.dateRelDate = podDateRelDP.Value;
                podUpdated.editor = podEditorTB.Text;
                podUpdated.track = podTrackTB.Text;

                if(podUpdated.typeId != origPod.typeId &&
                    podUpdated.prodCode != origPod.prodCode)
                {
                    //update production code
                    if (!(tableData.updatePodProdCodeAndTypeId(selPod) > 0))
                    {
                        errorMessageBox("Could not update type and/or production code", "Production Code Warning");
                    }
                }

                Rating retRating = null;
                foreach(Rating updAddRates in selPod.ratings)
                {
                    retRating = tableData.addOrUpdateRating(updAddRates);
                    if (retRating == null)
                    {
                        errorMessageBox("Error adding rating for host " + updAddRates.host.firstName, "Rating Error");
                        break;
                    }
                }



                //add or update ratings
                //foreach(Rating updRating in updRatings)
                //{
                //    //tableData.updateRating(updRating);
                //    if (!(tableData.updateRating(updRating) > 0))
                //    {
                //        errorMessageBox("Could not update rating with for host: " + updRating.host.firstName, "Update Issue");
                //        break;
                //    }
                //}

                //foreach(Rating newRating in newRatings)
                //{
                //    //tableData.addRating(newRating);
                //    if ((tableData.addRating(newRating) == null))
                //    {
                //        errorMessageBox("Could not add rating for host: " + newRating.host.firstName, "Update Issue");
                //        break;
                //    }
                //}


                if (tableData.updatePodcast(podUpdated) > 0 && retRating != null)
                    togglePodInfoFields();
                else
                    errorMessageBox("Could not update title in Database", "DB Issue");
            }
        }

        private void InfoRetrieval_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAll();
            loadData();
        }

        private void podURLLLabel_Click(object sender, EventArgs e)
        {
            if(podURLLLabel.Text != "")
                System.Diagnostics.Process.Start(podURLLLabel.Text);
        }

        private void retrospectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form retroEditor = new RetroCreator();
            retroEditor.Top = this.Top + 20;
            retroEditor.Left = this.Left + 20;
            retroEditor.Show();
        }

        private void podcastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form podAdder = new PodcastAdd();
            podAdder.Top = this.Top + 20;
            podAdder.Left = this.Left + 20;
            podAdder.Show();
        }


        private void hostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form hostAdd = new HostAdd();
            hostAdd.Top = this.Top + 20;
            hostAdd.Left = this.Left + 20;
            hostAdd.Show();
        }

        private void retrospectiveQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form retroQuery = new RetroQuery();
            retroQuery.Top = this.Top + 20;
            retroQuery.Left = this.Left + 20;
            retroQuery.Show();
        }

        private void podDateRecClearLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            podDateRecDP.Value = new DateTime(2001, 1, 1);
            checkDateValues();
        }

        private void podDateRelClearLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            podDateRelDP.Value = new DateTime(2001, 1, 1);
            checkDateValues();
        }

        #endregion

        private void podDateRelDP_ValueChanged(object sender, EventArgs e)
        {
            podDateRelDP.Format = DateTimePickerFormat.Short;
        }

        private void podDateRecDP_ValueChanged(object sender, EventArgs e)
        {
            podDateRecDP.Format = DateTimePickerFormat.Short;
        }

        private void ratingConvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tableData.shakeBaby();
        }

        private void podHostRatingsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (podHostRatingsLB.SelectedItem != null)
            {
                podHostRateRemBtn.Enabled = true;
                podHostRateEditBtn.Enabled = true;
            }
            else
            {
                podHostRateRemBtn.Enabled = true;
                podHostRateEditBtn.Enabled = true;
            }
        }

        private void podHostRateAddBtn_Click(object sender, EventArgs e)
        {
            Rating rating = null;

            using (HostAndScoreAdd hostAndScoreAdd = new HostAndScoreAdd(selPod.ratings.Cast<Rating>().ToList()))
            {
                if (hostAndScoreAdd.ShowDialog() == DialogResult.OK)
                {
                    rating = hostAndScoreAdd.GetRating();
                    rating.tempId = getAndIncTempId();
                    if (rating.podcastId == 0)
                        rating.podcastId = selPod.id;
                    selPod.ratings.Add(rating);
                    setHostRatings();
                }
            }
        }

        private void podHostRateEditBtn_Click(object sender, EventArgs e)
        {
            if (podHostRatingsLB.SelectedItem != null)
            {
                Rating updRate = (Rating)podHostRatingsLB.SelectedItem;
                bool updNewRate = false;

                using (HostAndScoreAdd hostAndScoreAdd = new HostAndScoreAdd(updRate))
                {
                    if (hostAndScoreAdd.ShowDialog() == DialogResult.OK)
                    {
                        updRate = hostAndScoreAdd.GetRating();

                        //once it comes back, update selPod
                        for (int i = 0; i < selPod.ratings.Count; i++)
                        {
                            if (((Rating)selPod.ratings[i]).tempId == updRate.tempId)
                            {
                                selPod.ratings[i] = updRate;
                            }
                        }

                        //for(int i = 0; i < newRatings.Count; i++) 
                        //{
                        //    if(((Rating)newRatings[i]).id == updRate.id)
                        //    {
                        //        newRatings[i] = updRate;
                        //        updNewRate = true;
                        //    }
                        //}

                        //if(!updNewRate)
                        //    updRatings.Add(updRate);

                        setHostRatings();
                    }
                }
            }
        }

        private void podHostRateRemBtn_Click(object sender, EventArgs e)
        {
            if(podHostRatingsLB.SelectedIndex != null)
            {
                Rating remRating = (Rating)podHostRatingsLB.SelectedItem;
                selPod.ratings.Remove(remRating);
                podHostRatingsLB.Items.RemoveAt(podHostRatingsLB.SelectedIndex);
                remRatings.Add(remRating);
                setHostRatings();
            }
        }

        private void podResetLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            resetPodInfo();
        }

        private void retrospectiveTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form retroTypeMan = new RetroTypeManager();
            retroTypeMan.Top = this.Top + 20;
            retroTypeMan.Left = this.Left + 20;
            retroTypeMan.Show();
        }

        private void podTypeLockLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!podTypeCB.Enabled)
            {
                if (MessageBox.Show("Any changes to podcast type will mean the production code will need to be updated. " +
                    "This should only be done if absolutely necessary." +
                    "\n\nAre you sure you want to continue?",
                  "Production Code Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show("The production code will not be updated until the type field is locked. ", "Production Code Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    togglePodTypeToState(true);


                }
            }
            else
            {
                //if the type has changed then ask if they wanna continue with the prodcode update
                if ((origPod.typeId != ((PodType)podTypeCB.SelectedItem).id) &&
                    (MessageBox.Show("The podcast type was changed. Are you sure you want to continue? " +
                    "\nThis will result in an update to the production code.",
                  "Production Code Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    ProdCodeManager prodCodeManager = new ProdCodeManager(selPod, (Retrospective)retroComboBox.SelectedItem);

                    selPod.prodCode = prodCodeManager.assignNewPodType(selPod.prodCode, ((PodType)podTypeCB.SelectedItem).code);
                    selPod.typeId = ((PodType)podTypeCB.SelectedItem).id;
                    podProdCodeTB.Text = selPod.prodCode;

                    //if(tableData.updatePodProdCodeAndTypeId(selPod) > 0)
                    //{
                    //MessageBox.Show("Original Production Code: " + origPod.prodCode +
                    //    "\nNew Production Code: " + selPod.prodCode + "\tTypeID: " + selPod.typeId, 
                    //    "Production Code Warning", 
                    //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //}


                }
                else
                {
                    //revert back to original type
                    for(int i = 0; i < podTypeCB.Items.Count; i++)
                    {
                        if(((PodType)podTypeCB.Items[i]).id == origPod.typeId)
                        {
                            podTypeCB.SelectedIndex = i;
                        }
                    }
                }

                togglePodTypeToState(false);
            }
     
        }



        private void togglePodTypeToState(bool enable)
        {
            if (enable)
            {
                podTypeLockLabel.Text = "lock";
                //update the pod type and production code 
                podTypeCB.Enabled = true;
            }
            else
            {
                podTypeLockLabel.Text = "unlock";
                podTypeCB.Enabled = false;
            } 

        }


        private void toggleRetroTypeToState(bool enable)
        {
            if (enable)
            {
                retroTypeLockLabel.Text = "lock";
                //update the pod type and production code 
                retroTypeCB.Enabled = true;
            }
            else
            {
                retroTypeLockLabel.Text = "unlock";
                retroTypeCB.Enabled = false;
            }

        }

        //TODO - when the change is made to the retro type, then update all of the pods inside of retro 
        private void retroTypeLockLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!retroTypeCB.Enabled)
            {
                if (MessageBox.Show("Any changes to the type will mean the production code for ALL podcasts assigned to this " +
                    "retrospective will need to be updated. " +
                    "\n\nThis should only be done if absolutely necessary." +
                    "\n\nAre you sure you want to continue?",
                  "Production Code Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show("The production codes will not be updated until the type field is locked. ", "Production Code Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    toggleRetroTypeToState(true);


                }
            }
            else
            {
                toggleRetroTypeToState(false);
            }
                //    //if the type has changed then ask if they wanna continue with the prodcode update
                //    if ((origPod.typeId != ((PodType)podTypeCB.SelectedItem).id) &&
                //        (MessageBox.Show("The podcast type was changed. Are you sure you want to continue? " +
                //        "\nThis will result in an update to the production code.",
                //      "Production Code Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                //    {
                //        ProdCodeManager prodCodeManager = new ProdCodeManager(selPod, (Retrospective)retroComboBox.SelectedItem);

                //        selPod.prodCode = prodCodeManager.assignNewPodType(selPod.prodCode, ((PodType)podTypeCB.SelectedItem).code);
                //        selPod.typeId = ((PodType)podTypeCB.SelectedItem).id;
                //        podProdCodeTB.Text = selPod.prodCode;

                //        //if(tableData.updatePodProdCodeAndTypeId(selPod) > 0)
                //        //{
                //        //MessageBox.Show("Original Production Code: " + origPod.prodCode +
                //        //    "\nNew Production Code: " + selPod.prodCode + "\tTypeID: " + selPod.typeId, 
                //        //    "Production Code Warning", 
                //        //    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        //}


                //    }
                //    else
                //    {
                //        //revert back to original type
                //        for (int i = 0; i < podTypeCB.Items.Count; i++)
                //        {
                //            if (((PodType)podTypeCB.Items[i]).id == origPod.typeId)
                //            {
                //                podTypeCB.SelectedIndex = i;
                //            }
                //        }
                //    }

                //    togglePodTypeToState(false);
                //}
            }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login();
        }
    }

}
