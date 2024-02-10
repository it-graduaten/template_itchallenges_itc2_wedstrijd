﻿
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
                            INNER JOIN categoriën C ON P.categorieid = C.categorieid
                            INNER JOIN clubs CL ON P.clubid = CL.clubid
                            INNER JOIN sporten S ON P.sportid = S.sportid
                            Order by ploegnaam";

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
                }, splitOn: "categorieId,clubid,sportid");
                // De debugVar is enkel toegevoegd om een breakpunt te kunnen zetten
                // en de inhoud van de variabele te kunnen bekijken.
                return debugVar;

            }
        }

        public bool ToevoegenPloeg(Ploeg ploeg)
        {
               string sql = @"INSERT INTO ploegen (ploegnaam, categorieid, clubid, sportid)
                  VALUES (@ploegnaam, @categorieid, @clubid, @sportid)";

               var parameters = new
               {
                   ploegnaam = ploeg.PloegNaam,
                   categorieid = ploeg.Categorie.CategorieId,
                   clubid = ploeg.Club.ClubId,
                   sportid = ploeg.Sport.SportId
               };

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql, parameters);

               return affectedRows == 1;
            }

        public bool VerwijderenPloeg(int id)
        {
                string sql = @"DELETE FROM spelersploegen WHERE ploegid = @id;
                                DELETE FROM ploegen WHERE ploegid = @id";

                 using IDbConnection db = new SqlConnection(ConnectionString);
                 var affectedRows = db.Execute(sql, new { id });

                 return affectedRows >= 1;

        }

        public bool WijzigenPloeg(Ploeg ploeg)
        {
               string sql = @"UPDATE ploegen
                              SET ploegnaam = @ploegnaam,
                                  categorieid = @categorieid,
                                  clubid = @clubid,
                                  sportid = @sportid
                              WHERE ploegid = @ploegid";

               var parameters = new
               {
                   ploegid = ploeg.PloegId,
                   ploegnaam = ploeg.PloegNaam,
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