using System;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmPregledPromena : Form
    {
        public FrmPregledPromena()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPregledMup_Click(object sender, EventArgs e)
        {
            FrmPregledPromenaMup forma = new FrmPregledPromenaMup();
            forma.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPregledPromenaMku forma = new FrmPregledPromenaMku();
            forma.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPregledPromenaMkv forma = new FrmPregledPromenaMkv();
            forma.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmPregledPromenaMupStari forma = new FrmPregledPromenaMupStari();
            forma.ShowDialog();
        }
    }
}
