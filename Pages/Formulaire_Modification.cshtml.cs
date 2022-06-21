using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Examen1.Pages
{
	public class Formulaire_ModificationModel : PageModel
    {
        [BindProperty]
        public string id_entreprise { get; set; }
        [BindProperty]
        public string nom { get; set; }
        [BindProperty]
        public string telephone { get; set; }
        [BindProperty]
        public string couriel { get; set; }
        [BindProperty]
        public string site_web { get; set; }

        public IActionResult OnPost()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=localhost,1433;Database=examen1;User=sa;Password=Malo1986!(*@Malo1986!(*@Sinfab;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql = "UPDATE entreprise SET nom=@nom, telephone=@telephone,couriel=@couriel, site_web=@site_web where id_entreprise=@id_entreprise";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id_entreprise", this.id_entreprise);
            command.Parameters.AddWithValue("@nom", this.nom);
            command.Parameters.AddWithValue("@telephone", this.telephone);
            command.Parameters.AddWithValue("@couriel", this.couriel);
            command.Parameters.AddWithValue("@site_web", this.site_web);

            dataReader = command.ExecuteReader();
            cnn.Close();
            return new RedirectToPageResult("/Index");
        }
        public void OnGet()
        {
            //Initialisation de la connexion à la base de données
            string connectionString = @"Server=localhost,1433;Database=examen1;User=sa;Password=Malo1986!(*@Malo1986!(*@Sinfab;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();


            string sql = "SELECT id_entreprise, nom, telephone, couriel, site_web FROM entreprise where id_entreprise=" + Request.Query["id_entreprise"];
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                ViewData["id_entreprise"] = (int)dataReader.GetValue(0);
                ViewData["nom"] = (string)dataReader.GetValue(1);
                ViewData["telephone"] = (string)dataReader.GetValue(2);
                ViewData["couriel"] = (string)dataReader.GetValue(3);
                ViewData["site_web"] = (string)dataReader.GetValue(4);
            }
            cnn.Close();
        }
    }
}
