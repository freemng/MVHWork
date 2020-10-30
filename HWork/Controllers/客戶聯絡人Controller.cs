using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWork.Models;
using Omu.ValueInjecter;

namespace HWork.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        //private BankCustomerEntities db = new BankCustomerEntities();
        客戶聯絡人Repository repo;
        客戶資料Repository repo客戶資料;

        public 客戶聯絡人Controller()
        {
            repo = RepositoryHelper.Get客戶聯絡人Repository();
            repo客戶資料 = RepositoryHelper.Get客戶資料Repository(repo.UnitOfWork);
        }

        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            //var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料);
            var 客戶聯絡人 = repo.All().Include(p => p.客戶資料);
            List<SelectListItem> vlst職稱 = new List<SelectListItem>();
            foreach (var v職稱 in 客戶聯絡人.Select(s => s.職稱).Distinct().ToList())
            {
                if (!string.IsNullOrEmpty(v職稱))
                {
                    vlst職稱.Add(new SelectListItem()
                    {
                        Text = v職稱,
                        Value = v職稱
                    });

                }
            }

            ViewBag.lst職稱 = new SelectList(vlst職稱, "Value", "Text"); ;



            return View(客戶聯絡人.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchString, string filterString)
        {
            var 客戶聯絡人 = repo.All().Include(客 => 客.客戶資料);
            List<SelectListItem> vlst職稱 = new List<SelectListItem>();
            foreach (var v職稱 in 客戶聯絡人.Select(s => s.職稱).Distinct().ToList())
            {
                if (!string.IsNullOrEmpty(v職稱))
                {
                    vlst職稱.Add(new SelectListItem()
                    {
                        Text = v職稱,
                        Value = v職稱
                    });

                }
            }
            ViewBag.lst職稱 = new SelectList(vlst職稱, "Value", "Text"); ;

            if (!string.IsNullOrEmpty(searchString))
            {
                var search客戶聯絡人 = repo.All().Include(客 => 客.客戶資料).Where(s => s.姓名.Contains(searchString)).ToList();
                return View(search客戶聯絡人.ToList());

            }
            else if (!string.IsNullOrEmpty(filterString))
            {
                var search客戶聯絡人1 = repo.All().Include(客 => 客.客戶資料).Where(s => s.職稱.Contains(filterString)).ToList();
                return View(search客戶聯絡人1.ToList());
            }




            return View(客戶聯絡人.ToList());
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repo.All().FirstOrDefault(p => p.Id == id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                //db.客戶聯絡人.Add(客戶聯絡人);
                //db.SaveChanges();
                repo.Add(客戶聯絡人);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repo.All().FirstOrDefault(p => p.Id == id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                var item = repo.All().FirstOrDefault(p => p.Id == 客戶聯絡人.Id);

                //db.Entry(客戶聯絡人).State = EntityState.Modified;
                //db.SaveChanges();
                item.InjectFrom(客戶聯絡人);
                repo.UnitOfWork.Commit();


                return RedirectToAction("Index");
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(repo客戶資料.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.All().FirstOrDefault(p => p.Id == id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            //db.客戶聯絡人.Remove(客戶聯絡人);
            //db.SaveChanges();
            客戶聯絡人 客戶聯絡人 = repo.All().FirstOrDefault(p => p.Id == id);
            repo.Delete(客戶聯絡人);
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
