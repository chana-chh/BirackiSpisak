using BirackiSpisakDataManager.Models;
using Dapper;

namespace BirackiSpisakDataManager.ModelsData
{
    public class KorisnikData
    {
        public Korisnik KorisnikPoKorisnickomImenu(string korisnickoIme)
        {
            Korisnik Korisnik = new Korisnik();
            string sql = @"SELECT * FROM dbo.Korisnici WHERE KorisnickoIme = @ime;";
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@ime", korisnickoIme);
                conn.Open();
                Korisnik = conn.QuerySingleOrDefault<Korisnik>(sql, p);
            }
            return Korisnik;
        }

        public int Dodaj(Korisnik korisnik)
        {
            int id = 0;
            using (var conn = Db.Conn("BirackiSpisak"))
            {
                conn.Open();
                string sql = "INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, Admin)" +
                                "VALUES (@Ime, @Prezime, @KorisnickoIme, @Lozinka, @Admin);" +
                                "SELECT CAST(SCOPE_IDENTITY() as int);";
                id = conn.QuerySingle<int>(sql, korisnik);
            }
            return id;
        }
    }
}
