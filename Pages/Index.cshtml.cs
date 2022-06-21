using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Examen1.Pages;

public class IndexModel : PageModel
{
    public List<Entreprise> liste = new List<Entreprise>();

    

    public void OnGet()
    {
        string connetionString;
        SqlConnection cnn;
        connetionString = @"Server=localhost,1433;Database=examen1;User=sa;Password=Malo1986!(*@Malo1986!(*@Sinfab;";
        cnn = new SqlConnection(connetionString);
        SqlCommand command;
        SqlDataReader dataReader;
        string sql;

        if (Request.Query.Keys.Contains("id_entreprise"))
        {
            cnn.Open();
            string id_entreprise = Request.Query["id_entreprise"];
            sql = "delete from entreprise where id_entreprise=@id_entreprise";
            command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@id_entreprise", id_entreprise);
            dataReader = command.ExecuteReader();
            cnn.Close();
        }


        cnn.Open();

        sql = "SELECT id_entreprise, nom, telephone, couriel, site_web FROM entreprise";
        command = new SqlCommand(sql, cnn);
        dataReader = command.ExecuteReader();
        while (dataReader.Read())
        {
            Entreprise e = new Entreprise((int)dataReader.GetValue(0), (string)dataReader.GetValue(1), (string)dataReader.GetValue(2), (string)dataReader.GetValue(3), (string)dataReader.GetValue(4));
            liste.Add(e);
        }
        cnn.Close();

    }
}

