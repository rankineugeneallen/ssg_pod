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


        public RetroCreator()
        {
            InitializeComponent();
            loadRetrospectives();
        }


        private void loadRetrospectives()
        {
            Retrospective[] retroArr;
            retroListBox.Items.Clear();

            retroArr = (Retrospective[])tableData.getRetrospectives().ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
            {
                retroListBox.Items.Add(retroArr[i]);
            }
        }


    }
}
