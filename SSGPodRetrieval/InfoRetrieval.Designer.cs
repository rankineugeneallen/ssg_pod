namespace SSGPodRetrieval
{
    partial class InfoRetrieval
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoRetrieval));
            this.retroItemListBox = new System.Windows.Forms.ListBox();
            this.retroComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.retroPodGrpBox = new System.Windows.Forms.GroupBox();
            this.podTypeCB = new System.Windows.Forms.ComboBox();
            this.podEditDoneBtn = new System.Windows.Forms.Button();
            this.podInfoEditBtn = new System.Windows.Forms.Button();
            this.podDateRelTB = new System.Windows.Forms.TextBox();
            this.podDateRecTB = new System.Windows.Forms.TextBox();
            this.podHostsTB = new System.Windows.Forms.TextBox();
            this.podEditorTB = new System.Windows.Forms.TextBox();
            this.podRuntimeTB = new System.Windows.Forms.TextBox();
            this.podTypeTB = new System.Windows.Forms.TextBox();
            this.podProdCodeTB = new System.Windows.Forms.TextBox();
            this.podShortNameTB = new System.Windows.Forms.TextBox();
            this.podURLLLabel = new System.Windows.Forms.LinkLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.retroTypeCB = new System.Windows.Forms.ComboBox();
            this.retroEditDoneBtn = new System.Windows.Forms.Button();
            this.retroCodeTB = new System.Windows.Forms.TextBox();
            this.retroIdTB = new System.Windows.Forms.TextBox();
            this.retroTitleTB = new System.Windows.Forms.TextBox();
            this.retroInfoEditBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.filterSortCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.filterMainLineTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.filterSuppTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.sortAlphaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.sortRelDateTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.sortRecDateTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.sortFilmRelTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.sortRuntimeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.filterSortBtnTT = new System.Windows.Forms.ToolTip(this.components);
            this.filterSortChkBx = new System.Windows.Forms.CheckBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRetrospectiveEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retroPodGrpBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.filterSortCMS.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // retroItemListBox
            // 
            this.retroItemListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroItemListBox.FormattingEnabled = true;
            this.retroItemListBox.ItemHeight = 20;
            this.retroItemListBox.Location = new System.Drawing.Point(15, 75);
            this.retroItemListBox.Name = "retroItemListBox";
            this.retroItemListBox.Size = new System.Drawing.Size(380, 244);
            this.retroItemListBox.TabIndex = 4;
            this.retroItemListBox.SelectedIndexChanged += new System.EventHandler(this.retroItemListBox_SelectedIndexChanged);
            // 
            // retroComboBox
            // 
            this.retroComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroComboBox.FormattingEnabled = true;
            this.retroComboBox.Location = new System.Drawing.Point(15, 41);
            this.retroComboBox.Name = "retroComboBox";
            this.retroComboBox.Size = new System.Drawing.Size(282, 28);
            this.retroComboBox.Sorted = true;
            this.retroComboBox.TabIndex = 5;
            this.retroComboBox.SelectedIndexChanged += new System.EventHandler(this.retroComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Retrospective";
            // 
            // retroPodGrpBox
            // 
            this.retroPodGrpBox.Controls.Add(this.podTypeCB);
            this.retroPodGrpBox.Controls.Add(this.podEditDoneBtn);
            this.retroPodGrpBox.Controls.Add(this.podInfoEditBtn);
            this.retroPodGrpBox.Controls.Add(this.podDateRelTB);
            this.retroPodGrpBox.Controls.Add(this.podDateRecTB);
            this.retroPodGrpBox.Controls.Add(this.podHostsTB);
            this.retroPodGrpBox.Controls.Add(this.podEditorTB);
            this.retroPodGrpBox.Controls.Add(this.podRuntimeTB);
            this.retroPodGrpBox.Controls.Add(this.podTypeTB);
            this.retroPodGrpBox.Controls.Add(this.podProdCodeTB);
            this.retroPodGrpBox.Controls.Add(this.podShortNameTB);
            this.retroPodGrpBox.Controls.Add(this.podURLLLabel);
            this.retroPodGrpBox.Controls.Add(this.label16);
            this.retroPodGrpBox.Controls.Add(this.label15);
            this.retroPodGrpBox.Controls.Add(this.label14);
            this.retroPodGrpBox.Controls.Add(this.label13);
            this.retroPodGrpBox.Controls.Add(this.label12);
            this.retroPodGrpBox.Controls.Add(this.label11);
            this.retroPodGrpBox.Controls.Add(this.label10);
            this.retroPodGrpBox.Controls.Add(this.label8);
            this.retroPodGrpBox.Controls.Add(this.label4);
            this.retroPodGrpBox.Location = new System.Drawing.Point(12, 325);
            this.retroPodGrpBox.Name = "retroPodGrpBox";
            this.retroPodGrpBox.Size = new System.Drawing.Size(653, 276);
            this.retroPodGrpBox.TabIndex = 7;
            this.retroPodGrpBox.TabStop = false;
            this.retroPodGrpBox.Text = "Podcast Info";
            this.retroPodGrpBox.Enter += new System.EventHandler(this.retroPodGrpBox_Enter);
            // 
            // podTypeCB
            // 
            this.podTypeCB.Enabled = false;
            this.podTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podTypeCB.FormattingEnabled = true;
            this.podTypeCB.Location = new System.Drawing.Point(10, 92);
            this.podTypeCB.Name = "podTypeCB";
            this.podTypeCB.Size = new System.Drawing.Size(187, 28);
            this.podTypeCB.TabIndex = 28;
            // 
            // podEditDoneBtn
            // 
            this.podEditDoneBtn.Enabled = false;
            this.podEditDoneBtn.Location = new System.Drawing.Point(487, 247);
            this.podEditDoneBtn.Name = "podEditDoneBtn";
            this.podEditDoneBtn.Size = new System.Drawing.Size(75, 23);
            this.podEditDoneBtn.TabIndex = 27;
            this.podEditDoneBtn.Text = "Done";
            this.podEditDoneBtn.UseVisualStyleBackColor = true;
            this.podEditDoneBtn.Click += new System.EventHandler(this.podEditDoneBtn_Click);
            // 
            // podInfoEditBtn
            // 
            this.podInfoEditBtn.Enabled = false;
            this.podInfoEditBtn.Location = new System.Drawing.Point(568, 247);
            this.podInfoEditBtn.Name = "podInfoEditBtn";
            this.podInfoEditBtn.Size = new System.Drawing.Size(75, 23);
            this.podInfoEditBtn.TabIndex = 26;
            this.podInfoEditBtn.Text = "Edit";
            this.podInfoEditBtn.UseVisualStyleBackColor = true;
            this.podInfoEditBtn.Click += new System.EventHandler(this.podEditBtn_Click);
            // 
            // podDateRelTB
            // 
            this.podDateRelTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podDateRelTB.Location = new System.Drawing.Point(203, 156);
            this.podDateRelTB.Name = "podDateRelTB";
            this.podDateRelTB.ReadOnly = true;
            this.podDateRelTB.Size = new System.Drawing.Size(133, 26);
            this.podDateRelTB.TabIndex = 25;
            // 
            // podDateRecTB
            // 
            this.podDateRecTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podDateRecTB.Location = new System.Drawing.Point(10, 156);
            this.podDateRecTB.Name = "podDateRecTB";
            this.podDateRecTB.ReadOnly = true;
            this.podDateRecTB.Size = new System.Drawing.Size(141, 26);
            this.podDateRecTB.TabIndex = 24;
            // 
            // podHostsTB
            // 
            this.podHostsTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podHostsTB.Location = new System.Drawing.Point(443, 92);
            this.podHostsTB.Name = "podHostsTB";
            this.podHostsTB.ReadOnly = true;
            this.podHostsTB.Size = new System.Drawing.Size(200, 26);
            this.podHostsTB.TabIndex = 23;
            // 
            // podEditorTB
            // 
            this.podEditorTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podEditorTB.Location = new System.Drawing.Point(342, 92);
            this.podEditorTB.Name = "podEditorTB";
            this.podEditorTB.ReadOnly = true;
            this.podEditorTB.Size = new System.Drawing.Size(95, 26);
            this.podEditorTB.TabIndex = 22;
            // 
            // podRuntimeTB
            // 
            this.podRuntimeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podRuntimeTB.Location = new System.Drawing.Point(203, 92);
            this.podRuntimeTB.Name = "podRuntimeTB";
            this.podRuntimeTB.ReadOnly = true;
            this.podRuntimeTB.Size = new System.Drawing.Size(133, 26);
            this.podRuntimeTB.TabIndex = 21;
            // 
            // podTypeTB
            // 
            this.podTypeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podTypeTB.Location = new System.Drawing.Point(10, 92);
            this.podTypeTB.Name = "podTypeTB";
            this.podTypeTB.ReadOnly = true;
            this.podTypeTB.Size = new System.Drawing.Size(187, 26);
            this.podTypeTB.TabIndex = 20;
            // 
            // podProdCodeTB
            // 
            this.podProdCodeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podProdCodeTB.Location = new System.Drawing.Point(464, 34);
            this.podProdCodeTB.Name = "podProdCodeTB";
            this.podProdCodeTB.ReadOnly = true;
            this.podProdCodeTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.podProdCodeTB.Size = new System.Drawing.Size(179, 26);
            this.podProdCodeTB.TabIndex = 19;
            this.podProdCodeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // podShortNameTB
            // 
            this.podShortNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podShortNameTB.Location = new System.Drawing.Point(10, 34);
            this.podShortNameTB.Name = "podShortNameTB";
            this.podShortNameTB.ReadOnly = true;
            this.podShortNameTB.Size = new System.Drawing.Size(445, 26);
            this.podShortNameTB.TabIndex = 18;
            // 
            // podURLLLabel
            // 
            this.podURLLLabel.AutoEllipsis = true;
            this.podURLLLabel.AutoSize = true;
            this.podURLLLabel.Location = new System.Drawing.Point(7, 218);
            this.podURLLLabel.Name = "podURLLLabel";
            this.podURLLLabel.Size = new System.Drawing.Size(0, 13);
            this.podURLLLabel.TabIndex = 17;
            this.podURLLLabel.Click += new System.EventHandler(this.podURLLLabel_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Podbean URL";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(440, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Hosts";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(339, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Editor";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(200, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Date Released";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Date Recorded";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(200, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Runtime (h:mm:ss)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Short Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Prod Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.retroTypeCB);
            this.groupBox1.Controls.Add(this.retroEditDoneBtn);
            this.groupBox1.Controls.Add(this.retroCodeTB);
            this.groupBox1.Controls.Add(this.retroIdTB);
            this.groupBox1.Controls.Add(this.retroTitleTB);
            this.groupBox1.Controls.Add(this.retroInfoEditBtn);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(401, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retrospective Info";
            // 
            // retroTypeCB
            // 
            this.retroTypeCB.Enabled = false;
            this.retroTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroTypeCB.FormattingEnabled = true;
            this.retroTypeCB.Location = new System.Drawing.Point(66, 80);
            this.retroTypeCB.Name = "retroTypeCB";
            this.retroTypeCB.Size = new System.Drawing.Size(128, 28);
            this.retroTypeCB.TabIndex = 14;
            // 
            // retroEditDoneBtn
            // 
            this.retroEditDoneBtn.Enabled = false;
            this.retroEditDoneBtn.Location = new System.Drawing.Point(144, 10);
            this.retroEditDoneBtn.Name = "retroEditDoneBtn";
            this.retroEditDoneBtn.Size = new System.Drawing.Size(55, 23);
            this.retroEditDoneBtn.TabIndex = 13;
            this.retroEditDoneBtn.Text = "Done";
            this.retroEditDoneBtn.UseVisualStyleBackColor = true;
            this.retroEditDoneBtn.Click += new System.EventHandler(this.retroEditDoneBtn_Click);
            // 
            // retroCodeTB
            // 
            this.retroCodeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroCodeTB.Location = new System.Drawing.Point(200, 81);
            this.retroCodeTB.Name = "retroCodeTB";
            this.retroCodeTB.ReadOnly = true;
            this.retroCodeTB.Size = new System.Drawing.Size(58, 26);
            this.retroCodeTB.TabIndex = 12;
            // 
            // retroIdTB
            // 
            this.retroIdTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroIdTB.Location = new System.Drawing.Point(6, 81);
            this.retroIdTB.Name = "retroIdTB";
            this.retroIdTB.ReadOnly = true;
            this.retroIdTB.Size = new System.Drawing.Size(51, 26);
            this.retroIdTB.TabIndex = 10;
            // 
            // retroTitleTB
            // 
            this.retroTitleTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroTitleTB.Location = new System.Drawing.Point(6, 36);
            this.retroTitleTB.Name = "retroTitleTB";
            this.retroTitleTB.ReadOnly = true;
            this.retroTitleTB.Size = new System.Drawing.Size(252, 26);
            this.retroTitleTB.TabIndex = 9;
            // 
            // retroInfoEditBtn
            // 
            this.retroInfoEditBtn.Location = new System.Drawing.Point(205, 10);
            this.retroInfoEditBtn.Name = "retroInfoEditBtn";
            this.retroInfoEditBtn.Size = new System.Drawing.Size(50, 23);
            this.retroInfoEditBtn.TabIndex = 8;
            this.retroInfoEditBtn.Text = "Edit";
            this.retroInfoEditBtn.UseVisualStyleBackColor = true;
            this.retroInfoEditBtn.Click += new System.EventHandler(this.retroInfoEditBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID";
            // 
            // filterSortCMS
            // 
            this.filterSortCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.filterMainLineTSMI,
            this.filterSuppTSMI,
            this.toolStripSeparator1,
            this.toolStripTextBox2,
            this.sortAlphaTSMI,
            this.sortRelDateTSMI,
            this.sortRecDateTSMI,
            this.sortFilmRelTSMI,
            this.sortRuntimeTSMI});
            this.filterSortCMS.Name = "filterSortCMS";
            this.filterSortCMS.Size = new System.Drawing.Size(165, 214);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Filtering";
            // 
            // filterMainLineTSMI
            // 
            this.filterMainLineTSMI.CheckOnClick = true;
            this.filterMainLineTSMI.Name = "filterMainLineTSMI";
            this.filterMainLineTSMI.Size = new System.Drawing.Size(164, 22);
            this.filterMainLineTSMI.Text = "Main Line Only";
            this.filterMainLineTSMI.CheckedChanged += new System.EventHandler(this.filterMainLineTSMI_CheckedChanged);
            // 
            // filterSuppTSMI
            // 
            this.filterSuppTSMI.CheckOnClick = true;
            this.filterSuppTSMI.Name = "filterSuppTSMI";
            this.filterSuppTSMI.Size = new System.Drawing.Size(164, 22);
            this.filterSuppTSMI.Text = "Supporting Only";
            this.filterSuppTSMI.CheckStateChanged += new System.EventHandler(this.filterSuppTSMI_CheckStateChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Enabled = false;
            this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Text = "Sorting";
            // 
            // sortAlphaTSMI
            // 
            this.sortAlphaTSMI.CheckOnClick = true;
            this.sortAlphaTSMI.Name = "sortAlphaTSMI";
            this.sortAlphaTSMI.Size = new System.Drawing.Size(164, 22);
            this.sortAlphaTSMI.Text = "Alphabetical";
            this.sortAlphaTSMI.CheckStateChanged += new System.EventHandler(this.sortAlphaTSMI_CheckStateChanged);
            // 
            // sortRelDateTSMI
            // 
            this.sortRelDateTSMI.CheckOnClick = true;
            this.sortRelDateTSMI.Name = "sortRelDateTSMI";
            this.sortRelDateTSMI.Size = new System.Drawing.Size(164, 22);
            this.sortRelDateTSMI.Text = "Release Date";
            this.sortRelDateTSMI.CheckStateChanged += new System.EventHandler(this.sortRelDateTSMI_CheckStateChanged);
            // 
            // sortRecDateTSMI
            // 
            this.sortRecDateTSMI.CheckOnClick = true;
            this.sortRecDateTSMI.Name = "sortRecDateTSMI";
            this.sortRecDateTSMI.Size = new System.Drawing.Size(164, 22);
            this.sortRecDateTSMI.Text = "Record Date";
            this.sortRecDateTSMI.CheckStateChanged += new System.EventHandler(this.sortRecDateTSMI_CheckStateChanged);
            // 
            // sortFilmRelTSMI
            // 
            this.sortFilmRelTSMI.CheckOnClick = true;
            this.sortFilmRelTSMI.Name = "sortFilmRelTSMI";
            this.sortFilmRelTSMI.Size = new System.Drawing.Size(164, 22);
            this.sortFilmRelTSMI.Text = "Film Release Year";
            this.sortFilmRelTSMI.CheckStateChanged += new System.EventHandler(this.sortFilmRelTSMI_CheckStateChanged);
            // 
            // sortRuntimeTSMI
            // 
            this.sortRuntimeTSMI.CheckOnClick = true;
            this.sortRuntimeTSMI.Name = "sortRuntimeTSMI";
            this.sortRuntimeTSMI.Size = new System.Drawing.Size(164, 22);
            this.sortRuntimeTSMI.Text = "Podcast Runtime";
            this.sortRuntimeTSMI.CheckStateChanged += new System.EventHandler(this.sortRuntimeTSMI_CheckStateChanged);
            // 
            // filterSortChkBx
            // 
            this.filterSortChkBx.Appearance = System.Windows.Forms.Appearance.Button;
            this.filterSortChkBx.ContextMenuStrip = this.filterSortCMS;
            this.filterSortChkBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterSortChkBx.Location = new System.Drawing.Point(303, 41);
            this.filterSortChkBx.Name = "filterSortChkBx";
            this.filterSortChkBx.Size = new System.Drawing.Size(92, 28);
            this.filterSortChkBx.TabIndex = 10;
            this.filterSortChkBx.Text = "Filter/Sort - OFF";
            this.filterSortBtnTT.SetToolTip(this.filterSortChkBx, "Right-click for Filter/Sort options");
            this.filterSortChkBx.UseVisualStyleBackColor = true;
            this.filterSortChkBx.CheckedChanged += new System.EventHandler(this.filterSortChkBx_CheckedChanged);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(686, 24);
            this.mainMenuStrip.TabIndex = 11;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRetrospectiveEditorToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openRetrospectiveEditorToolStripMenuItem
            // 
            this.openRetrospectiveEditorToolStripMenuItem.Name = "openRetrospectiveEditorToolStripMenuItem";
            this.openRetrospectiveEditorToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.openRetrospectiveEditorToolStripMenuItem.Text = "Open Retrospective Editor";
            this.openRetrospectiveEditorToolStripMenuItem.Click += new System.EventHandler(this.openRetrospectiveEditorToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // InfoRetrieval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 613);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.filterSortChkBx);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.retroPodGrpBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.retroComboBox);
            this.Controls.Add(this.retroItemListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "InfoRetrieval";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SSG Podcast Retrival";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoRetrieval_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.retroPodGrpBox.ResumeLayout(false);
            this.retroPodGrpBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.filterSortCMS.ResumeLayout(false);
            this.filterSortCMS.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox retroItemListBox;
        private System.Windows.Forms.ComboBox retroComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox retroPodGrpBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel podURLLLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolTip filterSortBtnTT;
        private System.Windows.Forms.ContextMenuStrip filterSortCMS;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem filterMainLineTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem sortAlphaTSMI;
        private System.Windows.Forms.ToolStripMenuItem filterSuppTSMI;
        private System.Windows.Forms.ToolStripMenuItem sortRelDateTSMI;
        private System.Windows.Forms.ToolStripMenuItem sortRecDateTSMI;
        private System.Windows.Forms.ToolStripMenuItem sortFilmRelTSMI;
        private System.Windows.Forms.ToolStripMenuItem sortRuntimeTSMI;
        private System.Windows.Forms.CheckBox filterSortChkBx;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRetrospectiveEditorToolStripMenuItem;
        private System.Windows.Forms.Button retroInfoEditBtn;
        private System.Windows.Forms.TextBox retroTitleTB;
        private System.Windows.Forms.TextBox retroIdTB;
        private System.Windows.Forms.TextBox retroCodeTB;
        private System.Windows.Forms.Button retroEditDoneBtn;
        private System.Windows.Forms.TextBox podShortNameTB;
        private System.Windows.Forms.TextBox podProdCodeTB;
        private System.Windows.Forms.TextBox podTypeTB;
        private System.Windows.Forms.TextBox podRuntimeTB;
        private System.Windows.Forms.TextBox podEditorTB;
        private System.Windows.Forms.TextBox podHostsTB;
        private System.Windows.Forms.TextBox podDateRelTB;
        private System.Windows.Forms.TextBox podDateRecTB;
        private System.Windows.Forms.Button podEditDoneBtn;
        private System.Windows.Forms.Button podInfoEditBtn;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ComboBox retroTypeCB;
        private System.Windows.Forms.ComboBox podTypeCB;
    }
}

