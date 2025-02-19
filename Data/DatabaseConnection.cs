

namespace ITC2Wedstrijd.Data;

public static class DatabaseConnection
{
    public static string Connectionstring(string name)
    {
        //var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Wedstrijden;Integrated Security=True;";
        return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        //return connectionString;
    }

}
