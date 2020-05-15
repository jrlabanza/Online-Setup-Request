﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OSR.Models
{
    public class osrMod
    {
        public Boolean OSRFormSubmit(string testerID, string handlerID, string family, string package, string process, string expectedDateofSetup, string shift, string status, string userFullName, string m3Number, string userFFID)
        {
            string query = "INSERT INTO osr(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number, sub_ffID)"+
            "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '"+ m3Number +"', '"+ userFFID +"')";

            string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number)" +
            "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "')";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
            Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

            return results;
        }

        public Boolean OSRBurnInFormSubmit(string handlerID, string family, string package, string process, string expectedDateofSetup, string shift, string status, string userFullName, string m3Number, string userFFID)
        {
            string query = "INSERT INTO osr_burnin(handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number, sub_ffID)" +
            "VALUES ('" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "', '" + userFFID + "')";

            string query2 = "INSERT INTO osr_history_burnin(handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number)" +
            "VALUES ('" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "')";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
            Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

            return results;
        }

        public Boolean OSRFormUpdate(int id, string m3Number, string testerID, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo)
        {

            if (status == "RELEASED")
            {
                string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else {
                string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            
            }

        }

        public Boolean OSRBurnInFormUpdate(int id, string m3Number, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo)
        {

            if (status == "RELEASED")
            {
                string query = "UPDATE osr_burnin SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_burnin(handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                "VALUES ('" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else
            {
                string query = "UPDATE osr_burnin SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_burnin(handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks)" +
                "VALUES ('" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;

            }

        }

        public Boolean OSRFormUpdateWithExpectedUpdate(int id, string m3Number, string testerID, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo, string reasonToChangeSetup)
        {

            if (status == "RELEASED")
            {
                string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + reasonToChangeSetup + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else
            {
                string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,reasonToChangeExpectedDateOfSetup)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '"+ reasonToChangeSetup +"')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;

            }

        }

        public Boolean OSRBurnInFormUpdateWithExpectedUpdate(int id, string m3Number, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo, string reasonToChangeSetup)
        {

            if (status == "RELEASED")
            {
                string query = "UPDATE osr_burnin SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_burnin(handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup)" +
                "VALUES ('" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + reasonToChangeSetup + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else
            {
                string query = "UPDATE osr_burnin SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_burnin(handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,reasonToChangeExpectedDateOfSetup)" +
                "VALUES ('" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + reasonToChangeSetup + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;

            }

        }

        public Boolean OSRM3Number(string m3gen, int id)
        {
            string query = "UPDATE osr SET m3Number = '"+ m3gen +"' WHERE id ="+ id;
            string query2 = "UPDATE osr_history SET m3Number = '" + m3gen + "' ORDER BY id DESC LIMIT 1";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert FLA Form", Connection.expert_connstring);
            Connection.ExecuteThisQuery(query2, "Insert FLA Form", Connection.expert_connstring);

            return results;
        }

        public Boolean OSRBurnInM3Number(string m3gen, int id)
        {
            string query = "UPDATE osr_burnin SET m3Number = '" + m3gen + "' WHERE id =" + id;
            string query2 = "UPDATE osr_history_burnin SET m3Number = '" + m3gen + "' ORDER BY id DESC LIMIT 1";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert FLA Form", Connection.expert_connstring);
            Connection.ExecuteThisQuery(query2, "Insert FLA Form", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_data()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr WHERE isDeleted = 0 ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> calendar()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT m3Number as title, DATE_FORMAT(expectedDateofSetup, '%Y-%m-%d') as end, DATE_FORMAT(dateRequest, '%Y-%m-%d') as start FROM ftdr.osr WHERE status != 'FORM CANCELLED';";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_data()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_burnin WHERE isDeleted = 0 ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_history(string osr_id)
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_history WHERE m3Number = '" + osr_id + "' ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR HISTORY", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> data_extraction()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT m3Number, testerID, handlerID, package, family, process, dateRequest, expectedDateofSetup, shift, requestBy, status  FROM ftdr.osr WHERE requestBy != 'Joe Labanza' AND isDeleted = 0;";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_history(string osr_id)
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_history_burnin WHERE m3Number = '" + osr_id + "' ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR HISTORY", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_data_live()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr WHERE isDeleted = 0 ORDER BY dateRequest ASC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_data_live()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr WHERE isDeleted = 0 ORDER BY dateRequest ASC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public IDictionary<string, string> get_osr_form(int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr WHERE id ="+ id;

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public IDictionary<string, string> get_osr_burnin_form(int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr_burnin WHERE id =" + id;

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);
            //var data = (JObject)JsonConvert.DeserializeObject(json);

            return results;
        }

        public List<IDictionary<string, string>> get_tester_id()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            //string query = "SELECT TABLE_NAME AS TEST FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='p1_equipt_db' AND TABLE_NAME LIKE '%ts%'";
            string query = "SELECT Tester_ID FROM testers WHERE TesterID LIKE 'ts%' OR Tester_ID LIKE 'xfn%' OR Location = 'XFN'";

            results = Connection.GetDataAssociateArray(query, "GET TESTER ID", Connection.promis_connString);

            return results;
        }

        public List<IDictionary<string, string>> get_handler_id()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT TABLE_NAME AS HAND FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='p1_equipt_db' AND TABLE_NAME LIKE 'hd%'";

            results = Connection.GetDataAssociateArray(query, "GET HANDLER ID", Connection.promis_connString);

            return results;
        }

        public List<IDictionary<string, string>> get_handler_id_xfn()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT Equipt_ID FROM equipt_list WHERE Prod_Line='XDFN'";

            results = Connection.GetDataAssociateArray(query, "GET HANDLER ID", Connection.promis_connString);

            return results;
        }

        public List<IDictionary<string, string>> get_handler_id_burnin()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            //string query = "SELECT Equipt_ID FROM equipt_list WHERE Prod_Line='Burn-in'";

            string query = "SELECT New_Tester_ID, Tester_ID FROM testers WHERE TesterModel='Burn-in Oven'";

            results = Connection.GetDataAssociateArray(query, "GET HANDLER ID", Connection.promis_connString);

            return results;
        }

        public List<IDictionary<string, string>> get_device()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT DEVICE FROM p1_uph2";

            results = Connection.GetDataAssociateArray(query, "GET DEVICE", Connection.promis_connString);

            return results;
        }

        public IDictionary<string, string> get_package_from_family(string familyID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT Pkg_Type FROM p1_uph2 WHERE DEVICE = '" + familyID + "'";

            results = Connection.GetDataArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.promis_connString);

            return results;
        }


        public List<IDictionary<string, string>> get_process()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT process FROM process";

            results = Connection.GetDataAssociateArray(query, "GET PROCESS", Connection.promis_connString);

            return results;
        }

        public IDictionary<string, string> get_handler_id_from_tester_id(string testerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT Handler_ID,pkg_type FROM testers WHERE Tester_ID = '" + testerID + "'";

            results = Connection.GetDataArray(query, "GET HANDLER ID FROM TESTER ID", Connection.promis_connString);

            return results;
        }

        public IDictionary<string, string> get_tester_id_from_handler_id(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT TesterID,pkg_type FROM testers WHERE Handler_ID = '" + handlerID + "'";

            results = Connection.GetDataArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.promis_connString);

            return results;
        }

        public IDictionary<string, string> getLastInputIDOSR()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT id FROM osr WHERE isDeleted = 0 ORDER BY id DESC LIMIT 1;";

            results = Connection.GetDataArray(query, "Get last ID", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> getLastInputIDOSRBurnIn()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT id FROM osr_burnin WHERE isDeleted = 0 ORDER BY id DESC LIMIT 1;";

            results = Connection.GetDataArray(query, "Get last ID", Connection.expert_connstring);

            return results;
        }

        public Boolean upload_image_repair_reports(string flaId, string pic_name)
        {
            string query = "INSERT INTO osr_uploads(item_name, itemId) " +
                            "VALUES('" + pic_name + "','" + flaId + "')";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert FLA Form", Connection.expert_connstring);

            return results;
        }

        public Boolean upload_image_repair_reports_burnin(string flaId, string pic_name)
        {
            string query = "INSERT INTO osr_uploads_burnin(item_name, itemId) " +
                            "VALUES('" + pic_name + "','" + flaId + "')";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert FLA Form", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_documents(int osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_uploads WHERE itemId='" + osr_id + "'";

            results = Connection.GetDataAssociateArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burn_in_documents(int osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_uploads_burnin WHERE itemId='" + osr_id + "'";

            results = Connection.GetDataAssociateArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> m3_number_by_id()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr ORDER BY id DESC LIMIT 1";

            results = Connection.GetDataArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> m3_burn_in_number_by_id()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr_burnin ORDER BY id DESC LIMIT 1";

            results = Connection.GetDataArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> is_valid(string FFID)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();
         
            string query = "SELECT FFID FROM osr_users WHERE FFID ='" + FFID + "'";

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);

            
            return results;
        }

        public IDictionary<string, string> is_valid_for_update(string FFID)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT FFID FROM osr_date_changers WHERE FFID ='" + FFID + "'";

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);


            return results;
        }

        public List<IDictionary<string, string>> get_user_list()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT firstName, lastName FROM employeeinfos";

            results = Connection.GetDataAssociateArray(query, "GET USER INFO", Connection.user_connstring);

            return results;
        }

        public IDictionary<string, string> get_download_id(string m3Number)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT id FROM osr WHERE m3Number ='" + m3Number + "'";

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);


            return results;
        }

        public IDictionary<string, string> get_download_id_burnin(string m3Number)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT id FROM osr_burnin WHERE m3Number ='" + m3Number + "'";

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);


            return results;
        }

        public IDictionary<string, string> get_download_burnin_id(string m3Number)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT id FROM osr_burnin WHERE m3Number ='" + m3Number + "'";

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);


            return results;
        }

        public List<IDictionary<string, string>> get_chart_result()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT m3Number, dateRequest, WEEKDAY(dateRequest) AS WEEKDAYCOUNT FROM ftdr.osr WHERE dateRequest BETWEEN (DATE(NOW()) - INTERVAL 7 DAY) AND (DATE(NOW())) AND status = 'FORM CANCELLED' AND isDeleted = 0 ORDER BY dateRequest DESC;";

            results = Connection.GetDataAssociateArray(query, "GET USER INFO", Connection.expert_connstring);

            return results;
        }
    }
}
