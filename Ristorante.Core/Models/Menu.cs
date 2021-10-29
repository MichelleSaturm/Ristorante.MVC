using System.Collections.Generic;

namespace Ristorante.Core.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public List<Piatto> Piatti { get; set; }
    }
}
