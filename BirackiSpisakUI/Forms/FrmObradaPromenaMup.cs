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
        private bool _sl = false;
        private bool _punolenti = false;

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
                lblBrojPromena.Text = $"0 од 0";
                _promena = null;
            }
        }

        private void ProveriGreske(Mup promena)
        {
            string greske = "";
            if (!Jmbg.jeIspravan(promena.Jmbg))
            {
                greske += "ЈМБГ: Није исправан!" + Environment.NewLine;
            }

            int razlika = DateTime.Compare((DateTime)Dates.DobFromJmbg(promena.Jmbg), (DateTime)promena.DatumRodjenja);

            if (razlika != 0)
            {
                greske += "ЈМБГ: Датум рођења се не слаже са ЈМБГ!" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(promena.JmbgStari))
            {
                greske += "ЈМБГ: Постоји стари ЈМБГ!" + Environment.NewLine;
            }

            if (promena.Status.Equals("U"))
            {
                greske += "СТАТУС: Умрло лице!" + Environment.NewLine;
                BackColor = Color.DimGray;
            }
            else
            {
                BackColor = Color.White;
            }

            if (promena.DatumOtpustaIzDrzavljanstva != null)
            {
                greske += "ОТПУСТ: Отпуст из држављанства!" + Environment.NewLine;
            }

            if (promena.DatumPrijaveAdrese == null)
            {
                greske += "ПРЕБИВАЛИШТЕ: Нема пријаву пребивалишта!" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(promena.DatumOdjaveAdrese.ToString()) && !promena.Status.Equals("U"))
            {
                greske += "ПРЕБИВАЛИШТЕ: Одјава пребивалишта!" + Environment.NewLine;
                BackColor = Color.Red;

                if (promena.DatumOtpustaIzDrzavljanstva == null)
                {
                    btnOdjavaPrebivalistaSluzbeno.Enabled = true;
                    btnOdjavaPrebivalista.Enabled = true;
                }
            }
            else
            {
                BackColor = Color.White;
                btnOdjavaPrebivalistaSluzbeno.Enabled = false;
                btnOdjavaPrebivalista.Enabled = false;
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
                s += $"Стари ЈМБГ: {_promena.JmbgStari}" + Environment.NewLine;
                s += $"Отпуст из држављанства: {_promena.DatumOtpustaIzDrzavljanstva}" + Environment.NewLine;
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
                DialogResult dr = MessageBox.Show($"Да ли желите да решите промену за{Environment.NewLine}{_promena.PunoIme}", "Промене МУП", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
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

        private void btnAdresa_Click(object sender, EventArgs e)
        {
            JbsWeb.UpisiAdresu(_promena);
        }
        private void btnLicniPodaci_Click(object sender, EventArgs e)
        {
            JbsWeb.UpisiLicnePodatke(_promena, true, true);
        }

        private void btnResenje_Click(object sender, EventArgs e)
        {
            if (_punolenti)
            {
                if (!ZupWeb.UpisiMkrZaPunoletne(_promena))
                {
                    MessageBox.Show("У еЗуп-у није отворена МКР за ово лице", "Подаци из МКР");
                }
            }

            _punolenti = false;

            JbsWeb.PopuniOvlascenje();
            if (_sl)
            {
                JbsWeb.PopuniResenje(_promena, true);
            }
            else
            {
                JbsWeb.PopuniResenje(_promena);
            }
            _sl = false;
        }

        private void btnPromenaPrebivalista_Click(object sender, EventArgs e)
        {
            JbsWeb.PromeniPrebivaliste(_promena);
        }

        private void btnUpisPrebivalista_Click(object sender, EventArgs e)
        {
            JbsWeb.UpisiPrebivaliste(_promena);
        }

        private void btnPunoletni_Click(object sender, EventArgs e)
        {
            JbsWeb.UpisiPunoletnoLice(_promena);
            _punolenti = true;
        }

        private void btnPumoletniMkr_Click(object sender, EventArgs e)
        {
            if (!ZupWeb.UpisiMkrZaPunoletne(_promena))
            {
                MessageBox.Show("У еЗуп-у није отворена МКР за ово лице", "Подаци из МКР");
            }
        }

        private void btnPromenaLicnihPodataka_Click(object sender, EventArgs e)
        {
            JbsWeb.PromeniLicnePodatke(_promena);
        }

        private void btnOdjavaPrebivalista_Click(object sender, EventArgs e)
        {
            JbsWeb.OdjaviPrebivaliste(_promena);
        }

        private void btnOdjavaPrebivalistaSluzbeno_Click(object sender, EventArgs e)
        {
            _sl = true;
            JbsWeb.OdjaviPrebivalisteSluzbeno(_promena);
        }

        private void btnTrenutnoPrebivaliste_Click(object sender, EventArgs e)
        {
            ZupWeb.TrenutnoPrebivaliste(_promena.Jmbg, _promena.ImeLk, _promena.PrezimeLk);
        }

        private void btnMkr_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkr(_promena.Jmbg, _promena.ImeLk, _promena.PrezimeLk);
        }

        private void btnMku_Click(object sender, EventArgs e)
        {
            ZupWeb.Mku(_promena.Jmbg, _promena.ImeLk, _promena.PrezimeLk);
        }

        private void btnMkv_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkv(_promena.Jmbg, _promena.ImeLk, _promena.PrezimeLk);
        }
    }
}
