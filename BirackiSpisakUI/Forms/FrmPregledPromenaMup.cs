using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmPregledPromenaMup : Form
    {
        private MupData _mupData = new MupData();
        private List<Mup> _lista = new List<Mup>();
        private Mup _promena;

        public FrmPregledPromenaMup()
        {
            InitializeComponent();
            OsveziTabelu();
        }

        private void OsveziTabelu()
        {
            dgvTabela.DataSource = null;
            _lista = _mupData.PromenePoJmbg(txtJmbg.Text);
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
                _promena = (Mup)dgvTabela.CurrentRow.DataBoundItem;
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
                _mupData.AktivirajPromenu(_promena);
                OsveziTabelu();
            }
            else
            {
                MessageBox.Show($"Да би се активирала промена потребно је кликнути на жељену промену у табели.",
                            "Преглед промена МУП",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            if (_promena != null)
            {
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
            else
            {
                MessageBox.Show($"Да би се активирала промена потребно је кликнути на жељену промену у табели.",
                            "Преглед промена МУП",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }
    }
}
