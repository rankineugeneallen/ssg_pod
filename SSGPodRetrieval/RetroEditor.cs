﻿using SSG_Pod_Retrieval.model;
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
    public partial class RetroEditor : Form
    {

        ArrayList retrospectives = new ArrayList();
        public RetroEditor(ArrayList retrospectives)
        {
            InitializeComponent();
            this.retrospectives = retrospectives;
            loadRetrospectives();
        }


        private void loadRetrospectives()
        {
            Retrospective[] retroArr;
            retroListBox.Items.Clear();

            retroArr = (Retrospective[])retrospectives.ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
            {
                retroListBox.Items.Add(retroArr[i]);
            }
        }


    }
}
