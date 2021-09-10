using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyClothesShop.Models
{
    public class User
    {     
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")] 
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public string Gender { get; set; }
        [Display(Name = "Email")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [Display(Name = "Tên đăng  nhập")] 
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")] 
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài phải ít nhất 6 ký tự")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ConfirmPassword { get; set; } 
    }
}