using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Examen1.Pages
{
	public class Formulaire_AjoutModel : PageModel
    {
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
            String sql = "INSERT INTO entreprise ( nom, telephone, couriel, site_web) VALUES (@nom,@telephone,@couriel,@site_web)";
            command = new SqlCommand(sql, cnn);
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
        }
    }
}
