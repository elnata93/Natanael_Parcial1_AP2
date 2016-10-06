using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Materiales : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int IdMaterial { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public List<SolicitudesDetalle> MaterialDetalle { get; set; }

        public Materiales()
        {
            this.IdMaterial = 0;
            this.Descripcion = "";
            this.Precio = 0;
            MaterialDetalle = new List<SolicitudesDetalle>();
        }

        public Materiales(int idmaterial,string descripcion,float precio)
        {
            this.IdMaterial = idmaterial;
            this.Descripcion = descripcion;
            this.Precio = precio;
        }

        public void AgregarMaterial(int idSolicitud, int Idmaterial, int cantidad, float precio)
        {
            this.MaterialDetalle.Add(new SolicitudesDetalle(idSolicitud, Idmaterial, cantidad, precio));
        }

        public override bool Insertar()
        {
           
            int retorno = 0;
            object identity;

            try {

                identity = conexion.ObtenerDatos(String.Format("Insert into Facturas(Descripcion,Precio) values('{0}',{1}) select @@identity ", this.Descripcion,this.Precio));
                int.TryParse(retorno.ToString(), out retorno);
                this.IdMaterial = retorno;
                if (retorno > 0 )
                {
                    foreach (var item in MaterialDetalle)
                    {
                        conexion.Ejecutar(String.Format("insert into MaterialesDetalle(Material,Cantidad) values('{0}',{1})", retorno, item.Cantidad));
                    }
                }
            }catch (Exception Ex)
            {

                throw Ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
           
            try
            {
                retorno = conexion.Ejecutar(String.Format("update  Facturas set Descripcion='{0}',Precio={1} where IdMaterial={2} ", this.Descripcion,this.Precio));
                retorno = conexion.Ejecutar(String.Format("delete from MaterialesDetalle where IdMaterial = {0}", this.IdMaterial));
                if (retorno)
                {
                    foreach (var item in MaterialDetalle)
                    {
                        retorno = conexion.Ejecutar(String.Format("insert into MaterialesDetalle(IdMateial,Material,Cantidad) values({0},{1},'{1}')", this.IdMaterial, item.Cantidad));
                    }
                }
                return retorno;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format("delete from MaterialesDetalle where FacturaId= {0}" + "delete from Facturas where FacturaId = {0}",this.IdMaterial));
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
                this.IdMaterial = (int)dt.Rows[0]["IdMaterial"];
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.Precio = (float)dt.Rows[0]["Precio"];

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
