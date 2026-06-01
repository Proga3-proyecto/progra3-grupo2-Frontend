namespace Progra3_Frontend.Components.Features.Products
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }

        // Ahora esto solo almacena el nombre del archivo (ej. "gin-bombay.png")
        public string Imagen { get; set; }
        public bool Favorito { get; set; } = false;

        // El URL se calcula dinámicamente aquí
        public string ImagenUrl => $"/assets/products/{Categoria.ToLower()}/{Imagen}";
    }
}
