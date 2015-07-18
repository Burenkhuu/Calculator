using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication16.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Calculator";
            return View();
        }
        [HttpPost]
        public JsonResult Calculate(Int64 num1=0,Int64 num2=0,String op="")
        {
            Int64 result = 0;
            string resultStr=string.Empty;
            switch(op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        resultStr = "can not divide by zero!";
                    }
                    break;
                default:
                    resultStr = "no operator!";
                    break;
            }
            return Json(new
            {
                resultNum = (resultStr==string.Empty? result.ToString():resultStr),
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
