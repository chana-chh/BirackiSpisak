namespace BirackiSpisakUI
{
    partial class FrmKontrolnaTabla
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
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.btnUvozPromena = new System.Windows.Forms.Button();
            this.btnPregledPromena = new System.Windows.Forms.Button();
            this.btnUnosPromena = new System.Windows.Forms.Button();
            this.btnMupPromene = new System.Windows.Forms.Button();
            this.btnMkuPromene = new System.Windows.Forms.Button();
            this.btnMkvPromene = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaShell;
            this.btnIzlaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzlaz.ForeColor = System.Drawing.Color.Red;
            this.btnIzlaz.Location = new System.Drawing.Point(12, 365);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(126, 30);
            this.btnIzlaz.TabIndex = 0;
            this.btnIzlaz.Text = "Крај рада";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNaslov.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNaslov.Location = new System.Drawing.Point(12, 9);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(131, 65);
            this.lblNaslov.TabIndex = 1;
            this.lblNaslov.Text = "БСКг";
            // 
            // btnUvozPromena
            // 
            this.btnUvozPromena.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnUvozPromena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUvozPromena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUvozPromena.Location = new System.Drawing.Point(12, 77);
            this.btnUvozPromena.Name = "btnUvozPromena";
            this.btnUvozPromena.Size = new System.Drawing.Size(126, 30);
            this.btnUvozPromena.TabIndex = 2;
            this.btnUvozPromena.Text = "Увоз промена";
            this.btnUvozPromena.UseVisualStyleBackColor = true;
            this.btnUvozPromena.Click += new System.EventHandler(this.btnUvozPromena_Click);
            // 
            // btnPregledPromena
            // 
            this.btnPregledPromena.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnPregledPromena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPregledPromena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPregledPromena.Location = new System.Drawing.Point(12, 113);
            this.btnPregledPromena.Name = "btnPregledPromena";
            this.btnPregledPromena.Size = new System.Drawing.Size(126, 30);
            this.btnPregledPromena.TabIndex = 2;
            this.btnPregledPromena.Text = "Преглед промена";
            this.btnPregledPromena.UseVisualStyleBackColor = true;
            this.btnPregledPromena.Click += new System.EventHandler(this.btnPregledPromena_Click);
            // 
            // btnUnosPromena
            // 
            this.btnUnosPromena.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnUnosPromena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnosPromena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUnosPromena.Location = new System.Drawing.Point(12, 149);
            this.btnUnosPromena.Name = "btnUnosPromena";
            this.btnUnosPromena.Size = new System.Drawing.Size(126, 30);
            this.btnUnosPromena.TabIndex = 2;
            this.btnUnosPromena.Text = "Унос промена";
            this.btnUnosPromena.UseVisualStyleBackColor = true;
            this.btnUnosPromena.Click += new System.EventHandler(this.btnUnosPromena_Click);
            // 
            // btnMupPromene
            // 
            this.btnMupPromene.BackColor = System.Drawing.Color.MintCream;
            this.btnMupPromene.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMupPromene.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnMupPromene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMupPromene.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMupPromene.Location = new System.Drawing.Point(12, 185);
            this.btnMupPromene.Name = "btnMupPromene";
            this.btnMupPromene.Size = new System.Drawing.Size(126, 30);
            this.btnMupPromene.TabIndex = 2;
            this.btnMupPromene.Text = "МУП промене";
            this.btnMupPromene.UseVisualStyleBackColor = false;
            this.btnMupPromene.Visible = false;
            this.btnMupPromene.Click += new System.EventHandler(this.btnMupPromene_Click);
            // 
            // btnMkuPromene
            // 
            this.btnMkuPromene.BackColor = System.Drawing.Color.MintCream;
            this.btnMkuPromene.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnMkuPromene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMkuPromene.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMkuPromene.Location = new System.Drawing.Point(12, 221);
            this.btnMkuPromene.Name = "btnMkuPromene";
            this.btnMkuPromene.Size = new System.Drawing.Size(126, 30);
            this.btnMkuPromene.TabIndex = 2;
            this.btnMkuPromene.Text = "МКУ промене";
            this.btnMkuPromene.UseVisualStyleBackColor = false;
            this.btnMkuPromene.Visible = false;
            // 
            // btnMkvPromene
            // 
            this.btnMkvPromene.BackColor = System.Drawing.Color.MintCream;
            this.btnMkvPromene.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.btnMkvPromene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMkvPromene.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMkvPromene.Location = new System.Drawing.Point(12, 257);
            this.btnMkvPromene.Name = "btnMkvPromene";
            this.btnMkvPromene.Size = new System.Drawing.Size(126, 30);
            this.btnMkvPromene.TabIndex = 2;
            this.btnMkvPromene.Text = "МКВ промене";
            this.btnMkvPromene.UseVisualStyleBackColor = false;
            this.btnMkvPromene.Visible = false;
            // 
            // FrmKontrolnaTabla
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(150, 405);
            this.ControlBox = false;
            this.Controls.Add(this.btnMkvPromene);
            this.Controls.Add(this.btnMkuPromene);
            this.Controls.Add(this.btnMupPromene);
            this.Controls.Add(this.btnUnosPromena);
            this.Controls.Add(this.btnPregledPromena);
            this.Controls.Add(this.btnUvozPromena);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.btnIzlaz);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKontrolnaTabla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmKontrolnaTabla";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FrmKontrolnaTabla_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Button btnUvozPromena;
        private System.Windows.Forms.Button btnPregledPromena;
        private System.Windows.Forms.Button btnUnosPromena;
        private System.Windows.Forms.Button btnMupPromene;
        private System.Windows.Forms.Button btnMkuPromene;
        private System.Windows.Forms.Button btnMkvPromene;
    }
}