
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext _context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            _context = context;
        }

        
        public void RegistrarCompra(SolicitacaoAgg.SolicitacaoCompra solicitacaoCompra)
        {
            _context.Set<SolicitacaoAgg.SolicitacaoCompra>().Add(solicitacaoCompra);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
