using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using PaymentFacilities.SharedKernel;
using PaymentFacilities.SharedKernel.Interfaces;
using ent=PaymentFacilities.Core.Entities;
using PaymentFacilities.Core.Entities;
using Test = PaymentFacilities.Core.Entities.PaymentFacility;

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

        // public Task<ent.PaymentFacility> GetPaymentFacility<PaymentFacility>(long id)
        // {
        //     FilterDefinition<ent.PaymentFacility> filter =
        //         Builders<ent.PaymentFacility>.Filter.Eq(m => ((ent.PaymentFacility)m).IdNumber, id);
                
        //     IMongoCollection<ent.PaymentFacility> facilities =
        //         (IMongoCollection<ent.PaymentFacility>) _dbContext.PaymentFacilities;

        //     return facilities
        //             .Find<ent.PaymentFacility>(filter)
        //             .FirstOrDefaultAsync();
        // }

        // public Task<Test> GetPaymentFacility<Test>(long id)
        // {
        //     FilterDefinition<Test> filter =
        //         Builders<Test>.Filter.Eq(m => m.IdNumber, id);
                
        //     IMongoCollection<Test> facilities =
        //         (IMongoCollection<Test>) _dbContext.PaymentFacilities;

        //     return facilities
        //             .Find<Test>(filter)
        //             .FirstOrDefaultAsync();
        // }

        public Task<PaymentFacility> GetPaymentFacility<PaymentFacility>(long id)
        {
            IMongoCollection<PaymentFacility> facilities =
                (IMongoCollection<PaymentFacility>) _dbContext.PaymentFacilities;

            FilterDefinition<PaymentFacility> filter =
                Builders<PaymentFacility>.Filter.Eq(m => m.IdNumber, id);

            return facilities
                    .Find<PaymentFacility>(filter)
                    .FirstOrDefaultAsync();
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