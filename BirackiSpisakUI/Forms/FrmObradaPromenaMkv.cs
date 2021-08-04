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
using System.Text;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmObradaPromenaMkv : Form
    {
        private Korisnik _korisnik;
        private MkvData _mkvData = new MkvData();
        private List<Mkv> _lista = new List<Mkv>();
        private Mkv _promena = new Mkv();
        private int _indeks = 0;

        public FrmObradaPromenaMkv(Korisnik korisnik)
        {
            InitializeComponent();
            _korisnik = korisnik;
            _lista = _mkvData.SveNeresenePromene();
            PrikaziPromenu();
        }

        private void PrikaziPromenu(int index = 0)
        {
            if (_lista.Count > 0)
            {
                _promena = _lista[index];
                ProveriGreske(_promena);
                txtDatumZakljucenja.Text = _promena.DatumZakljucenjaBraka != null ? _promena.DatumZakljucenjaBraka.Value.ToShortDateString() : "";
                txtMestoZakljucenja.Text = _promena.MestoZakljucenjaBraka;
                txtMaticnaKnjiga.Text = _promena.CeoMkvZapis;
                txtZenikIme.Text = _promena.ZenikPunoImeOdabrano;
                txtZenikImeOdabrano.Text = _promena.ZenikPunoIme;
                txtZenikJmbg.Text = _promena.ZenikJmbg;
                txtZenikDatumRodjenja.Text = _promena.ZenikDatumRodjenja != null ? _promena.ZenikDatumRodjenja.Value.ToShortDateString() : "";
                txtZenikPrebivaliste.Text = _promena.ZenikPrebivaliste;
                txtNevestaIme.Text = _promena.NevestaPunoImeOdabrano;
                txtNevestaImeOdabrano.Text = _promena.NevestaPunoIme;
                txtNevestaJmbg.Text = _promena.NevestaJmbg;
                txtNevestaDatumRodjenja.Text = _promena.NevestaDatumRodjenja != null ? _promena.NevestaDatumRodjenja.Value.ToShortDateString() : "";
                txtNevestaPrebivaliste.Text = _promena.NevestaPrebivaliste;
                lblBrojPromena.Text = $"{index + 1} од {_lista.Count}";
            }
            else
            {
                txtDatumZakljucenja.Text = "";
                txtMestoZakljucenja.Text = "";
                txtMaticnaKnjiga.Text = "";
                txtZenikIme.Text = "";
                txtZenikImeOdabrano.Text = "";
                txtZenikJmbg.Text = "";
                txtZenikDatumRodjenja.Text = "";
                txtZenikPrebivaliste.Text = "";
                txtNevestaIme.Text = "";
                txtNevestaImeOdabrano.Text = "";
                txtNevestaJmbg.Text = "";
                txtNevestaDatumRodjenja.Text = "";
                txtNevestaPrebivaliste.Text = "";
                lblBrojPromena.Text = $"0 од 0";
                _promena = null;
            }
        }

        private void ProveriGreske(Mkv promena)
        {
            if (!Jmbg.jeIspravan(promena.ZenikJmbg))
            {
                MessageBox.Show("ЈМБГ женика: Није исправан!", "МКВ промене", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //int razlikaDatuma = DateTime.Compare((DateTime)Dates.DobFromJmbg(_promena.ZenikJmbg), (DateTime)_promena.ZenikDatumRodjenja);
                //if (razlikaDatuma != 0)
                //{
                //    MessageBox.Show("Датум рођења женика се не слаже са ЈМБГ!", "МКВ промене", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }

            if (!Jmbg.jeIspravan(promena.NevestaJmbg))
            {
                MessageBox.Show("ЈМБГ невесте: Није исправан!", "МКВ промене", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //int razlikaDatuma = DateTime.Compare((DateTime)Dates.DobFromJmbg(_promena.NevestaJmbg), (DateTime)_promena.NevestaDatumRodjenja);
                //if (razlikaDatuma != 0)
                //{
                //    MessageBox.Show("Датум рођења невесте се не слаже са ЈМБГ!", "МКВ промене", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }

            string zenikPromenaPrezimena = "";
            string nevestaPromenaPrezimena = "";

            if (_promena.ZenikPrezime != _promena.ZenikPrezimeOdabrano)
            {
                zenikPromenaPrezimena = "ЖЕНИК ПРОМЕНИО ПРЕЗИМЕ ; ";
                txtPromenaPrezimena.ForeColor = Color.Red;
            }
            else
            {
                txtPromenaPrezimena.ForeColor = Color.Black;
            }

            if (_promena.NevestaPrezime != _promena.NevestaPrezimeOdabrano)
            {
                nevestaPromenaPrezimena = "НЕВЕСТА ПРОМЕНИЛА ПРЕЗИМЕ";
            }
            txtPromenaPrezimena.Text = $"{zenikPromenaPrezimena}{nevestaPromenaPrezimena}";
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrethodni_Click(object sender, EventArgs e)
        {
            _lista = _mkvData.SveNeresenePromene();
            if (_indeks > 0)
            {
                _indeks -= 1;
                PrikaziPromenu(_indeks);
            }
        }

        private void btnSledeci_Click(object sender, EventArgs e)
        {
            _lista = _mkvData.SveNeresenePromene();
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
                string s = $"МКВ подаци        датум фајла:{_promena.DatumFajla.Value.ToShortDateString()}" + Environment.NewLine;
                s += $"================================================================================" + Environment.NewLine;
                s += $"Брак закључен {_promena.DatumZakljucenjaBraka} у {_promena.MestoZakljucenjaBraka}" + Environment.NewLine;
                s += $"--------------------------------------------------------------------------------" + Environment.NewLine;
                s += $"ЖЕНИК" + Environment.NewLine;
                s += $"ЈМБГ: {_promena.ZenikJmbg}" + Environment.NewLine;
                s += $"Име: {_promena.ZenikPunoIme}" + Environment.NewLine;
                s += $"Име одабрано: {_promena.ZenikPunoImeOdabrano}" + Environment.NewLine;
                s += $"Датум рођења: {_promena.ZenikDatumRodjenja}" + Environment.NewLine;
                s += $"Пребивалиште: {_promena.ZenikPrebivaliste}" + Environment.NewLine;
                s += $"НЕВЕСТА" + Environment.NewLine;
                s += $"ЈМБГ: {_promena.NevestaJmbg}" + Environment.NewLine;
                s += $"Име: {_promena.NevestaPunoIme}" + Environment.NewLine;
                s += $"Име одабрано: {_promena.NevestaPunoImeOdabrano}" + Environment.NewLine;
                s += $"Датум рођења: {_promena.NevestaDatumRodjenja}" + Environment.NewLine;
                s += $"Пребивалиште: {_promena.NevestaPrebivaliste}" + Environment.NewLine;
                s += $"--------------------------------------------------------------------------------" + Environment.NewLine;
                s += $"Књига, матично подручје (текући број/година уписа); град, општина" + Environment.NewLine;
                s += $"{_promena.CeoMkvZapis}";

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
                DialogResult dr = MessageBox.Show($"Да ли желите да решите промену за{Environment.NewLine}{_promena.ZenikPunoIme}{Environment.NewLine}{_promena.NevestaPunoIme}", "Промене МКВ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    _promena.Reseno = true;
                    _promena.Datum = DateTime.Now;
                    _promena.Referent = _korisnik.PunoIme;
                    _mkvData.ResiPromenu(_promena);
                    _lista = _mkvData.SveNeresenePromene();
                    if (_indeks >= _lista.Count)
                    {
                        _indeks = _lista.Count - 1;
                    }
                }
            }
            PrikaziPromenu(_indeks);
        }

        private void btnJmbgZenik_Click(object sender, EventArgs e)
        {
            JbsWeb.Jmbg(_promena.ZenikJmbg);
        }

        private void btnZahteviZenik_Click(object sender, EventArgs e)
        {
            JbsWeb.Zahtevi(_promena.ZenikJmbg);
        }

        private void btnJmbgNevesta_Click(object sender, EventArgs e)
        {
            JbsWeb.Jmbg(_promena.NevestaJmbg);
        }

        private void btnZahteviNevesta_Click(object sender, EventArgs e)
        {
            JbsWeb.Zahtevi(_promena.NevestaJmbg);
        }

        private void btnTrenutnoPrebivalisteZenik_Click(object sender, EventArgs e)
        {
            ZupWeb.TrenutnoPrebivaliste(_promena.ZenikJmbg, _promena.ZenikIme, _promena.ZenikPrezimeOdabrano);
        }

        private void btnMkrZenik_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkr(_promena.ZenikJmbg, _promena.ZenikIme, _promena.ZenikPrezimeOdabrano);
        }

        private void btnMkuZenik_Click(object sender, EventArgs e)
        {
            ZupWeb.Mku(_promena.ZenikJmbg, _promena.ZenikIme, _promena.ZenikPrezimeOdabrano);
        }

        private void btnMkvZenik_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkv(_promena.ZenikJmbg, _promena.ZenikIme, _promena.ZenikPrezimeOdabrano);
        }

        private void btnTrenutnoPrebivalisteNevesta_Click(object sender, EventArgs e)
        {
            ZupWeb.TrenutnoPrebivaliste(_promena.NevestaJmbg, _promena.NevestaIme, _promena.NevestaPrezimeOdabrano);
        }

        private void btnMkrNevesta_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkr(_promena.NevestaJmbg, _promena.NevestaIme, _promena.NevestaPrezimeOdabrano);
        }

        private void btnMukNevesta_Click(object sender, EventArgs e)
        {
            ZupWeb.Mku(_promena.NevestaJmbg, _promena.NevestaIme, _promena.NevestaPrezimeOdabrano);
        }

        private void btnMkvNevesta_Click(object sender, EventArgs e)
        {
            ZupWeb.Mkv(_promena.NevestaJmbg, _promena.NevestaIme, _promena.NevestaPrezimeOdabrano);
        }

        private void btnPromenaZenik_Click(object sender, EventArgs e)
        {
            JbsWeb.PromeniLPzaZenika(_promena);
        }

        private void BtnPromenaNevesta_Click(object sender, EventArgs e)
        {
            JbsWeb.PromeniLPzaNevestu(_promena);
        }

        private void btnResenjeZenik_Click(object sender, EventArgs e)
        {
            JbsWeb.PopuniOvlascenje();
            JbsWeb.PopuniResenjeMkv(_promena);
        }

        private void btnResenjeNevesta_Click(object sender, EventArgs e)
        {
            JbsWeb.PopuniOvlascenje();
            JbsWeb.PopuniResenjeMkv(_promena);
        }
    }
}
