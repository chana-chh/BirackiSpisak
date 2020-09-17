using BirackiSpisakDataManager.Models;
using BirackiSpisakUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BirackiSpisakUI
{
    public partial class FrmKontrolnaTabla : Form
    {
        public Korisnik korisnik { get; set; }

        public FrmKontrolnaTabla()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUvozPromena_Click(object sender, EventArgs e)
        {
            FrmUvozPromena forma = new FrmUvozPromena();
            forma.ShowDialog();
        }
    }
}
