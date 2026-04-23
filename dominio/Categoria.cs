using System;
using System.Collections.Generic;

namespace GestorArt.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}

