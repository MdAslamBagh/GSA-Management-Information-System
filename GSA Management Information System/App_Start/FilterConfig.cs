﻿using System.Web;
using System.Web.Mvc;

namespace GSA_Management_Information_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
			// filters.Add(new AuthorizeAttribute());//returnurl login controller call every action
        }
    }
}
