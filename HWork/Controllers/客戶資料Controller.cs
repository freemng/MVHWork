﻿using System;
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
    public class 客戶資料Controller : Controller
    {
        //private BankCustomerEntities db = new BankCustomerEntities();
        客戶資料Repository repo;

        List<SelectListItem> vlst客戶分類 = new List<SelectListItem>() {
            new SelectListItem() {
                Text = "客戶分類1", Value = "1"
            },
            new SelectListItem() {
                Text = "客戶分類2", Value = "2"
            },
            new SelectListItem() {
                Text = "客戶分類3", Value = "3"
            }
        };

        public 客戶資料Controller()
        {
            repo = RepositoryHelper.Get客戶資料Repository();
        }


        // GET: 客戶資料
        public ActionResult Index()
        {
            ViewBag.lst客戶分類 = new SelectList(vlst客戶分類, "Value", "Text", "1"); ;

            //return View(db.客戶資料.ToList());
            return View(repo.All());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchType, string searchString)
        {
            ViewBag.lst客戶分類 = new SelectList(vlst客戶分類, "Value", "Text", "1");

            //if (searchString != null && searchType != null)
            //{
            //    if (searchType == "客戶名稱")
            //    {
            //        return View(repo.All().Where(s => s.客戶名稱.Contains(searchString)).ToList());
            //    }
            //    else if (searchType == "客戶分類")
            //    {
            //        return View(repo.All().Where(s => s.客戶分類.Contains(searchString)).ToList());
            //    }
            //    else
            //    {
            //        return View(repo.All().ToList());
            //    }

            //    //return View(db.客戶資料.Where(s=> s.客戶名稱.Contains(searchString)).ToList());



            //}


            //return View(repo.All());
            return View(repo.getFiltered客戶資料(searchType, searchString));

        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.All().FirstOrDefault(p => p.Id == id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            ViewBag.lst客戶分類 = new SelectList(vlst客戶分類, "Value", "Text", "1"); ;

            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();
                //repo.Add(客戶資料);
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.All().FirstOrDefault(p => p.Id == id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            ViewBag.lst客戶分類 = new SelectList(vlst客戶分類, "Value", "Text", "1"); ;
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                var item = repo.All().FirstOrDefault(p => p.Id == 客戶資料.Id);

                //db.Entry(客戶資料).State = EntityState.Modified;
                //db.SaveChanges();
                item.InjectFrom(客戶資料);
                repo.UnitOfWork.Commit();


                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.All().FirstOrDefault(p => p.Id == id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            //db.SaveChanges();
            客戶資料 客戶資料 = repo.All().FirstOrDefault(p => p.Id == id);
            repo.Delete(客戶資料);
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
