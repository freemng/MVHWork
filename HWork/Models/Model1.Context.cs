﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HWork.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankCustomerEntities : DbContext
    {
        public BankCustomerEntities()
            : base("name=BankCustomerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<客戶資料> 客戶資料 { get; set; }
        public virtual DbSet<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual DbSet<客戶聯絡人> 客戶聯絡人 { get; set; }
        public virtual DbSet<客戶統計清單> 客戶統計清單 { get; set; }
    }
}
