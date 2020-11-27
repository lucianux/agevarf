using PaymentFacilities.Infrastructure.Data.Config;
using PaymentFacilities.Core.Entities;
using MongoDB.Driver;
using System;

namespace PaymentFacilities.Infrastructure.Data
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _db;

        public AppDbContext(MongoDBConfig config)
        {

        }

        public IMongoCollection<PaymentFacility> PaymentFacilities =>
            _db.GetCollection<PaymentFacility>("PaymentFacilities");
    }
}