using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.interfaces;
using System;
using System.Collections.Generic;

using System.Linq;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity, ISolicitacaoCompra
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public CondicaoPagamento condicaoPagamento { get; private set; }

        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        private SolicitacaoCompra() { }
        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            Itens = new List<Item>();
            condicaoPagamento = new CondicaoPagamento(0);
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            if (itens.Count() == 0) throw new BusinessRuleException("Ops! Você precisar ter pelo menos um produto para registrar uma compra.");

            foreach (var item in itens)
            {
                TotalGeral.Add(item.Subtotal);
            }
            //Gerando condicao de pagamento após Registrar comprar...
            GerarCondicaoPagamento30Dias();

        }

        public void GerarCondicaoPagamento30Dias()
        {

            if (TotalGeral.Value > 500000)
            {
                condicaoPagamento = new CondicaoPagamento(30);
            }

        }

        
    }
}
