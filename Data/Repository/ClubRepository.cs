

namespace ITC2Wedstrijd.Data
{
    public class ClubRepository : BaseRepository, IClubRepository
    {
        public IEnumerable<Club> ClubOphalen()
        {
            string sql = @"SELECT * FROM clubs Order By naam";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var clubs = db.Query<Club>(sql).ToList();
                return clubs;
            }
        }

        public bool ToevoegenClub(Club club)
        {
               string sql = @"INSERT INTO clubs (naam) VALUES ('" + club.Naam + "')";

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql);

               return affectedRows == 1;
            }

        public bool VerwijderenClub(int id)
        {
                string sql = @"DELETE FROM clubs WHERE ClubId = @id";

                 using IDbConnection db = new SqlConnection(ConnectionString);
                 var affectedRows = db.Execute(sql, new { id });

                 return affectedRows == 1;
        }

        public bool WijzigenClub(Club club)
        {
               string sql = @"UPDATE clubs
                              SET naam = '" + club.Naam + "' WHERE clubid = " + @club.ClubId;

               using IDbConnection db = new SqlConnection(ConnectionString);
               var affectedRows = db.Execute(sql);

               return affectedRows == 1;

        }
    }
}