namespace HWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HWork.CustomValidation;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }

    public partial class 客戶聯絡人MetaData
    {
        public int Id { get; set; }
        public int 客戶Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "輸入字串不可超過{1}字")]
        public string 職稱 { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "輸入字串不可超過{1}字")]
        public string 姓名 { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "電郵格式錯誤")]
        [StringLength(250, ErrorMessage = "輸入字串不可超過{1}字")]
        [DuplicatedEmail]
        public string Email { get; set; }
        [MaxLength(50, ErrorMessage = "輸入字串不可超過{1}字")]
        [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "「手機」的電話格式必須為正確的格式 ( e.g. 0911-111111 )")]
        public string 手機 { get; set; }
        [MaxLength(50, ErrorMessage = "輸入字串不可超過{1}字")]
        public string 電話 { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
