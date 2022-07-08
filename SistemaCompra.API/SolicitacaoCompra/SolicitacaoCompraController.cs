using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitacaoCompra.SistemaCompra.API.Produto
{
    public class SolicitacaoCompraController : Controller
    {
        private readonly IMediator _mediator;


        public SolicitacaoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        [HttpPost("solicitacaocompra/registrarcompra")]
        public IActionResult RegistrarCompra(RegistrarCompraCommand registrarCompraCommand)
        {
            if (!ModelState.IsValid) return BadRequest();

            _mediator.Send(registrarCompraCommand);
            return Ok();
        }
    }
}
