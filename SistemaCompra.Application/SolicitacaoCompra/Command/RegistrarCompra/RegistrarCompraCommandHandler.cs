using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoAggInterface = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {

        private readonly SolicitacaoAggInterface.ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        public RegistrarCompraCommandHandler(IUnitOfWork uow, IMediator mediator,
            SolicitacaoAggInterface.ISolicitacaoCompraRepository solicitacaoCompraRepository) :
            base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new SolicitacaoAgg.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
           
            //obtendo os itens das compras...
            solicitacaoCompra.RegistrarCompra(request.Itens);          

            _solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);


            Commit();


            return Task.FromResult(true);
        }
    }
}
