

namespace ITC2Wedstrijd.Data
{
    public class ClubRepository : BaseRepository, IClubRepository
    {
        public IEnumerable<Club> ClubOphalen()
        {
            string sql = @"SELECT * FROM Club Order By naam";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var Club = db.Query<Club>(sql).ToList();
                return Club;
            }
        }

        public bool ToevoegenClub(Club club)
        {
               string sql = @"INSERT INTO Club (naam) VALUES ('" + club.Naam + "')";

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql);

               return affectedRows == 1;
            }

        public bool VerwijderenClub(int id)
        {
                string sql = @"DELETE FROM Club WHERE id = @id";

                 using IDbConnection db = new SqlConnection(ConnectionString);
                 var affectedRows = db.Execute(sql, new { id });

                 return affectedRows == 1;
        }

        public bool WijzigenClub(Club club)
        {
               string sql = @"UPDATE Club
                              SET naam = '" + club.Naam + "' WHERE id = " + @club.Id;

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql);

               return affectedRows == 1;

        }
    }
}