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
    public partial class HostAdd : Form
    {
        TableData tableData = TableData.Instance;
        public Host host { get; private set; }
        private Host editHost;

        public Host GetHost()
        {
            return host;
        }

        public HostAdd()
        {
            InitializeComponent();
        }
        
        public HostAdd(Host host)
        {
            InitializeComponent();

            this.editHost = host;
            loadHost();
        }

        private void loadHost()
        {
            hostFirstNameTB.Text = host.firstName;
            hostLastNameTB.Text = host.lastName;
        }

        private void hostAddBtn_Click(object sender, EventArgs e)
        {
            if(editHost == null)
            {
                Host host = new Host();

                host.firstName = hostFirstNameTB.Text;
                host.lastName = hostLastNameTB.Text;

                if (tableData.addHost(host) != null)
                {
                    if(MessageBox.Show("Name: " + host.firstName + " " + host.lastName + "\nID: " + host.id, "Host added successfully!", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error adding host", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        //private bool hostExists()
        //{
        //    ArrayList hosts = tableData.getHosts();

        //    for (int i = 0; i < hosts.Count; i++)
        //    {
        //        if (((Host)hosts[i]).firstName == hostFirstNameTB.Text &&
        //            ((Host)hosts[i]).lastName == hostLastNameTB.Text)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        private void hostCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
