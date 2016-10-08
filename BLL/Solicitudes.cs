using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Solicitudes : ClaseMaestra
    {
        ConexionDb conexion = new ConexionDb();
        public int IdSolicitud { get; set; }
        public string Fecha { get; set; }
        public string Razon { get; set; }
        public float Total { get; set; }
        public List<SolicitudesDetalle> SolicitudDetalle { get; set; }

        public Solicitudes()
        {
            this.IdSolicitud = 0;
            this.Fecha = "";
            this.Razon = "";
            this.Total = 0;
            this.SolicitudDetalle = new List<SolicitudesDetalle>();
        }

        public Solicitudes(int idSolicitud,string fecha,string razon,float total)
        {
            this.IdSolicitud = idSolicitud;
            this.Fecha = fecha;
            this.Razon = razon;
            this.Total = total;
        }

        public void AgregarSolicitud( int Idmaterial, int cantidad, float precio)
        {
            this.SolicitudDetalle.Add(new SolicitudesDetalle( Idmaterial, cantidad, precio));
        }

        public override bool Insertar()
        {
           
            int retorno = 0;
            object identity;

            try {

                identity = conexion.ObtenerDatos(String.Format("Insert into Solicitudes(Fecha,Razon,Total) values('{0}','{1}',{2}) select @@identity ", this.Fecha,this.Razon,this.Total));
                int.TryParse(retorno.ToString(), out retorno);
                this.IdSolicitud = retorno;
                if (retorno > 0 )
                {
                    foreach (var item in SolicitudDetalle)
                    {
                        conexion.Ejecutar(String.Format("insert into SolicitudesDetalle(IdSolicitud,IdMaterial,Cantidad,Precio) values({0},{1},{2},{3})", retorno,item.IdMaterial,item.Cantidad,item.Precio));
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
                retorno = conexion.Ejecutar(String.Format("update  Solicitudes set Fecha='{0}',Razon='{1}',Total={2} where IdSolicitud={3} ", this.Fecha,this.Razon,this.Total,this.IdSolicitud));
                
                if (retorno)
                {
                    retorno = conexion.Ejecutar(String.Format("delete from SolicitudesDetalle where IdSolicitud = {0}", this.IdSolicitud));
                    foreach (SolicitudesDetalle item in SolicitudDetalle)
                    {
                        retorno = conexion.Ejecutar(String.Format("insert into SolicitudesDetalle(IdSolicitud,IdMaterial,Cantidad,Precio) values({0},{1},{2},{3})", this.IdSolicitud, item.IdMaterial, item.Cantidad, item.Precio));
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
                retorno = conexion.Ejecutar(String.Format("delete from SolicitudesDetalle where IdSolicitud= {0}" + "delete from Solicitudes where IdSolicitud = {0}", this.IdSolicitud));
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
            dt = conexion.ObtenerDatos(string.Format("select * from Solicitudes where IdSolicitud= " + IdBuscado));
            if (dt.Rows.Count > 0)
            {
                this.IdSolicitud = (int)dt.Rows[0]["IdSolicitud"];
                this.Fecha = dt.Rows[0]["Fecha"].ToString();
                this.Razon = dt.Rows[0]["Razon"].ToString();
                this.Total = (float)dt.Rows[0]["Precio"];

                data = conexion.ObtenerDatos(string.Format("select * from SolicitudesDetalle where IdSolicitud= " + IdBuscado));
                foreach (DataRow item in data.Rows)
                {
                    this.AgregarSolicitud(Convert.ToInt32(data.Rows[0]["IdMaterial"]), Convert.ToInt32(data.Rows[0]["Cantidad"]), Convert.ToSingle(data.Rows[0]["Precio"]));
                }
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = " Order By" + Orden;
            return conexion.ObtenerDatos("select" + Campos+ "from Solicitudes where " + Condicion + Orden);
        }
    }
}
