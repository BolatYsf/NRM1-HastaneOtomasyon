using Hastane.Core.Enums;
using Hastane.DataAccess.EntityFramework.Context;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace NRM1_HastaneOtomasyon.Models.SeedDataFolder
{
    public static class SeedData
    {   
        //program.cs dosyasında bulunan app ile aynı sey
        public static void Seed(IApplicationBuilder app)
        {
            var scope=app.ApplicationServices.CreateScope(); //services olusturuyor
            var dbContext = scope.ServiceProvider.GetService<HastaneDbContext>();

            dbContext.Database.Migrate();
            if(dbContext.Admins.Count()==0)
            {
                dbContext.Admins.Add(new Admin
                {
                    Id = Guid.NewGuid(),
                    Name = "Yusuf",
                    Surname = "Bolat",
                    EmailAddress = "ysf@gmail.com",
                    Status =Status.Active,
                    Password = "1234",
                    CreatedDate = DateTime.Now,
                });
            }

            dbContext.SaveChanges();

        }
    }
}
