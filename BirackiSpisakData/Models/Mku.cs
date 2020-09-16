using BirackiSpisakDataManager.Helpers;
using System;

namespace BirackiSpisakDataManager.Models
{
    public class Mku
    {
        public int Id { get; set; }
        public DateTime? DatumFajla { get; set; }
        public string Grad { get; set; }
        public string Opstina { get; set; }
        public string Knjiga { get; set; }
        public string MaticnoPodrucje { get; set; }
        public string TekuciBroj { get; set; }
        public string GodinaUpisa { get; set; }
        public string Ime { get; set; }
        public string ImeNM { get; set; }
        public string Prezime { get; set; }
        public string PrezimeNM { get; set; }
        public string PrezimePreBraka { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public DateTime? DatumSmrti { get; set; }
        public string MestoSmrti { get; set; }
        public string OpstinaSmrti { get; set; }
        public string DrzavaSmrti { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string MestoRodjenja { get; set; }
        public string OpstinaRodjenja { get; set; }
        public string DrzavaRodjenja { get; set; }
        public string Prebivaliste { get; set; }
        public string Adresa { get; set; }
        public string OtacIme { get; set; }
        public string OtacPrezime { get; set; }
        public string MajkaIme { get; set; }
        public string MajkaPrezime { get; set; }
        public string Obradjen { get; set; }
        public bool Reseno { get; set; } = false;
        public DateTime? Datum { get; set; }
        public string Referent { get; set; }

        public string Info
        {
            get { return Converter.LatToCyr($"{Id} - {Jmbg} - {Prezime} {Ime}"); }
        }

        public string PunoIme
        {
            get { return Converter.LatToCyr($"{Prezime} ({OtacIme}) {Ime}"); }
        }

        public string PunoImeNM
        {
            get { return Converter.LatToCyr($"{PrezimeNM} {ImeNM}"); }
        }

        public string PunoImeOtac
        {
            get { return Converter.LatToCyr($"{OtacPrezime} {OtacIme}"); }
        }

        public string PunoImeMajka
        {
            get { return Converter.LatToCyr($"{MajkaPrezime} {MajkaIme}"); }
        }

        public string PunoPrebivaliste
        {
            get { return Converter.LatToCyr($"{Adresa}; {Prebivaliste}"); }
        }

        public string CeoMkuZapis
        {
            get { return Converter.LatToCyr($"{Knjiga}, {MaticnoPodrucje} ({TekuciBroj}/{GodinaUpisa}) ; {Grad}, {Opstina}"); }
        }

        public string PunoMestoSmrti
        {
            get
            {
                string drz = string.IsNullOrEmpty(DrzavaSmrti) ? "" : $" ; {DrzavaSmrti}";
                return Converter.LatToCyr($"{MestoSmrti} ; {OpstinaSmrti}{drz}");
            }
        }

        public string PunoMestoRodjenja
        {
            get
            {
                string drz = string.IsNullOrEmpty(DrzavaRodjenja) ? "" : $" ; {DrzavaRodjenja}";
                return Converter.LatToCyr($"{MestoRodjenja} ; {OpstinaRodjenja}{drz}");
            }
        }

        public string GradOpstina
        {
            get { return string.IsNullOrEmpty(Grad) ? Opstina : Grad; }
        }
    }
}
