using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromovArte.Models
{
    public class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }


        public TipoEvento()
        {

        }

        public TipoEvento(int idTipoEvento, string nombre)
        {
            IdTipoEvento = idTipoEvento;
            Nombre = nombre;
        }
    }
}