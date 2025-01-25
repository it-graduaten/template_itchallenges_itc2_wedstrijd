
namespace ITC2Wedstrijd.Models
{
    public class Ploeg
    {
        public int Id { get; set; }
        public string Naam {  get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set;}
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public int SportId {  get; set; }
        public Sport Sport { get; set; }


    }
}
