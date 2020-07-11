using MaxsGornTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows.Forms;
using FormCollection = System.Web.Mvc.FormCollection;

namespace MaxsGornTest.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ContextDb = new Context();
            AddUser(new User() { value = MvcApplication.GetCook });
        }
        private void AddUser(User user)
        {
                while (true)
                {
                    bool ee= false;
                    foreach (var el in ContextDb.Users)
                    {
                        if (el.value == user.value)
                        {
                           ee = true;
                        }
                    }
                    if (ee == false)
                    {
                        ContextDb.Users.Add(user);
                        ContextDb.SaveChanges();
                    }
                    break;
                }

        }
        private Context ContextDb;
        public ActionResult Index()
        {
            IEnumerable<Sound> Sounds = ContextDb.Sounds;
            return View(Sounds.ToList());
        }
        public ActionResult create()
        {
            return View();
        }
        public int GetId(IEnumerable<User> users, string name)
        {
            foreach (var el in users)
            {
                if (el.value == name)
                {
                    return el.id;
                }
            }
            return 0;
        }
        [HttpPost]
        public ActionResult AddSound(Sound sound)
        {
            try
            {
                ContextDb.Sounds.Add(new Sound { UserId = GetId(ContextDb.Users, MvcApplication.GetCook), FileNameUrl = sound.FileNameUrl, DateStart = sound.DateStart, Duration = sound.Duration });
                ContextDb.SaveChanges();
                ViewBag.message = "Saved!";
                return RedirectToAction("Index");
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message+sound.Duration);
                return View(sound);
            } 
        }
    }
}