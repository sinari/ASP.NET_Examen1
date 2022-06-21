using System;
namespace ASP.NET_Examen1
{
	public class Entreprise
	{
		public int id_entreprise { set; get; }
		public string nom { set; get; }
		public string telephone { set; get; }
		public string couriel { set; get; }
		public string site_web { set; get; }



        public Entreprise(int id_entreprise, string nom, string telephone, string couriel, string site_web)
        {
            this.id_entreprise = id_entreprise;
            this.nom = nom;
            this.telephone = telephone;
            this.couriel = couriel;
            this.site_web = site_web;
        }
    }
}

