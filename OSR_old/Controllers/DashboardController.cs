using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSR.Models;

namespace OSR.Controllers
{
    public class DashboardController : BaseController
    {
        osrMod osrObject = new osrMod();
        //
        // GET: /Dashboard/

        public ActionResult OSR()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();

            return View();
        }

        public ActionResult liveupdates()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            return View();
        }

        public ActionResult history(string controller, string action, string id)
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.ControllerName = controller;
            ViewBag.ActionName = action;
            ViewBag.idNumber = id;

            var employeeData = this.Get_user_session_data();

            //if (employeeData == null)
            //{
            //    return RedirectToAction("OSR", "Dashboard");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }

        public JsonResult get_osr_dashboard()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_data();

            return Json(results);
        }

        public JsonResult get_osr_history(string osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_history(osr_id);

            return Json(results);
        }

        public JsonResult get_osr_dashboard_live()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_data_live();

            return Json(results);
        }

        public JsonResult get_device()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_device();

            return Json(results);
        }

        public JsonResult get_tester_id()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_tester_id();

            return Json(results);
        }

        public JsonResult get_handler_id()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_handler_id();

            return Json(results);
        }

        public JsonResult get_handler_id_xfn()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_handler_id_xfn();

            return Json(results);
        }

        public JsonResult m3_number_by_id()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.m3_number_by_id();

            return Json(results);
        }

        public JsonResult get_tester_id_from_handler_id(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_tester_id_from_handler_id(handlerID);

            return Json(results);
        }

        public JsonResult get_handler_id_from_tester_id(string testerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_handler_id_from_tester_id(testerID);

            return Json(results);
        }

        public JsonResult get_download_id(string m3Number)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_download_id(m3Number);

            return Json(results);
        }

        public JsonResult get_process()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_process();

            return Json(results);
        }
    }
}
