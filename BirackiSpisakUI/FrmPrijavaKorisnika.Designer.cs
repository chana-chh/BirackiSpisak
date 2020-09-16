namespace BirackiSpisakUI
{
    partial class FrmPrijavaKorisnika
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrijavaKorisnika));
            this.lblPrijavaKorisnika = new System.Windows.Forms.Label();
            this.lblKorisnickoIme = new System.Windows.Forms.Label();
            this.lblLozinka = new System.Windows.Forms.Label();
            this.btnPrijava = new System.Windows.Forms.Button();
            this.btnKrajRada = new System.Windows.Forms.Button();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPrijavaKorisnika
            // 
            this.lblPrijavaKorisnika.AutoSize = true;
            this.lblPrijavaKorisnika.Location = new System.Drawing.Point(274, 36);
            this.lblPrijavaKorisnika.Name = "lblPrijavaKorisnika";
            this.lblPrijavaKorisnika.Size = new System.Drawing.Size(113, 15);
            this.lblPrijavaKorisnika.TabIndex = 0;
            this.lblPrijavaKorisnika.Text = "Пријава корисника";
            // 
            // lblKorisnickoIme
            // 
            this.lblKorisnickoIme.AutoSize = true;
            this.lblKorisnickoIme.Location = new System.Drawing.Point(274, 93);
            this.lblKorisnickoIme.Name = "lblKorisnickoIme";
            this.lblKorisnickoIme.Size = new System.Drawing.Size(100, 15);
            this.lblKorisnickoIme.TabIndex = 0;
            this.lblKorisnickoIme.Text = "Корисничко име";
            // 
            // lblLozinka
            // 
            this.lblLozinka.AutoSize = true;
            this.lblLozinka.Location = new System.Drawing.Point(274, 160);
            this.lblLozinka.Name = "lblLozinka";
            this.lblLozinka.Size = new System.Drawing.Size(53, 15);
            this.lblLozinka.TabIndex = 0;
            this.lblLozinka.Text = "Лозинка";
            // 
            // btnPrijava
            // 
            this.btnPrijava.Location = new System.Drawing.Point(546, 186);
            this.btnPrijava.Name = "btnPrijava";
            this.btnPrijava.Size = new System.Drawing.Size(163, 40);
            this.btnPrijava.TabIndex = 1;
            this.btnPrijava.Text = "Пријави се";
            this.btnPrijava.UseVisualStyleBackColor = true;
            this.btnPrijava.Click += new System.EventHandler(this.btnPrijava_Click);
            // 
            // btnKrajRada
            // 
            this.btnKrajRada.Location = new System.Drawing.Point(546, 232);
            this.btnKrajRada.Name = "btnKrajRada";
            this.btnKrajRada.Size = new System.Drawing.Size(163, 40);
            this.btnKrajRada.TabIndex = 1;
            this.btnKrajRada.Text = "Крај рада";
            this.btnKrajRada.UseVisualStyleBackColor = true;
            this.btnKrajRada.Click += new System.EventHandler(this.btnKrajRada_Click);
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(380, 90);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(329, 23);
            this.txtKorisnickoIme.TabIndex = 2;
            // 
            // txtLozinka
            // 
            this.txtLozinka.Location = new System.Drawing.Point(380, 157);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.Size = new System.Drawing.Size(329, 23);
            this.txtLozinka.TabIndex = 2;
            // 
            // FrmPrijavaKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 295);
            this.Controls.Add(this.txtLozinka);
            this.Controls.Add(this.txtKorisnickoIme);
            this.Controls.Add(this.btnKrajRada);
            this.Controls.Add(this.btnPrijava);
            this.Controls.Add(this.lblLozinka);
            this.Controls.Add(this.lblKorisnickoIme);
            this.Controls.Add(this.lblPrijavaKorisnika);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrijavaKorisnika";
            this.Text = "Пријављивање корисника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrijavaKorisnika;
        private System.Windows.Forms.Label lblKorisnickoIme;
        private System.Windows.Forms.Label lblLozinka;
        private System.Windows.Forms.Button btnPrijava;
        private System.Windows.Forms.Button btnKrajRada;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.TextBox txtLozinka;
    }
}

