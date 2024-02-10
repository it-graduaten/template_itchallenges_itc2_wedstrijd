
namespace ITC2Wedstrijd.Data
{
    public class SportRepository : BaseRepository, ISportRepository
    {
        public IEnumerable<Sport> SportOphalen()
        {
            string sql = @"SELECT * FROM Sporten Order By naam";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sporten = db.Query<Sport>(sql).ToList();
                return sporten;
            }
        }

        public bool ToevoegenSport(Sport sport)
        {
               string sql = @"INSERT INTO Sporten (naam) VALUES ('" + sport.Naam + "')";

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql);

               return affectedRows == 1;
            }

        public bool VerwijderenSport(int id)
        {
                string sql = @"DELETE FROM Sporten WHERE Id = @id";

                 using IDbConnection db = new SqlConnection(ConnectionString);
                 var affectedRows = db.Execute(sql, new { id });

                 return affectedRows == 1;
        }

        public bool WijzigenSport(Sport sport)
        {
               string sql = @"UPDATE Sporten
                              SET naam = '" + sport.Naam + "' WHERE id = " + @sport.Id;

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql);

               return affectedRows == 1;

        }
    }
}