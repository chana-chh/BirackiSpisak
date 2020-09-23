using BirackiSpisakDataManager.Models;
using BirackiSpisakUI.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BirackiSpisakUI
{
    public partial class FrmKontrolnaTabla : Form
    {
        public Korisnik korisnik { get; set; }

        private bool _promene = false;

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

        private void btnPregledPromena_Click(object sender, EventArgs e)
        {
            FrmPregledPromena forma = new FrmPregledPromena();
            forma.ShowDialog();
        }

        private void btnUnosPromena_Click(object sender, EventArgs e)
        {
            if (_promene)
            {
                _promene = false;
                btnUvozPromena.Enabled = true;
                btnPregledPromena.Enabled = true;
                btnMupPromene.Visible = false;
                btnMkuPromene.Visible = false;
                btnMkvPromene.Visible = false;
                btnUnosPromena.BackColor = Color.White;
            }
            else
            {
                _promene = true;
                btnUvozPromena.Enabled = false;
                btnPregledPromena.Enabled = false;
                btnMupPromene.Visible = true;
                btnMkuPromene.Visible = true;
                btnMkvPromene.Visible = true;
                btnUnosPromena.BackColor = Color.LightSkyBlue;
            }
        }

        private void btnMupPromene_Click(object sender, EventArgs e)
        {
            btnMupPromene.BackColor = Color.OrangeRed;
            FrmObradaPromenaMup forma = new FrmObradaPromenaMup(korisnik);
            forma.ShowDialog();
        }

        private void FrmKontrolnaTabla_Activated(object sender, EventArgs e)
        {
            btnMupPromene.BackColor = Color.MintCream;
            btnMkuPromene.BackColor = Color.MintCream;
            btnMkvPromene.BackColor = Color.MintCream;
        }
    }
}
