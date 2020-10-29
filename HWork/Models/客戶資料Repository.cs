using System;
using System.Linq;
using System.Collections.Generic;

namespace HWork.Models
{
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
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

	}
}