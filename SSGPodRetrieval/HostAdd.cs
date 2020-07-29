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
        QueryDaoImpl query = new QueryDaoImpl();
        TableData tableData = TableData.Instance;

        public HostAdd()
        {
            InitializeComponent();
        }

        private void hostAddBtn_Click(object sender, EventArgs e)
        {
            Host host = new Host();

            host.firstName = hostFirstNameTB.Text;
            host.lastName = hostLastNameTB.Text;

            if (!hostExists())
            {
                Console.WriteLine(query.insertHost(host));
            }
            else
            {
                string message = "Host Already Exists";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private bool hostExists()
        {
            ArrayList hosts = tableData.getHosts();

            for (int i = 0; i < hosts.Count; i++)
            {
                if (((Host)hosts[i]).firstName == hostFirstNameTB.Text &&
                    ((Host)hosts[i]).lastName == hostLastNameTB.Text)
                {
                    return true;
                }
            }

            return false;
        }

        private void hostCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
