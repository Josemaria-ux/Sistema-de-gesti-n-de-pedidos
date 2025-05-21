using Infraestructura.LogicaAccesoDatos.EF.Config;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using LogicaNegocio.ValueObject.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class PedidoContext : DbContext
    {
        // fluenapi para personalizar

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Admin> Administradores { get; set; }

        public DbSet<Normal> Normales { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Express> PedidosExpres { get; set; }

        public DbSet<Comun> Comunes { get; set; }

        public DbSet<Linea> Lineas { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Obligatorio_P3; Integrated Security = True");
        //}
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Autor>().ToTable("AutoresNombre");

            //modelBuilder.Entity<Autor>().HasOne(aut => aut.MiPais).WithMany(p => p.MisAutores).OnDelete(DeleteBehavior.NoAction);

            // todo pasar todo a configuracion
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            var emailConvert = new ValueConverter<Email, string>(
                v => v.Value,
            v => new Email(v)
                );

            modelBuilder.Entity<Usuario>().Property(a => a.Email).HasConversion(emailConvert);
            modelBuilder.Entity<Usuario>().HasIndex(a => a.Email).IsUnique();


            modelBuilder.ApplyConfiguration(new ArticuloConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new LineaConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
        }
    }
}
