using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        [RegularExpression(@"^[А-ЯЁA-Z]{1}[а-яёa-z]+$", ErrorMessage = "Имя должно начинатсья с большой буквы")]
        public string Name { get; set; } = string.Empty;
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 50 символов")]
        [RegularExpression(@"^[А-ЯЁA-Z]{1}[а-яёa-z]+$", ErrorMessage = "Фамилия должна начинатсья с большой буквы")]
        public string Surname { get; set; } = string.Empty;
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Логин должно быть от 5 до 20 символов")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Логин должен состоять только из английских символов и цифр")]
        public string Login { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Пароль должен быть от 5 до 20 символов")]
        [RegularExpression(@"^[A-Za-z0-9._-]+$", ErrorMessage = "Пароль должен состоять только из английских символов, цифр и символов - _ .")]
        public string Password { get; set; } = string.Empty;
        [RegularExpression(@"^([a-zA-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверный формат email")]
        public string Email { get; set; } = string.Empty;
        [RegularExpression(@"^\+375\d{9}$", ErrorMessage = "Телефон должен быть в формате +375XXXXXXXXX")]
        public string Phone { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
    }
}


