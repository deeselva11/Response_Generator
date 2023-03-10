using Response_Generator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Response_Generator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Test Model)
        {

            using (var client = new WebClient())
            {
                var data = new NameValueCollection();
                data["UserName"] = Model.UserName;
                data["Response"] = Model.Response;
                data["StatusMessage"] = Model.StatusMessage;
                data["StatusCode"] = Model.StatusCode;
                var Url = System.Configuration.ConfigurationManager.AppSettings["ClientUrl"];
                var response = client.UploadValues(Url, "POST", data);
                var responseString = Encoding.Default.GetString(response);
            }
            return View();
        }
    }
}