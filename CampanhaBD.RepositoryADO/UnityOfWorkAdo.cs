using System;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class UnityOfWorkAdo : IUnityOfWork, IDisposable
    {
        private readonly Context _context = new Context();
        private bool _disposed;

        #pragma warning disable 649
        private ClientRepositoryAdo _clientRepository;
        #pragma warning restore 649

        public void Commit()
        {
            
        }

        public void RollBack()
        {
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ClientRepositoryAdo Clients
        {
            get { return (_clientRepository ?? new ClientRepositoryAdo(_context)); }
        }
    }
}
