
namespace MiniKindleForm
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
            this.uxHeaderTextBox = new System.Windows.Forms.TextBox();
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
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(12, 121);
            this.uxTextBox.Multiline = true;
            this.uxTextBox.Name = "uxTextBox";
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
            // uxHeaderTextBox
            // 
            this.uxHeaderTextBox.Location = new System.Drawing.Point(12, 29);
            this.uxHeaderTextBox.Multiline = true;
            this.uxHeaderTextBox.Name = "uxHeaderTextBox";
            this.uxHeaderTextBox.Size = new System.Drawing.Size(601, 57);
            this.uxHeaderTextBox.TabIndex = 5;
            // 
            // BookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 705);
            this.Controls.Add(this.uxHeaderTextBox);
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
        private System.Windows.Forms.TextBox uxHeaderTextBox;
    }
}

