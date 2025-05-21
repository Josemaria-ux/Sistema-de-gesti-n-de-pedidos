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
    public class LineaConfiguration : IEntityTypeConfiguration<Linea>
    {
        public void Configure(EntityTypeBuilder<Linea> builder)
        {
            builder.OwnsOne(a => a.Precio, p =>
            {
                p.Property(n => n.Value).HasColumnName("Precio");
            }
         );
        }
    }
}
