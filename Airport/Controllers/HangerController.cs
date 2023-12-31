﻿using Airport.Models.BusinessLayer;
using Airport.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Airport.Controllers
{
    public class HangerController : Controller
    {
        // GET: Hanger
        [TypeAuthorization("Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [TypeAuthorization("Admin")]
        [HttpPost]
        public ActionResult Index(AddHanger Ah, string HangerBtn)
        {
            if (HangerBtn == "AddHanger")
            {
                if (ModelState.IsValid)
                {
                    string st = "";
                    AddingHanger addingHanger = new AddingHanger();
                    Ah = addingHanger.trim(Ah);
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
        [TypeAuthorization("Manager")]
        [HttpGet]
        public ActionResult GetHangers()
        {
            return View();
        }
        [TypeAuthorization("Manager")]
        [HttpPost]
        public ActionResult GetHangers(DateTime? FromDate, DateTime? ToDate, string GetHangersBtn)
        {
            if (GetHangersBtn == "GetHangers")
            {
                List<GetAvailableHangers> l = null;
                TempData["fromdate"] = FromDate;
                TempData["todate"] = ToDate;
                TempData["fromdate1"] = FromDate;
                TempData["todate1"] = ToDate;
                if (!ToDate.HasValue)
                {
                    ToDate = FromDate;
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44304/api/");
                    var query = $"HangerDetails/GetAvailableHangers?fromdate={FromDate}&todate={ToDate}";


                    var responseTask = client.GetAsync(query);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    var readData = result.Content.ReadAsAsync<List<GetAvailableHangers>>();
                    if (result.IsSuccessStatusCode)
                    {
                        l = readData.Result;

                        ModelState.Clear();
                        return View("displayHangers", l);
                    }
                    else
                    {
                        l = readData.Result;
                        if (l == null || l.Count == 0)
                        {
                            ViewBag.msg = "No Hangers Available chose different dates to find hanger availability";
                            return View();
                        }
                        else
                        {
                            return View();
                        }
                    }
                }
            }

            else
            {
                ViewBag.msg = "couldn't get Hangers";
                ModelState.Clear();
                return View();
            }
        }
        [TypeAuthorization("Manager")]
        public ActionResult displayHangers(List<GetAvailableHangers> data)
        {
            return View(data);
        }


        //[HttpPost]
        //public ActionResult displayHangers(string Book,FormCollection form)
        //{
        //    string HangerLocation= form[Book+1];
        //    string HangerId = form[Book+2];
        //    TempData["hangerlocation"] = HangerLocation;
        //    TempData["hangerid"]=HangerId;
        //    TempData["hangerid1"] = HangerId;
        //    if (ModelState.IsValid)
        //    {
        //        List<GetAvailablePlanes> l = null;
        //        DateTime FromDate = (DateTime)TempData["fromdate"];
        //        DateTime ToDate = (DateTime)TempData["todate"];
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://localhost:44304/api/");
        //            var query = $"HangerDetails/GetAvailablePlanes?fromdate={FromDate:yyyy-MM-dd}&todate={ToDate:yyyy-MM-dd}";


        //            var responseTask = client.GetAsync(query);
        //            responseTask.Wait();
        //            var result = responseTask.Result;
        //            var readData = result.Content.ReadAsAsync<List<GetAvailablePlanes>>();
        //            if (result.IsSuccessStatusCode)
        //            {
        //                l = readData.Result;

        //                ModelState.Clear();
        //                return View("BookHanger",l);
        //            }
        //            else
        //            {
        //                l = readData.Result;
        //                if (l == null || l.Count == 0)
        //                {
        //                    l.Add(null);
        //                }
        //                ViewBag.msg = "No Plane Available in the Selected timeframe";
        //                return View();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.msg = "Select Plane";
        //        return View();
        //    }

        //}
        //public ActionResult BookHanger()
        //{
        //    return View();
        //}
        [TypeAuthorization("Manager")]
        [HttpPost]
        public ActionResult BookHanger(DateTime fromdate, DateTime todate, string planeId, string hangerId)
        {
            string st = "";
            Booking b = new Booking();
            b.FromDate = fromdate;
            b.ToDate = todate;
            b.PlaneId = planeId;
            b.HangerId = hangerId;
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
                    return Json(st);
                }
                else
                {
                    st = readData.Result;
                    ViewBag.msg = st;
                    return Json(st);
                }
            }
        }
        [TypeAuthorization("Manager")]
        public ActionResult GetStatus()
        {
            List<Hanger> st = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/api/");
                var responseTask = client.GetAsync("HangerDetails/GetAllHangers");
                responseTask.Wait();
                var result = responseTask.Result;
                var readData = result.Content.ReadAsAsync<List<Hanger>>();
                if (result.IsSuccessStatusCode)
                {
                    st = readData.Result;
                    if (st != null && st.Count > 0)
                    {
                        return View(st);
                    }
                    else

                    {
                        return View("NoHangers");//create view to display no hangers message
                    }
                }
                else
                {
                    st = readData.Result;
                    ViewBag.msg = st;
                    return View(st);
                }
            }
        }
        /*[HttpPost]
        public ActionResult GetStatus(DateTime fromdate, DateTime todate)
        {
            List<Hanger> st = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/api/");
                var responseTask = client.GetAsync("HangerDetails/GetAllHangers");
                responseTask.Wait();
                var result = responseTask.Result;
                var readData = result.Content.ReadAsAsync<List<Hanger>>();
                if (result.IsSuccessStatusCode)
                {
                    st = readData.Result;
                    return View(st);
                }
                else
                {
                    st = readData.Result;
                    ViewBag.msg = st;
                    return View(st);
                }
            }
        }*/
        [TypeAuthorization("Manager")]
        public ActionResult GetPlanes(string FromDate, string ToDate)
        {
            List<GetAvailablePlanes> l = null;
            //string formattedFromDate = FromDate.ToString("yyyy-MM-dd");
            //DateTime parsedFromDate = DateTime.ParseExact(formattedFromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //string formattedToDate = ToDate.ToString("yyyy-MM-dd");
            //DateTime parsedToDate = DateTime.ParseExact(formattedToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/api/");
                var query = $"HangerDetails/GetAvailablePlanes?fromdate=" + FromDate + "&todate=" + ToDate;


                var responseTask = client.GetAsync(query);
                responseTask.Wait();
                var result = responseTask.Result;
                var readData = result.Content.ReadAsAsync<List<GetAvailablePlanes>>();
                if (result.IsSuccessStatusCode)
                {
                    l = readData.Result;


                    return Json(l, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    l = readData.Result;
                    if (l == null || l.Count == 0)
                    {
                        l.Add(null);
                    }
                    ViewBag.msg = "No Plane Available in the Selected timeframe";
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult ReloadHangers(string fromdate,string todate)
        {
            List<GetAvailableHangers> l = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/api/");
                var query = $"HangerDetails/GetAvailableHangers?fromdate="+fromdate+"&todate="+todate;


                var responseTask = client.GetAsync(query);
                responseTask.Wait();
                var result = responseTask.Result;
                var readData = result.Content.ReadAsAsync<List<GetAvailableHangers>>();
                if (result.IsSuccessStatusCode)
                {
                    l = readData.Result;

                    ModelState.Clear();
                    return Json(l, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    l = readData.Result;
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}
    
