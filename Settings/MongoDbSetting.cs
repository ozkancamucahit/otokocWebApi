
namespace otokocWebApi.Settings;

public class MongoDbSettings
{
    public string Host { get; set; }//= "localhost";

    public int Port { get; set; }// = 27017;

    public string ConnectionString
     { 
         get
         {
             return $"mongodb://{Host}:{Port}";
         }
     }
}

