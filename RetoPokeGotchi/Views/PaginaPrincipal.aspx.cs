using RetoPokeGotchi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetoPokeGotchi.Views
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void butCargarPartida_Click(object sender, EventArgs e)
        {
            DALPokegotchi daLPokegotchi = new DALPokegotchi();
            try
            {
                if (daLPokegotchi.SelectUsuario(textNombre.Text) != null)
                {
                    Session["userId"] = daLPokegotchi.SelectIdUsuario(textNombre.Text);
                    Response.Redirect("PaginaPokedex.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe ninguna partida con ese nombre.')", true);
                }
            }
            catch(Exception error) { textNombre.Text = error.Message ; }
        }

        protected void butNuevaPartida_Click(object sender, EventArgs e)
        {
            DALPokegotchi daLPokegotchi = new DALPokegotchi();
            
            if(daLPokegotchi.SelectUsuario(textNombre.Text) == null && textNombre.Text != "")
            {
                daLPokegotchi.InsertarUsuario(textNombre.Text);
                Session["userId"] = daLPokegotchi.SelectIdUsuario(textNombre.Text);
                Response.Redirect("PaginaPokedex.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ya existe una partida con ese nombre. Prueba a introducir uno diferente')", true);
            }
        }
    }
}