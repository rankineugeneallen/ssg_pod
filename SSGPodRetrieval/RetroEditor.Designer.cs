namespace SSGPodRetrieval
{
    partial class RetroEditor
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
            this.retroListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addRetroBtn = new System.Windows.Forms.Button();
            this.removeRetroBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // retroListBox
            // 
            this.retroListBox.FormattingEnabled = true;
            this.retroListBox.Location = new System.Drawing.Point(12, 52);
            this.retroListBox.Name = "retroListBox";
            this.retroListBox.Size = new System.Drawing.Size(179, 355);
            this.retroListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Retrospectives";
            // 
            // addRetroBtn
            // 
            this.addRetroBtn.Location = new System.Drawing.Point(12, 415);
            this.addRetroBtn.Name = "addRetroBtn";
            this.addRetroBtn.Size = new System.Drawing.Size(110, 23);
            this.addRetroBtn.TabIndex = 2;
            this.addRetroBtn.Text = "Add";
            this.addRetroBtn.UseVisualStyleBackColor = true;
            // 
            // removeRetroBtn
            // 
            this.removeRetroBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.removeRetroBtn.Location = new System.Drawing.Point(128, 415);
            this.removeRetroBtn.Name = "removeRetroBtn";
            this.removeRetroBtn.Size = new System.Drawing.Size(63, 23);
            this.removeRetroBtn.TabIndex = 3;
            this.removeRetroBtn.Text = "Remove";
            this.removeRetroBtn.UseVisualStyleBackColor = false;
            // 
            // RetroEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removeRetroBtn);
            this.Controls.Add(this.addRetroBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retroListBox);
            this.Name = "RetroEditor";
            this.Text = "RetroEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox retroListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addRetroBtn;
        private System.Windows.Forms.Button removeRetroBtn;
    }
}