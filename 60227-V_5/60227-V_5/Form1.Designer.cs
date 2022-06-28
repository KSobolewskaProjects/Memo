
namespace Memo
{
    partial class form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.przyciskStart = new System.Windows.Forms.Button();
            this.licznikCzasu = new System.Windows.Forms.Label();
            this.przyciskStop = new System.Windows.Forms.Button();
            this.przyciskReset = new System.Windows.Forms.Button();
            this.przyciskExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // przyciskStart
            // 
            this.przyciskStart.Location = new System.Drawing.Point(575, 150);
            this.przyciskStart.Name = "przyciskStart";
            this.przyciskStart.Size = new System.Drawing.Size(75, 23);
            this.przyciskStart.TabIndex = 0;
            this.przyciskStart.Text = "Start";
            this.przyciskStart.UseVisualStyleBackColor = true;
            this.przyciskStart.Click += new System.EventHandler(this.przyciskStartKlik);
            // 
            // licznikCzasu
            // 
            this.licznikCzasu.AutoSize = true;
            this.licznikCzasu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.licznikCzasu.Location = new System.Drawing.Point(588, 275);
            this.licznikCzasu.Name = "licznikCzasu";
            this.licznikCzasu.Size = new System.Drawing.Size(49, 18);
            this.licznikCzasu.TabIndex = 1;
            this.licznikCzasu.Text = "00:60";
            // 
            // przyciskStop
            // 
            this.przyciskStop.Location = new System.Drawing.Point(575, 215);
            this.przyciskStop.Name = "przyciskStop";
            this.przyciskStop.Size = new System.Drawing.Size(75, 23);
            this.przyciskStop.TabIndex = 18;
            this.przyciskStop.Text = "Stop";
            this.przyciskStop.UseVisualStyleBackColor = true;
            this.przyciskStop.Visible = false;
            this.przyciskStop.Click += new System.EventHandler(this.przyciskStopKlik);
            // 
            // przyciskReset
            // 
            this.przyciskReset.Location = new System.Drawing.Point(575, 335);
            this.przyciskReset.Name = "przyciskReset";
            this.przyciskReset.Size = new System.Drawing.Size(75, 23);
            this.przyciskReset.TabIndex = 19;
            this.przyciskReset.Text = "Reset";
            this.przyciskReset.UseVisualStyleBackColor = true;
            this.przyciskReset.Visible = false;
            this.przyciskReset.Click += new System.EventHandler(this.przyciskResetKlik);
            // 
            // przyciskExit
            // 
            this.przyciskExit.Location = new System.Drawing.Point(575, 400);
            this.przyciskExit.Name = "przyciskExit";
            this.przyciskExit.Size = new System.Drawing.Size(75, 23);
            this.przyciskExit.TabIndex = 20;
            this.przyciskExit.Text = "Exit";
            this.przyciskExit.UseVisualStyleBackColor = true;
            this.przyciskExit.Click += new System.EventHandler(this.przyciskExitKlik);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 572);
            this.Controls.Add(this.przyciskExit);
            this.Controls.Add(this.przyciskReset);
            this.Controls.Add(this.przyciskStop);
            this.Controls.Add(this.licznikCzasu);
            this.Controls.Add(this.przyciskStart);
            this.Name = "form1";
            this.Text = "Memo by Karolina Sobolewska";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button przyciskStart;
        private System.Windows.Forms.Label licznikCzasu;
        private System.Windows.Forms.Button przyciskStop;
        private System.Windows.Forms.Button przyciskReset;
        private System.Windows.Forms.Button przyciskExit;
    }
}

