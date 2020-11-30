using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentFacilities.SharedKernel.Interfaces
{
    public interface IRepository
    {
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<T> GetPaymentFacility<T>(long id);
        Task Create<T>(T paymentFacility);
        Task<long> GetNextId();
    }
}
