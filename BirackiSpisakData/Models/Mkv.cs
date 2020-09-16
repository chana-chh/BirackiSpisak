using BirackiSpisakDataManager.Helpers;
using System;

namespace BirackiSpisakDataManager.Models
{
    public class Mkv
    {
        public int Id { get; set; }
        public DateTime? DatumFajla { get; set; }
        public string Grad { get; set; }
        public string Opstina { get; set; }
        public string Knjiga { get; set; }
        public string MaticnoPodrucje { get; set; }
        public string TekuciBroj { get; set; }
        public string GodinaUpisa { get; set; }
        public string MestoZakljucenjaBraka { get; set; }
        public DateTime? DatumZakljucenjaBraka { get; set; }
        public string ZenikIme { get; set; }
        public string ZenikImeNM { get; set; }
        public string ZenikPrezime { get; set; }
        public string ZenikPrezimeNM { get; set; }
        public string ZenikPrezimeOdabrano { get; set; }
        public string ZenikPrezimeOdabranoNM { get; set; }
        public string ZenikJmbg { get; set; }
        public DateTime? ZenikDatumRodjenja { get; set; }
        public string ZenikPrebivaliste { get; set; }
        public string NevestaIme { get; set; }
        public string NevestaImeNM { get; set; }
        public string NevestaPrezime { get; set; }
        public string NevestaPrezimeNM { get; set; }
        public string NevestaPrezimeOdabrano { get; set; }
        public string NevestaPrezimeOdabranoNM { get; set; }
        public string NevestaJmbg { get; set; }
        public DateTime? NevestaDatumRodjenja { get; set; }
        public string NevestaPrebivaliste { get; set; }
        public string Obradjen { get; set; }
        public bool Reseno { get; set; } = false;
        public DateTime? Datum { get; set; }
        public string Referent { get; set; }

        public string Info
        {
            get
            {
                if (!ZenikPrezime.Equals(ZenikPrezimeOdabrano))
                {
                    return Converter.LatToCyr($"{Id} - {ZenikJmbg} - {ZenikPrezimeOdabrano} {ZenikIme}");
                }
                else
                {
                    return Converter.LatToCyr($"{Id} - {NevestaJmbg} - {NevestaPrezimeOdabrano} {NevestaIme}");
                }

            }
        }

        public string ZenikPunoIme
        {
            get { return Converter.LatToCyr($"{ZenikPrezime} {ZenikIme}"); }
        }

        public string ZenikPunoImeOdabrano
        {
            get { return Converter.LatToCyr($"{ZenikPrezimeOdabrano} {ZenikIme}"); }
        }

        public string ZenikPunoImeNM
        {
            get { return $"{ZenikPrezimeOdabranoNM} {ZenikImeNM}"; }
        }

        public string NevestaPunoIme
        {
            get { return Converter.LatToCyr($"{NevestaPrezime} {NevestaIme}"); }
        }

        public string NevestaPunoImeOdabrano
        {
            get { return Converter.LatToCyr($"{NevestaPrezimeOdabrano} {NevestaIme}"); }
        }

        public string NevestaPunoImeNM
        {
            get { return $"{NevestaPrezimeOdabranoNM} {NevestaImeNM}"; }
        }

        public string CeoMkvZapis
        {
            get { return Converter.LatToCyr($"{Knjiga}, {MaticnoPodrucje} ({TekuciBroj}/{GodinaUpisa}) ; {Grad}, {Opstina}"); }
        }

        public string GradOpstina
        {
            get { return string.IsNullOrEmpty(Grad) ? Opstina : Grad; }
        }
    }
}
