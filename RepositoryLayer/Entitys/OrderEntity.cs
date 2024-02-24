using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entitys
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderID { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Carts")]
        public long CartId {  get; set; }

    }
}
