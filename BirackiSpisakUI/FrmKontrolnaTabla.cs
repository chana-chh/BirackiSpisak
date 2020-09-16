using BirackiSpisakDataManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BirackiSpisakUI
{
    public partial class FrmKontrolnaTabla : Form
    {
        private Korisnik _korisnik;

        public Korisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        public FrmKontrolnaTabla()
        {
            InitializeComponent();
        }
    }
}
