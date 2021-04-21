using RetoPokeGotchi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetoPokeGotchi.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Convert.ToInt32(Session["userId"]);
            DALPokegotchi daLPokegotchi = new DALPokegotchi();

            List<int> idPokemons = daLPokegotchi.selectIdPokemons(Convert.ToInt32(Session["userId"]));
            foreach (int id in idPokemons)
            {
                listPokemons.Items.Add(Convert.ToString(id));
            }
        }
    }
}