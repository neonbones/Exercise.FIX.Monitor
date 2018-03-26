using System.ComponentModel.DataAnnotations;

namespace Monitor.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить \"Имя\"")]
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить \"Логин\"")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить \"Пароль\"")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Необходимо заполнить \"Роль\"")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
