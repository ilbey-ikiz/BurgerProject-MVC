using BurgerProject_MVC_G4.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Intrinsics.X86;

namespace BurgerProject_MVC_G4.Models
{
    public static class ForLogin
    {

        public static async void AddSuperUserAsync(UserManager<AppUser> userMan)
        {
            //@Adminekleme
            AppUser user = new AppUser()
            {
                //mikrosoft;aksini söylemedikce Identity kullanımında mail adreslerini otomatik olarak user name kısmına atar
                //değiştirmek için Areas=> Identity=> register=> OnPost
                //devamı program cs de var ve burayı silebiliriz adminimiz oluştuktan sonra aynı şekilde program cs de de kaldırabiliriz
                Name = "Admin",
                Surname = "Insan",
                EmailConfirmed = true,
                UserName = "su@deneme.com",
                NormalizedUserName = "SU@DENEME.COM",
                Email = "su@deneme.com",
                NormalizedEmail = "SU@DENEME.COM"
            };
            await userMan.CreateAsync(user, "Admin123.");
            await userMan.AddToRoleAsync(user, "Admin");

            AppUser user1 = new AppUser()
            {
                //mikrosoft;aksini söylemedikce Identity kullanımında mail adreslerini otomatik olarak user name kısmına atar
                //değiştirmek için Areas=> Identity=> register=> OnPost
                //devamı program cs de var ve burayı silebiliriz adminimiz oluştuktan sonra aynı şekilde program cs de de kaldırabiliriz
                Name = "ilbey",
                Surname = "ikiz",
                EmailConfirmed = true,
                UserName = "ilbey@gmail.com",
                NormalizedUserName = "ILBEY@GMAIL.COM",
                Email = "ilbey@gmail.com",
                NormalizedEmail = "ILBEY@GMAIL.COM"
            };
            await userMan.CreateAsync(user1, "Ilbey123.");
            await userMan.AddToRoleAsync(user1, "User");

            AppUser user2 = new AppUser()
            {
                //mikrosoft;aksini söylemedikce Identity kullanımında mail adreslerini otomatik olarak user name kısmına atar
                //değiştirmek için Areas=> Identity=> register=> OnPost
                //devamı program cs de var ve burayı silebiliriz adminimiz oluştuktan sonra aynı şekilde program cs de de kaldırabiliriz
                Name = "Emre",
                Surname = "Kara",
                EmailConfirmed = true,
                UserName = "emre@gmail.com",
                NormalizedUserName = "EMRE@GMAIL.COM",
                Email = "emre@gmail.com",
                NormalizedEmail = "EMRE@GMAIL.COM"
            };
            await userMan.CreateAsync(user2, "Emre123.");
            await userMan.AddToRoleAsync(user2, "User");

            AppUser user3 = new AppUser()
            {
                //mikrosoft;aksini söylemedikce Identity kullanımında mail adreslerini otomatik olarak user name kısmına atar
                //değiştirmek için Areas=> Identity=> register=> OnPost
                //devamı program cs de var ve burayı silebiliriz adminimiz oluştuktan sonra aynı şekilde program cs de de kaldırabiliriz
                Name = "Nazli",
                Surname = "Koc",
                EmailConfirmed = true,
                UserName = "nazli@gmail.com",
                NormalizedUserName = "NAZLI@GMAIL.COM",
                Email = "nazli@gmail.com",
                NormalizedEmail = "NAZLI@GMAIL.COM"
            };
            await userMan.CreateAsync(user3, "Nazli123.");
            await userMan.AddToRoleAsync(user3, "User");
        }



    }




}

