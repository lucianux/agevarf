namespace PaymentFacilities.Infraestructure.Data.Config
{
    public class ServerConfig
    {
        public MongoDBConfig MongoDB { get; set; } = new MongoDBConfig();
    }
}