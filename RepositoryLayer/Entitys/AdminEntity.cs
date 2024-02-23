using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entitys
{
    public class AdminEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AdminId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
    }
}
