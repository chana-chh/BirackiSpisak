using System;
using System.Collections.Generic;
using System.Text;

namespace BirackiSpisakDataManager.Models
{
    public class MupStari
    {
        public int ID { get; set; }
        public DateTime? datumfajl { get; set; }
        public string JMBG { get; set; }
        public string DATUM_JMBG_OD { get; set; }
        public string PREZIME { get; set; }
        public string IME { get; set; }
        public string IME_RODIT { get; set; }
        public string DATUM_DRPREZ { get; set; }
        public string DAT_RODJ { get; set; }
        public string POL { get; set; }
        public string DRZAVA_RODJ { get; set; }
        public string MESTO_RODJ { get; set; }
        public string STRANO_MESTO_RODJ { get; set; }
        public string OPSTINA_LK { get; set; }
        public string MESTO_LK { get; set; }
        public string ULICA_LK { get; set; }
        public string BROJ_LK { get; set; }
        public string DODATAK_LK { get; set; }
        public string DATUM_ADRESA_PR_OD { get; set; }
        public string DATUM_ODJ_ADR { get; set; }
        public string LK_PREZIME { get; set; }
        public string LK_IME { get; set; }
        public string MKD_DATUM_OTP { get; set; }
        public string STATUS { get; set; }
        public string OPSTINA_BO { get; set; }
        public string MESTO_BO { get; set; }
        public string ULICA_BO { get; set; }
        public string BROJ_BO { get; set; }
        public string DODATAK_BO { get; set; }
        public string DATUM_ADRESA_BO_OD { get; set; }
        public string DATUM_ODJ_ADR_BO { get; set; }
        public string JMBG_OLD { get; set; }
        public string DATUM_JMBG_OLD_OD { get; set; }
        public string DATUM_PROMENE { get; set; }
        public string VRSTA_PROMENE { get; set; }
        public bool RESENO { get; set; }
        public DateTime? DATUM { get; set; }
        public string REFERENT { get; set; }
    }
}
