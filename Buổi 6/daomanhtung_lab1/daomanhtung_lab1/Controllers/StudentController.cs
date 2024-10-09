using daomanhtung_lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace daomanhtung_lab1.Controllers
{
	public static class Database
	{
		public static List<Student> listStudents = new List<Student>
		{
 
            // Tạo danh sách sinh viên với 4 dữ liệu mẫu

                new Student { Id = 101, Name = "Hải Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", Email = "nam@g.com",Avatar = "/images/user.png" },
                new Student { Id = 102, Name = "Minh Tú", Branch = Branch.BE, Gender = Gender.Female, IsRegular = true, Address = "A1-2019", Email = "tu@g.com",Avatar = "/images/user.png" },
                new Student { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male, IsRegular = false, Address = "A1-2020", Email = "phong@g.com",Avatar = "/images/user.png" },
                new Student { Id = 104, Name = "Xuân Mai", Branch = Branch.EE, Gender = Gender.Female, IsRegular = false, Address = "A1-2021", Email = "mai@g.com",Avatar = "/images/user.png" }

		};
	}
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            // Trả về View Index.cshtml cùng Model là danh sách sv listStudents
            return View(Database.listStudents);
        }
		[HttpGet]
		public IActionResult Create()
		{
			//Lấy danh sách các giá trị Gender để hiển thị radio button trên form
			ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
			//Lấy danh sách các giá trị Branch để hiển thị select-option trên form
			//Để hiển thị select-option trên View cần dùng List<SelectListItem>
			ViewBag.AllBranches = new List<SelectListItem>()
			{
				new SelectListItem { Text = "IT", Value = "1" },
				new SelectListItem { Text = "BE", Value = "2" },
				new SelectListItem { Text = "CE", Value = "3" },
				new SelectListItem { Text = "EE", Value = "4" }
			};
			return View();
		}



        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = Database.listStudents.Last().Id + 1;
                Database.listStudents.Add(s);
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
    {
        new SelectListItem { Text = "IT", Value = "1" },
        new SelectListItem { Text = "BE", Value = "2" },
        new SelectListItem { Text = "CE", Value = "3" },
        new SelectListItem { Text = "EE", Value = "4" }
    };
            return View();
        }
        public async Task<IActionResult> Create(Student student, IFormFile avatarFile)
        {
            // Xử lý upload ảnh
            if (avatarFile != null && avatarFile.Length > 0)
            {
                var fileName = Path.GetFileName(avatarFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await avatarFile.CopyToAsync(fileStream);
                }
                student.Avatar = "/images/" + fileName; 
            }
            else student.Avatar = "/images/user.png";



            if (Database.listStudents.Count > 0) student.Id = Database.listStudents.Last<Student>().Id + 1;
            else student.Id = 1; 
              
            Database.listStudents.Add(student);
            return View("Index", Database.listStudents);
        }

    }


}
