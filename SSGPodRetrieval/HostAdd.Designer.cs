namespace SSGPodRetrieval
{
    partial class HostAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hostFirstNameTB = new System.Windows.Forms.TextBox();
            this.hostLastNameTB = new System.Windows.Forms.TextBox();
            this.hostAddBtn = new System.Windows.Forms.Button();
            this.hostCancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // hostFirstNameTB
            // 
            this.hostFirstNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostFirstNameTB.Location = new System.Drawing.Point(13, 29);
            this.hostFirstNameTB.MaxLength = 100;
            this.hostFirstNameTB.Name = "hostFirstNameTB";
            this.hostFirstNameTB.Size = new System.Drawing.Size(147, 26);
            this.hostFirstNameTB.TabIndex = 2;
            // 
            // hostLastNameTB
            // 
            this.hostLastNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostLastNameTB.Location = new System.Drawing.Point(166, 29);
            this.hostLastNameTB.MaxLength = 100;
            this.hostLastNameTB.Name = "hostLastNameTB";
            this.hostLastNameTB.Size = new System.Drawing.Size(156, 26);
            this.hostLastNameTB.TabIndex = 3;
            // 
            // hostAddBtn
            // 
            this.hostAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostAddBtn.Location = new System.Drawing.Point(13, 61);
            this.hostAddBtn.Name = "hostAddBtn";
            this.hostAddBtn.Size = new System.Drawing.Size(98, 26);
            this.hostAddBtn.TabIndex = 4;
            this.hostAddBtn.Text = "Add Host";
            this.hostAddBtn.UseVisualStyleBackColor = true;
            this.hostAddBtn.Click += new System.EventHandler(this.hostAddBtn_Click);
            // 
            // hostCancelBtn
            // 
            this.hostCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostCancelBtn.Location = new System.Drawing.Point(246, 61);
            this.hostCancelBtn.Name = "hostCancelBtn";
            this.hostCancelBtn.Size = new System.Drawing.Size(76, 26);
            this.hostCancelBtn.TabIndex = 5;
            this.hostCancelBtn.Text = "Cancel";
            this.hostCancelBtn.UseVisualStyleBackColor = true;
            this.hostCancelBtn.Click += new System.EventHandler(this.hostCancelBtn_Click);
            // 
            // HostAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 99);
            this.Controls.Add(this.hostCancelBtn);
            this.Controls.Add(this.hostAddBtn);
            this.Controls.Add(this.hostLastNameTB);
            this.Controls.Add(this.hostFirstNameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HostAdd";
            this.Text = "Add Host";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hostFirstNameTB;
        private System.Windows.Forms.TextBox hostLastNameTB;
        private System.Windows.Forms.Button hostAddBtn;
        private System.Windows.Forms.Button hostCancelBtn;
    }
}