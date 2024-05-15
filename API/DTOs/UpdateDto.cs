namespace API.DTOs
{
    public class UpdateDto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string Sifra { get; set; }

        public double Cijena { get; set; }

        public string Proizvodac { get; set; }
    }
}
