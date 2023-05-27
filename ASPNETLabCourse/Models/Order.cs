using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETLabCourse.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введіть ім'я")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина ім'я не менше 2 символів")]
        public string FirstName { get; set; }
        [Display(Name = "Введіть прізвище")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина прізвища не менше 5 символів")]
        public string LastName { get; set; }
        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Довжина номера не менше 10 символів")]
        public string Phone { get; set; }
        [Display(Name = "Введіть електронну пошту")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Довжина email не менше 15 символів")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderPrice { get; set; }
        [Display(Name = "Введіть адресу")]
        [StringLength(35)]
        [Required(ErrorMessage = "Довжина адреси не менше 15 символів")]
        public string Address { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        [BindNever]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
