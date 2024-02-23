using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entitys;

namespace RepositoryLayer
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BooksEntity> Books { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
    }
}
