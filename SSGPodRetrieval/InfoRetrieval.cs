using SSG_Pod_Retrieval.model;
using SSGPodRetrieval.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSGPodRetrieval
{
    public partial class InfoRetrieval : Form
    {
        QueryDaoImpl query;
        ArrayList retrospectives = new ArrayList();
        ArrayList podTypes = new ArrayList();
        //List<PodType> podTypes = new List<PodType>();
        ArrayList retroTypes = new ArrayList();
        List<Podcast> podcasts;

        public InfoRetrieval()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load types then retros, then pods
            query = new QueryDaoImpl();
            loadPodTypes();
            loadRetroTypes();
            loadRetrospectives();
            loadPodcasts();
            setRetroTypes();
            setPodTypes();
            //query.getTotalMLPods();
            //query.closeConn();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void findRetroPodsBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void loadRetroItems(Retrospective retro)
        {
            ArrayList retroItems = new ArrayList();
            ArrayList organizedItems = new ArrayList();
            Podcast[] podArr;
            
            retroItemListBox.Items.Clear();
            
            foreach(Podcast podcast in podcasts)
            {
                if(podcast.retroId == retro.id)
                {
                    retroItems.Add(podcast);
                }
            }

            //organize
            organizedItems = organizeRetroItems(retroItems);
            
            podArr = (Podcast[])organizedItems.ToArray(typeof(Podcast));

            for (int i = 0; i < podArr.Length; i++)
            {
                retroItemListBox.Items.Add(podArr[i]);
            }

        }

        private void loadPodcasts()
        {
            podcasts = query.getAllPodcasts();
        }

        private void loadPodTypes()
        {
            podTypes = query.loadPodTypes();

            PodType[] podTypeArr = (PodType[])podTypes.ToArray(typeof(PodType));

            for (int i = 0; i < podTypeArr.Length; i++)
                podTypeCB.Items.Add(podTypeArr[i]);
        }

        private void setPodTypes()
        {
            foreach(Podcast podcast in podcasts)
            {
                foreach(PodType podType in podTypes)
                {
                    if(podcast.typeId == podType.id)
                    {
                        podcast.type = podType.type;
                    }
                }
            }
        }

        private void setRetroTypes()
        {
            foreach(Retrospective retrospective in retrospectives)
            {
                foreach(RetroType retroType in retroTypes)
                {
                    if(retrospective.typeId == retroType.id)
                    {
                        retrospective.type = retroType.title;
                    }
                }
            }
        }

        private void loadRetroTypes()
        {
            retroTypes = query.loadRetroTypes();
            RetroType[] retroTypeArr = (RetroType[])retroTypes.ToArray(typeof(RetroType));

            for (int i = 0; i < retroTypeArr.Length; i++)
                retroTypeCB.Items.Add(retroTypeArr[i]);
        }

        private void loadRetrospectives()
        {
            Retrospective[] retroArr;
            
            retroItemListBox.Items.Clear();
            retroComboBox.Items.Clear();

            retrospectives = query.getAllRetros();
            
            retroArr = (Retrospective[])retrospectives.ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
                retroComboBox.Items.Add(retroArr[i]);
        }

        private void retroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = retroComboBox.SelectedIndex;
            Retrospective selRetro = (Retrospective)retroComboBox.SelectedItem;

            writeRetroInfo(selRetro);
            loadRetroItems(selRetro);
        }

        private void writeRetroInfo(Retrospective retro)
        {
            RetroType tempRetroType;
            
            retroTitleTB.Text = retro.title;
            retroIdTB.Text = retro.id.ToString();
            //retroTypeTB.Text = retro.type;
            retroCodeTB.Text = retro.code;

            for(int i = 0; i < retroTypeCB.Items.Count; i++)
            {
                //tempRetroType = (RetroType)retroTypeCB.Items[i];
                
                if (((RetroType)retroTypeCB.Items[i]).id == retro.typeId)
                    retroTypeCB.SelectedIndex = i;
            }

        }

        private void writePodInfo(Podcast pod)
        {
            DateTime badDate = new DateTime(0001, 1, 1);
            podShortNameTB.Text = pod.shortName;
            podProdCodeTB.Text = pod.prodCode;
            //podTypeTB.Text = pod.type;
            podRuntimeTB.Text = pod.runtime;
            podEditorTB.Text = pod.editor;
            podHostsTB.Text = pod.hosts;
            podURLLLabel.Text = pod.url;

            podDateRecTB.Text = "";
            podDateRelTB.Text = "";

            if (pod.dateRecDate != badDate)
                podDateRecTB.Text = pod.dateRecDate.ToString("MM/dd/yyyy");
            if (pod.dateRelDate != badDate)
                podDateRelTB.Text = pod.dateRelDate.ToString("MM/dd/yyyy");
            for (int i = 0; i < podTypeCB.Items.Count; i++)
            {
                if (((PodType)podTypeCB.Items[i]).id == pod.typeId)
                    podTypeCB.SelectedIndex = i;
            }
        }

        private ArrayList organizeRetroItems(ArrayList retroItems)
        {
            retroItems = filterPodcasts(retroItems);
            retroItems = sortedPodcasts(retroItems);
            
            return retroItems;
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
            {
                sortedPodcastList.Add((Podcast)retroItems[i]);
            }


            if (sortRelDateTSMI.Checked)
            {
                sortedPodcastList.Sort((Podcast x, Podcast y) => DateTime.Compare(x.dateRelDate, y.dateRelDate));
            }
            if (sortRecDateTSMI.Checked)
            {
                sortedPodcastList.Sort((Podcast x, Podcast y) => DateTime.Compare(x.dateRecDate, y.dateRecDate));
            }
            if (sortAlphaTSMI.Checked)
            {
                sortedPodcastList.Sort((Podcast x, Podcast y) => string.Compare(x.shortName, y.shortName));
            }
            

            return new ArrayList(sortedPodcastList);
        }

        private void retroItemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Podcast selPod = (Podcast)retroItemListBox.SelectedItem;

            if (selPod != null)
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



        private void openRetrospectiveEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form retroEditor = new RetroEditor(retrospectives);
            retroEditor.Show();
        }

        private void retroInfoEditBtn_Click(object sender, EventArgs e)
        {
            retroTitleTB.ReadOnly = !retroTitleTB.ReadOnly;
            //retroTypeTB.ReadOnly = !retroTypeTB.ReadOnly;
            retroTypeCB.Enabled = !retroTypeCB.Enabled;
            retroCodeTB.ReadOnly = !retroCodeTB.ReadOnly;

            retroEditDoneBtn.Enabled = !retroEditDoneBtn.Enabled;

            if (retroInfoEditBtn.Text == "Edit")
                retroInfoEditBtn.Text = "Cancel";
            else
                retroInfoEditBtn.Text = "Edit";
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

                    retroTitleTB.ReadOnly = !retroTitleTB.ReadOnly;
                    //retroTypeTB.ReadOnly = !retroTypeTB.ReadOnly;
                    retroTypeCB.Enabled = !retroTypeCB.Enabled;
                    retroCodeTB.ReadOnly = !retroCodeTB.ReadOnly;

                    retroEditDoneBtn.Enabled = !retroEditDoneBtn.Enabled;

                    if (retroInfoEditBtn.Text == "Edit")
                        retroInfoEditBtn.Text = "Cancel";
                    else
                        retroInfoEditBtn.Text = "Edit";
                }

            }
        }

        private void podEditBtn_Click(object sender, EventArgs e)
        {
            podShortNameTB.ReadOnly = !podShortNameTB.ReadOnly;
            //podTypeTB.ReadOnly = !podTypeTB.ReadOnly;
            podTypeCB.Enabled = !podTypeCB.Enabled;
            //podRetroCB.Enabled = !podRetroCB.Enabled;
            podRuntimeTB.ReadOnly = !podRuntimeTB.ReadOnly;
            podEditorTB.ReadOnly = !podEditorTB.ReadOnly;
            podHostsTB.ReadOnly = !podHostsTB.ReadOnly;
            podDateRecTB.ReadOnly = !podDateRecTB.ReadOnly;
            podDateRelTB.ReadOnly = !podDateRelTB.ReadOnly;

            podEditDoneBtn.Enabled = !podEditDoneBtn.Enabled;

            if (podInfoEditBtn.Text == "Edit")
                podInfoEditBtn.Text = "Cancel";
            else
                podInfoEditBtn.Text = "Edit";
        }

        private void InfoRetrieval_FormClosing(object sender, FormClosingEventArgs e)
        {
            //query.closeConn();
        }

        private void retroPodGrpBox_Enter(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            retroComboBox.Items.Clear();
            retroComboBox.SelectedIndex = -1;
            retroComboBox.Text = "";
            retroItemListBox.Items.Clear();
            retroTitleTB.Text = "";
            retroIdTB.Text = "";
            //retroTypeTB.Text = "";
            retroTypeCB.SelectedText = "";
            retroTypeCB.SelectedIndex = -1;
            retroCodeTB.Text = "";

            podShortNameTB.Text = "";
            podProdCodeTB.Text = "";
            //podTypeTB.Text = "";
            podTypeCB.SelectedText = "";
            podTypeCB.SelectedIndex = -1;
            podRuntimeTB.Text = "";
            podEditorTB.Text = "";
            podHostsTB.Text = "";
            podURLLLabel.Text = "";
            podDateRecTB.Text = "";
            podDateRelTB.Text = "";


            loadPodTypes();
            loadRetroTypes();
            loadRetrospectives();
            loadPodcasts();
            setRetroTypes();
            setPodTypes();
        }

        private void podEditDoneBtn_Click(object sender, EventArgs e)
        {
            Podcast podUpdated;
            if (podEditDoneBtn.Enabled && retroItemListBox.SelectedItem != null)
            {
                podUpdated = (Podcast)retroItemListBox.SelectedItem;
                podUpdated.shortName = podShortNameTB.Text;
                podUpdated.typeId = ((PodType)podTypeCB.SelectedItem).id;
                //podUpdated.retroId = ((Retrospective)podRetroCB.SelectedItem).id;
                podUpdated.runtime = podRuntimeTB.Text;
                podUpdated.dateRec = podDateRecTB.Text;
                podUpdated.dateRel = podDateRelTB.Text;
                podUpdated.editor = podEditorTB.Text;
                podUpdated.hosts = podHostsTB.Text;
                
                if (query.updatePod(podUpdated) > 0)
                {
                    loadPodcasts();

                    podShortNameTB.ReadOnly = !podShortNameTB.ReadOnly;
                    //podTypeTB.ReadOnly = !podTypeTB.ReadOnly;
                    //podRetroCB.Enabled = !podRetroCB.Enabled;
                    podTypeCB.Enabled = !podTypeCB.Enabled;
                    podRuntimeTB.ReadOnly = !podRuntimeTB.ReadOnly;
                    podEditorTB.ReadOnly = !podEditorTB.ReadOnly;
                    podHostsTB.ReadOnly = !podHostsTB.ReadOnly;
                    podDateRecTB.ReadOnly = !podDateRecTB.ReadOnly;
                    podDateRelTB.ReadOnly = !podDateRelTB.ReadOnly;

                    podEditDoneBtn.Enabled = !podEditDoneBtn.Enabled;

                    if (podInfoEditBtn.Text == "Edit")
                        podInfoEditBtn.Text = "Cancel";
                    else
                        podInfoEditBtn.Text = "Edit";
                }
            }
        }

        private void podURLLLabel_Click(object sender, EventArgs e)
        {
            if(podURLLLabel.Text != "")
            {
                System.Diagnostics.Process.Start(podURLLLabel.Text);
            }
        }

        
    }
}
