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
    public class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.OwnsOne(a => a.Nombre, nomA =>
            {
                nomA.Property(n => n.Name).HasColumnName("Nombre");
            });

            builder.OwnsOne(a => a.CodigoBarras, cBArt =>
            {
                cBArt.Property(c => c.Value).HasColumnName("Codigo_de_barras");
            });

            builder.OwnsOne(a => a.Precio, pArt =>
            {
                pArt.Property(p => p.Value).HasColumnName("Precio");
            });

            //modelBuilder.Entity<Articulo>().HasIndex(a => a.Nombre).IsUnique();

            //modelBuilder.Entity<Articulo>().HasIndex(a => a.CodigoBarras).IsUnique();

        }
    }
}
