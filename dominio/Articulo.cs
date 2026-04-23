using System;
using System.Collections.Generic;

namespace GestorArt.Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        
        // El enunciado indica que un articulo puede tener 1 o más imágenes.
        public List<Imagen> Imagenes { get; set; }

        public Articulo()
        {
            Imagenes = new List<Imagen>();
        }
    }
}

