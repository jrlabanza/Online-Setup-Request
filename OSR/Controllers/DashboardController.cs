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

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

        public ActionResult Home()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.LotIdValid = this.Get_Valid_Lot_User();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult OSR()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.LotIdValid = this.Get_Valid_Lot_User();
            ViewBag.LotValidUser = this.Is_User_lot_Valid();
            ViewBag.SchedValidUser = this.Is_User_Sched_Valid();
            ViewBag.ModalTrigger = "";
            
            return View();
        }

        public ActionResult OSRBURNIN()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult OSRQFN()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult OSR_CENTS()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult data_extraction()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult data_extraction_burnin()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult data_extraction_qfn()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult data_extraction_cents()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.CanUpdate = this.Get_user_valid_update();
            ViewBag.ModalTrigger = "";

            return View();
        }

        public ActionResult liveupdates()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            return View();
        }

        public ActionResult liveupdatesBurnIn()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            return View();
        }

        public ActionResult liveupdatesQFN()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            return View();
        }

        public ActionResult liveupdatesCENTS()
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

            return View();
        }

        public ActionResult history_burnin(string controller, string action, string id)
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.ControllerName = controller;
            ViewBag.ActionName = action;
            ViewBag.idNumber = id;

            var employeeData = this.Get_user_session_data();

            return View();
        }

        public ActionResult history_qfn(string controller, string action, string id)
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.ControllerName = controller;
            ViewBag.ActionName = action;
            ViewBag.idNumber = id;

            var employeeData = this.Get_user_session_data();

            return View();
        }

        public ActionResult history_cents(string controller, string action, string id)
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.userFFID = this.Get_user_ffID();
            ViewBag.fullName = this.Get_user_fullname();
            ViewBag.ControllerName = controller;
            ViewBag.ActionName = action;
            ViewBag.idNumber = id;

            var employeeData = this.Get_user_session_data();

            return View();
        }

        public JsonResult get_osr_dashboard(string data_check)
        {
            if (data_check == "OSR") 
            {
                IDictionary<string, List<IDictionary<string, string>>> final = new Dictionary<string, List<IDictionary<string, string>>>();
                List<IDictionary<string, string>> pending = new List<IDictionary<string, string>>();
                List<IDictionary<string, string>> archive = new List<IDictionary<string, string>>();

                pending = osrObject.get_osr_data_pending();
                archive = osrObject.get_osr_data_archive();
                final.Add("pending", pending);
                final.Add("archive", archive);

                return Json(final);
            }

            if (data_check == "OSRBURNIN")
            {
                IDictionary<string, List<IDictionary<string, string>>> final = new Dictionary<string, List<IDictionary<string, string>>>();
                List<IDictionary<string, string>> pending = new List<IDictionary<string, string>>();
                List<IDictionary<string, string>> archive = new List<IDictionary<string, string>>();

                pending = osrObject.get_osr_burnin_data_pending();
                archive = osrObject.get_osr_burnin_data_archive();
                final.Add("pending", pending);
                final.Add("archive", archive);
                return Json(final);
            }

            if (data_check == "OSRQFN")
            {
                IDictionary<string, List<IDictionary<string, string>>> final = new Dictionary<string, List<IDictionary<string, string>>>();
                List<IDictionary<string, string>> pending = new List<IDictionary<string, string>>();
                List<IDictionary<string, string>> archive = new List<IDictionary<string, string>>();

                pending = osrObject.get_osr_qfn_data_pending();
                archive = osrObject.get_osr_qfn_data_archive();
                final.Add("pending", pending);
                final.Add("archive", archive);
                return Json(final);
            }

            if (data_check == "OSR_CENTS")
            {
                IDictionary<string, List<IDictionary<string, string>>> final = new Dictionary<string, List<IDictionary<string, string>>>();
                List<IDictionary<string, string>> pending = new List<IDictionary<string, string>>();
                List<IDictionary<string, string>> archive = new List<IDictionary<string, string>>();

                pending = osrObject.get_osr_cents_data_pending();
                archive = osrObject.get_osr_cents_data_archive();
                final.Add("pending", pending);
                final.Add("archive", archive);
                return Json(final);
            }
            else 
            {
                IDictionary<string, List<IDictionary<string, string>>> final = new Dictionary<string, List<IDictionary<string, string>>>();
                return Json(final);
            }
            
        }

        //public JsonResult get_osr_burnin_dashboard()
        //{

        //    IDictionary<string, List<IDictionary<string, string>>> final = new Dictionary<string, List<IDictionary<string, string>>>();
        //    List<IDictionary<string, string>> pending = new List<IDictionary<string, string>>();
        //    List<IDictionary<string, string>> archive = new List<IDictionary<string, string>>();

        //    pending = osrObject.get_osr_burnin_data_pending();
        //    archive = osrObject.get_osr_burnin_data_archive();
        //    final.Add("pending", pending);
        //    final.Add("archive", archive);
        //    return Json(final);
        //}

        public JsonResult data_extraction_extract()
        {

            IDictionary<string, List<IDictionary<string, string>>> final = new Dictionary<string, List<IDictionary<string, string>>>();
            List<IDictionary<string, string>> osr = new List<IDictionary<string, string>>();
            List<IDictionary<string, string>> osr_burnin = new List<IDictionary<string, string>>();
            List<IDictionary<string, string>> osr_qfn = new List<IDictionary<string, string>>();
            List<IDictionary<string, string>> osr_cents = new List<IDictionary<string, string>>();

            osr = osrObject.get_released_to_data_from_data_extract();
            osr_burnin = osrObject.get_osr_burnin_data();
            osr_qfn = osrObject.get_osr_qfn_data();
            osr_cents = osrObject.get_osr_cents_data();
            final.Add("osr", osr);
            final.Add("osr_burnin", osr_burnin);
            final.Add("osr_qfn", osr_qfn);
            final.Add("osr_cents", osr_cents);
            return Json(final);
        }

        public JsonResult live_updates()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_data();

            return Json(results);
        }

        public JsonResult live_updates_burn_in()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_burnin_data();

            return Json(results);
        }

        public JsonResult live_updates_qfn()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_qfn_data();

            return Json(results);
        }

        public JsonResult live_updates_cents()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_cents_data();

            return Json(results);
        }

        public JsonResult get_osr_history(string osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_history(osr_id);

            return Json(results);
        }

        public JsonResult get_osr_burnin_history(string osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_burnin_history(osr_id);

            return Json(results);
        }

        public JsonResult get_osr_qfn_history(string osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_qfn_history(osr_id);

            return Json(results);
        }

        public JsonResult get_osr_cents_history(string osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_cents_history(osr_id);

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

        public JsonResult get_handler_model()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_handler_model();

            return Json(results);
        }

        public JsonResult get_handler_id_xfn()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_handler_id_xfn();

            return Json(results);
        }

        public JsonResult get_handler_id_burnin()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_handler_id_burnin();

            return Json(results);
        }

        public JsonResult m3_number_by_id()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.m3_number_by_id();

            return Json(results);
        }

        public JsonResult m3_burn_in_number_by_id()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.m3_burn_in_number_by_id();

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

        public JsonResult get_forecast(string m3Number)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_forecast(m3Number);

            return Json(results);
        }

        public JsonResult get_download_id(string m3Number)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_download_id(m3Number);

            return Json(results);
        }

        public JsonResult get_download_id_burnin(string m3Number)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_download_id_burnin(m3Number);

            return Json(results);
        }

        public JsonResult get_handler_model_from_id(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_handler_model_from_id(handlerID);

            return Json(results);
        }

        public JsonResult get_package_from_id(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_package_from_id(handlerID);

            return Json(results);
        }

        public JsonResult check_valid_package(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.check_valid_package(handlerID);

            return Json(results);
        }

        public JsonResult get_process()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_process();

            return Json(results);
        }

        public JsonResult report()
        {
            //IDictionary<string, string> results = new Dictionary<string, string>();

            IDictionary<string, IDictionary<string, string>> results = new Dictionary<string, IDictionary<string, string>>();

            var cal = Helpers.ONCalendar.GetByDate(DateTime.Now);
            var datestring = DateTime.Now;
            var getworkweek = Helpers.ONCalendar.GetWWOnlyByDate(DateTime.Now);
            var lastworkweek = getworkweek - 1;

            var getnewCal = Helpers.ONCalendar.GetFirstDay(getworkweek, datestring.Year);


            results.Add("firstDay", osrObject.released_form_count(getnewCal, getnewCal.AddDays(1)));
            results.Add("secondDay", osrObject.released_form_count(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("thirdDay", osrObject.released_form_count(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("fourthDay", osrObject.released_form_count(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("fifthDay", osrObject.released_form_count(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("sixthDay", osrObject.released_form_count(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("seventhDay", osrObject.released_form_count(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("overall", osrObject.released_form_count_overall());
            results.Add("cancelledFirstDay", osrObject.cancelled_form_count(getnewCal, getnewCal.AddDays(1)));
            results.Add("cancelledSecondDay", osrObject.cancelled_form_count(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("cancelledThirdDay", osrObject.cancelled_form_count(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("cancelledFourthDay", osrObject.cancelled_form_count(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("cancelledFifthDay", osrObject.cancelled_form_count(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("cancelledSixthDay", osrObject.cancelled_form_count(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("cancelledSeventhDay", osrObject.cancelled_form_count(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("cancelledOverall", osrObject.cancelled_form_count_overall());
            return Json(results);

        }

        public JsonResult report_burnin()
        {
            //IDictionary<string, string> results = new Dictionary<string, string>();

            IDictionary<string, IDictionary<string, string>> results = new Dictionary<string, IDictionary<string, string>>();

            var cal = Helpers.ONCalendar.GetByDate(DateTime.Now);
            var datestring = DateTime.Now;
            var getworkweek = Helpers.ONCalendar.GetWWOnlyByDate(DateTime.Now);
            var lastworkweek = getworkweek - 1;

            var getnewCal = Helpers.ONCalendar.GetFirstDay(getworkweek, datestring.Year);


            results.Add("firstDay", osrObject.released_form_count_burnin(getnewCal, getnewCal.AddDays(1)));
            results.Add("secondDay", osrObject.released_form_count_burnin(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("thirdDay", osrObject.released_form_count_burnin(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("fourthDay", osrObject.released_form_count_burnin(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("fifthDay", osrObject.released_form_count_burnin(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("sixthDay", osrObject.released_form_count_burnin(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("seventhDay", osrObject.released_form_count_burnin(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("overall", osrObject.released_form_count_overall_burnin());
            results.Add("cancelledFirstDay", osrObject.cancelled_form_count_burnin(getnewCal, getnewCal.AddDays(1)));
            results.Add("cancelledSecondDay", osrObject.cancelled_form_count_burnin(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("cancelledThirdDay", osrObject.cancelled_form_count_burnin(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("cancelledFourthDay", osrObject.cancelled_form_count_burnin(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("cancelledFifthDay", osrObject.cancelled_form_count_burnin(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("cancelledSixthDay", osrObject.cancelled_form_count_burnin(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("cancelledSeventhDay", osrObject.cancelled_form_count_burnin(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("cancelledOverall", osrObject.cancelled_form_count_overall_burnin());
            return Json(results);

        }

        public JsonResult report_qfn()
        {
            //IDictionary<string, string> results = new Dictionary<string, string>();

            IDictionary<string, IDictionary<string, string>> results = new Dictionary<string, IDictionary<string, string>>();

            var cal = Helpers.ONCalendar.GetByDate(DateTime.Now);
            var datestring = DateTime.Now;
            var getworkweek = Helpers.ONCalendar.GetWWOnlyByDate(DateTime.Now);
            var lastworkweek = getworkweek - 1;

            var getnewCal = Helpers.ONCalendar.GetFirstDay(getworkweek, datestring.Year);


            results.Add("firstDay", osrObject.released_form_count_qfn(getnewCal, getnewCal.AddDays(1)));
            results.Add("secondDay", osrObject.released_form_count_qfn(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("thirdDay", osrObject.released_form_count_qfn(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("fourthDay", osrObject.released_form_count_qfn(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("fifthDay", osrObject.released_form_count_qfn(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("sixthDay", osrObject.released_form_count_qfn(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("seventhDay", osrObject.released_form_count_qfn(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("overall", osrObject.released_form_count_overall_qfn());
            results.Add("cancelledFirstDay", osrObject.cancelled_form_count_qfn(getnewCal, getnewCal.AddDays(1)));
            results.Add("cancelledSecondDay", osrObject.cancelled_form_count_qfn(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("cancelledThirdDay", osrObject.cancelled_form_count_qfn(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("cancelledFourthDay", osrObject.cancelled_form_count_qfn(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("cancelledFifthDay", osrObject.cancelled_form_count_qfn(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("cancelledSixthDay", osrObject.cancelled_form_count_qfn(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("cancelledSeventhDay", osrObject.cancelled_form_count_qfn(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("cancelledOverall", osrObject.cancelled_form_count_overall_qfn());
            return Json(results);

        }

        public JsonResult report_cents()
        {
            //IDictionary<string, string> results = new Dictionary<string, string>();

            IDictionary<string, IDictionary<string, string>> results = new Dictionary<string, IDictionary<string, string>>();

            var cal = Helpers.ONCalendar.GetByDate(DateTime.Now);
            var datestring = DateTime.Now;
            var getworkweek = Helpers.ONCalendar.GetWWOnlyByDate(DateTime.Now);
            var lastworkweek = getworkweek - 1;

            var getnewCal = Helpers.ONCalendar.GetFirstDay(getworkweek, datestring.Year);


            results.Add("firstDay", osrObject.released_form_count_cents(getnewCal, getnewCal.AddDays(1)));
            results.Add("secondDay", osrObject.released_form_count_cents(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("thirdDay", osrObject.released_form_count_cents(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("fourthDay", osrObject.released_form_count_cents(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("fifthDay", osrObject.released_form_count_cents(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("sixthDay", osrObject.released_form_count_cents(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("seventhDay", osrObject.released_form_count_cents(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("overall", osrObject.released_form_count_overall_cents());
            results.Add("cancelledFirstDay", osrObject.cancelled_form_count_cents(getnewCal, getnewCal.AddDays(1)));
            results.Add("cancelledSecondDay", osrObject.cancelled_form_count_cents(getnewCal.AddDays(2), getnewCal.AddDays(3)));
            results.Add("cancelledThirdDay", osrObject.cancelled_form_count_cents(getnewCal.AddDays(3), getnewCal.AddDays(4)));
            results.Add("cancelledFourthDay", osrObject.cancelled_form_count_cents(getnewCal.AddDays(4), getnewCal.AddDays(5)));
            results.Add("cancelledFifthDay", osrObject.cancelled_form_count_cents(getnewCal.AddDays(5), getnewCal.AddDays(6)));
            results.Add("cancelledSixthDay", osrObject.cancelled_form_count_cents(getnewCal.AddDays(6), getnewCal.AddDays(7)));
            results.Add("cancelledSeventhDay", osrObject.cancelled_form_count_cents(getnewCal.AddDays(7), getnewCal.AddDays(8)));
            results.Add("cancelledOverall", osrObject.cancelled_form_count_overall_cents());
            return Json(results);

        }
    }
}
