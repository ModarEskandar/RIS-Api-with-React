
using Data.IRepository;
using Data.Models;
using Data.Repository;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RISDbContext _context;
        protected IGenericRepository<Patient> _patients;
        protected IGenericRepository<RadOrder> _radOrders;
        public UnitOfWork(RISDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Patient> patients => _patients ??= new GenericRepository<Patient>(_context);

        public IGenericRepository<RadOrder> radOrders => _radOrders ??= new GenericRepository<RadOrder>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }



        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}