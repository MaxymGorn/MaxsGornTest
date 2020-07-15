using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Interfaces;
using MaxsGornTest.Controllers;
using Newtonsoft.Json;
using Presentation_Layer.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows;

namespace Presentation_Layer.Controllers
{
    public class HomeController : Controller
    {
        ISoundService soundService;
        public HomeController(ISoundService soundService)
        {
            this.soundService = soundService;
            AddUser(new UserDTO() { value = MvcApplication.cookies.Value });
        }
 
        public  ActionResult Index( )
        {
            return View();
        }
        private void AddUser(UserDTO user)
        {
            while (true)
            {
                bool ee = false;
                using (CancellationTokenSource source = new CancellationTokenSource())
                {
                    CancellationToken token = source.Token;
                    var elem = soundService.GetUsers();
                    elem.ForEachAsync(elem.Count(), async i =>
                    {
                        if (i.value == user.value)
                        {
                            ee = true;
                            token.ThrowIfCancellationRequested();
                        }
                    }, token);
                    if (ee == false)
                    {
                        soundService.MakeUserAsync(user);
                    }
                    break;
                }
            }

        }
        public int GetId(IEnumerable<UserDTO> users, string name)
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Проверить аргументы или открытые методы", Justification = "<Ожидание>")]
        public async Task<JsonResult> Upload(HttpPostedFileBase blob, string dateStart, string duration)
        {
            using (AzureBlobManager azureBlobManager = AzureBlobManager.getInstance())
            {
                await soundService.MakeSoundAsync(new SoundDTO() { DateStart = dateStart, Duration = duration, FileNameUrl = await azureBlobManager.SaveAsync(blob).ConfigureAwait(true), UserId = GetId(soundService.GetUsers(), MvcApplication.cookies.Value) });
            }
            return JsonConvert.DeserializeObject<dynamic>("Success: " + blob.FileName);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                soundService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}