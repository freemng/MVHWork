using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWork.Models;

namespace HWork.Controllers
{
    public class 客戶統計清單Controller : Controller
    {
        private BankCustomerEntities db = new BankCustomerEntities();

        // GET: 客戶統計清單
        public ActionResult Index()
        {
            return View(db.客戶統計清單.ToList());
        }

        // GET: 客戶統計清單/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶統計清單 客戶統計清單 = db.客戶統計清單.Find(id);
            if (客戶統計清單 == null)
            {
                return HttpNotFound();
            }
            return View(客戶統計清單);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
