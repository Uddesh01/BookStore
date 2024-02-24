using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entitys
{
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CartId { get; set; }
        [ForeignKey("Users")]
        public long UserId { get; set; }
        public long BookId {  get; set; }
        public int Quantitys { get; set; }
        public int Amount { get; set;}
        public bool isOrdered { get; set; }
        [NotMapped]
        public UserEntity User { get; set; }
        [NotMapped]
        public BooksEntity book { get; set; }
    }
}
