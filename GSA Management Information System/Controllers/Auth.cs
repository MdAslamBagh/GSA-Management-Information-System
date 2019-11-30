using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Controllers
{
    public class Auth
    {
        public static string Token = "";
        public string BaseUrl = Properties.Settings.Default.BaseURL;

        public string GetBaseURL() //method return Base Url
        {
            return BaseUrl;
        }

        public void SetToken(string t) //method return Access Token of API
        {
            Token = t;
        }

        public string GetToken()
        {
            string T = Token;
            return T;
        }
        public void DestroyToken()
        {
            Token = "";
        }
    }
}