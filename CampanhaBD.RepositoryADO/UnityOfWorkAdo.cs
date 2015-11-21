using System;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class UnityOfWorkAdo : IUnityOfWork, IDisposable
    {
        private readonly Context _context = new Context();
        private bool _disposed;

        #pragma warning disable 649
        private ClienteRepositoryAdo _clientRepository;
        private UsuarioRepositoryAdo _usuarioRepository;
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

        public ClienteRepositoryAdo Clients
        {
            get { return (_clientRepository ?? new ClienteRepositoryAdo(_context)); }
        }

        public UsuarioRepositoryAdo Usuarios
        {
            get { return (_usuarioRepository ?? new UsuarioRepositoryAdo(_context)); }
        }
    }
}
