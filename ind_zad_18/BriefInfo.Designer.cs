namespace ind_zad_18
{
    partial class BriefInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BriefInfo));
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelWorkshop = new System.Windows.Forms.Label();
            this.labelWorkshopCost = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(581, 79);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(77, 31);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Close";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelWorkshop
            // 
            this.labelWorkshop.AutoSize = true;
            this.labelWorkshop.BackColor = System.Drawing.Color.Transparent;
            this.labelWorkshop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWorkshop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelWorkshop.Location = new System.Drawing.Point(318, -1);
            this.labelWorkshop.Name = "labelWorkshop";
            this.labelWorkshop.Size = new System.Drawing.Size(122, 29);
            this.labelWorkshop.TabIndex = 2;
            this.labelWorkshop.Text = "Workshop";
            // 
            // labelWorkshopCost
            // 
            this.labelWorkshopCost.AutoSize = true;
            this.labelWorkshopCost.BackColor = System.Drawing.Color.Transparent;
            this.labelWorkshopCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWorkshopCost.ForeColor = System.Drawing.Color.White;
            this.labelWorkshopCost.Location = new System.Drawing.Point(153, 24);
            this.labelWorkshopCost.Name = "labelWorkshopCost";
            this.labelWorkshopCost.Size = new System.Drawing.Size(146, 20);
            this.labelWorkshopCost.TabIndex = 3;
            this.labelWorkshopCost.Text = "Общая стоимость";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // BriefInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(670, 122);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelWorkshopCost);
            this.Controls.Add(this.labelWorkshop);
            this.Controls.Add(this.buttonExit);
            this.MaximumSize = new System.Drawing.Size(686, 160);
            this.MinimumSize = new System.Drawing.Size(686, 160);
            this.Name = "BriefInfo";
            this.Text = "BriefInfo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        public System.Windows.Forms.Label labelWorkshop;
        public System.Windows.Forms.Label labelWorkshopCost;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}