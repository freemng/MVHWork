using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using HWork.Models;


namespace HWork.Models
{
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public IQueryable<客戶資料> getFiltered客戶資料(string searchType, string searchString)
        {
            if (searchString != null && searchType != null)
            {
                if (searchType == "客戶名稱")
                {
                    return this.Where(s => s.客戶名稱.Contains(searchString));
                }
                else if (searchType == "客戶分類")
                {
                    return this.Where(s => s.客戶分類.Contains(searchString));
                }
                else
                {
                    return this.All();
                }

                //return View(db.客戶資料.Where(s=> s.客戶名稱.Contains(searchString)).ToList());

            }

            return this.All();

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.UnitOfWork.Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.IsDeleted == false);
        }


        public override void Delete(客戶資料 entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;
            entity.IsDeleted = true;
        }


    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{
        IQueryable<客戶資料> All();
        void Delete(客戶資料 entity);

        IQueryable<客戶資料> getFiltered客戶資料(string searchType, string searchString);
    }
}