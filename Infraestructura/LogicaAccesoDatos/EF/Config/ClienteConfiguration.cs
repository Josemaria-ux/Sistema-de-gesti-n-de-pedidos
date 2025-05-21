using LogicaNegocio.Entidades;
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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.OwnsOne(a => a.RUT, rut =>
            {
                rut.Property(e => e.Value).HasColumnName("RUT");
            }
            );

            builder.OwnsOne(a => a.Direccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Numero).HasColumnName("Numero");
                dir.Property(d => d.Ciudad).HasColumnName("Ciudad");
                dir.Property(d => d.Distancia).HasColumnName("Distancia");
            }
            );
        }
    }
}
