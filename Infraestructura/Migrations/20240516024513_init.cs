using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo_de_barras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RUT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distancia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechapedido = table.Column<DateTime>(name: "Fecha pedido", type: "datetime2", nullable: false),
                    Fechaentrega = table.Column<DateTime>(name: "Fecha entrega", type: "datetime2", nullable: false),
                    CostoTotal = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Entregado = table.Column<bool>(type: "bit", nullable: false),
                    Anulado = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lineas_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_ArticuloId",
                table: "Lineas",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_PedidoId",
                table: "Lineas",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_clienteId",
                table: "Usuarios",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
            migrationBuilder.InsertData(
table: "Articulos",
columns: new[] { "Nombre", "Descripcion", "Codigo_de_barras", "Precio", "Stock", "Eliminado" },
values: new object[,]
{
            { "Camiseta Azul", "Camiseta de algodón azul", "1234567890123", 19.99, 50, false },
            { "Pantalón Vaquero Negro", "Pantalón vaquero negro", "2345678901234", 29.99, 30, false },
            { "Zapatillas Deportivas Rojas", "Zapatillas deportivas rojas", "3456789012345", 39.99, 20, false },
            { "Gorra Negra", "Gorra negra con logo bordado", "4567890123456", 14.99, 40, false },
            { "Bufanda de Lana", "Bufanda de lana suave y cálida", "5678901234567", 24.99, 25, false },
            { "Reloj de Pulsera", "Reloj de pulsera analógico plateado", "6789012345678", 49.99, 15, false },
            { "Laptop Lenovo", "Laptop Lenovo de 15 pulgadas", "7890123456789", 899.99, 10, false },
            { "Teléfono Samsung", "Teléfono Samsung Galaxy último modelo", "8901234567890", 699.99, 8, false },
            { "TV LED 4K", "Televisor LED 4K de 55 pulgadas", "9012345678901", 1199.99, 5, false },
            { "Altavoces Bluetooth", "Altavoces Bluetooth portátiles", "0123456789012", 79.99, 30, false },
            { "Cámara DSLR", "Cámara réflex digital profesional", "1123456789012", 1499.99, 3, false },
            { "Libro de Ciencia Ficción", "Novela de ciencia ficción best-seller", "1223456789012", 19.99, 20, false },
            { "Juego de Mesa", "Juego de mesa familiar para todas las edades", "1323456789012", 29.99, 15, false },
            { "Kit de Herramientas", "Kit de herramientas básicas para bricolaje", "1423456789012", 49.99, 12, false },
            { "Mochila Escolar", "Mochila escolar resistente y espaciosa", "1523456789012", 34.99, 25, false },
            { "Silla de Oficina", "Silla ergonómica para oficina", "1623456789012", 149.99, 7, false },
            { "Cafetera Automática", "Cafetera automática programable", "1723456789012", 89.99, 10, false },
            { "Teclado Inalámbrico", "Teclado inalámbrico recargable", "1823456789012", 49.99, 18, false },
            { "Impresora Multifunción", "Impresora multifunción de inyección de tinta", "1923456789012", 129.99, 6, false },
            { "Tablet Android", "Tablet Android de 10 pulgadas", "2023456789012", 199.99, 9, false },
});

            migrationBuilder.InsertData(
                    table: "Clientes",
                    columns: new[] { "RazonSocial", "RUT", "Calle", "Numero", "Ciudad", "Distancia" },
                    values: new object[,]
                    {
            { "Empresa Innovación S.A.", "123456789012", "Avenida Libertador", "1000", "Buenos Aires", 12.5 },
            { "Tech Solutions LLC", "234567890123", "Calle de la Tecnología", "202", "San Francisco", 8.9 },
            { "Servicios Integrados Ltda.", "345678901234", "Pasaje Central", "305", "Santiago", 130 },
            { "Comercial y Ventas SpA", "456789012345", "Avenida Principal", "450", "Bogotá", 125 },
            { "Distribuidora Mayorista S.A.", "567890123456", "Calle Comercio", "678", "Lima", 100},
            { "Consultores Financieros Inc.", "678901234567", "Calle Economía", "789", "Ciudad de México", 18.2 },
            { "Desarrollos Tecnológicos S.A.", "789012345678", "Boulevard Innovación", "101", "Miami", 22.1 },
            { "Inversiones Globales LLC", "890123456789", "Calle Internacional", "909", "Madrid", 30.0 },
            { "Alimentos Orgánicos Ltda.", "901234567890", "Calle Salud", "110", "Barcelona", 14.8 },
            { "Construcciones Modernas S.A.", "012345678901", "Avenida Construcción", "1120", "Montevideo", 9.4 }
                    });


            migrationBuilder.InsertData(
        table: "Usuarios",
        columns: new[] { "Email", "Apellido", "Nombre", "Password", "PassHash", "clienteId", "Eliminado", "Discriminator" },
        values: new object[,]
        {
               { "juanperez@example.com", "Pérez", "Juan", "juan123","$2a$10$eQNHtHeQkOZqdaamjdOzSu5G3PoE.nCmoZZfHrcAJLin7FPl6..fm", 1, false, "Admin" },
               { "mariagarcia@example.com", "García", "María", "maria456","$2a$10$sl/T8ytqoldBC5ihBdmIr.4ELzPEckyFIDTznODv2m7blerphztKS", 2, false, "Normal" },
               { "luisrodriguez@example.com", "Rodríguez", "Luis", "luis789", "$2a$10$9BQhVFlEK5Yg5z3CBTmOEebX9We8KIZEjEupAckj3Xk9dqiDD2kAe", 3, false, "Normal" },
               { "anamartinez@example.com", "Martínez", "Ana", "ana456","$2a$10$hJqQqFS34CAZkcXn005nPusrNlUOJ4T8uDI6SpMO8ml9ESPLo6hhm", 4, false, "Normal" },
               { "pedrolopez@example.com", "López", "Pedro", "pedro123","$2a$10$S31mI9qhE0Lwmwd22NHUiOMq6DDTLe2.LmZvmaubamvMIoUstoOSK", 5, false, "Normal" },
               { "lauragomez@example.com", "Gómez", "Laura", "laura789","$2a$10$L1LPfIYEyg0orodefRYauOp5ivE5ePTYC14sWC676zBircf4cxWMi", 6, false, "Normal" },
               { "carlosruiz@example.com", "Ruiz", "Carlos", "carlos456","$2a$10$SYcHUpeCRxcGtNRxAGrUQe/eDcxhLdItGY.dDVjl3aG0KJMYXPp4u", 7, false, "Normal" },
               { "elenasantos@example.com", "Santos", "Elena", "elena123", "$2a$10$YfIsrj6TUnOYGhRGB5DV3.OVjNdA4XtQtLxSTm4Y55uJFkHT8z972",8, false, "Normal" },
               { "diegofernandez@example.com", "Fernández", "Diego", "diego789","$2a$10$CWL4pyXd1XyVzEw6jBUEz.ExloxdOSDnI2sYI4KST9k71EPBTdS9q", 9, false, "Normal" },
               { "martasanchez@example.com", "Sánchez", "Marta", "marta456","$2a$10$9m1sg3vd2XRAui67JizXPupzUknKBsGfaSdzVdbuV0yPEuHnU55au", 10, false, "Normal" },
                     });
            migrationBuilder.InsertData(
    table: "Pedidos",
    columns: new[] { "Fecha pedido", "Fecha entrega", "CostoTotal", "ClienteId", "Entregado", "Anulado", "Discriminator" },
    values: new object[,]
    {
            { new DateTime(2023, 5, 1), new DateTime(2023, 5, 8), 100.50, 1, true, false, "Comun" },
            { new DateTime(2023, 5, 2), new DateTime(2023, 5, 9), 200.75, 2, false, false, "Comun" },
            { new DateTime(2023, 5, 3), new DateTime(2023, 5, 10), 300.00, 3, true, false, "Comun" },
            { new DateTime(2023, 5, 4), new DateTime(2023, 5, 11), 150.25, 4, false, false, "Comun" },
            { new DateTime(2023, 5, 5), new DateTime(2023, 5, 12), 250.80, 5, true, true, "Comun" },
            { new DateTime(2023, 5, 6), new DateTime(2023, 5, 12), 125.60, 6, true, false, "Express" },
            { new DateTime(2023, 5, 7), new DateTime(2023, 5, 13), 350.45, 7, false, false, "Express" },
            { new DateTime(2023, 5, 8), new DateTime(2023, 5, 14), 275.30, 8, true, false, "Express" },
            { new DateTime(2023, 5, 9), new DateTime(2023, 5, 15), 180.00, 9, false, true, "Express" },
            { new DateTime(2023, 5, 10), new DateTime(2023, 5, 15), 210.99, 10, true, false, "Express" }

    });
            migrationBuilder.InsertData(
                table: "Lineas",
                columns: new[] { "ArticuloId", "Unidades", "Precio", "IdPedido", "PedidoId" },
                values: new object[,]
                {
            { 1, 2, 19.99, 1 ,1},
            { 2, 1, 29.99, 1 , 1},
            { 3, 3, 39.99, 2 , 2},
            { 4, 1, 14.99, 2 , 2},
            { 5, 2, 24.99, 3 , 3},
            { 6, 1, 49.99, 3 , 3},
            { 7, 1, 899.99, 4 , 4},
            { 8, 2, 699.99, 4 , 4},
            { 9, 1, 1199.99, 5 , 5},
            { 10, 3, 79.99, 5 , 5},
            { 11, 2, 1499.99, 6 , 6},
            { 12, 1, 19.99, 6 , 6},
            { 13, 2, 29.99, 7 , 7},
            { 14, 1, 49.99, 7 , 7},
            { 15, 1, 34.99, 8 , 8},
            { 1, 2, 19.99, 8 , 8},
            { 2, 1, 29.99, 9 , 9},
            { 3, 3, 39.99, 9 , 9},
            { 4, 1, 14.99, 10 , 10},
            { 5, 2, 24.99, 10 , 10}
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
