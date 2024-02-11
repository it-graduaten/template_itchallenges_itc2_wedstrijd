
namespace ITC2Wedstrijd.Data
{
    public class SpelerPloegRepository: BaseRepository, ISpelerPloegRepository
    {
        public IEnumerable<Speler> BeschikbareSpelersOphalen(Ploeg ploeg)
        {
            string sql = @"SELECT *
                    FROM spelers
                    WHERE Year(geboortedatum) <= (year(GETDATE())-@minleeftijd)
                        AND Year(geboortedatum) >= (year(GETDATE())-@maxleeftijd)
                        AND id NOT IN (SELECT spelerid FROM spelersploegen SP WHERE SP.ploegid = @ploegid)
                    Order by naam, voornaam";

            var parameters = new
            {
                ploegid = ploeg.Id,
                minleeftijd = ploeg.Categorie.MinLeeftijd,
                maxleeftijd = ploeg.Categorie.MaxLeeftijd
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var spelers = db.Query<Speler>(sql, parameters);
                return spelers;

            }
        }

        public IEnumerable<Speler> SpelersInPloegOphalen(Ploeg ploeg)
        {
            string sql = @"SELECT *
                    FROM spelers
                    WHERE Year(geboortedatum) <= (year(GETDATE())-@minleeftijd)
                        AND Year(geboortedatum) >= (year(GETDATE())-@maxleeftijd)
                        AND id IN (SELECT spelerid FROM spelersploegen SP WHERE SP.ploegid = @ploegid)
                    Order by naam, voornaam";

            var parameters = new
            {
                ploegid = ploeg.Id,
                minleeftijd = ploeg.Categorie.MinLeeftijd,
                maxleeftijd = ploeg.Categorie.MaxLeeftijd
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var spelers = db.Query<Speler>(sql, parameters);
                return spelers;

            }
        }

        public bool SpelerInPloegPlaatsen(Speler speler, Ploeg ploeg)
        {
            string sql = @"INSERT INTO spelersploegen (spelerid, ploegid)
                  VALUES (@spelerid, @ploegid)";

            var parameters = new
            {
                spelerid = speler.Id,
                ploegid = ploeg.Id
            };

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, parameters);

            return affectedRows == 1;
        }

        public bool SpelerUitPloegHalen(Speler speler, Ploeg ploeg)
        {
            string sql = @"DELETE FROM spelersploegen WHERE spelerid=@spelerid
                           AND ploegid=@ploegid";

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, new { spelerid=speler.Id,ploegid=ploeg.Id });

            return affectedRows == 1;
        }

    }
}