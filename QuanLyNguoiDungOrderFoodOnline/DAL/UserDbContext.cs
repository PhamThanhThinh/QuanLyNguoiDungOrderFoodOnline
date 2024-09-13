using Microsoft.EntityFrameworkCore;
using QuanLyNguoiDungOrderFoodOnline.Models;

namespace QuanLyNguoiDungOrderFoodOnline.DAL
{
  public class UserDbContext : DbContext
  {
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
  }
}
