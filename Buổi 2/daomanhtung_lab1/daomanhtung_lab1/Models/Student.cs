namespace daomanhtung_lab1.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên (Student ID)
        public string Name { get; set; } // Họ tên (Full Name)
        public string Email { get; set; } // Email
        public string? Password { get; set; } // Mật khẩu (Password)
        public Branch? Branch { get; set; } // Ngành học (Branch/Field of Study)
        public Gender? Gender { get; set; } // Giới tính (Gender)
        public bool IsRegular { get; set; } // Hệ: true - chính qui, false - phi cq (Regular System: true for regular, false for non-regular)
        public string? Address { get; set; } // Địa chỉ (Address)
		public DateTime DateofBirth { get; set; }
		public string? Avatar { get; set; }
	}
}
