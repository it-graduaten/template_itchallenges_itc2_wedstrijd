

namespace ITC2Wedstrijd.Data
{
    public interface ISpelerPloegRepository
    {
        public IEnumerable<Speler> BeschikbareSpelersOphalen(Ploeg ploeg);

        public IEnumerable<Speler> SpelersInPloegOphalen(Ploeg ploeg);

        public bool SpelerInPloegPlaatsen(Speler speler, Ploeg ploeg);
        public bool SpelerUitPloegHalen(Speler speler, Ploeg ploeg);
    }
}