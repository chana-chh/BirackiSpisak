using BirackiSpisakDataManager.Helpers;
using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using BirackiSpisakDataManager.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmObradaPromenaMup : Form
    {
        private Korisnik _korisnik;
        private MupData _mupData = new MupData();
        private List<Mup> _lista = new List<Mup>();
        private Mup _promena = new Mup();
        private int _indeks = 0;

        public FrmObradaPromenaMup(Korisnik korisnik)
        {
            InitializeComponent();
            _korisnik = korisnik;
            _lista = _mupData.SveNeresenePromene();
            PrikaziPromenu();
        }

        private void PrikaziPromenu(int index = 0)
        {
            if (_lista.Count > 0)
            {
                _promena = _lista[index];
                ProveriGreske(_promena);
                txtJmbg.Text = _promena.Jmbg;
                txtDatumOdredjivanjaJmbg.Text = _promena.DatumOdredjivanjaJmbg != null ? _promena.DatumOdredjivanjaJmbg.Value.ToShortDateString() : "";
                txtPol.Text = _promena.Pol.Equals("M") ? "М" : "Ж";
                txtStatus.Text = _promena.Status;
                txtJmbgStari.Text = _promena.JmbgStari;
                txtJmbgDatumStari.Text = _promena.DatumOdredjivanjaStarogJmbg != null ? _promena.DatumOdredjivanjaStarogJmbg.Value.ToShortDateString() : "";
                txtDatumRodjenja.Text = _promena.DatumRodjenja != null ? _promena.DatumRodjenja.Value.ToShortDateString() : "";
                txtDatumOtpusta.Text = _promena.DatumOtpustaIzDrzavljanstva != null ? _promena.DatumOtpustaIzDrzavljanstva.Value.ToShortDateString() : "";
                txtMestoRodjenja.Text = _promena.PunoMestoRodjenja;
                txtIme.Text = _promena.PunoIme;
                txtImeLk.Text = _promena.PunoImeLk;
                txtPrebivalistePrijava.Text = _promena.DatumPrijaveAdrese != null ? _promena.DatumPrijaveAdrese.Value.ToShortDateString() : "";
                txtPrebivalisteOdjava.Text = _promena.DatumOdjaveAdrese != null ? _promena.DatumOdjaveAdrese.Value.ToShortDateString() : "";
                txtPrebivalisteAdresa.Text = _promena.PunoPrebivaliste;
                txtBoravistePrijava.Text = _promena.DatumPrijaveBoravka != null ? _promena.DatumPrijaveBoravka.Value.ToShortDateString() : "";
                txtBoravisteOdjava.Text = _promena.DatumOdjaveBoravka != null ? _promena.DatumOdjaveBoravka.Value.ToShortDateString() : "";
                txtBoravisteAdresa.Text = _promena.PunoBoraviste;
                txtDatumFajla.Text = _promena.DatumFajla != null ? _promena.DatumFajla.Value.ToShortDateString() : "";
                txtDatumPromene.Text = _promena.DatumPromene != null ? _promena.DatumPromene.Value.ToShortDateString() : "";
                txtVrstaPromene.Text = _promena.VrstaPromene;
                lblBrojPromena.Text = $"{index + 1} од {_lista.Count}";
            }
            else
            {
                txtJmbg.Text = "";
                txtDatumOdredjivanjaJmbg.Text = "";
                txtPol.Text = "";
                txtStatus.Text = "";
                txtJmbgStari.Text = "";
                txtJmbgDatumStari.Text = "";
                txtDatumRodjenja.Text = "";
                txtDatumOtpusta.Text = "";
                txtMestoRodjenja.Text = "";
                txtIme.Text = "";
                txtImeLk.Text = "";
                txtPrebivalistePrijava.Text = "";
                txtPrebivalisteOdjava.Text = "";
                txtPrebivalisteAdresa.Text = "";
                txtBoravistePrijava.Text = "";
                txtBoravisteOdjava.Text = "";
                txtBoravisteAdresa.Text = "";
                txtDatumFajla.Text = "";
                txtDatumPromene.Text = "";
                txtVrstaPromene.Text = "";
                lblBrojPromena.Text = $"0 од {_lista.Count}";
                _promena = null;
            }
        }

        private void ProveriGreske(Mup promena)
        {
            string greske = "";
            if (!Jmbg.IsOK(promena.Jmbg))
            {
                greske += "ЈМБГ: Није исправан!" + Environment.NewLine;
            }
            else
            {
                int razlika = DateTime.Compare((DateTime)Dates.DobFromJmbg(promena.Jmbg), (DateTime)promena.DatumRodjenja);
                if (razlika != 0)
                {
                    greske += "ЈМБГ: Датум рођења се не слаже са ЈМБГ!" + Environment.NewLine;
                }
            }

            if (!string.IsNullOrEmpty(promena.JmbgStari))
            {
                greske += "ЈМБГ: Постоји стари ЈМБГ!" + Environment.NewLine;
            }

            if (promena.Status.Equals("U"))
            {
                greske += "СТАТУС: Умрло лице!" + Environment.NewLine;
            }

            if (promena.DatumOtpustaIzDrzavljanstva != null)
            {
                greske += "ОТПУСТ: Отпуст из држављанства!" + Environment.NewLine;
            }

            if (promena.DatumPrijaveAdrese == null)
            {
                greske += "ПРЕБИВАЛИШТЕ: Нема пријаву пребивалишта!" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(promena.DatumOdjaveAdrese.ToString()))
            {
                greske += "ПРЕБИВАЛИШТЕ: Одјава пребивалишта!" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(greske))
            {
                MessageBox.Show(greske, "МУП промене", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrethodni_Click(object sender, EventArgs e)
        {
            _lista = _mupData.SveNeresenePromene();
            if (_indeks > 0)
            {
                _indeks -= 1;
                PrikaziPromenu(_indeks);
            }
        }

        private void btnSledeci_Click(object sender, EventArgs e)
        {
            _lista = _mupData.SveNeresenePromene();
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
                string s = $"МУП подаци";
                s += $"    датум фајла:{_promena.DatumFajla.Value.ToShortDateString()}    датум промене:{_promena.DatumPromene}" + Environment.NewLine;
                s += $"================================================================================" + Environment.NewLine;
                s += $"ЈМБГ: {_promena.Jmbg}" + Environment.NewLine;
                s += $"Датум одређивања ЈМБГ: {_promena.DatumOdredjivanjaJmbg}" + Environment.NewLine;
                s += $"Пол: {_promena.Pol}" + Environment.NewLine;
                s += $"Статус: {_promena.Status}" + Environment.NewLine;
                s += $"Име: {_promena.PunoIme}" + Environment.NewLine;
                s += $"{_promena.PunoImeLk}" + Environment.NewLine;
                s += $"Рођен/а: {_promena.DatumRodjenja} у {_promena.PunoMestoRodjenja}" + Environment.NewLine;
                s += $"ПРЕБИВАЛИШТЕ" + Environment.NewLine;
                s += $"Датум пријаве: {_promena.DatumPrijaveAdrese}    датум одјаве: {_promena.DatumOdjaveAdrese}" + Environment.NewLine;
                s += $"Aдреса: {_promena.PunoPrebivaliste}" + Environment.NewLine;
                s += $"БОРАВИШТЕ" + Environment.NewLine;
                s += $"Датум пријаве: {_promena.DatumPrijaveBoravka}    датум одјаве: {_promena.DatumOdjaveBoravka}" + Environment.NewLine;
                s += $"Aдреса: {_promena.PunoBoraviste}" + Environment.NewLine;
                s += $"Промена: {_promena.VrstaPromene}";

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
                _promena.Reseno = true;
                _promena.Datum = DateTime.Now;
                _promena.Referent = _korisnik.PunoIme;
                _mupData.ResiPromenu(_promena);
                _lista = _mupData.SveNeresenePromene();
                if (_indeks >= _lista.Count)
                {
                    _indeks = _lista.Count - 1;
                }
            }
            PrikaziPromenu(_indeks);
        }

        private void btnChrome_Click(object sender, EventArgs e)
        {
            JbsMup.OtvoriChrome();
            btnPrijava.Enabled = true;
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (JbsMup.PripremiChrome())
            {
                btnChrome.Enabled = false;
                pnlDugmici.Enabled = true;
                btnPrijava.Enabled = false;
            }
            else
            {
                MessageBox.Show("Морају бити отворени само еЗуп и ЈБС.",
                    "Покретање претраживача",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }

        private void FrmObradaPromenaMup_FormClosed(object sender, FormClosedEventArgs e)
        {
            JbsMup.ZatvoriChrome();
        }

        private void btnJmbg_Click(object sender, EventArgs e)
        {
            JbsMup.Jmbg(txtJmbg.Text);
        }

        private void btnZahtevi_Click(object sender, EventArgs e)
        {
            JbsMup.Zahtevi(txtJmbg.Text);
        }

        private void btnPromenaPrebivalista_Click(object sender, EventArgs e)
        {
            JbsMup.PromeniPrebivaliste(_promena);
        }

        private void btnAdresa_Click(object sender, EventArgs e)
        {
            JbsMup.UpisiAdresu(_promena);
        }

        private void btnResenje_Click(object sender, EventArgs e)
        {
            JbsMup.PopuniOvlascenje();
            JbsMup.PopuniResenje(_promena);
        }

        private void btnUpisPrebivalista_Click(object sender, EventArgs e)
        {
            JbsMup.UpisiPrebivaliste(_promena);
        }
    }
}
