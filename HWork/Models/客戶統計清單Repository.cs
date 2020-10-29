using System;
using System.Linq;
using System.Collections.Generic;

namespace HWork.Models
{
	public  class 客戶統計清單Repository : EFRepository<客戶統計清單>, I客戶統計清單Repository
	{

	}

	public  interface I客戶統計清單Repository : IRepository<客戶統計清單>
	{

	}
}