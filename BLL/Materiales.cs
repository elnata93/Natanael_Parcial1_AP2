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

        public Materiales()
        {
            this.IdMaterial = 0;
            this.Descripcion = "";
            this.Precio = 0;
        }

        public Materiales(int idmaterial,string descripcion,float precio)
        {
            this.IdMaterial = idmaterial;
            this.Descripcion = descripcion;
            this.Precio = precio;
        }

        public override bool Insertar()
        {

            bool retorno = false;
            try {

                retorno = conexion.Ejecutar(String.Format("Insert into Materiales(Descripcion,Precio) values('{0}',{1}) ", this.Descripcion,this.Precio));
                
            }catch (Exception Ex)
            {

                throw Ex;
            }
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno = false;
           
            try
            {
                retorno = conexion.Ejecutar(String.Format("update Materiales set Descripcion='{0}',Precio={1} where IdMaterial={2} ", this.Descripcion,this.Precio,this.IdMaterial));
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(String.Format(" delete from Materiales where IdMaterial={0} ",this.IdMaterial));
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
            dt = conexion.ObtenerDatos(string.Format("select * from Materiales where IdMaterial= " + IdBuscado));
            if(dt.Rows.Count > 0)
            {
                this.IdMaterial = (int)dt.Rows[0]["IdMaterial"];
                this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                this.Precio = (float)Convert.ToSingle(dt.Rows[0]["Precio"]);
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = " Order By" + Orden;
            return conexion.ObtenerDatos("select" + Campos+ "from Materiales where " + Condicion + Orden);
        }
    }
}
