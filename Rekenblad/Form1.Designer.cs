using Spire.Pdf;

namespace Rekenblad
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnPiramide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Maak tafelblad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPiramide
            // 
            this.btnPiramide.Location = new System.Drawing.Point(84, 122);
            this.btnPiramide.Name = "btnPiramide";
            this.btnPiramide.Size = new System.Drawing.Size(101, 71);
            this.btnPiramide.TabIndex = 1;
            this.btnPiramide.Text = "Maak Piramide";
            this.btnPiramide.UseVisualStyleBackColor = true;
            this.btnPiramide.Click += new System.EventHandler(this.btnPiramide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnPiramide);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPiramide;

        
    }
}

