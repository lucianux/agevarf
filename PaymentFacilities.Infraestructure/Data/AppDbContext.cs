using PaymentFacilities.Infraestructure.Data.Config;
using PaymentFacilities.Core.Entities;
using MongoDB.Driver;
using System;

namespace PaymentFacilities.Infraestructure.Data
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _db;

        public AppDbContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<PaymentFacility> PaymentFacilities =>
            _db.GetCollection<PaymentFacility>("PaymentFacilities");
    }
}