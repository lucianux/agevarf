using PaymentFacilities.SharedKernel;

namespace PaymentFacilities.Core.Entities
{
    public class PaymentFacility : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}