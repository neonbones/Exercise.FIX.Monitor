using System.ComponentModel.DataAnnotations;

namespace Monitor.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Необходимо заполнить \"Логин\"")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить \"Пароль\"")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить \"Имя\"")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
