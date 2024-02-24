using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entitys
{
    public class CartEntity
    {
        public long CartId { get; set; }
        [ForeignKey("Users")]
        public long UserId { get; set; }
        public long BookId {  get; set; }
        public int Total_Quantitys { get; set; }
        public int Total_Price { get; set;}
        public bool isOrdered { get; set; }
    }
}
