using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitor.Constants
{
    public class ViewConstants
    {
        #region ru-ru
        public static readonly Dictionary<string, string> Resources = new Dictionary<string, string>
        {
            #region CRUD Commands
            { "Change", "Изменить" },
            { "Back", "Назад" },
            { "Home", "Домой" },
            { "Identifier", "Идентификатор" },
            { "DataBase", "База данных" },
            { "ExtendedInformation", "Информация" },
            { "Adding", "Добавление" },
            { "Add",  "Добавить" },
            { "Delete", "Удалить" },
            { "Edit", "Редактировать" },
            { "Editing", "Редактирование" },
            { "ConfirmDelete", "Удаление"},
            { "Actions", "Действия" },
            { "ExtendedInfo", "Информация" },
            { "Description", "Описание" },
            #endregion

            #region Login
            { "Enter", "Войти" },
            { "Logout", "Выйти:" },
            #endregion

            #region Site
            { "Site", "Сайт" },
            { "Sites", "Сайты" },
            { "RefreshTime", "Обновление" },
            #endregion

            #region Roles
            { "Roles", "Роли"},
            { "Role", "Роль" },
            #endregion

            #region Users
            { "Users", "Пользователи"},
            { "User", "Пользователь" },
            { "FirstName", "Имя"},
            { "Patronymic", "Отчество" },
            { "LastName", "Фамилия"},
            { "Login", "Логин" },
            { "Password", "Пароль" },
            #endregion
        };
        #endregion
    }
}
