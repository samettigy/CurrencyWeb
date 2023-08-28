using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWeb.Entities.Model
{
    public class MoneyRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Sell { get; set; }
        public double Buy { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyId { get; set; }
       // public Currency Currency { get; set; }
    }
}
