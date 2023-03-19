using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLibrary.Models
{
    public class CardModel
    {
        public int AgencyId { get; set; }
        public string? InvoiceId { get; set; }
        public string? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        
    }
}
