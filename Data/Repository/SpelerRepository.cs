
namespace ITC2Wedstrijd.Data
{
    public class SpelerRepository : BaseRepository, ISpelerRepository
    {
        public IEnumerable<Speler> SpelerOphalen()
        {
            string sql = @"SELECT * FROM Spelers Order by naam, voornaam";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var spelers = db.Query<Speler>(sql).ToList();
                return spelers;
            }
        }

        public bool ToevoegenSpeler(Speler speler)
        {
                string sql = @"INSERT INTO spelers (voornaam, naam, straat, huisnummer, gemeente, postcode, land, geboortedatum, geslacht)
                      VALUES (@voornaam, @naam, @straat, @huisnummer, @gemeente, @postcode, @land, @geboortedatum, @geslacht)";

                var parameters = new
                {
                    voornaam = speler.Voornaam,
                    naam = speler.Naam,
                    straat = speler.Straat,
                    huisnummer = speler.Huisnummer,
                    gemeente = speler.Gemeente,
                    postcode = speler.Postcode,
                    land = speler.Land,
                    geboortedatum = speler.Geboortedatum,
                    geslacht = speler.Geslacht
                };

                using IDbConnection db = new SqlConnection(ConnectionString);
                var affectedRows = db.Execute(sql, parameters);

               return affectedRows == 1;
            }

        public bool VerwijderenSpeler(int id)
        {
                string sql = @"DELETE FROM spelersploegen WHERE spelerid = @id;
                                DELETE FROM spelers WHERE spelerid = @id";

                 using IDbConnection db = new SqlConnection(ConnectionString);
                 var affectedRows = db.Execute(sql, new { id });

                 return affectedRows >= 1;
        }

        public bool WijzigenSpeler(Speler speler)
        {
            string sql = @"UPDATE Spelers
                        SET voornaam = @voornaam,
                            naam = @Naam,
                            straat = @straat,
                            huisnummer = @huisnummer,
                            gemeente = @gemeente,
                            postcode = @postcode,
                            land = @land,
                            geboortedatum = @geboortedatum,
                            geslacht = geslacht
                        WHERE spelerid = @spelerid";

            var parameters = new
            {
                spelerid = speler.SpelerId,
                voornaam = speler.Voornaam,
                naam = speler.Naam,
                straat = speler.Straat,
                huisnummer = speler.Huisnummer,
                gemeente = speler.Gemeente,
                postcode = speler.Postcode,
                land = speler.Land,
                geboortedatum = speler.Geboortedatum,
                geslacht = speler.Geslacht
            };

            using IDbConnection db = new SqlConnection(ConnectionString);
            var affectedRows = db.Execute(sql, parameters);

            return affectedRows == 1;

        }
    }
}