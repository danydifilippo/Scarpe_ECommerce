using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Scarpe_ECommerce.Models
{
    public class Articolo
    {
        
        public int IdArticolo { get; set; }
        
        [Display(Name = "Nome Articolo")]
        public string Name { get; set; }

        [Display(Name = "Descrizione")]
        public string Description { get; set; }

        [Display(Name = "Immagine di copertina")]
        public string Img_Cover { get; set; }

        [Display(Name = "Immagine Aggiuntiva 1")]
        public string Img_1 { get; set; }

        [Display(Name = "Immagine Aggiuntiva 2")]
        public string Img_2 { get; set; }

        [Display(Name = "Articolo Oscurato")]
        public bool Obscured { get; set; }

        [Display(Name = "Prezzo")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public double Price { get; set; }

    }
}