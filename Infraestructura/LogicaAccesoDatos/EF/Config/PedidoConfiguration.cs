using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.EF.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {

            builder.OwnsOne(a => a.FechaPedido, fPedido =>
            {
                fPedido.Property(n => n.FechaPedido).HasColumnName("Fecha pedido");
                fPedido.Property(n => n.FechaEntrega).HasColumnName("Fecha entrega");
                fPedido.Ignore(n => n.Discriminador);
            });
        }
    }
}
