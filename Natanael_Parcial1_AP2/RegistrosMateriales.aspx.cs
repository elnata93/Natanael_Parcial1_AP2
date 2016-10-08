using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Natanael_Parcial1_AP2
{
    public partial class RegistroMateriales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IdTextBox.Enabled = false;
        }
        Materiales material = new Materiales();

        private int Id(string cadena)
        {
            int id = 0;
            int.TryParse(cadena, out id);
            return id;
        }
        private void LlenarCampos()
        {
             DescripcionTextBox.Text = material.Descripcion;
             PrecioTextBox.Text = Convert.ToString(material.Precio);
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if(IdTextBox.Text == "")
            {
                Response.Write("<script>alert('Introdusca el ID')</script>");
            }else
            if(Id(IdTextBox.Text) != 0)
            {
                if (material.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarCampos();
                }else
                {
                    Response.Write("<script>alert('Id no exite')</script>");
                }
            }else
            {
                Response.Write("<script>alert('Id no encontrado')</script>");
            }
            
        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            PrecioTextBox.Text = "";
            IdTextBox.Enabled = true;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        private void LlenarDatos()
        {
            material.Descripcion = DescripcionTextBox.Text;
            material.Precio = Convert.ToSingle(PrecioTextBox.Text);
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            
            if (DescripcionTextBox.Text.Length == 0 || PrecioTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Hay campos sin completar')<script>");
            }
            else
            
            if(Id(IdTextBox.Text) == 0)
            {

                    LlenarDatos();
                    if (material.Insertar())
                    {
                        Response.Write("<script>alert('Material Guardado')<script>");
                    }else
                    {
                        Response.Write("<script>alert('Error al Guardar')</script>");
                    }
                    //Limpiar();
            }
            else
            if (Id(IdTextBox.Text) > 0)
            {
                if (material.Buscar(Id(IdTextBox.Text)))
                {
                    LlenarDatos();
                    if (material.Editar())
                    {
                        Response.Write("<script>alert('Material Guardado')<script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Guardar')</script>");
                    }
                }
            //Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Debe Ingresar el ID')<script>");
            }
            else
            {
                if (material.Buscar(Id(IdTextBox.Text)))
                {
                    material.Eliminar();
                    Response.Write("<script>alert('Material Eliminado')<script>");
                    //Limpiar();
                }
                else
                {
                    Response.Write("<script>alert('Error Material no se Elimino')<script>");
                    //Limpiar();
                }
            }
        }
    }
}