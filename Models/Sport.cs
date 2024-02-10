

namespace ITC2Wedstrijd.Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Naam {  get; set; }

        public override bool Equals(object obj)
        {
            return obj is Sport sport && SportId == sport.SportId;
        }
    }
}
