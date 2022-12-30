using Hastane.DataAccess.Abstract;
using Hastane.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NRM1_HastaneOtomasyon.Models;


namespace NRM1_HastaneOtomasyon.Controllers
{
    public class LoginController : Controller
    {

        //    //Giriş Yapan Kullanıcı Bilgileri Tutulur
        //    //Session 
        //    public static IUser activePerson;

        private readonly IAdminRepo _adminRepo;
        private readonly IManagerRepo _managerRepo;
        private readonly IPersonnelRepo _personnelRepo;
        public LoginController(IAdminRepo adminRepo,IManagerRepo managerRepo,IPersonnelRepo personnelRepo)
        {
            _adminRepo= adminRepo;
            _managerRepo= managerRepo;
            _personnelRepo= personnelRepo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string emailAddress, string password)
        {
            //admin manager personel aslında tek bir tablodan yonetilir ve bu tablodan sorgu yapılır anlık cozum uretmek icin boyle bir davranıs sergıledım

            //baserepo yazabilirdim by getbyemaıl metotlarını yazmamanın nedenı ise baserepo daki T kısıtlamasında emaıladress ve password bilgilerinin bulunmamasından kaynaklanmaktadır


            var adminUser = _adminRepo.GetByEmail(emailAddress, password);
            var managerUser = _managerRepo.GetByEmail(emailAddress, password);
            var personenelUser = _personnelRepo.GetByEmail(emailAddress, password);

            if (adminUser!=null)
            {
                return RedirectToAction("Index", "Admin");
            }
            if (managerUser != null)
            {
                return RedirectToAction("Index", "Manager");
            }
            if (personenelUser != null)
            {
                return RedirectToAction("Index", "Personnel");
            }

            return View();
        }
    }
}

