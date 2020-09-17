namespace BirackiSpisakUI.Forms
{
    partial class FrmUvozPromena
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
            this.btnMupUvoz = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.btnMkuUvoz = new System.Windows.Forms.Button();
            this.btnMkvUvoz = new System.Windows.Forms.Button();
            this.btnMupDupli = new System.Windows.Forms.Button();
            this.btnSviDupli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMupUvoz
            // 
            this.btnMupUvoz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnMupUvoz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMupUvoz.Location = new System.Drawing.Point(12, 12);
            this.btnMupUvoz.Name = "btnMupUvoz";
            this.btnMupUvoz.Size = new System.Drawing.Size(126, 30);
            this.btnMupUvoz.TabIndex = 2;
            this.btnMupUvoz.Text = "МУП";
            this.btnMupUvoz.UseVisualStyleBackColor = true;
            this.btnMupUvoz.Click += new System.EventHandler(this.btnMupUvoz_Click);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaShell;
            this.btnIzlaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzlaz.ForeColor = System.Drawing.Color.Red;
            this.btnIzlaz.Location = new System.Drawing.Point(12, 264);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(126, 30);
            this.btnIzlaz.TabIndex = 0;
            this.btnIzlaz.Text = "Излаз";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnMkuUvoz
            // 
            this.btnMkuUvoz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnMkuUvoz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMkuUvoz.Location = new System.Drawing.Point(12, 48);
            this.btnMkuUvoz.Name = "btnMkuUvoz";
            this.btnMkuUvoz.Size = new System.Drawing.Size(126, 30);
            this.btnMkuUvoz.TabIndex = 2;
            this.btnMkuUvoz.Text = "МКУ";
            this.btnMkuUvoz.UseVisualStyleBackColor = true;
            this.btnMkuUvoz.Click += new System.EventHandler(this.btnMkuUvoz_Click);
            // 
            // btnMkvUvoz
            // 
            this.btnMkvUvoz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnMkvUvoz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMkvUvoz.Location = new System.Drawing.Point(12, 84);
            this.btnMkvUvoz.Name = "btnMkvUvoz";
            this.btnMkvUvoz.Size = new System.Drawing.Size(126, 30);
            this.btnMkvUvoz.TabIndex = 2;
            this.btnMkvUvoz.Text = "МКВ";
            this.btnMkvUvoz.UseVisualStyleBackColor = true;
            this.btnMkvUvoz.Click += new System.EventHandler(this.btnMkvUvoz_Click);
            // 
            // btnMupDupli
            // 
            this.btnMupDupli.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnMupDupli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMupDupli.Location = new System.Drawing.Point(12, 156);
            this.btnMupDupli.Name = "btnMupDupli";
            this.btnMupDupli.Size = new System.Drawing.Size(126, 30);
            this.btnMupDupli.TabIndex = 2;
            this.btnMupDupli.Text = "МУП дупликати";
            this.btnMupDupli.UseVisualStyleBackColor = true;
            this.btnMupDupli.Click += new System.EventHandler(this.btnMupDupli_Click);
            // 
            // btnSviDupli
            // 
            this.btnSviDupli.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnSviDupli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSviDupli.Location = new System.Drawing.Point(12, 192);
            this.btnSviDupli.Name = "btnSviDupli";
            this.btnSviDupli.Size = new System.Drawing.Size(126, 30);
            this.btnSviDupli.TabIndex = 2;
            this.btnSviDupli.Text = "Сви дупликати";
            this.btnSviDupli.UseVisualStyleBackColor = true;
            this.btnSviDupli.Click += new System.EventHandler(this.btnSviDupli_Click);
            // 
            // FrmUvozPromena
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(150, 306);
            this.ControlBox = false;
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnSviDupli);
            this.Controls.Add(this.btnMupDupli);
            this.Controls.Add(this.btnMkvUvoz);
            this.Controls.Add(this.btnMkuUvoz);
            this.Controls.Add(this.btnMupUvoz);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(155, 65);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUvozPromena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmUvozPromena";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMupUvoz;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Button btnMkuUvoz;
        private System.Windows.Forms.Button btnMkvUvoz;
        private System.Windows.Forms.Button btnMupDupli;
        private System.Windows.Forms.Button btnSviDupli;
    }
}