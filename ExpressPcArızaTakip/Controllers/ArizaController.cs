//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.Entity;
//using System.Data.Entity.Migrations;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Security.Cryptography;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;
//using System.Windows.Forms;
//using System.Windows.Markup;
//using ExpressPcArızaTakip.Models.Entity;
//using ExpressPcArızaTakip.Models.viewmodel;




//namespace ExpressPcArızaTakip.Controllers
//{
//    [Authorize]
//    public class ArizaController : Controller
//    {
       


//        expresspcEntities db = new expresspcEntities();


//        public ActionResult Index()
//        {
//            var degerler = db.TBLPROBLEM.ToList();
           
//            ViewBag.degerler = degerler;

//            ViewBag.allSelectData = GetSelections();


//            return View(degerler);


//        }

//        public List<List<SelectListItem>> GetSelections()
//        {
//            var generalList = new List<List<SelectListItem>>();
//            List<SelectListItem> allUsers = (from i in db.TBLUSERS.ToList()
//                                          select new SelectListItem
//                                          {
//                                              Text = i.Users,
//                                              Value = i.UserId.ToString()
//                                          })
//                                             .ToList();
//            generalList.Add(allUsers);
//            List<SelectListItem> allReasons = (from a in db.TBLREASON.ToList()
//                                           select new SelectListItem
//                                           {
//                                               Text = a.ProblemReason,
//                                               Value = a.Id.ToString()
//                                           }).ToList();
//            generalList.Add(allReasons);
//            List<SelectListItem> allSituations = (from b in db.TBLSİTUATİON.ToList()
//                                           select new SelectListItem
//                                           {
//                                               Text = b.ProblemSituation,
//                                               Value = b.SituationId.ToString()
//                                           }).ToList();
//            generalList.Add(allSituations);
//            List<SelectListItem> allPlaces = (from c in db.TBLPLACE.ToList()
//                                           select new SelectListItem
//                                           {
//                                               Text = c.ProblemPlace,
//                                               Value = c.PlaceId.ToString()
//                                           }).ToList();
//            generalList.Add(allPlaces);
            
//            return generalList;
//        }
//        [HttpGet]
//        public ActionResult YeniArıza()
//        {
//            List<SelectListItem> degerler = (from i in db.TBLUSERS.ToList()
//                                             select new SelectListItem
//                                             {
//                                                 Text = i.Users,
//                                                 Value = i.UserId.ToString()
//                                             })
//                                             .ToList();

//            List<SelectListItem> degerler1 = (from a in db.TBLREASON.ToList()
//                                              select new SelectListItem
//                                              {
//                                                  Text = a.ProblemReason,
//                                                  Value = a.Id.ToString()
//                                              }).ToList();

//            List<SelectListItem> degerler2 = (from b in db.TBLSİTUATİON.ToList()
//                                              select new SelectListItem
//                                              {
//                                                  Text = b.ProblemSituation,
//                                                  Value = b.SituationId.ToString()
//                                              }).ToList();
//            List<SelectListItem> degerler3 = (from c in db.TBLPLACE.ToList()
//                                              select new SelectListItem
//                                              {
//                                                  Text = c.ProblemPlace,
//                                                  Value = c.PlaceId.ToString()
//                                              }).ToList();

//            ViewBag.dgr = degerler;
//            ViewBag.dgr1 = degerler1;
//            ViewBag.dgr2 = degerler2;
//            ViewBag.dgr3 = degerler3;
//            return View();
//        }
//        [HttpPost]
//        public ActionResult YeniArıza(TBLPROBLEM p1)

//        {
//            db.TBLPROBLEM.Add(p1);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public ActionResult SIL(int id)
//        {
           
//            var arıza = db.TBLPROBLEM.Find(id);
//            db.TBLPROBLEM.Remove(arıza);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        public ActionResult Update(TBLPROBLEM p1)
//        {
//            var defaultModel = db.TBLPROBLEM.Where(x => x.ProblemId == p1.ProblemId).FirstOrDefault();
//            defaultModel.ProblemId = p1.ProblemId;
//            defaultModel.ProblemSituationId = p1.ProblemSituationId;
//            defaultModel.ProblemReasonId = p1.ProblemReasonId;
//            defaultModel.ProblemUserId = p1.ProblemUserId;
//            defaultModel.ProblemPlaceId = p1.ProblemPlaceId;
//            db.TBLPROBLEM.AddOrUpdate(defaultModel);
//            db.SaveChanges();
//            return Json("Index");


//        }
//        [HttpGet]
//        public ActionResult GetProblem(int problemId)
//        {
//            var defaultModel = db.TBLPROBLEM.Where(x => x.ProblemId == problemId).FirstOrDefault();
//            var aw = new ProblemViewModel
//            {
//                ProblemId = problemId,
//                ProblemSituationId = defaultModel.ProblemSituationId,
//                ProblemPlaceId = defaultModel.ProblemPlaceId,
//                ProblemReasonId = defaultModel.ProblemReasonId,
//                ProblemUserId = defaultModel.ProblemUserId,
//                ProblemPlace = defaultModel.TBLPLACE.ProblemPlace,
//                ProblemReason = defaultModel.TBLREASON.ProblemReason,
//                ProblemSituation = defaultModel.TBLSİTUATİON.ProblemSituation,
//                Users = defaultModel.TBLUSERS.Users,
//            };
            
//            return Json(aw, JsonRequestBehavior.AllowGet);
//        }


//        [HttpGet]
//        public ActionResult GetAllProblem()
//        {
//            var allList = new List<ProblemViewModel>();
//            var defaultModel = db.TBLPROBLEM.ToList();
//            foreach (var item in defaultModel)
//            {
//                var aw = new ProblemViewModel
//                {
//                    ProblemId = item.ProblemId,
//                    ProblemSituationId = item.ProblemSituationId,
//                    ProblemPlaceId = item.ProblemPlaceId,
//                    ProblemReasonId = item.ProblemReasonId,
//                    ProblemUserId = item.ProblemUserId,
//                    ProblemPlace = item.TBLPLACE.ProblemPlace,
//                    ProblemReason = item.TBLREASON.ProblemReason,
//                    ProblemSituation = item.TBLSİTUATİON.ProblemSituation,
//                    Users = item.TBLUSERS.Users,
//                };
//                allList.Add(aw);
//            }
            

//            return Json(allList, JsonRequestBehavior.AllowGet);
//        }
//        [HttpGet]
//        public PartialViewResult RefreshProblemTable()
//        {
//            var problems = db.TBLPROBLEM
//                                   .Include(p => p.TBLUSERS)
//                                   .Include(p => p.TBLREASON)
//                                   .Include(p => p.TBLSİTUATİON)
//                                   .Include(p => p.TBLPLACE)
//                                   .ToList();
//            ViewBag.allSelectData = GetSelections();
//            return PartialView("ProblemTable", problems);
//        }
//        [HttpPost]
//        public JsonResult UpdateNotes(int problemId, string notes)
//        {
//            var problem = db.TBLPROBLEM.FirstOrDefault(p => p.ProblemId == problemId);
//            if (problem != null)
//            {
//                problem.ProblemDetails = notes;
//                db.SaveChanges();
//                return Json(new { success = true });
//            }
//            return Json(new { success = false });
//        }






//    }

//}

