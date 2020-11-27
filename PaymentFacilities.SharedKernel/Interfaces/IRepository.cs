using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentFacilities.SharedKernel.Interfaces
{
    public interface IRepository
    {
        //List<T> ListAll() where T : BaseEntity;
        Task<List<T>> ListAsync<T>();
        //List<T> ListAll(); 
    }
}
