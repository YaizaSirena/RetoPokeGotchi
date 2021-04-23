using RetoPokeGotchi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RetoPokeGotchi.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BindingList<String> data = new BindingList<String>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                recargarListPokegotchiPorIdUsuario(Convert.ToInt32(Session["userId"]));
            }
        }

        protected string obtenerSaludString(int salud)
        {
            return salud > 1 ? "Sano" : "Enfermo";
        }

        protected string construirTextoPokemon(Pokegotchi pokegotchi)
        {
            return pokegotchi.Pokemon.NombrePokemon.ToUpper() + " | Es de tipo  " + pokegotchi.Pokemon.Tipo.ToUpper() + " | Su estado de salud es  " + obtenerSaludString(pokegotchi.Salud) + " | Nivel de felicidad : " + pokegotchi.Felicidad;
        }

        protected void recargarListPokegotchiPorIdUsuario(int idUsuario)
        {
            List<Pokegotchi> listaPokegotchi = new DALPokegotchi().RecuperaPokegotchisPorIdUsuario(Convert.ToInt32(Session["userId"]));
            if (!IsPostBack)
            {
                int indice = 0;
                Hashtable listPokemonId = new Hashtable();
                List<String> listaTextoPokemons = new List<string>();
                foreach (Pokegotchi pokegotchi in listaPokegotchi)
                {
                    listaTextoPokemons.Add(construirTextoPokemon(pokegotchi));
                    listPokemonId.Add(indice, pokegotchi.Id);
                    indice++;
                }
                Session["listPokemonId"] = listPokemonId;
                listPokemons.DataSource = listaTextoPokemons;
                listPokemons.DataBind();
            }
            else
            {
                int indice = 0;
                Hashtable listPokemonId = new Hashtable();
                foreach (Pokegotchi pokegotchi in listaPokegotchi)
                {
                    data.Add(construirTextoPokemon(pokegotchi));
                    listPokemonId.Add(indice, pokegotchi.Id);
                    indice++;
                }
                Session["listPokemonId"] = listPokemonId;
                listPokemons.DataSource = data;
                listPokemons.DataBind();
            }
        }

        protected async void butCapturar_Click(object sender, EventArgs e)
        {
            if (textPedirPokemon.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Debe introducir un nombre de pokemon válido')", true);
            }
            else
            {
                try
                {
                    PokemonApi pokemonApi = await new DALPokemonApi().recuperarPokemonAPI(textPedirPokemon.Text);
                    if (pokemonApi != null)
                    {
                        DALPokegotchi dALPokegotchi = new DALPokegotchi();
                        if (!dALPokegotchi.ComprobarPokemonEnTabla(pokemonApi.Nombre))
                        {
                            dALPokegotchi.InsertarPokemon(pokemonApi);
                        }
                        Pokemon pokemonUsuario = dALPokegotchi.ObtenerIdPokemon(pokemonApi.Nombre);

                        dALPokegotchi.InsertarEnPokegotchi(pokemonUsuario, Convert.ToInt32(Session["userId"]));

                        recargarListPokegotchiPorIdUsuario(Convert.ToInt32(Session["userId"]));
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Pokémon introducido no existe, prueba con otro nombre')", true);
                    }
                }
                catch (Exception error) { }
            }

        }



        protected void listPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPokemons.SelectedIndex != -1)
            {
                Hashtable ht = new Hashtable();
                ht = (Hashtable)Session["listPokemonId"];
                DALPokegotchi dALpokegotchi = new DALPokegotchi();
                Pokegotchi pokegotchiSeleccionado = dALpokegotchi.RecuperaPokegotchiPorId((int)ht[listPokemons.SelectedIndex]);
                Image1.ImageUrl = "https://pokeres.bastionbot.org/images/pokemon/" + pokegotchiSeleccionado.Pokemon.IdApi + ".png";
                Image1.DataBind();

            }
        }

        protected void butRecolectar_Click(object sender, EventArgs e)
        {
            if (listPokemons.SelectedIndex == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un pokemon para poder recolectar')", true);
            }
            else
            {
                Hashtable hashTableIdPokemons = new Hashtable();
                hashTableIdPokemons = (Hashtable)Session["listPokemonId"];
                DALPokegotchi dALpokegotchi = new DALPokegotchi();
                dALpokegotchi.DisminuirFelicidad((int)hashTableIdPokemons[listPokemons.SelectedIndex]);
                dALpokegotchi.DisminuirSalud((int)hashTableIdPokemons[listPokemons.SelectedIndex]);
                recargarListPokegotchiPorIdUsuario(Convert.ToInt32(Session["userId"]));
            }

        }



        protected void butJugar_Click(object sender, EventArgs e)
        {
            if (listPokemons.SelectedIndex == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un pokemon para poder jugar')", true);
            }
            else
            {
                Hashtable hashTableIdPokemons = new Hashtable();
                hashTableIdPokemons = (Hashtable)Session["listPokemonId"];
                DALPokegotchi dALpokegotchi = new DALPokegotchi();
                dALpokegotchi.AumentarFelicidad((int)hashTableIdPokemons[listPokemons.SelectedIndex]);
                dALpokegotchi.AumentarSalud((int)hashTableIdPokemons[listPokemons.SelectedIndex]);
                recargarListPokegotchiPorIdUsuario(Convert.ToInt32(Session["userId"]));

                //controlar si hemos ganado
                int felicidad = dALpokegotchi.SelectMediaFelicidadPokegotchiPorIdUsuario(Convert.ToInt32(Session["userId"]));
                int salud = dALpokegotchi.SelectMediaSaludPokegotchiporIdUsuario(Convert.ToInt32(Session["userId"]));

                if (felicidad > 10 && salud > 10)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡Feicidades! Acabas de conseguir tu Pokegotchi Legendario')", true);

                }
            }

        }

    }
        
}