namespace ITC2Wedstrijd;

public abstract class BaseRepository
{
    protected string ConnectionString { get; }

    public BaseRepository()
    {
        ConnectionString = DatabaseConnection.Connectionstring("WedstrijdConnectionString");
    }
}
