using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSStore.Data.Model
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "ИМЯ БОЛЕЕ 1 СИМВОЛА")]
        public string firstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия БОЛЕЕ 1 СИМВОЛА")]
        public string lastName { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Адрес 1 СИМВОЛА")]
        public string address { get; set; }

        [Display(Name = "Емейл")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail БОЛЕЕ 1 СИМВОЛА")]
        public string email { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(10)]
        [Required(ErrorMessage = "Мало символов")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        public DateTime orderTime { get; set; }

        public List<OrderItems> orderItems { get; set; }
    }
}
