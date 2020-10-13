using BirackiSpisakDataManager.Helpers;
using System;

namespace BirackiSpisakDataManager.Models
{
    public class Mup
    {
        public int Id { get; set; }
        public DateTime? DatumFajla { get; set; }
        public string Jmbg { get; set; }
        public DateTime? DatumOdredjivanjaJmbg { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string ImeRoditelja { get; set; }
        public DateTime? DatumDrPrez { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string Pol { get; set; }
        public string DrzavaRodjenja { get; set; }
        public string MestoRodjenja { get; set; }
        public string StranoMestoRodjenja { get; set; }
        public string PrezimeLk { get; set; }
        public string ImeLk { get; set; }
        public string OpstinaLk { get; set; }
        public string MestoLk { get; set; }
        public string UlicaLk { get; set; }
        public string BrojLk { get; set; }
        public string DodatakBrojuLk { get; set; }
        public DateTime? DatumPrijaveAdrese { get; set; }
        public DateTime? DatumOdjaveAdrese { get; set; }
        public DateTime? DatumOtpustaIzDrzavljanstva { get; set; }
        public string Status { get; set; }
        public string BoravakOpstina { get; set; }
        public string BoravakMesto { get; set; }
        public string BoravakUlica { get; set; }
        public string BoravakBroj { get; set; }
        public string BoravakDodatakBroju { get; set; }
        public DateTime? DatumPrijaveBoravka { get; set; }
        public DateTime? DatumOdjaveBoravka { get; set; }
        public string JmbgStari { get; set; }
        public DateTime? DatumOdredjivanjaStarogJmbg { get; set; }
        public DateTime? DatumPromene { get; set; }
        public string VrstaPromene { get; set; }
        public bool Reseno { get; set; } = false;
        public DateTime? Datum { get; set; }
        public string Referent { get; set; }

        public string Info
        {
            get { return Converter.LatToCyr($"{Id} - {Jmbg} - {Prezime} ({ImeRoditelja}) {Ime}"); }
        }

        public string PunoIme
        {
            get { return Converter.LatToCyr($"{Prezime} ({ImeRoditelja}) {Ime}"); }
        }

        public string PunoImeLk
        {
            get { return $"{PrezimeLk} {ImeLk}"; }
        }

        public string PunoPrebivaliste
        {
            get
            {
                string ulica = string.IsNullOrEmpty(UlicaLk.Trim()) ? "" : $"{UlicaLk} ";
                string broj = string.IsNullOrEmpty(BrojLk.Trim()) ? "" : $"{BrojLk}";
                string slovo = string.IsNullOrEmpty(DodatakBrojuLk.Trim()) ? "" : $" / {DodatakBrojuLk}";
                string mesto = string.IsNullOrEmpty(MestoLk.Trim()) ? "" : $" ; {MestoLk}";
                string opstina = string.IsNullOrEmpty(OpstinaLk.Trim()) ? "" : $" ; {OpstinaLk}";
                ulica = UlicaLk.Equals("NEMA ULICE") ? $"{MestoLk} " : ulica;
                broj = BrojLk.Equals("BB") ? "0" : broj;

                return Converter.LatToCyr($"{ulica}{broj}{slovo}{mesto}{opstina}");
            }
        }

        public string PunoBoraviste
        {
            get
            {
                if (string.IsNullOrEmpty(BoravakUlica))
                {
                    return "";
                }
                return Converter.LatToCyr($"{BoravakUlica} {BoravakBroj} - {BoravakDodatakBroju}; {BoravakMesto}; {BoravakOpstina}");
            }
        }

        public string PunoMestoRodjenja
        {
            get
            {
                string mesto = string.IsNullOrEmpty(MestoRodjenja.Trim()) ? "" : $"{Converter.LatToCyr(MestoRodjenja)}, ";
                string drzava = string.IsNullOrEmpty(DrzavaRodjenja.Trim()) ? "" : $"{Converter.LatToCyr(DrzavaRodjenja)}";
                string strano = string.IsNullOrEmpty(StranoMestoRodjenja.Trim()) ? "" : $", {StranoMestoRodjenja}";
                return $"{mesto}{drzava}{strano}";
            }
        }

        public string GradOpstina
        {
            get { return Converter.LatToCyr(string.IsNullOrEmpty(MestoLk) ? OpstinaLk : MestoLk); }
        }
    }
}
