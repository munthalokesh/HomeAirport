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
                        var responseTask = client.PostAsJsonAsync<AddHanger>("HangerDetails/AddHanger", Ah);
                        responseTask.Wait();
                        var result = responseTask.Result;
                        var readData = result.Content.ReadAsAsync<string>();
                        if (result.IsSuccessStatusCode)
                        {
                            st = readData.Result;
                            ViewBag.msg = st;
                            ModelState.Clear();
                            return View();
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
                TempData["fromdate"] = FromDate;
                TempData["todate"]=ToDate;
                TempData["fromdate1"] = FromDate;
                TempData["todate1"] = ToDate;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44304/api/");
                    var query = $"HangerDetails/GetAvailableHangers?fromdate={FromDate:yyyy-MM-dd}&todate={ToDate:yyyy-MM-dd}";


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
        public ActionResult displayHangers(string Book,FormCollection form)
        {
            string HangerLocation= form[Book+1];
            string HangerId = form[Book+2];
            TempData["hangerlocation"] = HangerLocation;
            TempData["hangerid"]=HangerId;
            TempData["hangerid1"] = HangerId;
            if (ModelState.IsValid)
            {
                List<GetAvailablePlanes> l = null;
                DateTime FromDate = (DateTime)TempData["fromdate"];
                DateTime ToDate = (DateTime)TempData["todate"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44304/api/");
                    var query = $"HangerDetails/GetAvailablePlanes?fromdate={FromDate:yyyy-MM-dd}&todate={ToDate:yyyy-MM-dd}";


                    var responseTask = client.GetAsync(query);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    var readData = result.Content.ReadAsAsync<List<GetAvailablePlanes>>();
                    if (result.IsSuccessStatusCode)
                    {
                        l = readData.Result;
                        
                        ModelState.Clear();
                        return View("BookHanger",l);
                    }
                    else
                    {
                        l = readData.Result;
                        if (l == null || l.Count == 0)
                        {
                            l.Add(null);
                        }
                        ViewBag.msg = "No Plane Available in the Selected timeframe";
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.msg = "Select Plane";
                return View();
            }
            
        }
        public ActionResult BookHanger()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BookHanger(string SelectedPlaneId)
        {
            string st = "";
            Booking b=new Booking();
            b.FromDate = (DateTime)TempData["fromdate1"];
            b.ToDate = (DateTime)TempData["todate1"];
            b.PlaneId = SelectedPlaneId;
            b.HangerId = (string)TempData["hangerid1"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/api/");
                var responseTask = client.PostAsJsonAsync<Booking>("HangerDetails/AddBooking", b);
                responseTask.Wait();
                var result = responseTask.Result;
                var readData = result.Content.ReadAsAsync<string>();
                if (result.IsSuccessStatusCode)
                {
                    st = readData.Result;
                    ViewBag.msg = st;
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    st = readData.Result;
                    ViewBag.msg = st;
                    return View();
                }
            }
        }
    }
}