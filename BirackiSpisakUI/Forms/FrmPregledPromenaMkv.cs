using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmPregledPromenaMkv : Form
    {
        private MkvData _mkvData = new MkvData();
        private List<Mkv> _lista = new List<Mkv>();
        private Mkv _promena;

        public FrmPregledPromenaMkv()
        {
            InitializeComponent();
            OsveziTabelu();
        }

        private void OsveziTabelu()
        {
            dgvTabela.DataSource = null;
            _lista = _mkvData.PromenePoJmbg(txtJmbg.Text);
            dgvTabela.DataSource = _lista;
            dgvTabela.Refresh();
            lblBroj.Text = _lista.Count.ToString();
        }

        private void txtJmbg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OsveziTabelu();
            }
        }

        private void dgvTabela_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTabela.CurrentRow != null)
            {
                _promena = (Mkv)dgvTabela.CurrentRow.DataBoundItem;
            }
            else
            {
                _promena = null;
            }
        }

        private void btnPronadji_Click(object sender, EventArgs e)
        {
            OsveziTabelu();
        }

        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            txtJmbg.Text = "";
            OsveziTabelu();
        }

        private void btnAktiviraj_Click(object sender, EventArgs e)
        {
            if (_promena != null)
            {
                _promena.Reseno = false;
                _mkvData.AktivirajPromenu(_promena);
                OsveziTabelu();
            }
            else
            {
                MessageBox.Show($"Да би се активирала промена потребно је кликнути на жељену промену у табели.",
                            "Преглед промена МКВ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            if (_promena != null)
            {
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
            else
            {
                MessageBox.Show($"Да би се активирала промена потребно је кликнути на жељену промену у табели.",
                            "Преглед промена МКВ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }
    }
}
