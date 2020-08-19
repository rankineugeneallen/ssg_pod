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
    public partial class RetroTypeManager : Form
    {
        TableData tableData = TableData.Instance;

        public RetroTypeManager()
        {
            InitializeComponent();

            loadRetroTypes();
        }

        private void RetroTypeManager_Load(object sender, EventArgs e)
        {

        }


        private void loadRetroTypes()
        {
            retroTypeLB.Items.Clear();
            reassignTypeCB.Items.Clear();

            RetroType[] retroTypeArr = (RetroType[])tableData.getRetroTypes().ToArray(typeof(RetroType));

            for (int i = 0; i < retroTypeArr.Length; i++)
            {
                retroTypeLB.Items.Add(retroTypeArr[i]);
                reassignTypeCB.Items.Add(retroTypeArr[i]);

            }
        }

        private void retroTypeLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(retroTypeLB.SelectedItem != null)
            {
                loadRetrosOfType();

                reassignTypeCB.SelectedIndex = -1;
                reassignTypeCB.Enabled = false;
                retroTypeNameTB.Text = ((RetroType)retroTypeLB.SelectedItem).title;
                retroTypeCodeTB.Text = ((RetroType)retroTypeLB.SelectedItem).code;
                retroTypeSaveBtn.Enabled = false;

                errorDynLabel.Text = "";

            }
        }

        private void loadRetrosOfType()
        {
            retroTypesAssignLB.Items.Clear();
            int typeId = ((RetroType)retroTypeLB.SelectedItem).id;
            Retrospective[] retroArr = (Retrospective[])tableData.getRetrosOfType(typeId).ToArray(typeof(Retrospective));

            for (int i = 0; i < retroArr.Length; i++)
                retroTypesAssignLB.Items.Add(retroArr[i]);

        }

        private void retroTypesAssignLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (retroTypesAssignLB.SelectedItem != null || retroTypesAssignLB.SelectedItems.Count != 0)
                reassignTypeCB.Enabled = true;
            else 
                reassignTypeCB.Enabled = false;
        }

        private void reassignTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void reassignBtn_Click(object sender, EventArgs e)
        {
            //warn about production codes also needing to be updated. 
            if (MessageBox.Show("All of the podcasts attached to the selected retrospective(s) will " +
                "need to receive updated production codes. \nAre you sure you want to continue?",
                "Production Code Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Retrospective retroChange;

                for (int i = 0; i < retroTypesAssignLB.SelectedItems.Count; i++)
                {
                    retroChange = (Retrospective)retroTypesAssignLB.SelectedItems[i];

                    retroChange.typeId = ((RetroType)reassignTypeCB.SelectedItem).id;

                    if (!(tableData.updateRetro(retroChange) > 0))
                    {
                        errorAssignLabel.Visible = true;
                        break;
                    }

                }
                loadRetrosOfType();
            }
        }

        private void retroTypeRenameBtn_Click(object sender, EventArgs e)
        {
            if(retroTypeLB.SelectedItem != null)
            {
                RetroType selRetroType = (RetroType)retroTypeLB.SelectedItem;

                selRetroType.title = retroTypeNameTB.Text;
                selRetroType.code = retroTypeCodeTB.Text;

                if(!(tableData.updateRetroType(selRetroType) > 0))
                {
                    errorDynLabel.Text = "Error saving Retrospective Type";
                }
            }
            else
            { // adding a new retrospective type
                RetroType retroType = new RetroType();
                retroType.code = retroTypeCodeTB.Text;
                retroType.title = retroTypeNameTB.Text;

                if((tableData.addRetroType(retroType) == null))
                {
                    errorDynLabel.Text = "Error saving Retrospective Type";
                }
                else
                {
                    loadRetroTypes();
                    retroTypeCodeTB.Enabled = false;
                }
            }
        }

        private void retroTypeNameTB_TextChanged(object sender, EventArgs e)
        {
            retroTypeSaveBtn.Enabled = true;
        }

        private void retroTypeCodeTB_TextChanged(object sender, EventArgs e)
        {
            retroTypeSaveBtn.Enabled = true;
        }

        private void retroTypeAddBtn_Click(object sender, EventArgs e)
        {
            retroTypeNameTB.Text = "";
            retroTypeCodeTB.Text = "";
            retroTypeCodeTB.Enabled = true;
            retroTypeLB.SelectedIndex = -1;
            //empty retroTpesAssignLB
            retroTypesAssignLB.Items.Clear();
            retroTypeNameTB.Focus();
        }

        private void retroTypeRemBtn_Click(object sender, EventArgs e)
        {
            if (((RetroType)retroTypeLB.SelectedItem).id == 0)
                errorDynLabel.Text = "Cannot delete type uncategorized";
            else if(retroTypeLB.SelectedItem != null && !(retroTypesAssignLB.Items.Count > 0))
            {
                RetroType remRetroType = (RetroType)retroTypeLB.SelectedItem;
                if(tableData.removeRetroType(remRetroType) > 0)
                {
                    loadRetroTypes();
                    retroTypeNameTB.Text = "";
                    retroTypeCodeTB.Text = "";
                }
            }
            else
                errorDynLabel.Text = "Cannot remove type with retrospectives still assigned to it.";
        }

        private void errorDynLabel_Click(object sender, EventArgs e)
        {
            errorDynLabel.Text = "";
        }

        private void errorAssignLabel_Click(object sender, EventArgs e)
        {
            errorAssignLabel.Text = "";
        }

        private void retroTypeNameLL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
