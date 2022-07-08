using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacoesCompras");

            builder.OwnsOne(s => s.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral"));


            builder.OwnsOne(s => s.NomeFornecedor,
             sc =>
             {
                 sc.Property(s => s.Nome)
                     .HasColumnName("NomeFornecedor")
                     .HasColumnType("nvarchar(100)");
             });


            builder.OwnsOne(s => s.UsuarioSolicitante,
               sc =>
               {
                   sc.Property(s => s.Nome)
                       .HasColumnName("UsuarioSolicitante")
                       .HasColumnType("nvarchar(100)");
               });

            builder.OwnsOne(s => s.condicaoPagamento,
             sc =>
             {
                 sc.Property(s => s.Valor)
                     .HasColumnName("CondicaoPagamento")
                     .HasColumnType("decimal");
             });



        }
    }
}
