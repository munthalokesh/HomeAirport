using Airport.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Airport.Controllers
{
    public class HangerController : Controller
    {
        // GET: Hanger
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AddHanger Ah, string HangerBtn)
        {
            if (HangerBtn == "AddHanger")
            {
                if (ModelState.IsValid)
                {
                    string st = "";
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44304/api/");
                        var responseTask = client.PostAsJsonAsync<AddHanger>("HangerDetails", Ah);
                        responseTask.Wait();
                        var result = responseTask.Result;
                        var readData = result.Content.ReadAsAsync<string>();
                        if (result.IsSuccessStatusCode)
                        {
                            st = readData.Result;
                            ViewBag.msg = st;
                            ModelState.Clear();
                            return View(new AddHanger());
                        }
                        else
                        {
                            st = readData.Result;
                            ViewBag.msg = st;
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.msg = "couldn't add Hanger";
                    return View();
                }
            }
            else if (HangerBtn == "Reset")
            {
                ModelState.Clear();
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}