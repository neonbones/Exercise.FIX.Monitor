using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Monitor.Models;

namespace Monitor.Seed
{
    public class Initialize
    {
        public static void DatabaseInitialize(IServiceProvider serviceProvider)
        {

            string userRoleName = "User";
            string adminRoleName = "Administrator";

            string adminLogin = "administrator";
            string adminPassword = "admin";

            string userLogin = "skylark";
            string userPassword = "qwerty";

            string googleSiteName = "http://google.com";
            string vkSiteName = "http://vk.com";
            string facebookSiteName = "http://facebook.com";
            string microsoftiteName = "http://microsoft.com";
            string incorrectSiteName = "http://vvvvvveqwqw.ru";

            using (WebAppContext db = serviceProvider.GetRequiredService<WebAppContext>())
            {             

                // Role creation
                Role userRole = db.Roles.FirstOrDefault(x => x.Name == userRoleName);
                if (userRole == null)
                {
                    userRole = new Role { Name = userRoleName };
                    db.Roles.Add(userRole);
                }
                db.SaveChanges();

                Role adminRole = db.Roles.FirstOrDefault(x => x.Name == adminRoleName);
                if (adminRole == null)
                {
                    adminRole = new Role { Name = adminRoleName };
                    db.Roles.Add(adminRole);
                }
                db.SaveChanges();

                // First users creation
                User user = db.Users.FirstOrDefault(u => u.Login == userLogin);
             
                if (user == null)
                {
                    db.Users.Add(new User
                    {
                        FirstName = "Рустам",
                        LastName = "Асылгареев",
                        Patronymic = "Фанилевич",
                        Login = userLogin,
                        Password = userPassword,
                        Role = userRole,       
                    });
                    db.SaveChanges();
                }
                User admin = db.Users.FirstOrDefault(u => u.Login == adminLogin);
                if (admin == null)
                {
                    db.Users.Add(new User
                    {
                        FirstName = "Илья",
                        LastName = "Власов",
                        Patronymic = "Александрович",
                        Login = adminLogin,
                        Password = adminPassword,
                        Role = adminRole,         
                    });
                    db.SaveChanges();
                }

                // Sites adding
                Site googleSite = db.Sites.FirstOrDefault(u => u.Name == googleSiteName);
                if (googleSite == null)
                {
                    db.Sites.Add(new Site
                    {
                        Name = googleSiteName,
                        RefreshTime = 20000
                    });
                    db.SaveChanges();
                }

                Site vkSite = db.Sites.FirstOrDefault(u => u.Name == vkSiteName);
                if (vkSite == null)
                {
                    db.Sites.Add(new Site
                    {
                        Name = vkSiteName,
                        RefreshTime = 30000
                    });
                    db.SaveChanges();
                }
                Site facebookSite = db.Sites.FirstOrDefault(u => u.Name == facebookSiteName);
                if (facebookSite == null)
                {
                    db.Sites.Add(new Site
                    {
                        Name = facebookSiteName,
                        RefreshTime = 40000
                    });
                    db.SaveChanges();
                }
                Site microsoftSite = db.Sites.FirstOrDefault(u => u.Name == microsoftiteName);
                if (microsoftSite == null)
                {
                    db.Sites.Add(new Site
                    {
                        Name = microsoftiteName,
                        RefreshTime = 50000
                    });
                    db.SaveChanges();
                }

                Site incorrectSite = db.Sites.FirstOrDefault(u => u.Name == incorrectSiteName);
                if (incorrectSite == null)
                {
                    db.Sites.Add(new Site
                    {
                        Name = incorrectSiteName,
                        RefreshTime = 20000
                        
                    });
                    db.SaveChanges();
                }
            }
        }
        public static void CollectionInitialize(IServiceProvider serviceProvider)
        {

        }

    }
}