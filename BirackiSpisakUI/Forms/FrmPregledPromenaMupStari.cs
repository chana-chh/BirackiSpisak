using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmPregledPromenaMupStari : Form
    {
        private MupData _mupData = new MupData();
        private List<MupStari> _lista = new List<MupStari>();
        private MupStari _promena;

        public FrmPregledPromenaMupStari()
        {
            InitializeComponent();
            OsveziTabelu();
        }

        private void OsveziTabelu()
        {
            dgvTabela.DataSource = null;
            _lista = _mupData.StarePromenePoJmbg(txtJmbg.Text);
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
                _promena = (MupStari)dgvTabela.CurrentRow.DataBoundItem;
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

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            if (_promena != null)
            {
                string s = $"МУП подаци (стари)";
                s += $"    датум фајла:{_promena.datumfajl.Value.ToShortDateString()}    датум промене:{_promena.DATUM_PROMENE}" + Environment.NewLine;
                s += $"================================================================================" + Environment.NewLine;
                s += $"ЈМБГ: {_promena.JMBG}" + Environment.NewLine;
                s += $"Датум одређивања ЈМБГ: {_promena.DATUM_JMBG_OD}" + Environment.NewLine;
                s += $"Пол: {_promena.POL}" + Environment.NewLine;
                s += $"Статус: {_promena.STATUS}" + Environment.NewLine;
                s += $"Име: {_promena.IME} ({_promena.IME_RODIT}) {_promena.PREZIME}" + Environment.NewLine;
                s += $"Рођен/а: {_promena.DAT_RODJ} у {_promena.DRZAVA_RODJ}, {_promena.MESTO_RODJ}{_promena.STRANO_MESTO_RODJ}" + Environment.NewLine;
                s += $"ПРЕБИВАЛИШТЕ" + Environment.NewLine;
                s += $"Датум пријаве: {_promena.DATUM_ADRESA_PR_OD}    датум одјаве: {_promena.DATUM_ODJ_ADR}" + Environment.NewLine;
                s += $"Aдреса: {_promena.OPSTINA_LK}, {_promena.MESTO_LK}, {_promena.ULICA_LK} {_promena.BROJ_LK} {_promena.DODATAK_LK}" + Environment.NewLine;
                s += $"БОРАВИШТЕ" + Environment.NewLine;
                s += $"Датум пријаве: {_promena.DATUM_ADRESA_BO_OD}    датум одјаве: {_promena.DATUM_ODJ_ADR_BO}" + Environment.NewLine;
                s += $"Aдреса: {_promena.OPSTINA_BO}, {_promena.MESTO_BO}, {_promena.ULICA_BO} {_promena.BROJ_BO} {_promena.DODATAK_BO}" + Environment.NewLine;
                s += $"Промена: {_promena.VRSTA_PROMENE}";

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
