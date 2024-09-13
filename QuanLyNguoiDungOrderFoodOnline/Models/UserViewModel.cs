using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNguoiDungOrderFoodOnline.Models
{
  public class UserViewModel
  {
    public int Id { get; set; }

    [DisplayName("Tên")]
    public string FirstName { get; set; }
    
    [DisplayName("Họ")]
    public string LastName { get; set; }

    [DisplayName("Ngày sinh")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Địa chỉ Email")]
    public string Email { get; set; }

    public double Coin { get; set; }

    [DisplayName("Họ và tên")]
    public string FullName
    {
      get { return LastName + " " + FirstName; }
    }
  }
}
