using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Facturas : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int FacturaId { get; set; }
        public string Razon { get; set; }
        public List<MaterialesDetalle> MaterialDetalle { get; set; }

        public Facturas()
        {
            this.FacturaId = 0;
            this.Razon = "";
            MaterialDetalle = new List<MaterialesDetalle>();
        }

        public Facturas(int facturaId,string razon)
        {
            this.FacturaId = facturaId;
            this.Razon = razon;
        }

        public void AgregarMaterial(string material, int cantidad)
        {
            this.MaterialDetalle.Add(new MaterialesDetalle(material, cantidad));
        }

        public override bool Insertar()
        {
            bool retorno = false;
            int entero = 0;
            object identity;

            try {

                identity = conexion.ObtenerDatos(String.Format("Insert into Facturas(Razon) values('{0}') select @@identity ", this.Razon));
                int.TryParse(entero.ToString(), out entero);
                this.FacturaId = entero;
                if (entero == 0 )
                {
                    foreach (MaterialesDetalle item in MaterialDetalle)
                    {
                        retorno = conexion.Ejecutar(String.Format("insert into MaterialesDetalle(Material,Cantidad) values('{0}',{1})", entero, item.Cantidad, item.Cantidad));
                    }
                }
            }catch (Exception Ex)
            {

                throw Ex;
            }
            return retorno;
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("delete from MaterialesDetalle where FacturaId= {0}"+ "delete from Facturas where FacturaId = {0}",this.FacturaId));
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable data = new DataTable();
            if(dt.Rows.Count > 0)
            {
                this.FacturaId = (int)dt.Rows[0]["FacturaId"];
                this.Razon = dt.Rows[0]["Razon"].ToString();

                foreach (DataRow item in data.Rows)
                {
                    this.AgregarMaterial(item["Material"].ToString(), (int)item["Cantidad"]);
                }
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = " Order By" + Orden;
            return conexion.ObtenerDatos("select" + Campos+ "from Facturas where " + Condicion + Orden);
        }
    }
}
