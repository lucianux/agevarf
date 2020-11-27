using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using PaymentFacilities.SharedKernel;
using PaymentFacilities.SharedKernel.Interfaces;
using PaymentFacilities.Core.Entities;

namespace PaymentFacilities.Infrastructure.Data
{
    public class MongoDBRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public MongoDBRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> ListAsync<T>()
        {
            return await _dbContext
                .PaymentFacilities
                .Find(_ => true)
                .ToListAsync<T>();
        }

        // public List<T> ListAll()
        // {
        //     //return new 
        // }
    }
}