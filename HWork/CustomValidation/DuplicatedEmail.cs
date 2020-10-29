using HWork.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HWork.CustomValidation
{
    public class DuplicatedEmail : ValidationAttribute
    {
        private BankCustomerEntities db = new BankCustomerEntities();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vc客戶聯絡人 = (Models.客戶聯絡人)validationContext.ObjectInstance;

            //var db客戶聯絡人 = db.客戶聯絡人.Where(u => u.客戶Id == vc客戶聯絡人.客戶Id && u.Email == vc客戶聯絡人.Email && u.Id != vc客戶聯絡人.Id);
            //var ContactPerson = db.客戶聯絡人.Any(u => u.客戶Id == vc客戶聯絡人.客戶Id && u.Email == vc客戶聯絡人.Email && u.Id != vc客戶聯絡人.Id).select(p => p.);
            var db客戶聯絡人 = db.客戶聯絡人.FirstOrDefault(u => u.客戶Id == vc客戶聯絡人.客戶Id && u.Email == vc客戶聯絡人.Email && u.Id != vc客戶聯絡人.Id);

            if (db客戶聯絡人 != null)
                return new ValidationResult("同一個客戶下的聯絡人，其 Email 不能重複。");

            return ValidationResult.Success;
        }
    }
}