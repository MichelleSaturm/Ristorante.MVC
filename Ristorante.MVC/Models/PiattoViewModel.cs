using Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ristorante.MVC.Models
{
    public class PiattoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipo Tipologia { get; set; }
        public decimal Prezzo { get; set; }

        public Menu Menu { get; set; }
        public int MenuId { get; set; }


    }
}
