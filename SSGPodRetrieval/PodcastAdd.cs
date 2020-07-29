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
        QueryDaoImpl query = new QueryDaoImpl();

        public PodcastAdd()
        {
            InitializeComponent();
            
            loadHosts();
            loadPodTypes();
            loadRetrospectives();
        }

        private void loadRetrospectives()
        {
            Retrospective[] retroArr;
            
            retroComboBox.Items.Clear();

            retroArr = (Retrospective[])tableData.getRetrospectives().ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
                retroComboBox.Items.Add(retroArr[i]);
        }

        private void loadHosts()
        {
            hostCLB.Items.Clear();

            Host[] hostArr = (Host[])tableData.getHosts().ToArray(typeof(Host));

            for (int i = 0; i < hostArr.Length; i++)
                hostCLB.Items.Add(hostArr[i]);
        }

        private void loadPodTypes()
        {

            podTypeCB.Items.Clear();

            PodType[] podTypeArr = (PodType[])tableData.getPodTypes().ToArray(typeof(PodType));

            for (int i = 0; i < podTypeArr.Length; i++)
                podTypeCB.Items.Add(podTypeArr[i]);
        }

        private string getHostsFirstNamesFromCLB()
        {
            string hostStr = "";
            ArrayList checkedHosts = new ArrayList();

            for(int i = 0; i < hostCLB.CheckedItems.Count; i++)
            {
                checkedHosts.Add((Host)hostCLB.CheckedItems[i]);
            }
            
            
            for(int i = 0; i < checkedHosts.Count; i++)
            {
                hostStr += ((Host)checkedHosts[i]).firstName + " ";
                if (!(i + 1 >= checkedHosts.Count)) hostStr += ", ";
            }

            return hostStr;
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
            Podcast pod = new Podcast();

            pod.title = longTitleTB.Text;
            pod.shortName = shortNameTB.Text;
            pod.runtime = runtimeTB.Text;
            pod.typeId = ((PodType)podTypeCB.SelectedItem).id;
            pod.editor = editorTB.Text;
            pod.retroId = ((Retrospective)retroComboBox.SelectedItem).id;
            pod.hosts = getHostsFirstNamesFromCLB();
            


        }

        private void podCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hostAddBtn_Click(object sender, EventArgs e)
        {
            Form hostAdd = new HostAdd();
            hostAdd.Show();
        }

        private void PodcastAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
