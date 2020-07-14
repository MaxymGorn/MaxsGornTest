using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Interfaces;
using MaxsGornTest.Controllers;
using MaxsGornTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Presentation_Layer.Controllers
{
    public class SoundsController : Controller
    {
        ISoundService soundService;
        public SoundsController(ISoundService soundService)
        {
            this.soundService = soundService;
        }

        // GET: Sounds
        public async Task<ActionResult> Index()
        {
            return View(soundService.GetSounds());
        }

        // GET: Sounds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoundDTO sound = soundService.GetSound(id);
            if (sound == null)
            {
                return HttpNotFound();
            }
            return View(sound);
        }

        // GET: Sounds/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(soundService.GetUsers(), "id", "value");
            return View();
        }

        // POST: Sounds/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,FileNameUrl,DateStart,Duration,UserId")] SoundDTO sound)
        {
            if (ModelState.IsValid)
            {
                soundService.MakeSoundAsync(sound);
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(soundService.GetUsers(), "id", "value", sound.UserId);
            return View(sound);
        }

        // GET: Sounds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoundDTO sound = soundService.GetSound(id);
            if (sound == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(soundService.GetUsers(), "id", "value", sound.UserId);
            return View(sound);
        }

        // POST: Sounds/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,FileNameUrl,DateStart,Duration,UserId")] SoundDTO sound)
        {
            if (ModelState.IsValid)
            {
                await soundService.UpdateSound(sound);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(soundService.GetUsers(), "id", "value", sound.UserId);
            return View(sound);
        }

        // GET: Sounds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoundDTO sound =  soundService.GetSound(id);
            if (sound == null)
            {
                return HttpNotFound();
            }
            return View(sound);
        }

        // POST: Sounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (AzureBlobManager azureBlobManager = AzureBlobManager.getInstance())
            {
                SoundDTO sound = soundService.GetSound(id);
                await Task.Run(async () => await azureBlobManager.DeleteAsync(sound.FileNameUrl));
                await soundService.DeleteSoundAsync(sound);
            }
            return RedirectToAction("Index");
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