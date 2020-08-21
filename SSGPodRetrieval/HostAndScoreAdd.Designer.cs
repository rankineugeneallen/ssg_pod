namespace SSGPodRetrieval
{
    partial class HostAndScoreAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostAndScoreAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hostLB = new System.Windows.Forms.ListBox();
            this.hostRateCB = new System.Windows.Forms.ComboBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.hostRecoCB = new System.Windows.Forms.ComboBox();
            this.reqSS = new System.Windows.Forms.StatusStrip();
            this.dynSSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.dynLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.reqSS.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Host *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Recommend";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rating";
            // 
            // hostLB
            // 
            this.hostLB.FormattingEnabled = true;
            this.hostLB.Location = new System.Drawing.Point(13, 26);
            this.hostLB.Name = "hostLB";
            this.hostLB.Size = new System.Drawing.Size(118, 147);
            this.hostLB.TabIndex = 6;
            // 
            // hostRateCB
            // 
            this.hostRateCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostRateCB.FormattingEnabled = true;
            this.hostRateCB.Items.AddRange(new object[] {
            "",
            "-",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.hostRateCB.Location = new System.Drawing.Point(137, 26);
            this.hostRateCB.Name = "hostRateCB";
            this.hostRateCB.Size = new System.Drawing.Size(42, 28);
            this.hostRateCB.TabIndex = 45;
            this.hostRateCB.SelectedIndexChanged += new System.EventHandler(this.hostRateCB_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(137, 150);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(62, 23);
            this.addBtn.TabIndex = 46;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(205, 150);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(71, 23);
            this.cancelBtn.TabIndex = 47;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // hostRecoCB
            // 
            this.hostRecoCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostRecoCB.FormattingEnabled = true;
            this.hostRecoCB.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.hostRecoCB.Location = new System.Drawing.Point(197, 26);
            this.hostRecoCB.Name = "hostRecoCB";
            this.hostRecoCB.Size = new System.Drawing.Size(62, 28);
            this.hostRecoCB.TabIndex = 48;
            this.hostRecoCB.SelectedIndexChanged += new System.EventHandler(this.hostRecoCB_SelectedIndexChanged);
            // 
            // reqSS
            // 
            this.reqSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dynSSLabel,
            this.dynLabel});
            this.reqSS.Location = new System.Drawing.Point(0, 182);
            this.reqSS.Name = "reqSS";
            this.reqSS.Size = new System.Drawing.Size(285, 22);
            this.reqSS.TabIndex = 49;
            this.reqSS.Text = "statusStrip1";
            // 
            // dynSSLabel
            // 
            this.dynSSLabel.Name = "dynSSLabel";
            this.dynSSLabel.Size = new System.Drawing.Size(133, 17);
            this.dynSSLabel.Text = "A host must be selected";
            this.dynSSLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 78);
            this.label2.TabIndex = 50;
            this.label2.Text = "Note: Rating and recommend \r\nnot required. But if a rating \r\nis assigned, so must" +
    " a \r\nrecommend. And if a \r\nrecommend is assigned, so \r\nmust a rating. ";
            // 
            // dynLabel
            // 
            this.dynLabel.Name = "dynLabel";
            this.dynLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // HostAndScoreAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 204);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reqSS);
            this.Controls.Add(this.hostRecoCB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.hostRateCB);
            this.Controls.Add(this.hostLB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HostAndScoreAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Host";
            this.Load += new System.EventHandler(this.HostAndScoreAdd_Load);
            this.reqSS.ResumeLayout(false);
            this.reqSS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox hostLB;
        private System.Windows.Forms.ComboBox hostRateCB;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox hostRecoCB;
        private System.Windows.Forms.StatusStrip reqSS;
        private System.Windows.Forms.ToolStripStatusLabel dynSSLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel dynLabel;
    }
}