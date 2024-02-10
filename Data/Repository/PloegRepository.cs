
namespace ITC2Wedstrijd.Data
{
    public class PloegRepository : BaseRepository, IPloegRepository
    {
        public IEnumerable<Ploeg> PloegOphalen()
        {
            // De juiste volgorde is belangrijk!!
            // Eerst categorie, dan club en dan sport
            string sql = @"SELECT P.*, C.*, CL.*, S.* 
                            FROM ploegen P
                            INNER JOIN categoriën C ON P.categorieid = C.id
                            INNER JOIN clubs CL ON P.clubid = CL.id
                            INNER JOIN sporten S ON P.sportid = S.id
                            Order by P.naam";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var debugVar = db.Query<Ploeg, Categorie, Club, Sport, Ploeg>(
                sql,
                // Eerst categorie, dan club en dan sport
                (Ploeg, Categorie, Club, Sport) =>
                {
                    Ploeg.Categorie = Categorie;
                    Ploeg.Club = Club;
                    Ploeg.Sport = Sport;
                    return Ploeg;
               // Eerst categorieid, dan clubid en dan sportid
                }, splitOn: "id");
                // De debugVar is enkel toegevoegd om een breakpunt te kunnen zetten
                // en de inhoud van de variabele te kunnen bekijken.
                return debugVar;

            }
        }

        public bool ToevoegenPloeg(Ploeg ploeg)
        {
               string sql = @"INSERT INTO ploegen (naam, categorieid, clubid, sportid)
                  VALUES (@naam, @categorieid, @clubid, @sportid)";

               var parameters = new
               {
                   naam = ploeg.Naam,
                   categorieid = ploeg.Categorie.Id,
                   clubid = ploeg.Club.Id,
                   sportid = ploeg.Sport.Id
               };

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql, parameters);

               return affectedRows == 1;
            }

        public bool VerwijderenPloeg(int id)
        {
                string sql = @"DELETE FROM spelersploegen WHERE ploegid = @id;
                                DELETE FROM ploegen WHERE id = @id";

                 using IDbConnection db = new SqlConnection(ConnectionString);
                 var affectedRows = db.Execute(sql, new { id });

                 return affectedRows >= 1;

        }

        public bool WijzigenPloeg(Ploeg ploeg)
        {
               string sql = @"UPDATE ploegen
                              SET naam = @naam,
                                  categorieid = @categorieid,
                                  clubid = @clubid,
                                  sportid = @sportid
                              WHERE id = @id";

               var parameters = new
               {
                   id = ploeg.Id,
                   naam = ploeg.Naam,
                   categorieid = ploeg.CategorieId,
                   clubid = ploeg.ClubId,
                   sportid = ploeg.SportId
               };

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql, parameters);

               return affectedRows == 1;

        }
    }
}