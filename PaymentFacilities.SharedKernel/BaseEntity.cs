using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentFacilities.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
    }
}