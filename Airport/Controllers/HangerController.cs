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
        [HttpGet]
        public ActionResult GetHangers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetHangers(DateTime FromDate,DateTime ToDate)
        {
            if (ModelState.IsValid)
            {
                List < GetAvailableHangers > l= null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44304/api/");
                    var query = $"HangerDetails?fromdate={FromDate:yyyy-MM-dd}&todate={ToDate:yyyy-MM-dd}";


                    var responseTask = client.GetAsync(query);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    var readData = result.Content.ReadAsAsync<List<GetAvailableHangers>>();
                    if (result.IsSuccessStatusCode)
                    {
                        l = readData.Result;
                        
                        ModelState.Clear();
                        return View("displayHangers",l);
                    }
                    else
                    {
                        l = readData.Result;
                        if(l==null || l.Count==0)
                        {
                            ViewBag.msg = "No Hangers Available chose different dates to find hanger availability";
                        }
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.msg = "couldn't get Hangers";
                return View();
            }
        }

        public ActionResult displayHangers(List<GetAvailableHangers> data)
        {
            return View(data);
        }
        [HttpPost]
        public ActionResult displayHangers(string Book)
        {
            
            return View();

        }
    }
}