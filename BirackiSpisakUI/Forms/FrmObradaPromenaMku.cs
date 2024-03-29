﻿using BirackiSpisakDataManager.Helpers;
using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using BirackiSpisakDataManager.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmObradaPromenaMku : Form
    {
        private Korisnik _korisnik;
        private MkuData _mkuData = new MkuData();
        private List<Mku> _lista = new List<Mku>();
        private Mku _promena = new Mku();
        private int _indeks = 0;

        public FrmObradaPromenaMku(Korisnik korisnik)
        {
            InitializeComponent();
            _korisnik = korisnik;
            _lista = _mkuData.SveNeresenePromene();
            PrikaziPromenu();
        }

        private void PrikaziPromenu(int index = 0)
        {
            if (_lista.Count > 0)
            {
                _promena = _lista[index];
                ProveriGreske(_promena);
                txtJmbg.Text = _promena.Jmbg;
                txtPol.Text = _promena.Pol;
                txtIme.Text = _promena.PunoIme;
                txtPrezimePreBraka.Text = _promena.PrezimePreBraka;
                txtPrebivaliste.Text = _promena.PunoPrebivaliste;
                txtDatumRodjenja.Text = _promena.DatumRodjenja != null ? _promena.DatumRodjenja.Value.ToShortDateString() : "";
                txtMestoRodjenja.Text = _promena.PunoMestoRodjenja;
                txtDatumSmrti.Text = _promena.DatumSmrti != null ? _promena.DatumSmrti.Value.ToShortDateString() : "";
                txtMestoSmrti.Text = _promena.PunoMestoSmrti;
                txtMaticnaKnjiga.Text = _promena.CeoMkuZapis;
                txtDatumFajla.Text = _promena.DatumFajla.Value.ToShortDateString();
                lblBrojPromena.Text = $"{index + 1} од {_lista.Count}";
            }
            else
            {
                txtJmbg.Text = "";
                txtPol.Text = "";
                txtIme.Text = "";
                txtPrezimePreBraka.Text = "";
                txtPrebivaliste.Text = "";
                txtDatumRodjenja.Text = "";
                txtMestoRodjenja.Text = "";
                txtDatumSmrti.Text = "";
                txtMestoSmrti.Text = "";
                txtMaticnaKnjiga.Text = "";
                txtDatumFajla.Text = "";
                lblBrojPromena.Text = $"0 од 0";
                _promena = null;
            }
        }

        private void ProveriGreske(Mku promena)
        {
            if (!Jmbg.jeIspravan(promena.Jmbg))
            {
                MessageBox.Show("ЈМБГ: Није исправан!", "МКУ промене", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrethodni_Click(object sender, EventArgs e)
        {
            _lista = _mkuData.SveNeresenePromene();
            if (_indeks > 0)
            {
                _indeks -= 1;
                PrikaziPromenu(_indeks);
            }
        }

        private void btnSledeci_Click(object sender, EventArgs e)
        {
            _lista = _mkuData.SveNeresenePromene();
            if (_indeks < _lista.Count - 1)
            {
                _indeks += 1;
            }
            else
            {
                _indeks = _lista.Count - 1;
            }
            PrikaziPromenu(_indeks);
        }

        private void btnDokaz_Click(object sender, EventArgs e)
        {
            if (_lista.Count > 0)
            {
                _promena = _lista[_indeks];
                string s = $"МКУ подаци";
                s += $"        датум фајла:{_promena.DatumFajla.Value.ToShortDateString()}" + Environment.NewLine;
                s += $"================================================================================" + Environment.NewLine;
                s += $"ЈМБГ: {_promena.Jmbg}" + Environment.NewLine;
                s += $"Име: {_promena.PunoIme}" + Environment.NewLine;
                s += $"Презиме пре брака: {_promena.PrezimePreBraka}    Пол: {_promena.Pol}" + Environment.NewLine;
                s += $"Рођен/а: {_promena.DatumRodjenja} у {_promena.PunoMestoRodjenja}" + Environment.NewLine;
                s += $"СМРТ    датум: {_promena.DatumSmrti} у {_promena.PunoMestoSmrti}" + Environment.NewLine;
                s += $"Пребивалиште: {_promena.PunoPrebivaliste}" + Environment.NewLine;
                s += $"Име оца: {_promena.PunoImeOtac}" + Environment.NewLine;
                s += $"Име мајке: {_promena.PunoImeMajka}" + Environment.NewLine;
                s += $"Књига, матично подручје (текући број/година уписа); град, општина" + Environment.NewLine;
                s += $"{_promena.CeoMkuZapis}";

                PrintDocument p = new PrintDocument();
                p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                {
                    e1.Graphics.DrawString(s,
                        new Font("SegoeUI", 10),
                        new SolidBrush(Color.Black),
                        new RectangleF(80, 40, 700, 1000));
                };
                try
                {
                    p.Print();
                }
                catch (Exception ex)
                {
                    throw new Exception("Грешка приликом штампања!", ex);
                }
            }
        }

        private void btnReseno_Click(object sender, EventArgs e)
        {
            if (_promena != null)
            {
                DialogResult dr = MessageBox.Show($"Да ли желите да решите промену за{Environment.NewLine}{_promena.PunoIme}", "Промене МКУ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    _promena.Reseno = true;
                    _promena.Datum = DateTime.Now;
                    _promena.Referent = _korisnik.PunoIme;
                    _mkuData.ResiPromenu(_promena);
                    _lista = _mkuData.SveNeresenePromene();
                    if (_indeks >= _lista.Count)
                    {
                        _indeks = _lista.Count - 1;
                    }
                }
            }
            PrikaziPromenu(_indeks);
        }

        private void btnJmbg_Click(object sender, EventArgs e)
        {
            JbsWeb.Jmbg(txtJmbg.Text);
        }

        private void btnZahtevi_Click(object sender, EventArgs e)
        {
            JbsWeb.Zahtevi(txtJmbg.Text);
        }

        private void btnUmrli_Click(object sender, EventArgs e)
        {
            JbsWeb.IzbrisiUmrloLice(_promena);
        }

        private void btnResenje_Click(object sender, EventArgs e)
        {
            JbsWeb.PopuniOvlascenje();
            JbsWeb.PopuniResenjeMku(_promena);
        }

        private void btnTrenutnoPrebivaliste_Click(object sender, EventArgs e)
        {
            ZupWeb.TrenutnoPrebivaliste(_promena.Jmbg, _promena.Ime, _promena.Prezime);
        }

        private void btnMkr_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkr(_promena.Jmbg, _promena.Ime, _promena.Prezime);
        }

        private void btnMku_Click(object sender, EventArgs e)
        {
            ZupWeb.Mku(_promena.Jmbg, _promena.Ime, _promena.Prezime);
        }

        private void btnMkv_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkv(_promena.Jmbg, _promena.Ime, _promena.Prezime);
        }
    }
}
