using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudesDetalle
    {
        public int IdSolicitudDetalle { get; set; }
        public int IdMaterial { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

        public SolicitudesDetalle()
        {
            this.IdSolicitudDetalle = 0;
            this.IdMaterial = 0;
            this.Cantidad = 0;
            this.Precio = 0;
                
        }

        public SolicitudesDetalle(int Idmaterial,int cantidad, float precio)
        {
            this.IdMaterial = IdMaterial;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

    }
}
