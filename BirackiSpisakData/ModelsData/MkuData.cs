using BirackiSpisakDataManager.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BirackiSpisakDataManager.ModelsData
{
    public class MkuData
    {
        public void UpisiPromeneUBazu(List<Mku> promene)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"INSERT INTO dbo.MkuPodaci
                                (DatumFajla, Grad, Opstina, Knjiga, MaticnoPodrucje, TekuciBroj, GodinaUpisa, Ime, ImeNM, Prezime, PrezimeNM,
                                PrezimePreBraka, Pol, Jmbg, DatumSmrti, MestoSmrti, OpstinaSmrti, DatumRodjenja, MestoRodjenja, OpstinaRodjenja, DrzavaRodjenja,
                                Prebivaliste, Adresa, OtacIme, OtacPrezime, MajkaIme, MajkaPrezime, Obradjen, Reseno, Datum, Referent)
                                VALUES
                                (@DatumFajla, @Grad, @Opstina, @Knjiga, @MaticnoPodrucje, @TekuciBroj, @GodinaUpisa, @Ime, @ImeNM, @Prezime, @PrezimeNM,
                                @PrezimePreBraka, @Pol, @Jmbg, @DatumSmrti, @MestoSmrti, @OpstinaSmrti, @DatumRodjenja, @MestoRodjenja, @OpstinaRodjenja, @DrzavaRodjenja,
                                @Prebivaliste, @Adresa, @OtacIme, @OtacPrezime, @MajkaIme, @MajkaPrezime, @Obradjen, @Reseno, @Datum, @Referent);";

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

        public List<Mku> SveNeresenePromene()
        {
            List<Mku> NeresenePromene = new List<Mku>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MkuPodaci WHERE Reseno = 0 ORDER BY Id;";
                NeresenePromene = conn.Query<Mku>(sql).ToList();
            }
            return NeresenePromene;
        }

        public List<Mku> SvePromene()
        {
            List<Mku> SvePromene = new List<Mku>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MkuPodaci ORDER BY Id;";
                SvePromene = conn.Query<Mku>(sql).ToList();
            }
            return SvePromene;
        }

        public List<Mku> PromenePoJmbg(string Jmbg = null)
        {
            List<Mku> Promene = new List<Mku>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MkuPodaci ORDER BY Id;";
                if (Jmbg != null)
                {
                    sql = @"SELECT * FROM dbo.MkuPodaci WHERE Jmbg LIKE '%' + @Jmbg + '%' ORDER BY Id;";
                    Promene = conn.Query<Mku>(sql, new { Jmbg = Jmbg }).ToList();
                    return Promene;
                }

                Promene = conn.Query<Mku>(sql).ToList();
            }
            return Promene;
        }

        public void AktivirajPromenu(Mku Promena)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                using (var connection = Db.Conn("BirackiSpisak"))
                {
                    conn.Open();
                    string sql = @"UPDATE dbo.MkuPodaci SET Reseno = 0 WHERE Id = @Id;";
                    var isSuccess = conn.Execute(sql, Promena);
                }
            }
        }

        public void ResiPromenu(Mku Promena)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                using (var connection = Db.Conn("BirackiSpisak"))
                {
                    conn.Open();
                    string sql = @"UPDATE dbo.MkuPodaci SET Reseno = @Reseno, Datum = @Datum, Referent = @Referent WHERE Id = @Id;";
                    var isSuccess = conn.Execute(sql, Promena);
                }
            }
        }
    }
}
