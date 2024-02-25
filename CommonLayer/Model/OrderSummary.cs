using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class OrderSummary
    {
        public long OrderId { get; set; }
        public long BookId { get; set; }
        public string BookName {  get; set; }
        public string Author { get; set; }
        public string BookImage { get; set; }
        public int Quantitys { get; set; }
        public int Amount {  get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
