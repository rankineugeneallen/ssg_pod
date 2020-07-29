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
        QueryDaoImpl query;
        TableData tableData = TableData.Instance;

        public InfoRetrieval()
        {
            InitializeComponent();
            
            dynLabelSS.Text = "Loading...";
            
            query = new QueryDaoImpl();
            loadData();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
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

        private void writePodInfo(Podcast pod)
        {
            DateTime badDate = new DateTime(2001, 1, 1);
            podShortNameTB.Text = pod.shortName;
            podProdCodeTB.Text = pod.prodCode;
            podRuntimeTB.Text = pod.runtime;
            podEditorTB.Text = pod.editor;
            podHostsTB.Text = pod.hosts;
            podURLLLabel.Text = pod.url;
            podURLTB.Text = pod.url;
            

            if (pod.dateRecDate != badDate)
            {
                podDateRecDP.Value = pod.dateRecDate;
                podDateRecDP.Format = DateTimePickerFormat.Short;
            }
            else
                podDateRecDP.Format = DateTimePickerFormat.Custom;

            if (pod.dateRelDate != badDate)
            {
                podDateRelDP.Value = pod.dateRelDate;
                podDateRelDP.Format = DateTimePickerFormat.Short;
            }
            else
                podDateRelDP.Format = DateTimePickerFormat.Custom;

            //write score/recommendation
            if(!string.IsNullOrEmpty(pod.corbinRating.ToString()) ||
                !string.IsNullOrEmpty(pod.allenRating.ToString())){
                setHostRatings(pod);
                setHostRecommends(pod);
            }
            else
            {
                podCorbinRateCB.SelectedIndex = 0;
                podAllenRateCB.SelectedIndex = 0;
                podCorbinRecoCB.SelectedIndex = 0;
                podAllenRecoCB.SelectedIndex = 0;
            }

            for (int i = 0; i < podTypeCB.Items.Count; i++)
            {
                if (((PodType)podTypeCB.Items[i]).id == pod.typeId)
                    podTypeCB.SelectedIndex = i;
            }
        }

        private void setHostRatings(Podcast pod)
        {
            for(int i = 0; i < podCorbinRateCB.Items.Count; i++)
            {
                if (podCorbinRateCB.Items[i].ToString() == pod.corbinRating.ToString())
                {
                    podCorbinRateCB.SelectedIndex = i;
                    break;
                }
                else
                    podCorbinRateCB.SelectedIndex = 0;
            }

            for (int i = 0; i < podAllenRateCB.Items.Count; i++)
            {
                if (podAllenRateCB.Items[i].ToString() == pod.allenRating.ToString())
                {
                    podAllenRateCB.SelectedIndex = i;
                    break;
                }
                else
                    podAllenRateCB.SelectedIndex = 0;
            }
        }

        private void setHostRecommends(Podcast pod)
        {
            if(pod.corbinRecommend && !String.IsNullOrEmpty(pod.corbinRating))
                podCorbinRecoCB.SelectedIndex = 1;
            else if (!pod.corbinRecommend || !String.IsNullOrEmpty(pod.corbinRating))
                podCorbinRecoCB.SelectedIndex = 2;
            else
                podCorbinRecoCB.SelectedIndex = 0;

            if(pod.allenRecommend&& !String.IsNullOrEmpty(pod.allenRating))
                podAllenRecoCB.SelectedIndex = 1;
            else if (!pod.allenRecommend || !String.IsNullOrEmpty(pod.allenRating))
                podAllenRecoCB.SelectedIndex = 2;
            else
                podAllenRecoCB.SelectedIndex = 0;

            
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

        private void toggleRetroInfoFields()
        {
            retroTitleTB.ReadOnly = !retroTitleTB.ReadOnly;
            retroTypeCB.Enabled = !retroTypeCB.Enabled;
            retroCodeTB.ReadOnly = !retroCodeTB.ReadOnly;

            retroEditDoneBtn.Enabled = !retroEditDoneBtn.Enabled;

            if (retroInfoEditBtn.Text == "Edit")
                retroInfoEditBtn.Text = "Cancel";
            else
                retroInfoEditBtn.Text = "Edit";
        }

        private void togglePodInfoFields()
        {
            podShortNameTB.ReadOnly = !podShortNameTB.ReadOnly;
            podTypeCB.Enabled = !podTypeCB.Enabled;
            podRuntimeTB.ReadOnly = !podRuntimeTB.ReadOnly;
            podEditorTB.ReadOnly = !podEditorTB.ReadOnly;
            podHostsTB.ReadOnly = !podHostsTB.ReadOnly;
            podDateRecDP.Enabled = !podDateRecDP.Enabled;
            podDateRelDP.Enabled = !podDateRelDP.Enabled;
            podDateRecClearLabel.Enabled = !podDateRecClearLabel.Enabled;
            podDateRelClearLabel.Enabled = !podDateRelClearLabel.Enabled;
            podCorbinRateCB.Enabled = !podCorbinRateCB.Enabled;
            podAllenRateCB.Enabled = !podAllenRateCB.Enabled;
            podCorbinRecoCB.Enabled = !podCorbinRecoCB.Enabled;
            podAllenRecoCB.Enabled = !podAllenRecoCB.Enabled;
            podURLTB.Visible = !podURLTB.Visible;

            podURLLLabel.Text = podURLTB.Text;

            podEditDoneBtn.Enabled = !podEditDoneBtn.Enabled;

            if (podInfoEditBtn.Text == "Edit")
                podInfoEditBtn.Text = "Cancel";
            else
                podInfoEditBtn.Text = "Edit";
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
            podShortNameTB.Clear();
            podProdCodeTB.Clear();
            podTypeCB.Text = "";
            podRuntimeTB.Clear();
            podEditorTB.Clear();
            podHostsTB.Clear();
            podDateRecDP.Format = DateTimePickerFormat.Custom;
            podDateRelDP.Format = DateTimePickerFormat.Custom;
            podCorbinRateCB.SelectedIndex = 0;
            podCorbinRecoCB.SelectedIndex = 0;
            podAllenRateCB.SelectedIndex = 0;
            podAllenRecoCB.SelectedIndex = 0;
        }


        #endregion
        

        #region FORM ACTIONS

        private void retroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = retroComboBox.SelectedIndex;
            Retrospective selRetro = (Retrospective)retroComboBox.SelectedItem;


            writeRetroInfo(selRetro);
            loadRetroItems(selRetro);
        }

        private void retroItemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Podcast selPod = (Podcast)retroItemListBox.SelectedItem;

            if ((Podcast)retroItemListBox.SelectedItem != null)
            {
                writePodInfo(selPod);
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

        private void retroEditDoneBtn_Click(object sender, EventArgs e)
        {
            Retrospective retroUpdated;
            if (retroEditDoneBtn.Enabled && retroComboBox.SelectedItem != null)
            {
                retroUpdated = (Retrospective)retroComboBox.SelectedItem;
                retroUpdated.title = retroTitleTB.Text;
                retroUpdated.typeId = ((RetroType)retroTypeCB.SelectedItem).id;
                retroUpdated.code = retroCodeTB.Text;

                if (query.updateRetro(retroUpdated) > 0)
                {
                    loadRetrospectives();

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
                podUpdated.hosts = podHostsTB.Text;
                podUpdated.corbinRating = (string)podCorbinRateCB.Items[podCorbinRateCB.SelectedIndex];
                podUpdated.allenRating = (string)podAllenRateCB.Items[podAllenRateCB.SelectedIndex];
                
                if(podCorbinRecoCB.SelectedIndex == 1 ) podUpdated.corbinRecommend = true;
                else podUpdated.corbinRecommend = false;

                if (podAllenRecoCB.SelectedIndex == 1) podUpdated.allenRecommend = true;
                else podUpdated.allenRecommend = false;

                if (tableData.updatePodcast(podUpdated) > 0)
                {
                    tableData.loadPodcasts();
                    togglePodInfoFields();
                }
                else
                {
                    errorMessageBox("Could not update title in Database", "DB Issue");
                }
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
            retroEditor.Show();
        }

        private void podcastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form podAdder = new PodcastAdd();
            podAdder.Show();
        }

        private void podTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form hostAdd = new HostAdd();
            hostAdd.Show();
        }

        private void retrospectiveQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form retroQuery = new RetroQuery();
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
    }
}
