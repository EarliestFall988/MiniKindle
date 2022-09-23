
namespace Project_To_Turn_In
{
    partial class BookView
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
            this.uxNextBtn = new System.Windows.Forms.Button();
            this.uxPreviousBtn = new System.Windows.Forms.Button();
            this.uxPgNum = new System.Windows.Forms.NumericUpDown();
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.uxBookMark = new System.Windows.Forms.Button();
            this.uxTitleTextBox = new System.Windows.Forms.TextBox();
            this.uxBookMarked = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uxPgNum)).BeginInit();
            this.SuspendLayout();
            // 
            // uxNextBtn
            // 
            this.uxNextBtn.Location = new System.Drawing.Point(442, 607);
            this.uxNextBtn.Name = "uxNextBtn";
            this.uxNextBtn.Size = new System.Drawing.Size(171, 86);
            this.uxNextBtn.TabIndex = 0;
            this.uxNextBtn.Text = "Next";
            this.uxNextBtn.UseVisualStyleBackColor = true;
            this.uxNextBtn.Click += new System.EventHandler(this.uxNextBtn_Click);
            // 
            // uxPreviousBtn
            // 
            this.uxPreviousBtn.Enabled = false;
            this.uxPreviousBtn.Location = new System.Drawing.Point(12, 607);
            this.uxPreviousBtn.Name = "uxPreviousBtn";
            this.uxPreviousBtn.Size = new System.Drawing.Size(171, 86);
            this.uxPreviousBtn.TabIndex = 1;
            this.uxPreviousBtn.Text = "Previous";
            this.uxPreviousBtn.UseVisualStyleBackColor = true;
            this.uxPreviousBtn.Click += new System.EventHandler(this.uxPreviousBtn_Click);
            // 
            // uxPgNum
            // 
            this.uxPgNum.Location = new System.Drawing.Point(221, 638);
            this.uxPgNum.Name = "uxPgNum";
            this.uxPgNum.Size = new System.Drawing.Size(54, 26);
            this.uxPgNum.TabIndex = 2;
            this.uxPgNum.ValueChanged += new System.EventHandler(this.uxPgNum_ValueChanged);
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(12, 121);
            this.uxTextBox.Multiline = true;
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.ReadOnly = true;
            this.uxTextBox.Size = new System.Drawing.Size(601, 480);
            this.uxTextBox.TabIndex = 3;
            // 
            // uxBookMark
            // 
            this.uxBookMark.Location = new System.Drawing.Point(309, 630);
            this.uxBookMark.Name = "uxBookMark";
            this.uxBookMark.Size = new System.Drawing.Size(96, 63);
            this.uxBookMark.TabIndex = 4;
            this.uxBookMark.Text = "BookMark";
            this.uxBookMark.UseVisualStyleBackColor = true;
            this.uxBookMark.Click += new System.EventHandler(this.uxBookMark_Click);
            // 
            // uxTitleTextBox
            // 
            this.uxTitleTextBox.Location = new System.Drawing.Point(12, 29);
            this.uxTitleTextBox.Multiline = true;
            this.uxTitleTextBox.Name = "uxTitleTextBox";
            this.uxTitleTextBox.ReadOnly = true;
            this.uxTitleTextBox.Size = new System.Drawing.Size(601, 57);
            this.uxTitleTextBox.TabIndex = 5;
            this.uxTitleTextBox.TextChanged += new System.EventHandler(this.uxTitleTextBox_TextChanged);
            // 
            // uxBookMarked
            // 
            this.uxBookMarked.Location = new System.Drawing.Point(508, 92);
            this.uxBookMarked.Multiline = true;
            this.uxBookMarked.Name = "uxBookMarked";
            this.uxBookMarked.ReadOnly = true;
            this.uxBookMarked.Size = new System.Drawing.Size(105, 23);
            this.uxBookMarked.TabIndex = 6;
            this.uxBookMarked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 705);
            this.Controls.Add(this.uxBookMarked);
            this.Controls.Add(this.uxTitleTextBox);
            this.Controls.Add(this.uxBookMark);
            this.Controls.Add(this.uxTextBox);
            this.Controls.Add(this.uxPgNum);
            this.Controls.Add(this.uxPreviousBtn);
            this.Controls.Add(this.uxNextBtn);
            this.Name = "BookView";
            this.Text = "BookView";
            ((System.ComponentModel.ISupportInitialize)(this.uxPgNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxNextBtn;
        private System.Windows.Forms.Button uxPreviousBtn;
        private System.Windows.Forms.NumericUpDown uxPgNum;
        private System.Windows.Forms.TextBox uxTextBox;
        private System.Windows.Forms.Button uxBookMark;
        private System.Windows.Forms.TextBox uxTitleTextBox;
        private System.Windows.Forms.TextBox uxBookMarked;
    }
}

