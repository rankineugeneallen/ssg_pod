namespace SSGPodRetrieval
{
    partial class RetroTypeManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetroTypeManager));
            this.retroTypeLB = new System.Windows.Forms.ListBox();
            this.retroTypeNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.retroTypesAssignLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.retroTypeSaveBtn = new System.Windows.Forms.Button();
            this.retroTypeNameLL = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.reassignTypeCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorAssignLabel = new System.Windows.Forms.Label();
            this.reassignBtn = new System.Windows.Forms.Button();
            this.errorDynLabel = new System.Windows.Forms.Label();
            this.retroTypeCodeTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.retroTypeAddBtn = new System.Windows.Forms.Button();
            this.retroTypeRemBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // retroTypeLB
            // 
            this.retroTypeLB.FormattingEnabled = true;
            this.retroTypeLB.Location = new System.Drawing.Point(15, 25);
            this.retroTypeLB.Name = "retroTypeLB";
            this.retroTypeLB.Size = new System.Drawing.Size(130, 69);
            this.retroTypeLB.TabIndex = 0;
            this.retroTypeLB.SelectedIndexChanged += new System.EventHandler(this.retroTypeLB_SelectedIndexChanged);
            // 
            // retroTypeNameTB
            // 
            this.retroTypeNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroTypeNameTB.Location = new System.Drawing.Point(151, 25);
            this.retroTypeNameTB.Name = "retroTypeNameTB";
            this.retroTypeNameTB.Size = new System.Drawing.Size(160, 26);
            this.retroTypeNameTB.TabIndex = 1;
            this.retroTypeNameTB.TextChanged += new System.EventHandler(this.retroTypeNameTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // retroTypesAssignLB
            // 
            this.retroTypesAssignLB.FormattingEnabled = true;
            this.retroTypesAssignLB.Location = new System.Drawing.Point(15, 119);
            this.retroTypesAssignLB.Name = "retroTypesAssignLB";
            this.retroTypesAssignLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.retroTypesAssignLB.Size = new System.Drawing.Size(191, 225);
            this.retroTypesAssignLB.TabIndex = 0;
            this.retroTypesAssignLB.SelectedIndexChanged += new System.EventHandler(this.retroTypesAssignLB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Assigned Retrospectives";
            // 
            // retroTypeSaveBtn
            // 
            this.retroTypeSaveBtn.Enabled = false;
            this.retroTypeSaveBtn.Location = new System.Drawing.Point(290, 57);
            this.retroTypeSaveBtn.Name = "retroTypeSaveBtn";
            this.retroTypeSaveBtn.Size = new System.Drawing.Size(57, 23);
            this.retroTypeSaveBtn.TabIndex = 4;
            this.retroTypeSaveBtn.Text = "Save";
            this.retroTypeSaveBtn.UseVisualStyleBackColor = true;
            this.retroTypeSaveBtn.Click += new System.EventHandler(this.retroTypeRenameBtn_Click);
            // 
            // retroTypeNameLL
            // 
            this.retroTypeNameLL.AutoSize = true;
            this.retroTypeNameLL.Location = new System.Drawing.Point(263, 57);
            this.retroTypeNameLL.Name = "retroTypeNameLL";
            this.retroTypeNameLL.Size = new System.Drawing.Size(30, 13);
            this.retroTypeNameLL.TabIndex = 5;
            this.retroTypeNameLL.TabStop = true;
            this.retroTypeNameLL.Text = "reset";
            this.retroTypeNameLL.Visible = false;
            this.retroTypeNameLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.retroTypeNameLL_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Retrospective Types";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Reassign Type";
            // 
            // reassignTypeCB
            // 
            this.reassignTypeCB.BackColor = System.Drawing.Color.White;
            this.reassignTypeCB.Enabled = false;
            this.reassignTypeCB.FormattingEnabled = true;
            this.reassignTypeCB.Location = new System.Drawing.Point(212, 135);
            this.reassignTypeCB.Name = "reassignTypeCB";
            this.reassignTypeCB.Size = new System.Drawing.Size(135, 21);
            this.reassignTypeCB.TabIndex = 8;
            this.reassignTypeCB.SelectedIndexChanged += new System.EventHandler(this.reassignTypeCB_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Note: You can assign a type \r\n to multiple retros at one time";
            // 
            // errorAssignLabel
            // 
            this.errorAssignLabel.AutoSize = true;
            this.errorAssignLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorAssignLabel.Location = new System.Drawing.Point(209, 318);
            this.errorAssignLabel.Name = "errorAssignLabel";
            this.errorAssignLabel.Size = new System.Drawing.Size(133, 26);
            this.errorAssignLabel.TabIndex = 10;
            this.errorAssignLabel.Text = "Error assigning new type(s)\r\nto Retrospective(s).";
            this.errorAssignLabel.Visible = false;
            this.errorAssignLabel.Click += new System.EventHandler(this.errorAssignLabel_Click);
            // 
            // reassignBtn
            // 
            this.reassignBtn.Location = new System.Drawing.Point(276, 162);
            this.reassignBtn.Name = "reassignBtn";
            this.reassignBtn.Size = new System.Drawing.Size(71, 23);
            this.reassignBtn.TabIndex = 11;
            this.reassignBtn.Text = "Reassign";
            this.reassignBtn.UseVisualStyleBackColor = true;
            this.reassignBtn.Click += new System.EventHandler(this.reassignBtn_Click);
            // 
            // errorDynLabel
            // 
            this.errorDynLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorDynLabel.Location = new System.Drawing.Point(175, 83);
            this.errorDynLabel.Name = "errorDynLabel";
            this.errorDynLabel.Size = new System.Drawing.Size(172, 33);
            this.errorDynLabel.TabIndex = 12;
            this.errorDynLabel.Click += new System.EventHandler(this.errorDynLabel_Click);
            // 
            // retroTypeCodeTB
            // 
            this.retroTypeCodeTB.Enabled = false;
            this.retroTypeCodeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroTypeCodeTB.Location = new System.Drawing.Point(317, 25);
            this.retroTypeCodeTB.MaxLength = 1;
            this.retroTypeCodeTB.Name = "retroTypeCodeTB";
            this.retroTypeCodeTB.Size = new System.Drawing.Size(30, 26);
            this.retroTypeCodeTB.TabIndex = 13;
            this.retroTypeCodeTB.TextChanged += new System.EventHandler(this.retroTypeCodeTB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Code";
            // 
            // retroTypeAddBtn
            // 
            this.retroTypeAddBtn.Location = new System.Drawing.Point(151, 53);
            this.retroTypeAddBtn.Name = "retroTypeAddBtn";
            this.retroTypeAddBtn.Size = new System.Drawing.Size(18, 20);
            this.retroTypeAddBtn.TabIndex = 15;
            this.retroTypeAddBtn.Text = "+";
            this.retroTypeAddBtn.UseVisualStyleBackColor = true;
            this.retroTypeAddBtn.Click += new System.EventHandler(this.retroTypeAddBtn_Click);
            // 
            // retroTypeRemBtn
            // 
            this.retroTypeRemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.retroTypeRemBtn.Location = new System.Drawing.Point(151, 75);
            this.retroTypeRemBtn.Name = "retroTypeRemBtn";
            this.retroTypeRemBtn.Size = new System.Drawing.Size(18, 20);
            this.retroTypeRemBtn.TabIndex = 16;
            this.retroTypeRemBtn.Text = "-";
            this.retroTypeRemBtn.UseVisualStyleBackColor = false;
            this.retroTypeRemBtn.Click += new System.EventHandler(this.retroTypeRemBtn_Click);
            // 
            // RetroTypeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 357);
            this.Controls.Add(this.retroTypeRemBtn);
            this.Controls.Add(this.retroTypeAddBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.retroTypeCodeTB);
            this.Controls.Add(this.errorDynLabel);
            this.Controls.Add(this.reassignBtn);
            this.Controls.Add(this.errorAssignLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.reassignTypeCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.retroTypeSaveBtn);
            this.Controls.Add(this.retroTypeNameLL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.retroTypesAssignLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retroTypeNameTB);
            this.Controls.Add(this.retroTypeLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RetroTypeManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Retrospective Type Manager";
            this.Load += new System.EventHandler(this.RetroTypeManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox retroTypeLB;
        private System.Windows.Forms.TextBox retroTypeNameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox retroTypesAssignLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button retroTypeSaveBtn;
        private System.Windows.Forms.LinkLabel retroTypeNameLL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox reassignTypeCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label errorAssignLabel;
        private System.Windows.Forms.Button reassignBtn;
        private System.Windows.Forms.Label errorDynLabel;
        private System.Windows.Forms.TextBox retroTypeCodeTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button retroTypeAddBtn;
        private System.Windows.Forms.Button retroTypeRemBtn;
    }
}