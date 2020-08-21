namespace SSGPodRetrieval
{
    partial class RetroCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetroCreator));
            this.retroListBox = new System.Windows.Forms.ListBox();
            this.addPodBtn = new System.Windows.Forms.Button();
            this.remPodBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.retroTitleTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.retroCodeTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.retroTypeCB = new System.Windows.Forms.ComboBox();
            this.editPodBtn = new System.Windows.Forms.Button();
            this.retroAddBtn = new System.Windows.Forms.Button();
            this.cancelRetroBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.codeDynLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateRecLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateRelLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // retroListBox
            // 
            this.retroListBox.FormattingEnabled = true;
            this.retroListBox.Location = new System.Drawing.Point(6, 19);
            this.retroListBox.Name = "retroListBox";
            this.retroListBox.Size = new System.Drawing.Size(149, 160);
            this.retroListBox.TabIndex = 0;
            this.retroListBox.SelectedIndexChanged += new System.EventHandler(this.retroListBox_SelectedIndexChanged);
            // 
            // addPodBtn
            // 
            this.addPodBtn.Location = new System.Drawing.Point(6, 181);
            this.addPodBtn.Name = "addPodBtn";
            this.addPodBtn.Size = new System.Drawing.Size(58, 23);
            this.addPodBtn.TabIndex = 2;
            this.addPodBtn.Text = "Add";
            this.addPodBtn.UseVisualStyleBackColor = true;
            this.addPodBtn.Click += new System.EventHandler(this.addRetroBtn_Click);
            // 
            // remPodBtn
            // 
            this.remPodBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.remPodBtn.Enabled = false;
            this.remPodBtn.Location = new System.Drawing.Point(130, 181);
            this.remPodBtn.Name = "remPodBtn";
            this.remPodBtn.Size = new System.Drawing.Size(25, 23);
            this.remPodBtn.TabIndex = 3;
            this.remPodBtn.Text = "-";
            this.remPodBtn.UseVisualStyleBackColor = false;
            this.remPodBtn.Click += new System.EventHandler(this.removeRetroBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Retrospective Title";
            // 
            // retroTitleTB
            // 
            this.retroTitleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroTitleTB.Location = new System.Drawing.Point(11, 28);
            this.retroTitleTB.MaxLength = 100;
            this.retroTitleTB.Name = "retroTitleTB";
            this.retroTitleTB.Size = new System.Drawing.Size(241, 26);
            this.retroTitleTB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Code";
            // 
            // retroCodeTB
            // 
            this.retroCodeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroCodeTB.Location = new System.Drawing.Point(258, 28);
            this.retroCodeTB.MaxLength = 3;
            this.retroCodeTB.Name = "retroCodeTB";
            this.retroCodeTB.Size = new System.Drawing.Size(41, 26);
            this.retroCodeTB.TabIndex = 7;
            this.retroCodeTB.TextChanged += new System.EventHandler(this.retroCodeTB_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Type";
            // 
            // retroTypeCB
            // 
            this.retroTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroTypeCB.FormattingEnabled = true;
            this.retroTypeCB.Location = new System.Drawing.Point(305, 28);
            this.retroTypeCB.Name = "retroTypeCB";
            this.retroTypeCB.Size = new System.Drawing.Size(151, 28);
            this.retroTypeCB.TabIndex = 10;
            // 
            // editPodBtn
            // 
            this.editPodBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.editPodBtn.Enabled = false;
            this.editPodBtn.Location = new System.Drawing.Point(70, 181);
            this.editPodBtn.Name = "editPodBtn";
            this.editPodBtn.Size = new System.Drawing.Size(54, 23);
            this.editPodBtn.TabIndex = 11;
            this.editPodBtn.Text = "Edit";
            this.editPodBtn.UseVisualStyleBackColor = false;
            this.editPodBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // retroAddBtn
            // 
            this.retroAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroAddBtn.Location = new System.Drawing.Point(236, 337);
            this.retroAddBtn.Name = "retroAddBtn";
            this.retroAddBtn.Size = new System.Drawing.Size(139, 27);
            this.retroAddBtn.TabIndex = 12;
            this.retroAddBtn.Text = "Add Retrospective";
            this.retroAddBtn.UseVisualStyleBackColor = true;
            this.retroAddBtn.Click += new System.EventHandler(this.retroAddBtn_Click);
            // 
            // cancelRetroBtn
            // 
            this.cancelRetroBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRetroBtn.Location = new System.Drawing.Point(381, 337);
            this.cancelRetroBtn.Name = "cancelRetroBtn";
            this.cancelRetroBtn.Size = new System.Drawing.Size(75, 27);
            this.cancelRetroBtn.TabIndex = 13;
            this.cancelRetroBtn.Text = "Cancel";
            this.cancelRetroBtn.UseVisualStyleBackColor = true;
            this.cancelRetroBtn.Click += new System.EventHandler(this.cancelRetroBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateRelLabel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateRecLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.retroListBox);
            this.groupBox1.Controls.Add(this.remPodBtn);
            this.groupBox1.Controls.Add(this.addPodBtn);
            this.groupBox1.Controls.Add(this.editPodBtn);
            this.groupBox1.Location = new System.Drawing.Point(11, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 210);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podcasts";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // codeDynLabel
            // 
            this.codeDynLabel.AutoSize = true;
            this.codeDynLabel.Location = new System.Drawing.Point(255, 57);
            this.codeDynLabel.Name = "codeDynLabel";
            this.codeDynLabel.Size = new System.Drawing.Size(0, 13);
            this.codeDynLabel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Date Recorded";
            // 
            // dateRecLabel
            // 
            this.dateRecLabel.AutoSize = true;
            this.dateRecLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRecLabel.Location = new System.Drawing.Point(161, 33);
            this.dateRecLabel.Name = "dateRecLabel";
            this.dateRecLabel.Size = new System.Drawing.Size(0, 20);
            this.dateRecLabel.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date Released";
            // 
            // dateRelLabel
            // 
            this.dateRelLabel.AutoSize = true;
            this.dateRelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRelLabel.Location = new System.Drawing.Point(315, 33);
            this.dateRelLabel.Name = "dateRelLabel";
            this.dateRelLabel.Size = new System.Drawing.Size(0, 20);
            this.dateRelLabel.TabIndex = 15;
            // 
            // RetroCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 376);
            this.Controls.Add(this.codeDynLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelRetroBtn);
            this.Controls.Add(this.retroAddBtn);
            this.Controls.Add(this.retroTypeCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.retroCodeTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.retroTitleTB);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RetroCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Retrospective Creator";
            this.Load += new System.EventHandler(this.RetroCreator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox retroListBox;
        private System.Windows.Forms.Button addPodBtn;
        private System.Windows.Forms.Button remPodBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox retroTitleTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox retroCodeTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox retroTypeCB;
        private System.Windows.Forms.Button editPodBtn;
        private System.Windows.Forms.Button retroAddBtn;
        private System.Windows.Forms.Button cancelRetroBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label codeDynLabel;
        private System.Windows.Forms.Label dateRecLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dateRelLabel;
        private System.Windows.Forms.Label label6;
    }
}