using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmPregledPromenaMku : Form
    {
        private MkuData _mkuData = new MkuData();
        private List<Mku> _lista = new List<Mku>();
        private Mku _promena;

        public FrmPregledPromenaMku()
        {
            InitializeComponent();
            OsveziTabelu();
        }

        private void OsveziTabelu()
        {
            dgvTabela.DataSource = null;
            _lista = _mkuData.PromenePoJmbg(txtJmbg.Text);
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
                _promena = (Mku)dgvTabela.CurrentRow.DataBoundItem;
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
                _mkuData.AktivirajPromenu(_promena);
                OsveziTabelu();
            }
            else
            {
                MessageBox.Show($"Да би се активирала промена потребно је кликнути на жељену промену у табели.",
                            "Преглед промена МКУ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            if (_promena != null)
            {
                string s = $"МКУ подаци";
                s += $"        датум фајла:{_promena.DatumFajla.Value.ToShortDateString()}" + Environment.NewLine;
                s += $"================================================================================" + Environment.NewLine;
                s += $"ЈМБГ: {_promena.Jmbg}" + Environment.NewLine;
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
            else
            {
                MessageBox.Show($"Да би се активирала промена потребно је кликнути на жељену промену у табели.",
                            "Преглед промена МКУ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }
    }
}
