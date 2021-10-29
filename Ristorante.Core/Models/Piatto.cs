using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Models
{
    public enum Tipo
    {
        Contorno,
        Primo,
        Secondo,
        Dolce
    }
    public class Piatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipo Tipologia { get; set; }
        public decimal Prezzo { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

    }
}
