using System;
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
            LlenarDropDownList();
        }
        
        Solicitudes solicitud = new Solicitudes();
        Materiales material = new Materiales();



        private void LlenarDropDownList()
        {
            MaterialDropDownList.DataSource = material.Listado(" * ", " 1=1 ", " ");
            MaterialDropDownList.DataTextField = "Descripcion";
            MaterialDropDownList.DataValueField = "IdMaterial";
            MaterialDropDownList.DataBind();

            PrecioDropDownList.DataSource = material.Listado(" * ", " 1=1 ", " ");
            PrecioDropDownList.DataTextField = "Precio";
            PrecioDropDownList.DataValueField = "IdMaterial";
            PrecioDropDownList.DataBind();
        }
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
            //solicitud.Fecha = FechaTextBox.Text;
            //solicitud.Razon = RazonTextBox.Text;
            MaterialesGridView.DataSource = solicitud.SolicitudDetalle;
            MaterialesGridView.DataBind();
            MaterialesGridView.AutoGenerateColumns = false;

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
            FechaTextBox.Text = string.Empty;
            RazonTextBox.Text = "";
            MaterialDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";
            PrecioDropDownList.SelectedIndex = 0;
            MaterialesGridView.DataSource = null;
            MaterialesGridView.DataBind();

        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void LlenarDatos()
        {
            solicitud.Fecha = FechaTextBox.Text;
            solicitud.Razon = RazonTextBox.Text;
            foreach (GridViewRow item in MaterialesGridView.Rows)
            {
                solicitud.AgregarSolicitud(Convert.ToInt32(item.Cells[0]), Convert.ToInt32(item.Cells[1]), Convert.ToSingle(item.Cells[2]));
            }
            solicitud.Total = Convert.ToSingle(TotalTextBox.Text);
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (RazonTextBox.Text.Length == 0 || MaterialDropDownList.Text.Length == 0 || CantidadTextBox.Text.Length == 0 || PrecioDropDownList.Text.Length == 0 || MaterialesGridView.Rows.Count == 0 || TotalTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Hay campos sin completar');<script>");
            }
            else

            if (Id(IdTextBox.Text) == 0)
            {

                LlenarDatos();
                if (solicitud.Insertar())
                {
                    Response.Write("<script>alert('Solicitud Guardada');<script>");
                }
                else
                {
                    Response.Write("<script>alert('Error al Guardar');</script>");
                }
                //Limpiar();
            }
            else
            if (Id(IdTextBox.Text) > 0)
            {
                if (solicitud.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarDatos();
                    if (solicitud.Editar())
                    {
                        Response.Write("<script>alert('Solicitud Editada');<script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Editar');</script>");
                    }
                }
                //Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Debe Ingresar el ID');<script>");
            }
            else
            {
                if (solicitud.Buscar(Id(IdTextBox.Text)))
                {
                    solicitud.Eliminar();
                    Response.Write("<script>alert('Solicitud Eliminada');<script>");
                    //Limpiar();
                }
                else
                {
                    Response.Write("<script>alert('Error Solicitud no se Elimino');<script>");
                    //Limpiar();
                }
            }
        }

        private void CalculoTotal()
        {
            int Anterior, presente = 0;
            int.TryParse(TotalTextBox.Text, out Anterior);
            int precio, cantidad, total = 0;
            int.TryParse(PrecioDropDownList.Text, out precio);
            int.TryParse(CantidadTextBox.Text, out cantidad);
            total = precio * cantidad;
            presente = Anterior + total;
            TotalTextBox.Text = presente.ToString();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Solicitudes solicitud;

            if (Session["Solicitud"] == null)
            {
                Session["Solicitud"] = new Solicitudes();
            }
            solicitud = (Solicitudes)Session["Solicitud"];

            
            if (MaterialDropDownList.Text.Length == 0 || CantidadTextBox.Text.Length == 0 || PrecioDropDownList.Text.Length == 0 )
            {
                Response.Write("<script>alert('Debe llenar los Campos');</script>");
            }
            else
            {
                solicitud.AgregarSolicitud(Convert.ToInt32(MaterialDropDownList.Text), Convert.ToInt32(CantidadTextBox.Text), Convert.ToSingle(PrecioDropDownList.Text));
                MaterialesGridView.DataSource = solicitud.SolicitudDetalle;
                MaterialesGridView.DataBind();
                foreach (GridViewRow row in MaterialesGridView.Rows)
                {
                    solicitud.AgregarSolicitud(Convert.ToInt32(row.Cells[0]), Convert.ToInt32(row.Cells[1]), Convert.ToSingle(row.Cells[2]));
                }
                CalculoTotal();
                //MaterialDropDownList.Text = "";
                //CantidadTextBox.Text = "";
                //PrecioDropDownList.Text = "";
                //ImporteTextBox.Text = "";
            }
        }

        protected void FechaTextBox_TextChanged(object sender, EventArgs e)
        {
            
        
        }

        
    }
}