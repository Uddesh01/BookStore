//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace RepositoryLayer.Entitys
//{
//    public class OrderEntity
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public long OrderID { get; set; }
//        public int Quantity { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public int OrderAmout { get; set; }

//        [ForeignKey("Cart")]
//        public long CartId { get; set; }

//        // Navigation property to CartEntity
//        public CartEntity Cart { get; set; }

//    }
//}
