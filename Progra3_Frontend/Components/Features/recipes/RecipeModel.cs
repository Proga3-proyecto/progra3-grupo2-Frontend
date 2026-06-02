using Progra3_Frontend.Components.Features.Products;
using static System.Net.Mime.MediaTypeNames;
namespace Progra3_Frontend.Components.Pages.recipes
{
    // Tabla: Receta
    public class Receta
    {
        public int IdReceta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion  { get; set; }
        public string ImageSrc { get; set; }
        public string ImageUrl => $"/assets/recipes/{ImageSrc}";

        // INTERPRETACIÓN UNO A MUCHOS: Una receta conoce y contiene sus propios ingredientes/elementos
        public List<ElementoReceta> Elementos { get; set; } = new();
    }

     // Importamos para relacionar la clase Producto


    // Tabla: Elemento_Receta
    public class ElementoReceta
    {
        public int IdElementoReceta { get; set; } // PK
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; } = "oz"; // Atributo utilitario de presentación

        // INTERPRETACIÓN DE FK (id_producto): Un elemento de la receta apunta directamente al Objeto Producto completo
        public Producto Producto { get; set; } = default!;

        // Nota: No se incluye 'IdReceta' (FK) porque este elemento ya vive dentro de la lista de su Receta contenedora
    }

    // Tabla: Detalle_Receta
    public class DetalleReceta
    {
        public int IdDetalleReceta { get; set; } // PK
        public decimal DescuentoTotal { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal MontoTotal { get; set; }

        // INTERPRETACIÓN DE FK (id_receta_base): El detalle del carrito/pedido referencia a la estructura de la Receta original
        public Receta RecetaBase { get; set; } = default!;

        // INTERPRETACIÓN UNO A MUCHOS: Un detalle del carrito contiene la lista de especificaciones de sus elementos
        public List<DetalleElementoReceta> DetallesElementos { get; set; } = new();

        // Nota: Omitimos 'IdPedido' e 'IdClienteCarrito' ya que se interpretan mediante el flujo de la sesión o el contenedor del Pedido general
    }

    // Tabla: Detalle_Elemento_Receta
    public class DetalleElementoReceta
    {
        public int IdDetalleElementoReceta { get; set; } // PK
        public decimal CantidadEspecifica { get; set; }

        // INTERPRETACIÓN DE FK (id_elemento_base): Enlaza directamente al objeto de definición de ingrediente original
        public ElementoReceta ElementoBase { get; set; } = default!;
    }
}
