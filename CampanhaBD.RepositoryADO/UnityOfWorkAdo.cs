using System;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class UnityOfWorkAdo : IUnityOfWork, IDisposable
    {
        private readonly string _connectionString;
        private readonly Context _context;
        private static UnityOfWorkAdo _unit;

        #pragma warning disable 649
        private ClienteRepositoryAdo _clientRepository;
        private UsuarioRepositoryAdo _usuarioRepository;
        private BancoRepositoryAdo _bancoRepository;
        private ImportacaoRepositoryAdo _importacaoRepository;
        private CampanhaRepositoryAdo _campanhaRepository;
        private BeneficioRepositoryAdo _beneficioRepository;
        private EmprestimoRepositoryAdo _emprestimoRepository;
        #pragma warning restore 649

        private UnityOfWorkAdo(string connectionString)
        {
            _connectionString = connectionString;
            _context = new Context(connectionString);
        }

        public static UnityOfWorkAdo getInstance(string connectionString)
        {
            if (_unit == null)
                _unit = new UnityOfWorkAdo(connectionString);

            return _unit;
        }

        public void Commit()
        {
            
        }

        public void RollBack()
        {
            
        }

        public void AbrirConexao()
        {
            _context.AbrirConexao();
        }

        public void FecharConexao()
        {
            _context.FecharConexao();
        }

        public void Dispose()
        {
        }

        public ClienteRepositoryAdo Clientes
        {
            get { return (_clientRepository ?? new ClienteRepositoryAdo(_context)); }
        }

        public UsuarioRepositoryAdo Usuarios
        {
            get { return (_usuarioRepository ?? new UsuarioRepositoryAdo(_context)); }
        }

        public BancoRepositoryAdo Bancos
        {
            get { return (_bancoRepository ?? new BancoRepositoryAdo(_context)); }
        }

        public ImportacaoRepositoryAdo Importacoes
        {
            get { return (_importacaoRepository ?? new ImportacaoRepositoryAdo(_context)); }
        }

        public CampanhaRepositoryAdo Campanhas
        {
            get { return (_campanhaRepository ?? new CampanhaRepositoryAdo(_context)); }
        }

        public BeneficioRepositoryAdo Beneficios
        {
            get { return (_beneficioRepository ?? new BeneficioRepositoryAdo(_context)); }
        }

        public EmprestimoRepositoryAdo Emprestimos
        {
            get { return (_emprestimoRepository ?? new EmprestimoRepositoryAdo(_context)); }
        }
    }
}
