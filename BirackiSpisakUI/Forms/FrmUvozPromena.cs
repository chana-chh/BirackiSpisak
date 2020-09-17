using BirackiSpisakDataManager.Helpers;
using BirackiSpisakDataManager.Models;
using BirackiSpisakDataManager.ModelsData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BirackiSpisakUI.Forms
{
    public partial class FrmUvozPromena : Form
    {
        private MupData _mupData { get; set; } = new MupData();
        private MkuData _mkuData { get; set; } = new MkuData();
        private MkvData _mkvData { get; set; } = new MkvData();

        private List<Mup> _promeneMUP { get; set; }
        private List<Mku> _promeneMKU { get; set; }
        private List<Mkv> _promeneMKV { get; set; }

        public FrmUvozPromena()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMupUvoz_Click(object sender, EventArgs e)
        {
            string putanjaZaPromene = ConfigurationManager.AppSettings["PutanjaZaPromeneMUP"];
            string nazivFajla = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Одабери фајл са променама МУП-а";
            ofd.Filter = "Excel | *.xlsx";
            ofd.InitialDirectory = putanjaZaPromene;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                nazivFajla = ofd.SafeFileName;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string putanjaExcelFajla = $"{putanjaZaPromene}\\{nazivFajla}";
                    _promeneMUP = Excel.ImportMup(putanjaExcelFajla);
                    _mupData.UpisiPromeneUBazu(_promeneMUP);
                    _promeneMUP.Clear();

                    string putanjaZaObradjenePromene = $"{putanjaZaPromene}\\obradjeno\\{nazivFajla}";

                    try
                    {
                        if (File.Exists(putanjaExcelFajla))
                        {
                            if (File.Exists(putanjaZaObradjenePromene))
                            {
                                File.Delete(putanjaZaObradjenePromene);
                            }
                            File.Move(putanjaExcelFajla, putanjaZaObradjenePromene);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Дошло је до грешке приликом премештања Excel фајла.{Environment.NewLine}{ex.Message}",
                        "МУП промене",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Нове промене су успешно уписане.",
                    "МУП промене",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show($"Нове промене нису уписане у базу.{Environment.NewLine}{ex.Message}",
                    "МУП промене",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnMkuUvoz_Click(object sender, EventArgs e)
        {
            string putanjaZaPromene = ConfigurationManager.AppSettings["PutanjaZaPromeneMKU"];
            string nazivFajla = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Одабери фајл са променама МКУ";
            ofd.Filter = "Excel | *.xlsx";
            ofd.InitialDirectory = putanjaZaPromene;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                nazivFajla = ofd.SafeFileName;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string putanjaExcelFajla = $"{putanjaZaPromene}\\{nazivFajla}";
                    _promeneMKU = Excel.ImportMku(putanjaExcelFajla);
                    _mkuData.UpisiPromeneUBazu(_promeneMKU);
                    _promeneMKU.Clear();

                    string putanjaZaObradjenePromene = $"{putanjaZaPromene}\\obradjeno\\{nazivFajla}";

                    try
                    {
                        if (File.Exists(putanjaExcelFajla))
                        {
                            if (File.Exists(putanjaZaObradjenePromene))
                            {
                                File.Delete(putanjaZaObradjenePromene);
                            }
                            File.Move(putanjaExcelFajla, putanjaZaObradjenePromene);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Дошло је до грешке приликом премештања Excel фајла.{Environment.NewLine}{ex.Message}",
                        "МКУ промене",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Нове промене су успешно уписане.",
                    "МКУ промене",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show($"Нове промене нису уписане у базу.{Environment.NewLine}{ex.Message}",
                    "МКУ промене",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnMkvUvoz_Click(object sender, EventArgs e)
        {
            string putanjaZaPromene = ConfigurationManager.AppSettings["PutanjaZaPromeneMKV"];
            string nazivFajla = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Одабери фајл са променама МКВ";
            ofd.Filter = "Excel | *.xlsx";
            ofd.InitialDirectory = putanjaZaPromene;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                nazivFajla = ofd.SafeFileName;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string putanjaExcelFajla = $"{putanjaZaPromene}\\{nazivFajla}";
                    _promeneMKV = Excel.ImportMkv(putanjaExcelFajla);
                    _mkvData.UpisiPromeneUBazu(_promeneMKV);
                    _promeneMKV.Clear();

                    string putanjaZaObradjenePromene = $"{putanjaZaPromene}\\obradjeno\\{nazivFajla}";

                    try
                    {
                        if (File.Exists(putanjaExcelFajla))
                        {
                            if (File.Exists(putanjaZaObradjenePromene))
                            {
                                File.Delete(putanjaZaObradjenePromene);
                            }
                            File.Move(putanjaExcelFajla, putanjaZaObradjenePromene);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Дошло је до грешке приликом премештања Excel фајла.{Environment.NewLine}{ex.Message}",
                        "МКВ промене",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Нове промене су успешно уписане.",
                    "МКВ промене",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show($"Нове промене нису уписане у базу.{Environment.NewLine}{ex.Message}",
                    "МКВ промене",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnMupDupli_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            var duplikati = _mupData.Duplikati();

            foreach (var d in duplikati)
            {
                sb.Append($"{d}{Environment.NewLine}");
            }

            if (sb.Length == 0)
            {
                MessageBox.Show("Нема дупликата", "Провера дупликата МУП", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sb.ToString(), "Провера дупликата МУП", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSviDupli_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            var duplikati = _mupData.SviDuplikati();

            foreach (var d in duplikati)
            {
                sb.Append($"{d}{Environment.NewLine}");
            }

            if (sb.Length == 0)
            {
                MessageBox.Show("Нема дупликата", "Провера дупликата МУП, МКУ, МКВ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sb.ToString(), "Провера дупликата МУП, МКУ, МКВ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
