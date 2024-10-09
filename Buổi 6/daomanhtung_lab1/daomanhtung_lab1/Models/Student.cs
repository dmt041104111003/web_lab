using System.ComponentModel.DataAnnotations;

namespace daomanhtung_lab1.Models
{
    public class Student
    {
        [Display(Name = "Mã sinh viên")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải có từ 4 đến 100 ký tự")]
        [Display(Name = "Họ tên")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [RegularExpression(@"^[^@\s]+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com")]
        [Display(Name = "Địa chỉ email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ hoa, một chữ thường, một số và một ký tự đặc biệt")]
        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Ngành học là bắt buộc")]
        [Display(Name = "Ngành học")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ đào tạo")]
        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime DateofBirth { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string? Avatar { get; set; }

        [Required(ErrorMessage = "Điểm trung bình là bắt buộc")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm trung bình phải từ 0.0 đến 10.0")]
        [Display(Name = "Điểm trung bình")]
        public double AverageScore { get; set; }
        
    }
}