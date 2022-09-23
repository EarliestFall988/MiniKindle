
namespace Project_To_Turn_In
{
    partial class LibraryView
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
            this.uxListBox = new System.Windows.Forms.ListBox();
            this.uxOpenBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxListBox
            // 
            this.uxListBox.FormattingEnabled = true;
            this.uxListBox.ItemHeight = 20;
            this.uxListBox.Location = new System.Drawing.Point(0, 0);
            this.uxListBox.Name = "uxListBox";
            this.uxListBox.Size = new System.Drawing.Size(622, 504);
            this.uxListBox.TabIndex = 0;
            // 
            // uxOpenBtn
            // 
            this.uxOpenBtn.Location = new System.Drawing.Point(213, 546);
            this.uxOpenBtn.Name = "uxOpenBtn";
            this.uxOpenBtn.Size = new System.Drawing.Size(170, 88);
            this.uxOpenBtn.TabIndex = 1;
            this.uxOpenBtn.Text = "Open";
            this.uxOpenBtn.UseVisualStyleBackColor = true;
            this.uxOpenBtn.Click += new System.EventHandler(this.uxOpenBtn_Click);
            // 
            // LibraryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 677);
            this.Controls.Add(this.uxOpenBtn);
            this.Controls.Add(this.uxListBox);
            this.Name = "LibraryView";
            this.Text = "LibraryView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox uxListBox;
        private System.Windows.Forms.Button uxOpenBtn;
    }
}