using System;
using System.Threading.Tasks;

namespace AdessoRideShare.Domain.Interface
{
    public interface IUnitOfWork
    {
        Task<int> Complete();
        Task TransactionComplete(Action function);
        Task TransactionCompleteAsync(Func<Task> function);
    }
}
