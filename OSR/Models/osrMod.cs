using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OSR.Models
{
    public class osrMod
    {
        public Boolean OSRFormSubmit(string testerID, string handlerID, string family, string package, string process, string expectedDateofSetup, string shift, string status, string userFullName, string m3Number, string userFFID, string schedule, string reasonForUnplannedSetup)
        {
            if (schedule == "PLANNED") 
            { 
                string query = "INSERT INTO osr(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number, sub_ffID, isPlanned)"+
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '"+ m3Number +"', '"+ userFFID +"', 1)";

                string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else if (schedule == "UNPLANNED")
            {
                string query = "INSERT INTO osr(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number, sub_ffID, isPlanned)"+
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR APPROVAL', '"+ m3Number +"', '"+ userFFID +"', 0)";

                string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number,reasonForUnplannedSetup)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR APPROVAL', '" + m3Number + "', '" + reasonForUnplannedSetup + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else
            {
                Boolean results = false;

                return results;
            }

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

        public Boolean OSRQFNFormSubmit(string testerID, string handlerID, string family, string package, string process, string expectedDateofSetup, string shift, string status, string userFullName, string m3Number, string userFFID)
        {
            string query = "INSERT INTO osr_qfn(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number, sub_ffID)" +
            "VALUES ('" + testerID + "','" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "', '" + userFFID + "')";

            string query2 = "INSERT INTO osr_history_qfn(testerID,handlerID,package,family,process,expectedDateOfSetup,shift,requestBy,status,m3Number)" +
            "VALUES ('" + testerID + "','" + handlerID + "', '" + package + "', '" + family + "', '" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "')";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
            Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

            return results;
        }

        public Boolean OSRCENTSFormSubmit(string handlerID, string handlerModel, string package, string process, string expectedDateofSetup, string shift, string status, string userFullName, string m3Number, string userFFID, string request_qty)
        {
            string query = "INSERT INTO osr_cents(handlerID,handlerModel,package,process,expectedDateOfSetup,shift,requestBy,status,m3Number, sub_ffID, request_qty)" +
            "VALUES ('" + handlerID + "', '" + handlerModel + "', '" + package + "', '" + process + "','" + expectedDateofSetup + "', '"+ shift +"' ,'" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "', '" + userFFID + "', '"+ request_qty +"')";

            string query2 = "INSERT INTO osr_history_cents(handlerID,handlerModel,package,process,expectedDateOfSetup,shift,requestBy,status,m3Number, request_qty)" +
            "VALUES ('" + handlerID + "', '" + handlerModel + "', '" + package + "','" + process + "','" + expectedDateofSetup + "', '" + shift + "', '" + userFullName + "', 'FOR PREPARATION', '" + m3Number + "', '"+ request_qty +"')";

            Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
            Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

            return results;
        }

        public Boolean OSRFormUpdate(int id, string m3Number, string testerID, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo, string lot_status, string lot_approver_validity, string unscheduled_approval)
        {
            if (status == "FOR APPROVAL")
            {
                if (unscheduled_approval == "N/A" || unscheduled_approval == "")
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                }
                else if (unscheduled_approval == "APPROVED")
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = 'FOR PREPARATION', updater = '" + userFullName + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '"+ unscheduled_approval +"' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FOR PREPARATION', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '" + unscheduled_approval + "' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else 
                    {
                        string query = "UPDATE osr SET status = 'FOR PREPARATION', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '" + unscheduled_approval + "' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FOR PREPARATION', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }

                }
                else if (unscheduled_approval == "DECLINED")
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '" + unscheduled_approval + "' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '" + unscheduled_approval + "' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '" + unscheduled_approval + "' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }

                }
                else
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '"+ unscheduled_approval +"' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '" + unscheduled_approval + "' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else 
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW(),unplannedApprover = '" + userFullName + "', unplannedStatus = '" + unscheduled_approval + "' WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }

                }
            }
            else if (status == "RELEASED")
            {
                if (lot_status == "N/A" || lot_status == "")
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                else if (lot_status == "DECLINED")
                {
                    string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                else 
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','"+ userFullName +"')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
            }
            else {
                if (lot_status == "N/A" || lot_status == "")
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                else if (lot_status == "DECLINED")
                {
                    string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                else 
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW(), lot_status = '" + lot_status + "' WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks, lot_status, lot_status_approver)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + lot_status + "', '"+ userFullName +"')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
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

        public Boolean OSRQFNFormUpdate(int id, string m3Number, string testerID, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo)
        {

            if (status == "RELEASED")
            {
                string query = "UPDATE osr_qfn SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_qfn(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else
            {
                string query = "UPDATE osr_qfn SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_qfn(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;

            }

        }

        public Boolean OSRFormUpdateWithExpectedUpdate(int id, string m3Number, string testerID, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo, string reasonToChangeSetup, string lot_status, string unscheduled_approval)
        {
            if (status == "FOR APPROVAL")
            {
                if (unscheduled_approval == "N/A" || unscheduled_approval == "")
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "','"+ reasonToChangeSetup +"')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','" + reasonToChangeSetup + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','"+ reasonToChangeSetup +"')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                }
                else if (unscheduled_approval == "APPROVED")
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = 'FOR PREPARATION', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FOR PREPARATION', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "','" + userFullName + "','" + userFullName + "','"+ reasonToChangeSetup +"')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','" + userFullName + "','" + reasonToChangeSetup + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else
                    {
                        string query = "UPDATE osr SET status = 'FOR PREPARATION', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FOR PREPARATION', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','" + userFullName + "','"+ reasonToChangeSetup +"')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }

                }
                else if (unscheduled_approval == "DECLINED")
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "','" + userFullName + "','" + userFullName + "','" + reasonToChangeSetup + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','" + userFullName + "','" + reasonToChangeSetup + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','" + userFullName + "','" + reasonToChangeSetup + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }

                }
                else
                {
                    if (lot_status == "N/A" || lot_status == "")
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "','" + userFullName + "','" + userFullName + "','"+ reasonToChangeSetup +"')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else if (lot_status == "DECLINED")
                    {
                        string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','" + userFullName + "','" + reasonToChangeSetup + "')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }
                    else
                    {
                        string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', lot_status = '" + lot_status + "', dateUpdated = NOW() WHERE id =" + id;
                        string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,lot_status,lot_status_approver,unplannedApprover,reasonToChangeExpectedDateOfSetup)" +
                        "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                        "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + lot_status + "','" + userFullName + "','" + userFullName + "','"+ reasonToChangeSetup +"')";

                        Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                        Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                        return results;
                    }

                }
            }
            else if (status == "RELEASED")
            {
                if (lot_status == "N/A" || lot_status == "")
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + reasonToChangeSetup + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                if (lot_status == "DECLINED")
                {
                    string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', dateUpdated = NOW(), lot_status = '" + lot_status + "', lot_status_approver = '" + userFullName + "' WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup,lot_status,lot_status_approver)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + reasonToChangeSetup + "', '" + lot_status + "','" + userFullName + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                else 
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW(), lot_status = '" + lot_status + "', lot_status_approver = '"+ userFullName +"' WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup,lot_status,lot_status_approver)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + reasonToChangeSetup + "', '" + lot_status + "','"+ userFullName +"')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
            }
            else
            {
                if (lot_status == "N/A" || lot_status == "")
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,reasonToChangeExpectedDateOfSetup,lot_status)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + reasonToChangeSetup + "','" + lot_status + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                if (lot_status == "DECLINED")
                {
                    string query = "UPDATE osr SET status = 'FORM CANCELLED', updater = '" + userFullName + "', dateUpdated = NOW(), lot_status = '" + lot_status + "', lot_status_approver = '" + userFullName + "' WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,reasonToChangeExpectedDateOfSetup,lot_status,lot_status_approver)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', 'FORM CANCELLED', '" + userFullName + "', NOW(), '" + remarks + "', '" + reasonToChangeSetup + "','" + lot_status + "', '" + userFullName + "')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }
                else 
                {
                    string query = "UPDATE osr SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW(), lot_status = '" + lot_status + "', lot_status_approver = '"+ userFullName +"' WHERE id =" + id;
                    string query2 = "INSERT INTO osr_history(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,reasonToChangeExpectedDateOfSetup,lot_status,lot_status_approver)" +
                    "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                    "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + reasonToChangeSetup + "','" + lot_status + "', '"+ userFullName +"')";

                    Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                    Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                    return results;
                }

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

        public Boolean OSRQFNFormUpdateWithExpectedUpdate(int id, string m3Number, string testerID, string handlerID, string family, string package, string process, string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName, string remarks, string releasedTo, string reasonToChangeSetup)
        {

            if (status == "RELEASED")
            {
                string query = "UPDATE osr_qfn SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_qfn(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + reasonToChangeSetup + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else
            {
                string query = "UPDATE osr_qfn SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_qfn(testerID,handlerID,package,family,process,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,reasonToChangeExpectedDateOfSetup)" +
                "VALUES ('" + testerID + "', '" + handlerID + "', '" + package + "', '" + family + "', '" + process + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + reasonToChangeSetup + "')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;

            }

        }

        public Boolean OSRCENTSFormUpdateWithExpectedUpdate(int id, string m3Number, string socketID, string handlerID, string handlerModel, string package,
            string requestedBy, string dateSubmitted, string expectedDateofSetup, string recentlyUpdateBy, string shift, string status, string userFullName,
            string remarks, string releasedTo, string reasonToChangeSetup, string request_qty)
        {

            if (status == "RELEASED")
            {
                string query = "UPDATE osr_cents SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW(), socketID = '"+ socketID +"' WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_cents(socketID,handlerID,handlerModel,package,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,releasedTo,reasonToChangeExpectedDateOfSetup, request_qty)" +
                "VALUES ('" + socketID + "', '" + handlerID + "', '"+ handlerModel +"' ,'" + package + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
                "', '" + shift + "', '" + requestedBy + "', '" + status + "', '" + userFullName + "', NOW(), '" + remarks + "', '" + releasedTo + "', '" + reasonToChangeSetup + "', '"+ request_qty +"')";

                Boolean results = Connection.ExecuteThisQuery(query, "Insert Form Success", Connection.expert_connstring);
                Connection.ExecuteThisQuery(query2, "Insert History", Connection.expert_connstring);

                return results;
            }
            else
            {
                string query = "UPDATE osr_cents SET status = '" + status + "', updater = '" + userFullName + "', dateUpdated = NOW() WHERE id =" + id;
                string query2 = "INSERT INTO osr_history_cents(handlerID,handlerModel,package,m3Number,dateRequest,expectedDateOfSetup,shift,requestBy,status,updater,dateUpdated,remarks,reasonToChangeExpectedDateOfSetup)" +
                "VALUES ('" + handlerID + "', '"+ handlerModel +"' ,'" + package + "', '" + m3Number + "', '" + dateSubmitted + "', '" + expectedDateofSetup +
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

            return results;
        }

        public List<IDictionary<string, string>> get_osr_data_pending()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr WHERE isDeleted = 0 AND (status != 'RELEASED' AND status != 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_data_archive()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr WHERE isDeleted = 0 AND (status = 'RELEASED' OR status = 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_data()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_burnin WHERE isDeleted = 0 ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_data_pending()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_burnin WHERE isDeleted = 0 AND (status != 'RELEASED' AND status != 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_data_archive()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_burnin WHERE isDeleted = 0 AND (status = 'RELEASED' OR status = 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_qfn_data()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_qfn WHERE isDeleted = 0 ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_qfn_data_pending()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_qfn WHERE isDeleted = 0 AND (status != 'RELEASED' AND status != 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_qfn_data_archive()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_qfn WHERE isDeleted = 0 AND (status = 'RELEASED' OR status = 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_cents_data()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_cents WHERE isDeleted = 0 ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_cents_data_pending()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_cents WHERE isDeleted = 0 AND (status != 'RELEASED' AND status != 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_cents_data_archive()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_cents WHERE isDeleted = 0 AND (status = 'RELEASED' OR status = 'FORM CANCELLED') ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_history(string osr_id)
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_history WHERE m3Number = '" + osr_id + "' ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR HISTORY", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_history(string osr_id)
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_history_burnin WHERE m3Number = '" + osr_id + "' ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR HISTORY", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_qfn_history(string osr_id)
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_history_qfn WHERE m3Number = '" + osr_id + "' ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR HISTORY", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_cents_history(string osr_id)
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_history_cents WHERE m3Number = '" + osr_id + "' ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR HISTORY", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_data_live()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr WHERE isDeleted = 0 ORDER BY dateRequest ASC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_burnin_data_live()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr WHERE isDeleted = 0 ORDER BY dateRequest ASC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_osr_qfn_data_live()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_qfn WHERE isDeleted = 0 ORDER BY dateRequest ASC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_released_to_data_from_data_extract()
        {

            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = @"SELECT m3Number, UPPER(updater) AS updater, testerID, handlerID, package, family, process, dateRequest, expectedDateOfSetup, shift, requestBy, status, releasedTo FROM osr_history ORDER BY dateUpdated DESC";

            results = Connection.GetDataAssociateArray(query, "GET OSR DATA", Connection.expert_connstring);

            return results;
        }

        //public IDictionary<string, string> get_released_to_data_from_data_extract(string m3Number)
        //{
        //    IDictionary<string, string> results = new Dictionary<string, string>();

        //    string query = "SELECT m3Number, testerID, handlerID, package, family, process, dateRequest, expectedDateOfSetup, shift, requestBy, status, releasedTo FROM osr_history WHERE m3Number ='"+ m3Number +"'";

        //    results = Connection.GetDataArray(query, "GET RELEASED DATA", Connection.expert_connstring);

        //    return results;

        //}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IDictionary<string, string> released_form_count(DateTime startDay, DateTime endDay)////////////////////////////////
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> released_form_count_burnin(DateTime startDay, DateTime endDay)////////////////////////////////
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_burnin WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> released_form_count_qfn(DateTime startDay, DateTime endDay)////////////////////////////////
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_qfn WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> released_form_count_cents(DateTime startDay, DateTime endDay)////////////////////////////////
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_cents WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> released_form_count_overall()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> released_form_count_overall_burnin()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_burnin WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> released_form_count_overall_qfn()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_qfn WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> released_form_count_overall_cents()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_cents WHERE status = 'RELEASED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count(DateTime startDay, DateTime endDay)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count_burnin(DateTime startDay, DateTime endDay)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_burnin WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count_qfn(DateTime startDay, DateTime endDay)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_qfn WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count_cents(DateTime startDay, DateTime endDay)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_cents WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0 AND (expectedDateOfSetup BETWEEN '" + startDay.ToString("yyyy-MM-dd 01:00:00") + "' AND '" + endDay.ToString("yyyy-MM-dd 23:59:59") + "');";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count_overall()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count_overall_burnin()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_burnin WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count_overall_qfn()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_qfn WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> cancelled_form_count_overall_cents()
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT count(*) as released FROM ftdr.osr_cents WHERE status = 'FORM CANCELLED' AND sub_ffID != 'zbh4bc' AND isDeleted = 0;";

            results = Connection.GetDataArray(query, "RELEASED FORM COUNT", Connection.expert_connstring);

            return results;
        }
       
        public IDictionary<string, string> get_osr_form(int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr WHERE id ="+ id;

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> get_osr_burnin_form(int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr_burnin WHERE id =" + id;

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> get_osr_qfn_form(int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr_qfn WHERE id =" + id;

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> get_osr_cents_form(int id)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr_cents WHERE id =" + id;

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_tester_id()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

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

        public List<IDictionary<string, string>> get_handler_model()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT Equipt_Model FROM equipt_list";

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

        public IDictionary<string, string> getLastInputIDOSRQFN()
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT id FROM osr_qfn WHERE isDeleted = 0 ORDER BY id DESC LIMIT 1;";

            results = Connection.GetDataArray(query, "Get last ID", Connection.expert_connstring);

            return results;
        }

        public List<IDictionary<string, string>> get_all_user()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "select id,email_address from users ORDER BY first_name ASC";

            results = Connection.GetDataAssociateArray(query, "Get User", Connection.promis_connString);

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

        public Boolean upload_image_repair_reports_qfn(string flaId, string pic_name)
        {
            string query = "INSERT INTO osr_uploads_qfn(item_name, itemId) " +
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

        public List<IDictionary<string, string>> get_osr_qfn_documents(int osr_id)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT * FROM osr_uploads_qfn WHERE itemId='" + osr_id + "'";

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

        public IDictionary<string, string> check_user_promis(string user, string password)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "select * from users WHERE email_address ='" + user + "'AND password ='" + password + "'";

            results = Connection.GetDataArray(query, "Check User", Connection.promis_connString);

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

        public IDictionary<string, string> get_forecast(string m3Number)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT isPlanned FROM osr WHERE m3Number ='" + m3Number + "'";

            results = Connection.GetDataArray(query, "GET OSR FORM", Connection.expert_connstring);


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

        public IDictionary<string, string> get_existing_m3(string testerID, string handlerID, string family, string package)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr WHERE handlerID = '" + handlerID + "' AND (status != 'RELEASED' AND status != 'FORM CANCELLED') ORDER BY id DESC LIMIT 1;";

            results = Connection.GetDataArray(query, "GET EXISTING DATA", Connection.expert_connstring);

            return results; 
        }

        public IDictionary<string, string> get_existing_m3_burnin(string testerID, string handlerID, string family, string package)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr_burnin WHERE handlerID = '" + handlerID + "' AND (status != 'RELEASED' AND status != 'FORM CANCELLED')  ORDER BY id DESC LIMIT 1;";

            results = Connection.GetDataArray(query, "GET EXISTING DATA", Connection.expert_connstring);

            return results;
        }

        public IDictionary<string, string> get_existing_m3_qfn(string testerID, string handlerID, string family, string package)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM osr_qfn WHERE handlerID = '" + handlerID + "' AND (status != 'RELEASED' AND status != 'FORM CANCELLED') ORDER BY id DESC LIMIT 1;";

            results = Connection.GetDataArray(query, "GET EXISTING DATA", Connection.expert_connstring);

            return results;
        }
        //for socket cents

        public List<IDictionary<string, string>> get_socket_list()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string query = "SELECT socket_id, package_type FROM socket WHERE status = 'IN-GOOD' ";

            results = Connection.GetDataAssociateArray(query, "GET USER INFO", Connection.cents_connstring);

            return results;
        }

        public IDictionary<string, string> check_package_socket(string socketID, string package_type)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT socket_id FROM socket WHERE socket_id = '" + socketID + "' AND package_type = '"+ package_type +"' AND status = 'IN-GOOD'";

            results = Connection.GetDataArray(query, "GET EXISTING DATA", Connection.cents_connstring);

            return results;
        }

        public IDictionary<string, string> get_handler_model_from_id(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT Equipt_Model, Equipt_PF FROM equipt_list WHERE Equipt_ID = '" + handlerID + "' AND Active = 1";

            results = Connection.GetDataArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.promis_connString);

            return results;
        }

        public IDictionary<string, string> check_valid_package(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT pkg_type FROM testers WHERE Handler_ID = '" + handlerID + "'";

            results = Connection.GetDataArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.promis_connString);

            return results;
        }

        public IDictionary<string, string> get_package_from_id(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT pkg_type FROM testers WHERE Handler_ID = '" + handlerID + "'";

            results = Connection.GetDataArray(query, "GET LOADBOARD DATA FROM MACHINE", Connection.promis_connString);

            return results;
        }

        public Boolean update_cents(string socketID, string package_type, string status, string handler_id, string handler_model, string released_to, string remarks, string userFullName)
        {
            IDictionary<string, string> cents_socket_results = new Dictionary<string, string>();
            //List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            string cents_get_query = "SELECT * FROM socket WHERE socket_id = '"+ socketID +"'";
            cents_socket_results = Connection.GetDataArray(cents_get_query, "CENTS DATA", Connection.cents_connstring);
            string query1 = "UPDATE socket SET handler_id = '" + handler_id + "', remarks = '"+ remarks +"', date_time = CURRENT_TIMESTAMP(), status = 'OUT-PROD' WHERE socket_id = '" + socketID + "'";
            Connection.ExecuteThisQuery(query1, "UPDATED SOCKET CENTS", Connection.cents_connstring);
            string query2 = "INSERT INTO socket_history (socket_id,family,package_type,part_no,dut_req,tst_pf,status,tester_id,handler_id,loc,storage,line,vendor,client,"+
            "clerk,sFile,pin_type,pin_count,shotcount,max_shotcount,site,remarks,gs_code,n_plus,date_time) VALUES ('"+ cents_socket_results["socket_id"] +"', '"+ cents_socket_results["family"] +
            "', '"+ cents_socket_results["package_type"] +"', '"+ cents_socket_results["part_no"] +"', '"+ cents_socket_results["dut_req"] +
            "', '"+ cents_socket_results["tst_pf"] +"', 'OUT_PROD', '"+ cents_socket_results["tester_id"] +"', '"+ handler_id +
            "', '"+ cents_socket_results["loc"] +"', '"+ cents_socket_results["storage"] +"', '"+ cents_socket_results["line"] +
            "', '"+ cents_socket_results["vendor"] + "', '" + userFullName + "', '" + released_to + "', '" + cents_socket_results["sFile"] +
            "', '"+ cents_socket_results["pin_type"] +"', '"+ cents_socket_results["pin_count"] +"', '"+ cents_socket_results["shotcount"] +
            "', '"+ cents_socket_results["max_shotcount"] +"', '"+ cents_socket_results["site"] +"', '"+ remarks +
            "', '"+ cents_socket_results["gs_code"] +"', '"+ cents_socket_results["n_plus"] +"', CURRENT_TIMESTAMP())";
            Boolean results = Connection.ExecuteThisQuery(query2, "GET USER INFO", Connection.cents_connstring);

            return results;
        }

        //LOT USER VALIDATION

        public IDictionary<string,string> lot_id_validation(string FFID) 
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM lot_approvers WHERE FFID = '"+ FFID +"'";

            results = Connection.GetDataArray(query, "GET DATA FROM LOT USERS", Connection.expert_connstring);

            if (results.Values.Count > 0)
            {
                results["validUser"] = "TRUE";
                return results;
            }

            else
            {
                results["validUser"] = "FALSE";
                results["FFID"] = "INVALID";
                return results;
            }

            
        }

        public IDictionary<string, string> sched_validation(string FFID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            string query = "SELECT * FROM sched_approvers WHERE FFID = '" + FFID + "'";

            results = Connection.GetDataArray(query, "GET DATA FROM LOT USERS", Connection.expert_connstring);

            if (results.Values.Count > 0)
            {
                results["validUser"] = "TRUE";
                return results;
            }

            else
            {
                results["validUser"] = "FALSE";
                results["FFID"] = "INVALID";
                return results;
            }


        }

    }
}
