using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using PaymentFacilities.SharedKernel;
using PaymentFacilities.SharedKernel.Interfaces;
using PaymentFacilities.Core.Entities;

namespace PaymentFacilities.Infraestructure.Data
{
    public class MongoDBRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public MongoDBRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PaymentFacility>> ListAsync<PaymentFacility>() where PaymentFacility : BaseEntity
        {
            IMongoCollection<PaymentFacility> facilities =
                (IMongoCollection<PaymentFacility>) _dbContext.PaymentFacilities;

            return await facilities
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task Create<PaymentFacility>(PaymentFacility paymentFacility)
        {
            IMongoCollection<PaymentFacility> facilities =
                (IMongoCollection<PaymentFacility>) _dbContext.PaymentFacilities;

            await facilities.InsertOneAsync(paymentFacility);
        }

        public async Task<long> GetNextId()
        {
            return await _dbContext.PaymentFacilities.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}