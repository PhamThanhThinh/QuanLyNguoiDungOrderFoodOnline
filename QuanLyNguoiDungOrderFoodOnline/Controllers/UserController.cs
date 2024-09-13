using Microsoft.AspNetCore.Mvc;
using QuanLyNguoiDungOrderFoodOnline.DAL;
using QuanLyNguoiDungOrderFoodOnline.Models;

namespace QuanLyNguoiDungOrderFoodOnline.Controllers
{
  public class UserController : Controller
  {
    private readonly UserDbContext _dbContext;

    public UserController(UserDbContext dbContext)
    {
      this._dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
      var users = _dbContext.Users.ToList();
      List<UserViewModel> userViewModels = new List<UserViewModel>();

      if (users != null)
      {
        foreach (var user in users)
        {
          var UserViewModel = new UserViewModel()
          {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            Coin = user.Coin
          };
          userViewModels.Add(UserViewModel);
        }
        return View(userViewModels);
      }

      return View(userViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(UserViewModel userViewModel)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var user = new User()
          {
            FirstName = userViewModel.FirstName,
            LastName = userViewModel.LastName,
            DateOfBirth = userViewModel.DateOfBirth,
            Email = userViewModel.Email,
            Coin = userViewModel.Coin
          };

          _dbContext.Users.Add(user);
          _dbContext.SaveChanges();
          TempData["successMessage"] = "Them du lieu thanh cong";
          //return View("Index");
          return RedirectToAction("Index");
        }
        else
        {
          TempData["errorMessage"] = "Khong them duoc du lieu";
          return View();
        }
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View();
      }
    }

    [HttpGet]
    public IActionResult Edit(int Id)
    {
      var user = _dbContext.Users.SingleOrDefault(x => x.Id == Id);

      try
      {
        if (user != null)
        {
          var userViewModel = new UserViewModel()
          {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            Coin = user.Coin
          };
          return View(userViewModel);
        }
        else
        {
          TempData["errorMessage"] = $"Khong hien thi du lieu thanh cong, Id la {Id}";
          return RedirectToAction("Index");
        }
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return RedirectToAction("Index");
      }
    }
    [HttpPost]
    public IActionResult Edit(UserViewModel model)
    {
      try
      {
        if (ModelState.IsValid)
        {
          var user = new User()
          {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            Coin = model.Coin
          };
          _dbContext.Users.Update(user);
          _dbContext.SaveChanges();
          TempData["successMessage"] = "Sua du lieu thanh cong";
          return RedirectToAction("Index");
        }
        else
        {
          TempData["errorMessage"] = "Du lieu khong hop le";
          return View();
        }
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return RedirectToAction("Index");
      }
    }
    [HttpGet]
    public IActionResult Delete(int Id)
    {
      var user = _dbContext.Users.SingleOrDefault(x => x.Id == Id);

      try
      {
        if (user != null)
        {
          var userViewModel = new UserViewModel()
          {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            Coin = user.Coin
          };
          return View(userViewModel);
        }
        else
        {
          TempData["errorMessage"] = $"Khong hien thi du lieu thanh cong, Id la {Id}";
          return RedirectToAction("Index");
        }
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public IActionResult Delete(UserViewModel model)
    {
      var user = _dbContext.Users.SingleOrDefault(x => x.Id == model.Id);
      try
      {
        if (user != null)
        {
          _dbContext.Users.Remove(user);
          _dbContext.SaveChanges();
          TempData["successMessage"] = "Xoa du lieu thanh cong";
          return RedirectToAction("Index");
        }
        else
        {
          TempData["errorMessage"] = $"Khong hien thi du lieu thanh cong, Id la {model.Id}";
          return RedirectToAction("Index");
        }
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View();
      }
    }
  }
}
