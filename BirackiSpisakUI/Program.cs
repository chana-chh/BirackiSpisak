using System;
using System.Threading;
using System.Windows.Forms;

namespace BirackiSpisakUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            const string mutexIme = "BSK";

            _ = new Mutex(true, mutexIme, out bool jePrvaInstanca);

            if (!jePrvaInstanca)
            {
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmPrijavaKorisnika formaZaPrijavu = new FrmPrijavaKorisnika();
            formaZaPrijavu.Show();

            Application.Run();
        }
    }
}
