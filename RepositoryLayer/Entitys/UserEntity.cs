using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entitys
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserContact { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
