using System;
using System.Collections.Generic;
using System.Text;

namespace BirackiSpisakLibrary
{
    public static class Excel
    {
        public static List<Mup> PreuzmiMupPromene(string putanjaExcelFajla)
        {
            List<Mup> promene = new List<Mup>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string datumFajla = putanjaExcelFajla.Substring(putanjaExcelFajla.Length - 15, 10);

            using (var stream = File.Open(putanjaExcelFajla, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool pocetniRed = true;
                    do
                    {
                        while (reader.Read())
                        {
                            if (!pocetniRed)
                            {
                                promene.Add(new Mup
                                {
                                    DatumFajla = Datumi.TekstUDatum(datumFajla),
                                    Jmbg = reader.GetValue(0).ToString().Trim(),
                                    DatumOdredjivanjaJmbg = Datumi.TekstUDatum(reader.GetValue(1).ToString().Trim()),
                                    Prezime = reader.GetValue(2).ToString().Trim().ToUpper(),
                                    Ime = reader.GetValue(3).ToString().Trim().ToUpper(),
                                    ImeRoditelja = reader.GetValue(4).ToString().Trim().ToUpper(),
                                    DatumDrPrez = Datumi.TekstUDatum(reader.GetValue(5).ToString().Trim()),
                                    DatumRodjenja = Datumi.TekstUDatum(reader.GetValue(6).ToString().Trim()),
                                    Pol = reader.GetValue(7).ToString().Trim().ToUpper(),
                                    DrzavaRodjenja = reader.GetValue(8).ToString().Trim().ToUpper(),
                                    MestoRodjenja = reader.GetValue(9).ToString().Trim().ToUpper(),
                                    StranoMestoRodjenja = reader.GetValue(10).ToString().Trim().ToUpper(),
                                    OpstinaLk = reader.GetValue(11).ToString().Trim().ToUpper(),
                                    MestoLk = reader.GetValue(12).ToString().Trim().ToUpper(),
                                    UlicaLk = reader.GetValue(13).ToString().Trim().ToUpper(),
                                    BrojLk = reader.GetValue(14).ToString().Trim().ToUpper(),
                                    DodatakBrojuLk = reader.GetValue(15).ToString().Trim().ToUpper(),
                                    DatumPrijaveAdrese = Datumi.TekstUDatum(reader.GetValue(16).ToString().Trim()),
                                    DatumOdjaveAdrese = Datumi.TekstUDatum(reader.GetValue(17).ToString().Trim()),
                                    PrezimeLk = reader.GetValue(18).ToString().Trim().ToUpper(),
                                    ImeLk = reader.GetValue(19).ToString().Trim().ToUpper(),
                                    DatumOtpustaIzDrzavljanstva = Datumi.TekstUDatum(reader.GetValue(20).ToString().Trim()),
                                    Status = reader.GetValue(21).ToString().Trim().ToUpper(),
                                    BoravakOpstina = reader.GetValue(22).ToString().Trim().ToUpper(),
                                    BoravakMesto = reader.GetValue(23).ToString().Trim().ToUpper(),
                                    BoravakUlica = reader.GetValue(24).ToString().Trim().ToUpper(),
                                    BoravakBroj = reader.GetValue(25).ToString().Trim().ToUpper(),
                                    BoravakDodatakBroju = reader.GetValue(26).ToString().Trim().ToUpper(),
                                    DatumPrijaveBoravka = Datumi.TekstUDatum(reader.GetValue(27).ToString().Trim()),
                                    DatumOdjaveBoravka = Datumi.TekstUDatum(reader.GetValue(28).ToString().Trim()),
                                    JmbgStari = reader.GetValue(29).ToString().Trim(),
                                    DatumOdredjivanjaStarogJmbg = Datumi.TekstUDatum(reader.GetValue(30).ToString().Trim()),
                                    DatumPromene = Datumi.TekstUDatum(reader.GetValue(31).ToString().Trim()),
                                    VrstaPromene = reader.GetValue(32).ToString().Trim().ToUpper(),
                                    Reseno = false,
                                    Datum = null,
                                    Referent = null,
                                });
                            }
                            pocetniRed = false;
                        }
                    } while (reader.NextResult());
                }
            }

            return promene;
        }

        public static List<MkuModel> PreuzmiMkuPromene(string putanjaExcelFajla)
        {
            List<MkuModel> promene = new List<MkuModel>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string datumFajla = putanjaExcelFajla.Substring(putanjaExcelFajla.Length - 15, 10);

            using (var stream = File.Open(putanjaExcelFajla, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool pocetniRed = true;
                    do
                    {
                        while (reader.Read())
                        {
                            if (!pocetniRed)
                            {
                                string ds = $"{reader.GetValue(13)}.{reader.GetValue(14)}.{reader.GetValue(15)}";
                                string dr = $"{reader.GetValue(19)}.{reader.GetValue(20)}.{reader.GetValue(21)}";

                                promene.Add(new MkuModel
                                {
                                    DatumFajla = Datumi.TekstUDatum(datumFajla),
                                    Grad = reader.GetValue(0).ToString().Trim().ToUpper(),
                                    Opstina = reader.GetValue(1).ToString().Trim().ToUpper(),
                                    Knjiga = reader.GetValue(2).ToString().Trim().ToUpper(),
                                    MaticnoPodrucje = reader.GetValue(3).ToString().Trim().ToUpper(),
                                    TekuciBroj = reader.GetValue(4).ToString().Trim(),
                                    GodinaUpisa = reader.GetValue(5).ToString().Trim(),
                                    Ime = reader.GetValue(6).ToString().Trim().ToUpper(),
                                    ImeNM = reader.GetValue(7).ToString().Trim().ToUpper(),
                                    Prezime = reader.GetValue(8).ToString().Trim().ToUpper(),
                                    PrezimeNM = reader.GetValue(9).ToString().Trim().ToUpper(),
                                    PrezimePreBraka = reader.GetValue(10).ToString().Trim().ToUpper(),
                                    Pol = reader.GetValue(11).ToString().Trim().ToUpper(),
                                    Jmbg = reader.GetValue(12).ToString().Trim(),
                                    DatumSmrti = Datumi.TekstUDatum(ds.ToString().Trim()),
                                    MestoSmrti = reader.GetValue(16).ToString().Trim().ToUpper(),
                                    OpstinaSmrti = reader.GetValue(17).ToString().Trim().ToUpper(),
                                    DrzavaSmrti = reader.GetValue(18).ToString().Trim().ToUpper(),
                                    DatumRodjenja = Datumi.TekstUDatum(dr.ToString().Trim()),
                                    MestoRodjenja = reader.GetValue(22).ToString().Trim().ToUpper(),
                                    OpstinaRodjenja = reader.GetValue(23).ToString().Trim().ToUpper(),
                                    DrzavaRodjenja = reader.GetValue(24).ToString().Trim().ToUpper(),
                                    Prebivaliste = reader.GetValue(25).ToString().Trim().ToUpper(),
                                    Adresa = reader.GetValue(26).ToString().Trim().ToUpper(),
                                    OtacIme = reader.GetValue(27).ToString().Trim().ToUpper(),
                                    OtacPrezime = reader.GetValue(28).ToString().Trim().ToUpper(),
                                    MajkaIme = reader.GetValue(29).ToString().Trim().ToUpper(),
                                    MajkaPrezime = reader.GetValue(30).ToString().Trim().ToUpper(),
                                    Obradjen = reader.GetValue(31).ToString().Trim().ToUpper(),
                                    Reseno = false,
                                    Datum = null,
                                    Referent = null,
                                });
                            }
                            pocetniRed = false;
                        }
                    } while (reader.NextResult());
                }
            }

            return promene;
        }

        public static List<MkvModel> PreuzmiMkvPromene(string putanjaExcelFajla)
        {
            List<MkvModel> promene = new List<MkvModel>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string datumFajla = putanjaExcelFajla.Substring(putanjaExcelFajla.Length - 15, 10);

            using (var stream = File.Open(putanjaExcelFajla, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    bool pocetniRed = true;
                    do
                    {
                        while (reader.Read())
                        {
                            if (!pocetniRed)
                            {
                                promene.Add(new MkvModel
                                {
                                    DatumFajla = Datumi.TekstUDatum(datumFajla),
                                    Grad = reader.GetValue(0).ToString().Trim().ToUpper(),
                                    Opstina = reader.GetValue(1).ToString().Trim().ToUpper(),
                                    Knjiga = reader.GetValue(2).ToString().Trim().ToUpper(),
                                    MaticnoPodrucje = reader.GetValue(3).ToString().Trim().ToUpper(),
                                    TekuciBroj = reader.GetValue(4).ToString().Trim(),
                                    GodinaUpisa = reader.GetValue(5).ToString().Trim(),
                                    MestoZakljucenjaBraka = reader.GetValue(6).ToString().Trim().ToUpper(),
                                    DatumZakljucenjaBraka = Datumi.TekstUDatum(reader.GetValue(7).ToString().Trim()),
                                    ZenikIme = reader.GetValue(8).ToString().Trim().ToUpper(),
                                    ZenikImeNM = reader.GetValue(9).ToString().Trim().ToUpper(),
                                    ZenikPrezime = reader.GetValue(10).ToString().Trim().ToUpper(),
                                    ZenikPrezimeNM = reader.GetValue(11).ToString().Trim().ToUpper(),
                                    ZenikPrezimeOdabrano = reader.GetValue(12).ToString().Trim().ToUpper(),
                                    ZenikPrezimeOdabranoNM = reader.GetValue(13).ToString().Trim().ToUpper(),
                                    ZenikJmbg = reader.GetValue(14).ToString().Trim(),
                                    ZenikDatumRodjenja = Datumi.TekstUDatum(reader.GetValue(15).ToString().Trim()),
                                    ZenikPrebivaliste = reader.GetValue(16).ToString().Trim().ToUpper(),
                                    NevestaIme = reader.GetValue(17).ToString().Trim().ToUpper(),
                                    NevestaImeNM = reader.GetValue(18).ToString().Trim().ToUpper(),
                                    NevestaPrezime = reader.GetValue(19).ToString().Trim().ToUpper(),
                                    NevestaPrezimeNM = reader.GetValue(20).ToString().Trim().ToUpper(),
                                    NevestaPrezimeOdabrano = reader.GetValue(21).ToString().Trim().ToUpper(),
                                    NevestaPrezimeOdabranoNM = reader.GetValue(22).ToString().Trim().ToUpper(),
                                    NevestaJmbg = reader.GetValue(23).ToString().Trim(),
                                    NevestaDatumRodjenja = Datumi.TekstUDatum(reader.GetValue(24).ToString().Trim()),
                                    NevestaPrebivaliste = reader.GetValue(25).ToString().Trim().ToUpper(),
                                    Obradjen = reader.GetValue(26).ToString().Trim().ToUpper(),
                                    Reseno = false,
                                    Datum = null,
                                    Referent = null,
                                });
                            }
                            pocetniRed = false;
                        }
                    } while (reader.NextResult());
                }
            }

            return promene;
        }
    }
}
