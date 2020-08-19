using MySql.Data.MySqlClient;
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
    public partial class ConnectWin : Form
    {

        public ConnectWin()
        {
            InitializeComponent();
        }

        private void usrNmTB_TextChanged(object sender, EventArgs e)
        {
            checkEnableLogin();
        }

        private void passTB_TextChanged(object sender, EventArgs e)
        {
            checkEnableLogin();
        }

        private void connTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkEnableLogin();
        }

        private void checkEnableLogin()
        {
            if (!(string.IsNullOrEmpty(usrNmTB.Text)) &&
                (!(string.IsNullOrEmpty(passTB.Text))) &&
                connTypeCB.SelectedItem != null)
            {
                loginBtn.Enabled = true;
            }
            else
                loginBtn.Enabled = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Connect connectLo = new Connect(usrNmTB.Text, passTB.Text, (string)connTypeCB.SelectedItem);

            try
            {
                MySqlConnection connTest = new MySqlConnection("server=" + connectLo.ip + ";database=SSG_POD;userid=" + connectLo.username + ";password=" + connectLo.password + ";");
                connTest.Open();

                Properties.Settings.Default.username = connectLo.username;
                Properties.Settings.Default.password = connectLo.password;
                Properties.Settings.Default.ip = connectLo.ip;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if(ex.Code == 0)
                {
                    errLabel.Text = "Incorrect Credentials";
                }
                else
                {
                    errLabel.Text = "Error talking to DB";
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
