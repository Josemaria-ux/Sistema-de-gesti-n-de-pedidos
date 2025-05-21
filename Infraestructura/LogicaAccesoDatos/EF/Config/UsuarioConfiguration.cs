using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using LogicaNegocio.ValueObject.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.EF.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(a => a.NombreCompleto, nomC =>
            {
                nomC.Property(n => n.Name).HasColumnName("Nombre");
                nomC.Property(n => n.Apellido).HasColumnName("Apellido");
            }
            );


            builder.OwnsOne(a => a.Password, pass =>
            {
                pass.Property(e => e.Value).HasColumnName("Password");
            }
            );

            //modelBuilder.Entity<Usuario>().HasIndex(a => a.Email).IsUnique();
        }
    }
}
