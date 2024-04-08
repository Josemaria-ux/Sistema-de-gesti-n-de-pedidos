using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class PedidoContext : DbContext
    {
        // fluenapi para personalizar

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Obligatorio_P3; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Autor>().ToTable("AutoresNombre");

            //modelBuilder.Entity<Autor>().HasOne(aut => aut.MiPais).WithMany(p => p.MisAutores).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Usuario>().OwnsOne(a => a.NombreCompleto, nomC =>
            {
                nomC.Property(n => n.Name).HasColumnName("Nombre");
                nomC.Property(n => n.Apellido).HasColumnName("Apellido");
            }
            );

            modelBuilder.Entity<Usuario>().OwnsOne(a => a.Email, em =>
            {
                em.Property(e => e.Value).HasColumnName("Email");
            }
            );

            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();

        }
    }
}
