﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace Natanael_Parcial1_AP2
{
    public partial class RegistrosMateriales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("IdSolicitud"),new DataColumn("IdMaterial"),new DataColumn("Cantidad"),new DataColumn("Precio") });
            ViewState["SlicitudesDetalle"] = dt;
            //Session["dt"] = dt; { new DataColumn("IdSolicitud"); new DataColumn("IdMaterial"); new DataColumn("Cantidad"); new DataColumn("Precio"); }
            FechaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FechaTextBox.Enabled = false;
        }
        
        Solicitudes solicitud = new Solicitudes();
        Materiales material = new Materiales();
        // private void FechaTime()
        //{
        //    FechaTextBox = (int)((DateTime.Now.Day) (DateTime.Now.Month) (DateTime.Now.Year));
        //}
        private int  Id(string numero)
        {
            int id = 0;
            int.TryParse(numero, out id);
            return id;
        }

        private void LlenarCampos(Solicitudes solicitud)
        {
            FechaTextBox.Text = solicitud.Fecha;
            RazonTextBox.Text = solicitud.Razon;
            MaterialesGridView.DataSource = solicitud.SolicitudDetalle;
            MaterialesGridView.DataBind();

        }
        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            if(IdTextBox.Text == "")
            {
                Response.Write("<script>Alert('Introdusca el ID')</script>");
            }    
                if(IdTextBox.Text.Length > 0)
                {
                    if (solicitud.Buscar(Id(IdTextBox.Text)))
                    {
                        LlenarCampos(solicitud);
                    }
                    else
                    {
                        Response.Write("<script>Alert('Id no existe')</script>");
                    }
                }else
                {
                    Response.Write("<script>Alert('Id no Encontrado.')</script>");
                }

        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            RazonTextBox.Text = "";
            MaterialDropDownList.Text = "";
            CantidadTextBox.Text = "";
            PrecioDropDownList.Text = "";
            MaterialesGridView.DataSource = null;
            MaterialesGridView.DataBind();

        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void LlenarDatos()
        {

            solicitud.Razon = IdTextBox.Text;
            foreach (SolicitudesDetalle item in solicitud.SolicitudDetalle)
            {
                //solicitud.AgregarSolicitud(item[0], item[1]);
            }
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if(IdTextBox.Text.Length == 0)
            {
                LlenarDatos();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if(IdTextBox.Text.Length > 0)
            {
                if (solicitud.Eliminar())
                {

                }else
                {

                }
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Solicitudes solicitud;

            if (Session["solicitud"] == null)
            {
                Session["solicitud"] = new Solicitudes();
            }
            solicitud = (Solicitudes)Session["solicitud"];

            solicitud.AgregarSolicitud(Convert.ToInt32(MaterialDropDownList.Text), Convert.ToInt32(CantidadTextBox.Text),Convert.ToSingle(PrecioDropDownList.Text));
            MaterialesGridView.DataSource = solicitud.SolicitudDetalle;
            MaterialesGridView.DataBind();
        }

        protected void FechaTextBox_TextChanged(object sender, EventArgs e)
        {
            
        
        }

        
    }
}