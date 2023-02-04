using Data.IRepository;
using Data.Models;

namespace Data.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Patient> patients { get; }
        IGenericRepository<RadOrder> radOrders { get; }
        Task Save();
    }
}
