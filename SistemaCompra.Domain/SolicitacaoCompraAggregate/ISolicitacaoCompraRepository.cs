using System;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository: IDisposable
    {
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
