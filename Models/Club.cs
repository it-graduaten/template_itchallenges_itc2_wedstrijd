
namespace ITC2Wedstrijd.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public string Naam { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Club club && ClubId == club.ClubId;
        }
    }
}
