using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNguoiDungOrderFoodOnline.Models
{
  //[Table("User")]
  public class User
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }

    public double Coin { get; set; }
  }
}
