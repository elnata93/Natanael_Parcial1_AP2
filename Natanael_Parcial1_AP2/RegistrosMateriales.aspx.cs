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
        Facturas factura = new Facturas();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2]);
            //Session["dt"]= dt { new (""),new("")};
        }
        private int  Id(string numero)
        {
            int id = 0;
            int.TryParse(numero, out id);
            return id;
        }

        private void LlenarCampos()
        {
            RazonTextBox.Text = factura.Razon;
            MaterialesGridView.DataSource = factura.MaterialDetalle;
            MaterialesGridView.DataBind();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if(IdTextBox.Text == "")
            {
                LlenarCampos();
                if(IdTextBox.Text.Length > 0)
                {

                }else
                {

                }
            }
        }

        private void Limpiar()
        {
            IdTextBox.Text = "";
            RazonTextBox.Text = "";
            MaterialTextBox.Text = "";
            CantidadTextBox.Text = "";
            MaterialesGridView.DataSource = "";
            MaterialesGridView.DataBind();

        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void LlenarDatos()
        {
             factura.Razon = IdTextBox.Text;
            foreach (MaterialesDetalle item in factura.MaterialDetalle)
            {
                //factura.AgregarMaterial(item[0], item[1]);
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
                if (factura.Eliminar())
                {

                }else
                {

                }
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {

        }
    }
}