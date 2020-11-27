using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentFacilities.SharedKernel.Interfaces
{
    public interface IRepository
    {
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task Create<T>(T paymentFacility);
        Task<long> GetNextId();
    }
}
