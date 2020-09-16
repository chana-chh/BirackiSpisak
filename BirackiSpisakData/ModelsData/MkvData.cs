using BirackiSpisakDataManager.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirackiSpisakDataManager.ModelsData
{
    public class MkvData
    {
        public void UpisiPromeneUBazu(List<Mkv> promene)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"INSERT INTO dbo.MkvPodaci
                                (DatumFajla, Grad, Opstina, Knjiga, MaticnoPodrucje, TekuciBroj, GodinaUpisa, MestoZakljucenjaBraka, DatumZakljucenjaBraka,
                                ZenikIme, ZenikImeNM, ZenikPrezime, ZenikPrezimeNM, ZenikPrezimeOdabrano, ZenikPrezimeOdabranoNM,
                                ZenikJmbg, ZenikDatumRodjenja, ZenikPrebivaliste,
                                NevestaIme, NevestaImeNM, NevestaPrezime, NevestaPrezimeNM, NevestaPrezimeOdabrano, NevestaPrezimeOdabranoNM,
                                NevestaJmbg, NevestaDatumRodjenja, NevestaPrebivaliste, Obradjen, Reseno, Datum, Referent)
                                VALUES
                                (@DatumFajla, @Grad, @Opstina, @Knjiga, @MaticnoPodrucje, @TekuciBroj, @GodinaUpisa, @MestoZakljucenjaBraka, @DatumZakljucenjaBraka,
                                @ZenikIme, @ZenikImeNM, @ZenikPrezime, @ZenikPrezimeNM, @ZenikPrezimeOdabrano, @ZenikPrezimeOdabranoNM,
                                @ZenikJmbg, @ZenikDatumRodjenja, @ZenikPrebivaliste,
                                @NevestaIme, @NevestaImeNM, @NevestaPrezime, @NevestaPrezimeNM, @NevestaPrezimeOdabrano, @NevestaPrezimeOdabranoNM,
                                @NevestaJmbg, @NevestaDatumRodjenja, @NevestaPrebivaliste, @Obradjen, @Reseno, @Datum, @Referent);";

                using (var trans = conn.BeginTransaction())
                {
                    foreach (var pr in promene)
                    {
                        conn.Execute(sql, pr, transaction: trans);
                    }
                    trans.Commit();
                }
            }
        }

        public List<Mkv> SveNeresenePromene()
        {
            List<Mkv> NeresenePromene = new List<Mkv>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MkvPodaci WHERE Reseno = 0 ORDER BY Id;";
                NeresenePromene = conn.Query<Mkv>(sql).ToList();
            }
            return NeresenePromene;
        }

        public List<Mkv> SvePromene()
        {
            List<Mkv> SvePromene = new List<Mkv>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MkvPodaci ORDER BY Id;";
                SvePromene = conn.Query<Mkv>(sql).ToList();
            }
            return SvePromene;
        }

        public List<Mkv> PromenePoJmbg(string Jmbg = null)
        {
            List<Mkv> Promene = new List<Mkv>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MkvPodaci ORDER BY Id;";
                if (Jmbg != null)
                {
                    sql = @"SELECT * FROM dbo.MkvPodaci WHERE ZenikJMBG LIKE '%' + @Jmbg + '%' OR NevestaJMBG LIKE '%' + @Jmbg + '%' ORDER BY Id;";
                    Promene = conn.Query<Mkv>(sql, new { Jmbg = Jmbg }).ToList();
                    return Promene;
                }

                Promene = conn.Query<Mkv>(sql).ToList();
            }
            return Promene;
        }

        public void AktivirajPromenu(Mkv Promena)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                using (var connection = Db.Conn("BirackiSpisak"))
                {
                    conn.Open();
                    string sql = @"UPDATE dbo.MkvPodaci SET Reseno = 0 WHERE Id = @Id;";
                    var isSuccess = conn.Execute(sql, Promena);
                }
            }
        }

        public void ResiPromenu(Mkv Promena)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                using (var connection = Db.Conn("BirackiSpisak"))
                {
                    conn.Open();
                    string sql = @"UPDATE dbo.MkvPodaci SET Reseno = @Reseno, Datum = @Datum, Referent = @Referent WHERE Id = @Id;";
                    var isSuccess = conn.Execute(sql, Promena);
                }
            }
        }
    }
}
