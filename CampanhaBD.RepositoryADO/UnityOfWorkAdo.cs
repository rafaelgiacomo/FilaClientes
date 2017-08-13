using System;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class UnityOfWorkAdo : IUnityOfWork, IDisposable
    {
        private readonly string _connectionString;
        private readonly Context _context;

        #pragma warning disable 649
        private ClienteRepositoryAdo _clientRepository;
        private UsuarioRepositoryAdo _usuarioRepository;
        private BancoRepositoryAdo _bancoRepository;
        private ImportacaoRepositoryAdo _importacaoRepository;
        private FiltroRepositoryAdo _campanhaRepository;
        private BeneficioRepositoryAdo _beneficioRepository;
        private EmprestimoRepositoryAdo _emprestimoRepository;
        private ConsultaProcessaRepositoryAdo _consultaRepository;
        private ConsultaDadosProcessaRepositoryAdo _consultaDadosRepository;
        private SaldoRefinProcessaRepositoryAdo _saldoRefinRepository;
        private BaseOriginalRepositoryAdo _baseOriginalRepository;
        #pragma warning restore 649

        public UnityOfWorkAdo(string connectionString)
        {
            _connectionString = connectionString;
            _context = new Context(connectionString);
            _context.AbrirConexao();
        }

        public void AbrirTransacao()
        {
            _context.OpenTransaction();
        }

        public void Commit()
        {
            _context.Commit();
        }

        public void RollBack()
        {
            _context.RollBack();
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
            _context.FecharConexao();
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

        public FiltroRepositoryAdo Filtros
        {
            get
            {
                if (_campanhaRepository == null)
                {
                    _campanhaRepository = new FiltroRepositoryAdo(_context);
                }
                return _campanhaRepository;
            }
        }

        public BeneficioRepositoryAdo Beneficios
        {
            get { return (_beneficioRepository ?? new BeneficioRepositoryAdo(_context)); }
        }

        public EmprestimoRepositoryAdo Emprestimos
        {
            get { return (_emprestimoRepository ?? new EmprestimoRepositoryAdo(_context)); }
        }

        public ConsultaProcessaRepositoryAdo ConsultasProcessa
        {
            get { return (_consultaRepository ?? new ConsultaProcessaRepositoryAdo(_context)); }
        }

        public ConsultaDadosProcessaRepositoryAdo ConsultasDadosProcessa
        {
            get { return (_consultaDadosRepository ?? new ConsultaDadosProcessaRepositoryAdo(_context)); }
        }

        public SaldoRefinProcessaRepositoryAdo SaldosRefinProcessa
        {
            get { return (_saldoRefinRepository ?? new SaldoRefinProcessaRepositoryAdo(_context)); }
        }

        public BaseOriginalRepositoryAdo BasesOriginais
        {
            get { return (_baseOriginalRepository ?? new BaseOriginalRepositoryAdo(_context)); }
        }

    }
}
