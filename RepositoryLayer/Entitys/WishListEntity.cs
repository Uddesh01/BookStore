using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entitys
{
    public class WishListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WishListId { get; set; }
        [ForeignKey("Books")]
        public long BookId { get; set; }
        [ForeignKey("Users")]
        public long UserId { get; set; }
    }
}
