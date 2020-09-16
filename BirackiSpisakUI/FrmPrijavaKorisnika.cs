using BirackiSpisakDataManager.Helpers;
using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using System;
using System.Windows.Forms;

namespace BirackiSpisakUI
{
    public partial class FrmPrijavaKorisnika : Form
    {
        // Korisnicko ime: чана
        // Lozinka: чанам7ј

        // Korisnicko ime: микица
        // Lozinka: фукица

        // Korisnicko ime: маријана
        // Lozinka: меги0805

        public FrmPrijavaKorisnika()
        {
            InitializeComponent();
        }

        private void btnKrajRada_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            // Klasicna prijava
            // string korisnickoIme = txtKorisnickoIme.Text.Trim();
            // string lozinka = .Text.Trim();

            // Automatska prijava
            string korisnickoIme = "чана";
            string lozinka = "чанам7ј";

            if (!String.IsNullOrEmpty(korisnickoIme) && !String.IsNullOrEmpty(lozinka))
            {
                KorisnikData korisnikData = new KorisnikData();
                Korisnik korisnik = korisnikData.KorisnikPoKorisnickomImenu(korisnickoIme);

                if (korisnik != null)
                {
                    bool ispravnaLozinka = Password.Compare(lozinka, korisnik.Lozinka);
                
                    if (ispravnaLozinka)
                    {
                        FrmKontrolnaTabla KontrolnaTabla = new FrmKontrolnaTabla
                        {
                            Korisnik = korisnik
                        };
                        KontrolnaTabla.Show();
                        Close();
                    }
                    else
                    {
                        txtKorisnickoIme.Text = "";
                        txtLozinka.Text = "";
                        txtKorisnickoIme.Focus();
                        MessageBox.Show($"Нису унети исправни подаци.{Environment.NewLine}Покушајте поново.",
                            "Пријављивање корисника",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    txtKorisnickoIme.Text = "";
                    txtLozinka.Text = "";
                    txtKorisnickoIme.Focus();
                    MessageBox.Show($"Нису унети исправни подаци.{Environment.NewLine}Покушајте поново.",
                        "Пријављивање корисника",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                txtKorisnickoIme.Focus();
                MessageBox.Show("Морате унети корисничко име и лозинку.",
                    "Пријављивање корисника",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }
    }
}
