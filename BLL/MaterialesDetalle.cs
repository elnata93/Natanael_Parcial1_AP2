using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MaterialesDetalle
    {
        public int MaterialDetalleId { get; set; }
        public string Material { get; set; }
        public int Cantidad { get; set; }

        public MaterialesDetalle()
        {
            this.MaterialDetalleId = 0;
            this.Material = "";
            this.Cantidad = 0;
                
        }

        public MaterialesDetalle(string material,int cantidad)
        {
            this.Material = material;
            this.Cantidad = cantidad;
        }

    }
}
