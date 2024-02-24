using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entitys
{
    public class CartOrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CartOrderId { get; set; }
        public long CartId { get; set; }
        public long OrderId { get; set; }
        public CartEntity Cart { get; set; }
        public OrderEntity Order { get; set; }

    }
}
