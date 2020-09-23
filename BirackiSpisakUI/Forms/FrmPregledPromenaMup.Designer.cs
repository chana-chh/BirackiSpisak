namespace BirackiSpisakUI.Forms
{
    partial class FrmPregledPromenaMup
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
            this.lblJmbg = new System.Windows.Forms.Label();
            this.txtJmbg = new System.Windows.Forms.TextBox();
            this.btnPronadji = new System.Windows.Forms.Button();
            this.btnPrikaziSve = new System.Windows.Forms.Button();
            this.btnStampaj = new System.Windows.Forms.Button();
            this.btnAktiviraj = new System.Windows.Forms.Button();
            this.dgvTabela = new System.Windows.Forms.DataGridView();
            this.lblBroj = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Location = new System.Drawing.Point(12, 9);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(38, 17);
            this.lblJmbg.TabIndex = 0;
            this.lblJmbg.Text = "ЈМБГ";
            // 
            // txtJmbg
            // 
            this.txtJmbg.BackColor = System.Drawing.Color.White;
            this.txtJmbg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJmbg.ForeColor = System.Drawing.Color.Black;
            this.txtJmbg.Location = new System.Drawing.Point(56, 7);
            this.txtJmbg.MaxLength = 13;
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.Size = new System.Drawing.Size(100, 25);
            this.txtJmbg.TabIndex = 1;
            this.txtJmbg.WordWrap = false;
            this.txtJmbg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJmbg_KeyPress);
            // 
            // btnPronadji
            // 
            this.btnPronadji.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnPronadji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPronadji.Location = new System.Drawing.Point(162, 7);
            this.btnPronadji.Name = "btnPronadji";
            this.btnPronadji.Size = new System.Drawing.Size(126, 30);
            this.btnPronadji.TabIndex = 2;
            this.btnPronadji.Text = "Пронађи";
            this.btnPronadji.UseVisualStyleBackColor = true;
            this.btnPronadji.Click += new System.EventHandler(this.btnPronadji_Click);
            // 
            // btnPrikaziSve
            // 
            this.btnPrikaziSve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnPrikaziSve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikaziSve.Location = new System.Drawing.Point(294, 7);
            this.btnPrikaziSve.Name = "btnPrikaziSve";
            this.btnPrikaziSve.Size = new System.Drawing.Size(126, 30);
            this.btnPrikaziSve.TabIndex = 2;
            this.btnPrikaziSve.Text = "Прикажи све";
            this.btnPrikaziSve.UseVisualStyleBackColor = true;
            this.btnPrikaziSve.Click += new System.EventHandler(this.btnPrikaziSve_Click);
            // 
            // btnStampaj
            // 
            this.btnStampaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStampaj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnStampaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStampaj.Location = new System.Drawing.Point(1046, 7);
            this.btnStampaj.Name = "btnStampaj";
            this.btnStampaj.Size = new System.Drawing.Size(126, 30);
            this.btnStampaj.TabIndex = 2;
            this.btnStampaj.Text = "Штампај";
            this.btnStampaj.UseVisualStyleBackColor = true;
            this.btnStampaj.Click += new System.EventHandler(this.btnStampaj_Click);
            // 
            // btnAktiviraj
            // 
            this.btnAktiviraj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAktiviraj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnAktiviraj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAktiviraj.Location = new System.Drawing.Point(914, 7);
            this.btnAktiviraj.Name = "btnAktiviraj";
            this.btnAktiviraj.Size = new System.Drawing.Size(126, 30);
            this.btnAktiviraj.TabIndex = 2;
            this.btnAktiviraj.Text = "Активирај";
            this.btnAktiviraj.UseVisualStyleBackColor = true;
            this.btnAktiviraj.Click += new System.EventHandler(this.btnAktiviraj_Click);
            // 
            // dgvTabela
            // 
            this.dgvTabela.AllowUserToAddRows = false;
            this.dgvTabela.AllowUserToDeleteRows = false;
            this.dgvTabela.AllowUserToResizeRows = false;
            this.dgvTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTabela.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTabela.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabela.GridColor = System.Drawing.Color.Silver;
            this.dgvTabela.Location = new System.Drawing.Point(12, 43);
            this.dgvTabela.MultiSelect = false;
            this.dgvTabela.Name = "dgvTabela";
            this.dgvTabela.ReadOnly = true;
            this.dgvTabela.RowHeadersVisible = false;
            this.dgvTabela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabela.Size = new System.Drawing.Size(1160, 533);
            this.dgvTabela.TabIndex = 3;
            this.dgvTabela.Text = "dataGridView1";
            this.dgvTabela.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTabela_CellClick);
            // 
            // lblBroj
            // 
            this.lblBroj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBroj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBroj.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblBroj.Location = new System.Drawing.Point(1072, 579);
            this.lblBroj.Name = "lblBroj";
            this.lblBroj.Size = new System.Drawing.Size(100, 17);
            this.lblBroj.TabIndex = 4;
            this.lblBroj.Text = "0";
            this.lblBroj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmPregledPromenaMup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 605);
            this.Controls.Add(this.lblBroj);
            this.Controls.Add(this.dgvTabela);
            this.Controls.Add(this.btnAktiviraj);
            this.Controls.Add(this.btnStampaj);
            this.Controls.Add(this.btnPrikaziSve);
            this.Controls.Add(this.btnPronadji);
            this.Controls.Add(this.txtJmbg);
            this.Controls.Add(this.lblJmbg);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.Location = new System.Drawing.Point(305, 101);
            this.Name = "FrmPregledPromenaMup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Преглед промена МУП";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.TextBox txtJmbg;
        private System.Windows.Forms.Button btnPronadji;
        private System.Windows.Forms.Button btnPrikaziSve;
        private System.Windows.Forms.Button btnStampaj;
        private System.Windows.Forms.Button btnAktiviraj;
        private System.Windows.Forms.DataGridView dgvTabela;
        private System.Windows.Forms.Label lblBroj;
    }
}