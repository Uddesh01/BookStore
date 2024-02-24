using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entitys
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderID { get; set; }

        [ForeignKey("Users")]
        public long UserID { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderAmount { get; set; }
        [NotMapped]
        public UserEntity User { get; set; }
        [NotMapped]
        public BooksEntity Book { get; set; }

    }
}
