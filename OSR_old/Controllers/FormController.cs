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
            public string testerID { get; set; }
            public string handlerID { get; set; }
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
        }
        //
        // GET: /Form/
        osrMod osrObject = new osrMod();

        public ActionResult CreateOSR()
        {
            ViewBag.employeeData = this.Get_user_session_data();
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

        public JsonResult getOSRData(int id)
        { 
            IDictionary<string, string> results = new Dictionary<string, string>();
            results = osrObject.get_osr_form(id);
            return Json(results);
            
        }

        public JsonResult OSRFormSubmit(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRFormSubmit(osr.testerID, osr.handlerID, osr.family, osr.package, osr.process, osr.expectedDateofSetup, osr.shift, osr.status, userFullName, osr.m3Number, userFFID);

            LastID = osrObject.getLastInputIDOSR();

            return Json(LastID);
        }

        public JsonResult OSRFormUpdate(OSR osr)
        {
            var userFFID = this.Get_user_ffID();
            var userFullName = this.Get_user_fullname();
            IDictionary<string, string> results = new Dictionary<string, string>();
            IDictionary<string, string> LastID = new Dictionary<string, string>();

            osrObject.OSRFormUpdate(osr.id, osr.m3Number, osr.testerID, osr.handlerID, osr.family, osr.package, osr.process, 
            osr.requestedBy, osr.dateSubmitted,osr.expectedDateofSetup, osr.recentlyUpdateBy, osr.shift, osr.status, userFullName, osr.remarks, osr.releasedTo);

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

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult UploadDocumentsOSR(FormCollection data)
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

        public JsonResult get_osr_documents(int osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = osrObject.get_osr_documents(osr_id);

            return Json(results);
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

    }
}
