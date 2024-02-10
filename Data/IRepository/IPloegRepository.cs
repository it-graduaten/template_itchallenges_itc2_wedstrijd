

namespace ITC2Wedstrijd.Data
{
    public interface IPloegRepository
    {
        public IEnumerable<Ploeg> PloegOphalen();

        
        bool ToevoegenPloeg(Ploeg ploeg);
        bool WijzigenPloeg(Ploeg ploeg);
        bool VerwijderenPloeg(int id);
    }
}