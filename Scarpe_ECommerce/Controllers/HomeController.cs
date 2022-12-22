using Scarpe_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scarpe_ECommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection sql = Shared.GetConnection();
            List<Articolo> articolos = new List<Articolo>();
            try
            {
                sql.Open();
                SqlCommand com = Shared.GetCommand("SELECT * FROM ARTICOLO", sql);


                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Articolo a = new Articolo();
                    a.IdArticolo = Convert.ToInt32(reader["IDArticolo"]);
                    a.Name = reader["Nome"].ToString();
                    a.Description = reader["Descrizione"].ToString();
                    a.Img_Cover = reader["ImgCopertina"].ToString();
                    a.Img_1 = reader["Img_1"].ToString();
                    a.Img_2 = reader["Img_2"].ToString();
                    a.Obscured = Convert.ToBoolean(reader["Oscurato"]);
                    a.Price = Convert.ToDouble(reader["Prezzo"]);
                    articolos.Add(a);
                }


            }
            catch (Exception ex)
            {
                ViewBag.MessageError = $"<div class=\"alert alert-danger\">{ex.Message}</div>";
            }
            finally
            {
                sql.Close();
            }

            return View(articolos);

        }

        public ActionResult Details(int id)
        {
            SqlConnection sql = Shared.GetConnection();
            Articolo a = new Articolo();

            try
            {
                sql.Open();
                SqlCommand com = Shared.GetCommand("SELECT * FROM ARTICOLO WHERE IDArticolo = @IDArticolo", sql);
                com.Parameters.AddWithValue("IDArticolo", id);

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    
                    a.Name = reader["Nome"].ToString();
                    a.Description = reader["Descrizione"].ToString();
                    a.Img_Cover = reader["ImgCopertina"].ToString();
                    a.Img_1 = reader["Img_1"].ToString();
                    a.Img_2 = reader["Img_2"].ToString();
                    a.Price = Convert.ToDouble(reader["Prezzo"]);

                }

            }
            catch (Exception ex)
            {
                ViewBag.MessageError = $"<div class=\"alert alert-danger\">{ex.Message}</div>";
            }
            finally
            {
                sql.Close();
            }
            return View(a);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Articolo a, HttpPostedFileBase Upload1, HttpPostedFileBase Upload2, HttpPostedFileBase Upload3)
        {
            SqlConnection sql = Shared.GetConnection();

            string ImgNameDB1 = "";
            string ImgNameDB2 = "";
            string ImgNameDB3 = "";

            if (Upload1.ContentLength>0)
            {
                ImgNameDB1 = Upload1.FileName;
                string Path = Server.MapPath("/Content/img/" + ImgNameDB1);
                Upload1.SaveAs(Path);
            }
            if (Upload2.ContentLength > 0)
            {
                ImgNameDB2 = Upload1.FileName;
                string Path = Server.MapPath("/Content/img/" + ImgNameDB2);
                Upload2.SaveAs(Path);
            }
            if (Upload3.ContentLength > 0)
            {
                ImgNameDB3 = Upload1.FileName;
                string Path = Server.MapPath("/Content/img/" + ImgNameDB3);
                Upload3.SaveAs(Path);
            }

            try
            {
                sql.Open();
                SqlCommand com = Shared.GetStoreProcedure("CreateProduct", sql);

                com.Parameters.AddWithValue("Nome", a.Name);
                com.Parameters.AddWithValue("Descrizione", a.Description);
                com.Parameters.AddWithValue("Prezzo", a.Price);
                com.Parameters.AddWithValue("ImgCopertina", ImgNameDB1);
                com.Parameters.AddWithValue("Img_1", ImgNameDB2);
                com.Parameters.AddWithValue("Img_2", ImgNameDB3);
                com.Parameters.AddWithValue("Oscurato", a.Obscured);

                int row = com.ExecuteNonQuery();

                if(row>0)
                { ViewBag.MessageConfirm = "Articolo creato"; }
                

            }catch(Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }
            finally
            {
                sql.Close();
            } 

            return RedirectToAction("Admin");

    }

        public ActionResult Products()
        {

            SqlConnection sql = Shared.GetConnection();
            List<Articolo> articolos = new List<Articolo>();
            try
            {
                sql.Open();
                SqlCommand com = Shared.GetCommand("SELECT * FROM ARTICOLO", sql);


                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Articolo a = new Articolo();
                    a.IdArticolo = Convert.ToInt32(reader["IDArticolo"]);
                    a.Name = reader["Nome"].ToString();
                    a.Description = reader["Descrizione"].ToString();
                    a.Img_Cover = reader["ImgCopertina"].ToString();
                    a.Img_1 = reader["Img_1"].ToString();
                    a.Img_2 = reader["Img_2"].ToString();
                    a.Obscured = Convert.ToBoolean(reader["Oscurato"]);
                    a.Price = Convert.ToDouble(reader["Prezzo"]);
                    articolos.Add(a);
                }


            }
            catch (Exception ex)
            {
                ViewBag.MessageError = $"<div class=\"alert alert-danger\">{ex.Message}</div>";
            }
            finally
            {
                sql.Close();
            }

            return View(articolos);
        }



    }


}
