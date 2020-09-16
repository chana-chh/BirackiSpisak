using BirackiSpisakDataManager.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BirackiSpisakDataManager.ModelsData
{
    public class MupData
    {
        public void UpisiPromeneUBazu(List<Mup> promene)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"INSERT INTO dbo.MupPodaci
                                (DatumFajla, Jmbg, DatumOdredjivanjaJmbg, Prezime, Ime, ImeRoditelja, DatumDrPrez, DatumRodjenja, Pol,
                                DrzavaRodjenja, MestoRodjenja, StranoMestoRodjenja, PrezimeLk, ImeLk, OpstinaLk, MestoLk, UlicaLk, BrojLk,
                                DodatakBrojuLk, DatumPrijaveAdrese, DatumOdjaveAdrese, DatumOtpustaIzDrzavljanstva, Status, BoravakOpstina,
                                BoravakMesto, BoravakUlica, BoravakBroj, BoravakDodatakBroju, DatumPrijaveBoravka, DatumOdjaveBoravka, JmbgStari,
                                DatumOdredjivanjaStarogJmbg, DatumPromene, VrstaPromene, Reseno, Datum, Referent)
                                VALUES
                                (@DatumFajla, @Jmbg, @DatumOdredjivanjaJmbg, @Prezime, @Ime, @ImeRoditelja, @DatumDrPrez, @DatumRodjenja, @Pol,
                                @DrzavaRodjenja, @MestoRodjenja, @StranoMestoRodjenja, @PrezimeLk, @ImeLk, @OpstinaLk, @MestoLk, @UlicaLk, @BrojLk,
                                @DodatakBrojuLk, @DatumPrijaveAdrese, @DatumOdjaveAdrese, @DatumOtpustaIzDrzavljanstva, @Status, @BoravakOpstina,
                                @BoravakMesto, @BoravakUlica, @BoravakBroj, @BoravakDodatakBroju, @DatumPrijaveBoravka, @DatumOdjaveBoravka, @JmbgStari,
                                @DatumOdredjivanjaStarogJmbg, @DatumPromene, @VrstaPromene, @Reseno, @Datum, @Referent);";

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

        public List<Mup> SveNeresenePromene()
        {
            List<Mup> NeresenePromene = new List<Mup>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MupPodaci WHERE Reseno = 0 ORDER BY Id;";
                NeresenePromene = conn.Query<Mup>(sql).ToList();
            }
            return NeresenePromene;
        }

        public List<Mup> PromenePoJmbg(string Jmbg = null)
        {
            List<Mup> Promene = new List<Mup>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT * FROM dbo.MupPodaci ORDER BY Id;";
                if (Jmbg != null)
                {
                    sql = @"SELECT * FROM dbo.MupPodaci WHERE Jmbg LIKE '%' + @Jmbg + '%' ORDER BY Id;";
                    Promene = conn.Query<Mup>(sql, new { Jmbg = Jmbg }).ToList();
                    return Promene;
                }

                Promene = conn.Query<Mup>(sql).ToList();
            }
            return Promene;
        }

        public List<Mup> SvePromene()
        {
            List<Mup> SvePromene = new List<Mup>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT TOP (1000) * FROM [BirackiSpisak].[dbo].[MupPodaci] ORDER BY DatumFajla DESC;";
                SvePromene = conn.Query<Mup>(sql).ToList();
            }
            return SvePromene;
        }

        public void ResiPromenu(Mup Promena)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"UPDATE dbo.MupPodaci SET Reseno = @Reseno, Datum = @Datum, Referent = @Referent WHERE Id = @Id;";
                var isSuccess = conn.Execute(sql, Promena);
            }
        }

        public void AktivirajPromenu(Mup Promena)
        {
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"UPDATE dbo.MupPodaci SET Reseno = 0 WHERE Id = @Id;";
                var isSuccess = conn.Execute(sql, Promena);
            }
        }

        public List<string> SviDuplikati()
        {
            List<string> duplikati = new List<string>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT *
                                FROM
                                (SELECT MupPodaci.Jmbg AS mb FROM MupPodaci WHERE Reseno = 0
                                UNION ALL
                                SELECT MkuPodaci.Jmbg AS mb FROM MkuPodaci WHERE Reseno = 0
                                UNION ALL
                                SELECT MkvPodaci.ZenikJMBG AS mb FROM MkvPodaci WHERE Reseno = 0
                                UNION ALL
                                SELECT MkvPodaci.NevestaJMBG AS mb FROM MkvPodaci WHERE Reseno = 0) AS maticni
                                GROUP BY mb
                                HAVING COUNT(*) > 1;";
                duplikati = conn.Query<string>(sql).ToList();
            }
            return duplikati;
        }

        public List<string> Duplikati()
        {
            List<string> duplikati = new List<string>();
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = @"SELECT Jmbg
                                FROM MupPodaci
                                WHERE Reseno = 0
                                GROUP BY Jmbg
                                HAVING COUNT(*) > 1;";
                duplikati = conn.Query<string>(sql).ToList();
            }
            return duplikati;
        }
    }
}
