using ExpressPcArızaTakip.Models.Entity;
using ExpressPcArızaTakip.Models.viewmodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace ExpressPcArızaTakip.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        expresspcEntities db = new expresspcEntities();
        public ActionResult Index()
        {
            int? userId = Session["UserId"] as int?;
            var degerler = db.Problem.ToList();
            ViewBag.allSelectData = GetSelections1(userId);

            ViewBag.degerler = degerler;




            return View(degerler);
        }
        public ActionResult SorumluKisiler()
        {
            var degerler = db.User.ToList();

            ViewBag.degerler = degerler;
            return View(degerler);
        }

        #region Arıza tüm başlıklar

        /// <summary>
        /// Arıza nedenleri listeler
        /// </summary>
        /// <returns></returns>
        public ActionResult ArizaNedenleri()
        {
            var degerler = db.Reason.ToList();

            ViewBag.degerler = degerler;
            return View(degerler);
        }
        public ActionResult ArizaDurumlari()
        {
            var degerler = db.Situation.ToList();

            ViewBag.degerler = degerler;
            return View(degerler);
        }
        public ActionResult Sirketler()
        {
            var degerler = db.Company.ToList();

            ViewBag.degerler = degerler;
            return View(degerler);
        }

        #endregion

        public List<List<SelectListItem>> GetSelections()
        {
            var generalList = new List<List<SelectListItem>>();
            List<SelectListItem> allUsers = (from i in db.User.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Users,
                                                 Value = i.Id.ToString()

                                             })
                                             .ToList();
            generalList.Add(allUsers);
            List<SelectListItem> allReasons = (from a in db.Reason.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = a.ProblemReason,
                                                   Value = a.Id.ToString()
                                               }).ToList();
            generalList.Add(allReasons);
            List<SelectListItem> allSituations = (from b in db.Situation.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = b.ProblemSituation,
                                                      Value = b.Id.ToString()
                                                  }).ToList();
            generalList.Add(allSituations);
            List<SelectListItem> allCompanies = (from c in db.Company.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = c.Companies,
                                                     Value = c.Id.ToString()
                                                 }).ToList();
            generalList.Add(allCompanies);
            List<SelectListItem> allDeviceParts = (from c in db.DevicePart.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.DeviceParts,
                                                       Value = c.Id.ToString()
                                                   }).ToList();
            generalList.Add(allDeviceParts);

            List<SelectListItem> allDevices = (from c in db.Device.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = c.Devices,
                                                   Value = c.Id.ToString()
                                               }).ToList();
            generalList.Add(allDevices);


            return generalList;
        }
        public List<List<SelectListItem>> GetSelections1(int? userId)
        {
            var generalList = new List<List<SelectListItem>>();
            List<SelectListItem> allUsers = (from i in db.User.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Users,
                                                 Value = i.Id.ToString(),
                                                 Selected = userId.HasValue && i.Id == userId.Value

                                             })
                                             .ToList();
            generalList.Add(allUsers);
            List<SelectListItem> allReasons = (from a in db.Reason.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = a.ProblemReason,
                                                   Value = a.Id.ToString()
                                               }).ToList();
            generalList.Add(allReasons);
            List<SelectListItem> allSituations = (from b in db.Situation.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = b.ProblemSituation,
                                                      Value = b.Id.ToString()
                                                  }).ToList();
            generalList.Add(allSituations);
            var userCompanyId = db.User.Where(u => u.Id == userId).Select(u => u.CompanyId).FirstOrDefault();
            List<SelectListItem> allCompanies = (from c in db.Company.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = c.Companies,
                                                     Value = c.Id.ToString(),
                                                     Selected = userCompanyId.HasValue && c.Id == userCompanyId.Value
                                                 }).ToList();
            generalList.Add(allCompanies);
            List<SelectListItem> allDeviceParts = (from c in db.DevicePart.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.DeviceParts,
                                                       Value = c.Id.ToString()
                                                   }).ToList();
            generalList.Add(allDeviceParts);

            List<SelectListItem> allDevices = (from c in db.Device.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = c.Devices,
                                                   Value = c.Id.ToString()
                                               }).ToList();
            generalList.Add(allDevices);


            return generalList;
        }
        [HttpGet]
        public ActionResult YeniArizaEkle()
        {
            List<SelectListItem> degerler = (from i in db.User.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Users,
                                                 Value = i.Id.ToString()
                                             })
                                             .ToList();

            List<SelectListItem> degerler1 = (from a in db.Reason.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = a.ProblemReason,
                                                  Value = a.Id.ToString()
                                              }).ToList();

            List<SelectListItem> degerler2 = (from b in db.Situation.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = b.ProblemSituation,
                                                  Value = b.Id.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from c in db.Company.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = c.Companies,
                                                  Value = c.Id.ToString()
                                              }).ToList();

            ViewBag.dgr = degerler;
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniArizaEkle(Problem p1)

        {
            db.Problem.Add(p1);
            db.SaveChanges();
            return RedirectToAction("TabloyuGuncelle");
        }

        /// <summary>
        /// siler
        /// </summary>
        /// <param name="id">Sileceğin şeyin Id si </param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult SIL(int id)
        {
            var arıza = db.Problem.Find(id);
            db.Problem.Remove(arıza);
            db.SaveChanges();
            return RedirectToAction("TabloyuGuncelle");
        }

        public ActionResult Update(Problem p1)
        {
            var defaultModel = db.Problem.Where(x => x.Id == p1.Id).FirstOrDefault();
            defaultModel.Id = p1.Id;
            defaultModel.ProblemSituationId = p1.ProblemSituationId;
            defaultModel.ProblemReasonId = p1.ProblemReasonId;
            defaultModel.ProblemUserId = p1.ProblemUserId;
            defaultModel.ProblemCompanyId = p1.ProblemCompanyId;
            db.Problem.AddOrUpdate(defaultModel);
            db.SaveChanges();
            return Json("TabloyuGuncelle");


        }
        [HttpGet]
        public ActionResult GetProblem(int problemId)
        {
            var defaultModel = db.Problem.Where(x => x.Id == problemId).FirstOrDefault();
            var aw = new ProblemViewModel
            {
                Id = problemId,
                ProblemSituationId = defaultModel.ProblemSituationId,
                ProblemCompanyId = (int)defaultModel.ProblemCompanyId,
                ProblemReasonId = defaultModel.ProblemReasonId,
                ProblemUserId = defaultModel.ProblemUserId,
                ProblemDetails = defaultModel.ProblemDetails,
                Companies = defaultModel.Company.Companies,
                ProblemReason = defaultModel.Reason.ProblemReason,
                ProblemSituation = defaultModel.Situation.ProblemSituation,
                Users = defaultModel.User.Users,
            };

            return Json(aw, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]


        [HttpGet]
        public ActionResult GetAllProblem()
        {
            var allList = new List<ProblemViewModel>();
            var defaultModel = db.Problem.ToList();
            foreach (var item in defaultModel)
            {
                var aw = new ProblemViewModel
                {
                    Id = item.Id,
                    ProblemSituationId = item.ProblemSituationId,
                    ProblemCompanyId = (int)item.ProblemCompanyId,
                    ProblemReasonId = item.ProblemReasonId,
                    ProblemUserId = item.ProblemUserId,
                    Companies = item.Company.Companies,
                    ProblemReason = item.Reason.ProblemReason,
                    ProblemSituation = item.Situation.ProblemSituation,
                    Users = item.User.Users,
                };
                allList.Add(aw);
            }


            return Json(allList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult RefreshProblemTable()
        {
            var problems = db.Problem
                                   .Include(p => p.User)
                                   .Include(p => p.Reason)
                                   .Include(p => p.Situation)
                                   .Include(p => p.Company)
                                   .ToList();
            ViewBag.allSelectData = GetSelections();
            return PartialView("ProblemTable", problems);
        }

        public ActionResult TabloyuGuncelle()
        {
            var degerler = db.Problem.ToList();

            ViewBag.degerler = degerler;

            ViewBag.allSelectData = GetSelections();


            return View(degerler);
        }
        [HttpGet]
        public ActionResult SorumluKisiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SorumluKisiEkle(User p1)
        {
            db.User.Add(p1);
            db.SaveChanges();

            return RedirectToAction("SorumluKisiler");
        }
        public ActionResult SIL1(int id)
        {
            var user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Kullanıcının başka tablolarda kullanılıp kullanılmadığını kontrol edin
            bool isUsed = db.Problem.Any(x => x.ProblemUserId == id);

            if (isUsed)
            {
                return Json(new { success = false, message = "Bu kullanıcı başka tablolarda kullanıldığı için silinemez." }, JsonRequestBehavior.AllowGet);
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Json(new { success = true, message = "Kullanıcı başarıyla silindi." }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult ArizaNedeniEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ArizaNedeniEkle(Reason p1)
        {
            db.Reason.Add(p1);
            db.SaveChanges();

            return RedirectToAction("ArizaNedenleri");
        }
        [HttpGet]
        public ActionResult SirketEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SirketEkle(Company p1)
        {
            db.Company.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Sirketler");
        }

        public ActionResult SIL2(int id)
        {
            var user = db.Reason.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Kullanıcının başka tablolarda kullanılıp kullanılmadığını kontrol edin
            bool isUsed = db.Problem.Any(x => x.ProblemReasonId == id);

            if (isUsed)
            {
                return Json(new { success = false, message = "Bu arıza nedeni başka tablolarda kullanıldığı için silinemez." }, JsonRequestBehavior.AllowGet);
            }

            db.Reason.Remove(user);
            db.SaveChanges();

            return Json(new { success = true, message = "Arıza nedeni başarıyla silindi." }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult ArizaDurumuEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ArizaDurumuEkle(Situation p1)
        {
            db.Situation.Add(p1);
            db.SaveChanges();

            return RedirectToAction("ArizaDurumlari");
        }
        public ActionResult SIL3(int id)
        {
            var user = db.Situation.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Kullanıcının başka tablolarda kullanılıp kullanılmadığını kontrol edin
            bool isUsed = db.Problem.Any(x => x.ProblemSituationId == id);

            if (isUsed)
            {
                return Json(new { success = false, message = "Bu arıza durumu başka tablolarda kullanıldığı için silinemez." }, JsonRequestBehavior.AllowGet);
            }

            db.Situation.Remove(user);
            db.SaveChanges();

            return Json(new { success = true, message = "Arıza durumu başarıyla silindi." }, JsonRequestBehavior.AllowGet);

        }

       
        
        public ActionResult SIL4(int id)
        {
            var user = db.Company.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Kullanıcının başka tablolarda kullanılıp kullanılmadığını kontrol edin
            bool isUsed = db.Problem.Any(x => x.Id == id);

            if (isUsed)
            {
                return Json(new { success = false, message = "Bu arıza durumu başka tablolarda kullanıldığı için silinemez." }, JsonRequestBehavior.AllowGet);
            }

            db.Company.Remove(user);
            db.SaveChanges();

            return Json(new { success = true, message = "Arıza durumu başarıyla silindi." }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CozulenArizalar()
        {
            var cozulenArizalar = db.Problem
                .Include(p => p.User)
                .Include(p => p.Reason)
                .Include(p => p.Situation)
                .Include(p => p.Company)
                .Where(p => p.Situation.ProblemSituation == "Arıza Çözüldü")
                .ToList();

            return View(cozulenArizalar);
        }
        public ActionResult DevamEdenArizalar()
        {
            var cozulenArizalar = db.Problem
                .Include(p => p.User)
                .Include(p => p.Reason)
                .Include(p => p.Situation)
                .Include(p => p.Company)
                .Where(p => p.Situation.ProblemSituation == "Devam Ediyor")
                .ToList();

            return View(cozulenArizalar);
        }
        public JsonResult GetCompanyByUser(int userId)
        {
            // Kullanıcının şirket bilgisini bul
            var user = db.User.Include(u => u.Company).FirstOrDefault(u => u.Id == userId);

            if (user != null && user.Company != null)
            {
                return Json(new { success = true, companyId = user.Company.Id, companyName = user.Company.Companies }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult YeniKullaniciEkle()
        {
            // Dropdown'lar için gerekli verileri ViewBag'e atıyoruz
            ViewBag.Roles = db.Role.ToList();
            ViewBag.Companies = db.Company.ToList();

            // Boş bir model döndürüyoruz, bu sayfa sadece kullanıcı ekleme formunu gösterir
            return View();
        }
        public ActionResult KullaniciEkle()
        {
            var degerler = db.User.ToList();
            // Dropdown'lar için gerekli verileri ViewBag'e atıyoruz
            ViewBag.Roles = db.Role.ToList();
            ViewBag.Companies = db.Company.ToList();
            ViewBag.degerler = degerler;
            return View(degerler);
        }

        // Yeni Kullanıcıyı Kaydet
        [HttpPost]
        public ActionResult KullaniciEkle(User model)
        {
            if (ModelState.IsValid)
            {
                // Yeni kullanıcıyı veritabanına ekleme işlemi
                db.User.Add(model);
                db.SaveChanges();

                // Başarılı işlem sonrası yönlendirme
                return RedirectToAction("Index");
            }

            // Eğer işlem başarısız olursa, tekrar dropdown verilerini ViewBag'e atayıp formu geri döndürüyoruz
            ViewBag.Roles = db.Role.ToList();
            ViewBag.Companies = db.Company.ToList();

            return View(model);
        }




        [HttpGet]
        public ActionResult YeniArizaEkle1()
        {
            List<SelectListItem> degerler = (from i in db.User.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Users,
                                                 Value = i.Id.ToString()
                                             })
                                             .ToList();

            List<SelectListItem> degerler1 = (from a in db.Reason.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = a.ProblemReason,
                                                  Value = a.Id.ToString()
                                              }).ToList();

            List<SelectListItem> degerler2 = (from b in db.Situation.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = b.ProblemSituation,
                                                  Value = b.Id.ToString()
                                              }).ToList();
            List<SelectListItem> degerler3 = (from c in db.Company.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = c.Companies,
                                                  Value = c.Id.ToString()
                                              }).ToList();
            List<SelectListItem> degerler4 = (from c in db.Device.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = c.Devices,
                                                  Value = c.Id.ToString()
                                              }).ToList();
            List<SelectListItem> degerler5 = (from c in db.DevicePart.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = c.DeviceParts,
                                                  Value = c.Id.ToString()
                                              }).ToList();

            ViewBag.dgr = degerler;
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            ViewBag.dgr3 = degerler3;
            ViewBag.dgr4 = degerler4;
            ViewBag.dgr5 = degerler5;
            return View();
        }
        [HttpPost]
        public ActionResult YeniArizaEkle1(Problem p1)

        {
            db.Problem.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult ArizaTalepleri()
        {
            // Kullanıcı ID'sini oturumdan alın
            int? userId = Session["UserId"] as int?;

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account"); // Kullanıcı giriş yapmamışsa login sayfasına yönlendirin
            }

            using (var db = new expresspcEntities())
            {
                var arizaTalepleri = db.Problem
                                       .Include(p => p.User)
                                       .Include(p => p.Reason)
                                       .Include(p => p.Situation)
                                       .Include(p => p.Company)
                                       .Include(p => p.Device)
                                       .Include(p => p.DevicePart)
                                       .Where(p => p.User.Id == userId) // Kullanıcı ID'sine göre filtreleme
                                       .ToList();

                return View(arizaTalepleri);
            }
        }
        [HttpPost]
        public ActionResult UpdateProblemDetails(int ProblemId, string ProblemDetails)
        {
            // Veritabanından ilgili kaydı bulun
            var problem = db.Problem.Find(ProblemId);

            if (problem != null)
            {
                // Detayları güncelle
                problem.ProblemDetails = ProblemDetails;
                db.SaveChanges();
            }

            return RedirectToAction("TabloyuGuncelle");
        }
        [HttpPost]
        public ActionResult UpdateProblemDetails1(int ProblemId, string ProblemDetails)
        {
            // Veritabanından ilgili kaydı bulun
            var problem = db.Problem.Find(ProblemId);

            if (problem != null)
            {
                // Detayları güncelle
                problem.ProblemDetails = ProblemDetails;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateProblemDetailsForArizaTalepleri(int ProblemId, string ProblemDetails)
        {
            // Veritabanından ilgili kaydı bulun
            var problem = db.Problem.Find(ProblemId);

            if (problem != null)
            {
                // Detayları güncelle
                problem.ProblemDetails = ProblemDetails;
                db.SaveChanges();
            }

            return RedirectToAction("ArizaTalepleri");
        }
        [HttpPost]
        public ActionResult UpdateProblem(Problem model)
        {
            var problem = db.Problem.Find(model.Id);
            if (problem != null)
            {
                problem.ProblemUserId = model.ProblemUserId;
                problem.ProblemReasonId = model.ProblemReasonId;
                problem.ProblemSituationId = model.ProblemSituationId;
                problem.ProblemCompanyId = model.ProblemCompanyId;
                problem.ProblemDetails = model.ProblemDetails;

                db.SaveChanges(); // Veritabanına kaydediyoruz
            }

            return RedirectToAction("TabloyuGuncelle");
        }












    }
}