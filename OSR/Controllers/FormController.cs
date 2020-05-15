using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSR.Models;

namespace OSR.Controllers
{
    public class FormController : BaseController
    {
        public class OSR
        {
            public int id { get; set; }
            public string m3Number { get; set; }
            public string socketID { get; set; }
            public string testerID { get; set; }
            public string handlerID { get; set; }
            public string handlerModel { get; set; }
            public string family { get; set; }
            public string package { get; set; }
            public string process { get; set; }
            public string requestedBy { get; set; }
            public string dateSubmitted { get; set; }
            public string expectedDateofSetup { get; set; }
            public string recentlyUpdateBy { get; set; }
            public string shift { get; set; }
            public string status { get; set; }
            public string remarks { get; set; }
            public string releasedTo { get; set;}
            public string reasonToChangeSetup { get; set; }
            public string data_check { get; set; }
            public string request_qty { get; set; }
            public string lot_status { get; set; }
            public string schedule { get; set; }
            public string lot_approver_validity { get; set; }
            public string unscheduled_approval { get; set; }
            public string reasonForUnplannedSetup { get; set; }
        }
        //
        // GET: /Form/
        osrMod osrObject = new osrMod();

        public ActionResult CreateOSR()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.fullName = this.Get_user_fullname();
            var employeeData = this.Get_user_session_data();

            if (employeeData == null)
            {
                return RedirectToAction("OSR", "Dashboard");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CreateOSRBurnIn()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.fullName = this.Get_user_fullname();
            var employeeData = this.Get_user_session_data();

            if (employeeData == null)
            {
                return RedirectToAction("OSRBURNIN", "Dashboard");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CreateOSRQFN()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.fullName = this.Get_user_fullname();
            var employeeData = this.Get_user_session_data();

            if (employeeData == null)
            {
                return RedirectToAction("OSR", "Dashboard");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CreateOSRCents()
        {
            ViewBag.employeeData = this.Get_user_session_data();
            ViewBag.fullName = this.Get_user_fullname();
            var employeeData = this.Get_user_session_data();

            if (employeeData == null)
            {
                return RedirectToAction("OSR_CENTS", "Dashboard");
            }
            else
            {
                return View();
            }
            
        }

        public JsonResult getOSRData(int id)
        { 
            IDictionary<string, string> results = new Dictionary<string, string>();
            results = osrObject.get_osr_form(id);
            return Json(results);
            
        }

        public JsonResult getOSRBurnInData(int id)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();
            results = osrObject.get_osr_burnin_form(id);
            return Json(results);

        }

        public JsonResult getOSRQFNData(int id)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();
            results = osrObject.get_osr_qfn_form(id);
            return Json(results);
        }

        public JsonResult getOSRCENTSData(int id)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();
            results = osrObject.get_osr_cents_form(id);
            return Json(results);

        }

        public JsonResult OSRFormSubmit(OSR osr)
        {
            if (osr.data_check == "CREATEOSR") 
            {
                var userFFID = this.Get_user_ffID();
                var userFullName = this.Get_user_fullname();
                IDictionary<string, string> results = new Dictionary<string, string>();
                IDictionary<string, string> LastID = new Dictionary<string, string>();

                osrObject.OSRFormSubmit(osr.testerID, osr.handlerID, osr.family, osr.package, osr.process, osr.expectedDateofSetup, osr.shift, osr.status, userFullName, osr.m3Number, userFFID, osr.schedule, osr.reasonForUnplannedSetup);

                LastID = osrObject.getLastInputIDOSR();

                return Json(LastID);
            }
            if (osr.data_check == "CREATEOSRBURNIN")
            {
                var userFFID = this.Get_user_ffID();
                var userFullName = this.Get_user_fullname();
                IDictionary<string, string> results = new Dictionary<string, string>();
                IDictionary<string, string> LastID = new Dictionary<string, string>();

                osrObject.OSRBurnInFormSubmit(osr.handlerID, osr.family, osr.package, osr.process, osr.expectedDateofSetup, osr.shift, osr.status, userFullName, osr.m3Number, userFFID);

                LastID = osrObject.getLastInputIDOSRBurnIn();

                return Json(LastID);
            }
            if (osr.data_check == "CREATEOSRQFN")
            {
                var userFFID = this.Get_user_ffID();
                var userFullName = this.Get_user_fullname();
                IDictionary<string, string> results = new Dictionary<string, string>();
                IDictionary<string, string> LastID = new Dictionary<string, string>();

                osrObject.OSRQFNFormSubmit(osr.testerID, osr.handlerID, osr.family, osr.package, osr.process, osr.expectedDateofSetup, osr.shift, osr.status, userFullName, osr.m3Number, userFFID);

                LastID = osrObject.getLastInputIDOSRQFN();

                return Json(LastID);
            }
            if (osr.data_check == "CREATEOSRCENTS")
            {
                var userFFID = this.Get_user_ffID();
                var userFullName = this.Get_user_fullname();
                IDictionary<string, string> results = new Dictionary<string, string>();
                IDictionary<string, string> LastID = new Dictionary<string, string>();

                osrObject.OSRCENTSFormSubmit(osr.handlerID, osr.handlerModel, osr.package, osr.process, osr.expectedDateofSetup, osr.shift, osr.status, userFullName, osr.m3Number, userFFID, osr.request_qty);

                LastID = osrObject.getLastInputIDOSRQFN();

                return Json(LastID);
            }
            else 
            {
                IDictionary<string, string> LastID = new Dictionary<string, string>();
                return Json(LastID);
            }

        }

        //public JsonResult OSRBurnInFormSubmit(OSR osr)
        //{
        //    var userFFID = this.Get_user_ffID();
        //    var userFullName = this.Get_user_fullname();
        //    IDictionary<string, string> results = new Dictionary<string, string>();
        //    IDictionary<string, string> LastID = new Dictionary<string, string>();

        //    osrObject.OSRBurnInFormSubmit(osr.handlerID, osr.family, osr.package, osr.process, osr.expectedDateofSetup, osr.shift, osr.status, userFullName, osr.m3Number, userFFID);

        //    LastID = osrObject.getLastInputIDOSRBurnIn();

        //    return Json(LastID);
        //}

        public JsonResult OSRFormUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRFormUpdate(osr.id, osr.m3Number, osr.testerID, osr.handlerID, osr.family, osr.package, osr.process,
            osr.requestedBy, osr.dateSubmitted, osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo, osr.lot_status, osr.lot_approver_validity, osr.unscheduled_approval);

            LastID = osrObject.getLastInputIDOSR();

            return Json(LastID);
        }

        public JsonResult OSRBurnInFormUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRBurnInFormUpdate(osr.id, osr.m3Number, osr.handlerID, osr.family, osr.package, osr.process,
            osr.requestedBy, osr.dateSubmitted, osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo);

            LastID = osrObject.getLastInputIDOSRBurnIn();

            return Json(LastID);
        }

        public JsonResult OSRQFNFormUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRQFNFormUpdate(osr.id, osr.m3Number, osr.testerID, osr.handlerID, osr.family, osr.package, osr.process,
            osr.requestedBy, osr.dateSubmitted, osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo);

            LastID = osrObject.getLastInputIDOSR();

            return Json(LastID);
        }

        public JsonResult OSRFormUpdateWithExpectedUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRFormUpdateWithExpectedUpdate(osr.id, osr.m3Number, osr.testerID, osr.handlerID, osr.family, osr.package, osr.process,
            osr.requestedBy, osr.dateSubmitted, osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo, osr.reasonToChangeSetup, osr.lot_status, osr.unscheduled_approval);

            LastID = osrObject.getLastInputIDOSR();

            return Json(LastID);
        }

        public JsonResult OSRBurnInFormUpdateWithExpectedUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRBurnInFormUpdateWithExpectedUpdate(osr.id, osr.m3Number, osr.handlerID, osr.family, osr.package, osr.process,
            osr.requestedBy, osr.dateSubmitted, osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo, osr.reasonToChangeSetup);

            LastID = osrObject.getLastInputIDOSRBurnIn();

            return Json(LastID);
        }

        public JsonResult OSRQFNFormUpdateWithExpectedUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRQFNFormUpdateWithExpectedUpdate(osr.id, osr.m3Number, osr.testerID, osr.handlerID, osr.family, osr.package, osr.process,
            osr.requestedBy, osr.dateSubmitted, osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo, osr.reasonToChangeSetup);

            LastID = osrObject.getLastInputIDOSR();

            return Json(LastID);
        }

        public JsonResult OSRCENTSFormUpdateWithExpectedUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRCENTSFormUpdateWithExpectedUpdate(osr.id, osr.m3Number, osr.socketID, osr.handlerID, osr.handlerModel, osr.package, osr.requestedBy,
                osr.dateSubmitted, osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo, osr.reasonToChangeSetup, osr.request_qty);

            LastID = osrObject.getLastInputIDOSR();

            return Json(LastID);
        }

        public JsonResult OSRM3Number(string m3gen, int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRM3Number(m3gen, id);

            LastID = osrObject.getLastInputIDOSR();

            return Json(LastID);
        }

        public JsonResult OSRBurnInM3Number(string m3gen, int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRM3Number(m3gen, id);

            LastID = osrObject.getLastInputIDOSRBurnIn();

            return Json(LastID);
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult UploadDocumentsOSR(FormCollection data)
        {
            if (data["data_check"] == "CREATEOSR")
            {
                int filesLen = Request.Files.Count;

                for (int i = 0; i < filesLen; i++)
                {

                    HttpPostedFileBase file = Request.Files[i];

                    var upload_results = this.UploadThisFile(file, "~/uploads/osr/");

                    if (upload_results["done"] == "TRUE")
                    {
                        osrObject.upload_image_repair_reports(data["lastId"], upload_results["newFileName"]);
                    }
                    else
                    {

                    }
                }
                return Json(data);
            }

            if (data["data_check"] == "CREATEOSRBURNIN")
            {
                int filesLen = Request.Files.Count;

                for (int i = 0; i < filesLen; i++)
                {

                    HttpPostedFileBase file = Request.Files[i];

                    var upload_results = this.UploadThisFile(file, "~/uploads/osr_burnin/");

                    if (upload_results["done"] == "TRUE")
                    {
                        osrObject.upload_image_repair_reports_burnin(data["lastId"], upload_results["newFileName"]);
                    }
                    else
                    {

                    }
                }
                return Json(data);
            }

            if (data["data_check"] == "CREATEOSRQFN")
            {
                int filesLen = Request.Files.Count;

                for (int i = 0; i < filesLen; i++)
                {

                    HttpPostedFileBase file = Request.Files[i];

                    var upload_results = this.UploadThisFile(file, "~/uploads/osr_qfn/");

                    if (upload_results["done"] == "TRUE")
                    {
                        osrObject.upload_image_repair_reports_qfn(data["lastId"], upload_results["newFileName"]);
                    }
                    else
                    {

                    }
                }
                return Json(data);
            }
            else
            {
                return Json(data);
            }
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult UploadEmailLotVerificationOSR(FormCollection data)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();
            if (data["data_check"] == "OSR")
            {
                int filesLen = Request.Files.Count;

                for (int i = 0; i < filesLen; i++)
                {

                    HttpPostedFileBase file = Request.Files[i];

                    var upload_results = this.UploadThisFileMSGONLY(file, "~/uploads/osr/");

                    if (upload_results["done"] == "TRUE")
                    {
                        osrObject.upload_image_repair_reports(data["lastId"], upload_results["newFileName"]);
                        results["done"] = "Upload Successful";
                        results["msg"] = upload_results["msg"];
                        results["uploadedfileType"] = upload_results["uploadedfileType"];
                    }
                    else
                    {
                        results["done"] = "Upload Failed";
                        results["msg"] = upload_results["msg"];
                        results["uploadedfileType"] = upload_results["uploadedfileType"];
                    }
                }
                return Json(results);
            }

            //if (data["data_check"] == "CREATEOSRBURNIN")
            //{
            //    int filesLen = Request.Files.Count;

            //    for (int i = 0; i < filesLen; i++)
            //    {

            //        HttpPostedFileBase file = Request.Files[i];

            //        var upload_results = this.UploadThisFile(file, "~/uploads/osr_burnin/");

            //        if (upload_results["done"] == "TRUE")
            //        {
            //            osrObject.upload_image_repair_reports_burnin(data["lastId"], upload_results["newFileName"]);
            //        }
            //        else
            //        {

            //        }
            //    }
            //    return Json(data);
            //}

            //if (data["data_check"] == "CREATEOSRQFN")
            //{
            //    int filesLen = Request.Files.Count;

            //    for (int i = 0; i < filesLen; i++)
            //    {

            //        HttpPostedFileBase file = Request.Files[i];

            //        var upload_results = this.UploadThisFile(file, "~/uploads/osr_qfn/");

            //        if (upload_results["done"] == "TRUE")
            //        {
            //            osrObject.upload_image_repair_reports_qfn(data["lastId"], upload_results["newFileName"]);
            //        }
            //        else
            //        {

            //        }
            //    }
            //    return Json(data);
            //}
            else
            {
                return Json(data);
            }
        }

        //[HttpPost]
        //[ValidateInput(true)]
        //public JsonResult UploadDocumentsOSRBurnIn(FormCollection data)
        //{
        //    int filesLen = Request.Files.Count;

        //    for (int i = 0; i < filesLen; i++)
        //    {

        //        HttpPostedFileBase file = Request.Files[i];

        //        var upload_results = this.UploadThisFile(file, "~/uploads/osr_burnin/");

        //        if (upload_results["done"] == "TRUE")
        //        {
        //            osrObject.upload_image_repair_reports_burnin(data["lastId"], upload_results["newFileName"]);
        //        }
        //        else
        //        {

        //        }
        //    }
        //    return Json(data);
        //}

        public JsonResult get_osr_documents(int osr_id, string data_check)
        {
            if (data_check == "history")
            {
                List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

                results = osrObject.get_osr_documents(osr_id);

                return Json(results);
            }
            if (data_check == "OSRBURNIN") 
            {
                List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

                results = osrObject.get_osr_burn_in_documents(osr_id);

                return Json(results);
            }
            if (data_check == "OSRQFN")
            {
                List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

                results = osrObject.get_osr_qfn_documents(osr_id);

                return Json(results);
            }
            else 
            {
                List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();
                return Json(results);
            }
        }
        
        public JsonResult get_user_list()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_user_list();

            return Json(results);
        }

        public JsonResult get_package_from_family(string familyID)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_package_from_family(familyID);

            return Json(results);
        }

        public JsonResult get_existing_m3Number(string testerID, string handlerID, string package, string family) {

            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_existing_m3(testerID, handlerID, package, family);

            return Json(results);

        }

        public JsonResult get_existing_m3Number_burnin(string testerID, string handlerID, string package, string family)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_existing_m3_burnin(testerID, handlerID, package, family);

            return Json(results);

        }

        public JsonResult get_existing_m3Number_qfn(string testerID, string handlerID, string package, string family)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.get_existing_m3_qfn(testerID, handlerID, package, family);

            return Json(results);

        }

        public JsonResult get_user()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_all_user();

            return Json(results);
        }
        //for socket
        public JsonResult get_socket_list()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_socket_list();

            return Json(results);
        }

        public JsonResult check_package_socket(string socketID, string package_type)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            results = osrObject.check_package_socket(socketID, package_type);

            return Json(results);

        }

        public JsonResult update_cents(string socketID, string package_type, string status, string handler_id, string handler_model, string released_to, string remarks)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();
            var userFullName = this.Get_user_fullname();
            osrObject.update_cents(socketID,package_type,status,handler_id,handler_model,released_to,remarks, userFullName);
            results["done"] = "TRUE";
            return Json(results);
        }
    }
}
