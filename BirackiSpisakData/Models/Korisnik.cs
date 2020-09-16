namespace BirackiSpisakDataManager.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public bool Admin { get; set; }
        public string PunoIme
        {
            get { return $"{Ime} {Prezime}"; }
        }
    }
}
