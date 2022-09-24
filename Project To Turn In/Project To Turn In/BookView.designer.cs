
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
            this.uxNextBtn.Location = new System.Drawing.Point(589, 759);
            this.uxNextBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxNextBtn.Name = "uxNextBtn";
            this.uxNextBtn.Size = new System.Drawing.Size(228, 108);
            this.uxNextBtn.TabIndex = 0;
            this.uxNextBtn.Text = "Next";
            this.uxNextBtn.UseVisualStyleBackColor = true;
            this.uxNextBtn.Click += new System.EventHandler(this.uxNextBtn_Click);
            // 
            // uxPreviousBtn
            // 
            this.uxPreviousBtn.Enabled = false;
            this.uxPreviousBtn.Location = new System.Drawing.Point(16, 759);
            this.uxPreviousBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxPreviousBtn.Name = "uxPreviousBtn";
            this.uxPreviousBtn.Size = new System.Drawing.Size(228, 108);
            this.uxPreviousBtn.TabIndex = 1;
            this.uxPreviousBtn.Text = "Previous";
            this.uxPreviousBtn.UseVisualStyleBackColor = true;
            this.uxPreviousBtn.Click += new System.EventHandler(this.uxPreviousBtn_Click);
            // 
            // uxPgNum
            // 
            this.uxPgNum.Location = new System.Drawing.Point(295, 798);
            this.uxPgNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxPgNum.Name = "uxPgNum";
            this.uxPgNum.Size = new System.Drawing.Size(72, 31);
            this.uxPgNum.TabIndex = 2;
            this.uxPgNum.ValueChanged += new System.EventHandler(this.uxPgNum_ValueChanged);
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(16, 151);
            this.uxTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxTextBox.MaxLength = 5000;
            this.uxTextBox.Multiline = true;
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.ReadOnly = true;
            this.uxTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.uxTextBox.Size = new System.Drawing.Size(800, 599);
            this.uxTextBox.TabIndex = 3;
            // 
            // uxBookMark
            // 
            this.uxBookMark.Location = new System.Drawing.Point(412, 788);
            this.uxBookMark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxBookMark.Name = "uxBookMark";
            this.uxBookMark.Size = new System.Drawing.Size(128, 79);
            this.uxBookMark.TabIndex = 4;
            this.uxBookMark.Text = "BookMark";
            this.uxBookMark.UseVisualStyleBackColor = true;
            this.uxBookMark.Click += new System.EventHandler(this.uxBookMark_Click);
            // 
            // uxTitleTextBox
            // 
            this.uxTitleTextBox.Location = new System.Drawing.Point(16, 36);
            this.uxTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxTitleTextBox.Multiline = true;
            this.uxTitleTextBox.Name = "uxTitleTextBox";
            this.uxTitleTextBox.ReadOnly = true;
            this.uxTitleTextBox.Size = new System.Drawing.Size(800, 70);
            this.uxTitleTextBox.TabIndex = 5;
            this.uxTitleTextBox.TextChanged += new System.EventHandler(this.uxTitleTextBox_TextChanged);
            // 
            // uxBookMarked
            // 
            this.uxBookMarked.Location = new System.Drawing.Point(677, 115);
            this.uxBookMarked.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxBookMarked.Multiline = true;
            this.uxBookMarked.Name = "uxBookMarked";
            this.uxBookMarked.ReadOnly = true;
            this.uxBookMarked.Size = new System.Drawing.Size(139, 28);
            this.uxBookMarked.TabIndex = 6;
            this.uxBookMarked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 881);
            this.Controls.Add(this.uxBookMarked);
            this.Controls.Add(this.uxTitleTextBox);
            this.Controls.Add(this.uxBookMark);
            this.Controls.Add(this.uxTextBox);
            this.Controls.Add(this.uxPgNum);
            this.Controls.Add(this.uxPreviousBtn);
            this.Controls.Add(this.uxNextBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

