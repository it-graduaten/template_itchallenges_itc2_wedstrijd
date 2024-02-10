

namespace ITC2Wedstrijd.Data
{
    public class CategorieRepository : BaseRepository, ICategorieRepository
    {
        public IEnumerable<Categorie> CategorieOphalen()
        {
            string sql = @"SELECT * FROM categoriën Order By naam";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var categoriën = db.Query<Categorie>(sql).ToList();
                return categoriën;
            }
        }


        public bool ToevoegenCategorie(Categorie categorie)
        {
               string sql = @"INSERT INTO categoriën (naam, minleeftijd, maxleeftijd, categorietype)
                  VALUES (@naam, @minleeftijd, @maxleeftijd, @categorietype)";

               var parameters = new
               {
                   naam = categorie.Naam,
                   minleeftijd = categorie.MinLeeftijd,
                   maxleeftijd = categorie.MaxLeeftijd,
                   geslacht = categorie.CategorieType
               };

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql, parameters);

               return affectedRows == 1;
            }

        public bool VerwijderenCategorie(int id)
        {
                string sql = @"DELETE FROM categoriën WHERE CategorieId = @id";

                 using IDbConnection db = new SqlConnection(ConnectionString);
                 var affectedRows = db.Execute(sql, new { id });

                 return affectedRows == 1;

        }

        public bool WijzigenCategorie(Categorie categorie)
        {
               string sql = @"UPDATE categoriën
                              SET naam = @Naam,
                                  minleeftijd = @minleeftijd,
                                  maxleeftijd = @maxleeftijd,
                                  categorietype = @categorietype
                              WHERE categorieid = @categorieid";

               var parameters = new
               {
                   categorieid = categorie.CategorieId,
                   naam = categorie.Naam,
                   minleeftijd = categorie.MinLeeftijd,
                   maxleeftijd = categorie.MaxLeeftijd,
                   categorietype = categorie.CategorieType
               };

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql, parameters);

               return affectedRows == 1;

        }
    }
}