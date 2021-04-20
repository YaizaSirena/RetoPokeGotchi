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
                    Response.Redirect("Pokedex.aspx");
                }
                else
                {
                    textNombre.Text = Convert.ToString("¿Seguro?");
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
                Response.Redirect("Pokedex.aspx");
            }
            else
            {
                textNombre.Text = Convert.ToString("Prueba otro nombre");
            }

        }
    }
}