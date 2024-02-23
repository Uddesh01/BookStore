using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class AddBookModel
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string BookImage { get; set; }
        public int Quantity { get; set; }

    }
}
