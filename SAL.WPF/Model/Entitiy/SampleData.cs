using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace SAL.Model
{
    public class SampleData
    {
        public SampleData()
        { }

        public static CustomerModel GetCustomerData()
        {
            CustomerModel model = new CustomerModel();

            //------------------------------------------------------------- Sites
            model.AddSite(new Site
            {
                Sys_ID = 10001,
                Address = "Address 1",
                Phone = "416-222-2222",
                numEqipment = 50,
                LastVisit = "Scott | Dec/12/2011 - Dec/15/2011 | Energize | In-Progress"
            });

            model.AddSite(new Site
            {
                Sys_ID = 10002,
                Address = "Address 2",
                Phone = "416-222-2222",
                numEqipment = 35,
                LastVisit = "Peter | Dec/12/2010 - Dec/15/201 | De-Energize | Complete"
            });

            model.AddSite(new Site
            {
                Sys_ID = 10003,
                Address = "Address 3",
                Phone = "416-222-2222",
                numEqipment = 15,
                LastVisit = "-"
            });

            //------------------------------------------------------------- Agreement
            model.AddAgreement(new Agreement
            {
                Sys_ID = 5001,
                AgreementNum = "T20-1516",
                DateSigned = "10-Jan-2010",
                DateEffective = "01-Mar-2010",
                DateExpiry = "28-Feb-2013"
            });

            model.AddAgreement(new Agreement
            {
                Sys_ID = 5002,
                AgreementNum = "T30-1576",
                DateSigned = "10-Jan-2010",
                DateEffective = "01-Mar-2010",
                DateExpiry = "28-Feb-2013"
            });

            //------------------------------------------------------------- Contact
            model.AddContact(new Contact
            {
                Sys_ID = 20001,
                Name = "Geoffrey Li",
                ContactType = "",
                Title = "Manager",
                phone = "",
                fax = "",
                email = ""
            });

            model.AddContact(new Contact
            {
                Sys_ID = 20002,
                Name = "stepphan Armstrong",
                ContactType = "",
                phone = "",
                fax = "",
                email = ""
            });

            return model;
        }

        public static SiteModel GetSiteData()
        {
            SiteModel model = new SiteModel();

            //------------------------------------------------------------- Sites
            model.AddEquipment(new Equipment
            {
                Sys_ID = "EQP10001",
                AssetID = "20-150-2111 (A)",
                Type = "Switch",
                Location = "Power Panel in Basement",
                FedFrom = "",
                ProblemExist = "N"
            });
            model.AddEquipment(new Equipment
            {
                Sys_ID = "EQP10002",
                AssetID = "20-150-2111 (B)",
                Type = "Switch",
                Location = "Power Panel in Basement",
                FedFrom = "",
                ProblemExist = "N"
            });
            model.AddEquipment(new Equipment
            {
                Sys_ID = "EQP10003",
                AssetID = "20-150-2114",
                Type = "Switch",
                Location = "Power Panel in Basement",
                FedFrom = "",
                ProblemExist = "N"
            });


            //------------------------------------------------------------- visit
            model.AddVisit(new Visit
            {
                Sys_ID = "5001",
                VisitBy = "Geoffrey Li",
                ExpectDate = "Dec/13/2012 - Dec/20/2012",
                ActualDate = "Dec/13/2012 - Dec/20/2012",
                Status = "Complete"
            });
            model.AddVisit(new Visit
            {
                Sys_ID = "5002",
                VisitBy = "Geoffrey Li",
                ExpectDate = "Dec/13/2012 - Dec/20/2012",
                ActualDate = "Dec/13/2012 - Dec/20/2012",
                Status = "Complete"
            });
            model.AddVisit(new Visit
            {
                Sys_ID = "5003",
                VisitBy = "Geoffrey Li",
                ExpectDate = "Dec/13/2012 - Dec/20/2012",
                ActualDate = "Dec/13/2012 - Dec/20/2012",
                Status = "Complete"
            });

            //------------------------------------------------------------- Attachment
            model.AddAttachment(new Attachment
            {
                Sys_ID = "20001",
                FileName ="De-energize Form 10/Dec/2011",
                Type = "Image",
                Logged_by = "Geoffrey Li",
                ShortDesc = "Baseline photo"
            });

            model.AddAttachment(new Attachment
            {
                Sys_ID = "20002",
                FileName = "De-energize Form 10/Dec/2011",
                Type = "Image",
                Logged_by = "Geoffrey Li",
                ShortDesc = "Problem photo"
            });

            model.AddAttachment(new Attachment
            {
                Sys_ID = "20003",
                FileName = "De-energize Form 10/Dec/2011",
                Type = "Form",
                Logged_by = "Geoffrey Li",
                ShortDesc = "De-energize form"
            });

            return model;
        }

        public static EquipmentModel GetEquipmentData()
        {
            EquipmentModel model = new EquipmentModel();
            
            #region Atrribute
            //-------------------------------------------- attribute
            model.AddAttributeValue(new AttributeValue
            {
                Sys_ID = "ATT10001",
                AttributeType = "Distribution Panel",
                AttributeName = "Ambient Temperature",
                Value=  "200",
                Unit = "degrees C"
            });

            model.AddAttributeValue(new AttributeValue
            {
                Sys_ID = "ATT10002",
                AttributeType = "Distribution Panel",
                AttributeName = "Humidity",
                Value = "30",
                Unit = "%"
            });

            model.AddAttributeValue(new AttributeValue
            {
                Sys_ID = "ATT10003",
                AttributeType = "Distribution Panel",
                AttributeName = "Bus Voltage",
                Value = "250",
                Unit = "volts"
            });

           #endregion

            #region Problem
            //------------------------------------------------------------- Problem
            model.AddProblem(new Problem
            {
                Sys_ID = "PRO1001",
                SiteVisit = "02-Feb-2011 ~ 05-Feb-2011",
                ProblemType = "PROTECTION",
                ProblemDesc = "Unused openings in boxes, cabinets and fittings.  ( 12-3026 O.E.S.C. )",
                ProblemSeverity = "Critical",
                ProblemImage = "",
                Recommendation = "Install appropriate size of  knock out filler 1,  1-1/4 in to cover opening.",
                WorkLog = "",
                DateFound = "02-Feb-2011",
                DateFixed= "",
            });

            model.AddProblem(new Problem
            {
                Sys_ID = "PRO1002",
                SiteVisit = "02-Feb-2011 ~ 05-Feb-2011",
                ProblemType = "other",
                ProblemDesc = "Improper lug used for #10 AWG wire.  Lug good for 500 MCM to 2/0 wire.",
                ProblemSeverity = "Critical",
                ProblemImage = "",
                Recommendation = "Replace lug to accommodate for #10 AWG wire.",
                WorkLog = "",
                DateFound = "02-Feb-2011",
                DateFixed = "",
            });

            #endregion

            #region CustomerInput
            //------------------------------------------------------------- CustomerInput
            model.AddCustomerInput(new CustomerInput
            {
                Sys_ID = "10001",
                Type = "GENERAL",
                Description = "This equipement was hdg dg jsdg dg g sdg dsgfdg gf gf",
                InputBy = "Jeff 20/Jan/2011",
                AttachmentLink = ""
            });

            model.AddCustomerInput(new CustomerInput
            {
                Sys_ID = "10002",
                Type = "GENERAL",
                Description = "Manufacturer Diagram",
                InputBy = "Jeff 20/Jan/2011",
                AttachmentLink = ""
            });
            #endregion

            return model;
        }

        public static WorkflowModel GetWorkfowData()
        {
            WorkflowModel model = new WorkflowModel();

            //------------------------------------------------------------- Pending
            model.AddPendingList(new WorkflowPending 
            {
                Task_ID = "TASK10001",
                select = false,
                customer = "Environment Canada",
                agreement = "T20-1516", 
                site = "Address 1",
                NumofEquipment = "200 of 500", 
                JobType = "Energize", 
                LoggedBy = "Jeff Dec/30/2012"
            });

            //------------------------------------------------------------- Progress
            model.AddProgressList(new WorkflowInProgress
            {
                Task_ID = "TASK10001",
                select = false,
                customer = "Environment Canada",
                agreement = "T20-1516",
                site = "Address 1",
                NumofEquipment = "200 of 500",
                JobType = "Energize",
                AssignmentSynchStatu = "Jeffrey -  not Synched<br>Hong - Synched on Dec/28/2012"
            });


            //------------------------------------------------------------- Complete
            model.AddCompleteList(new WorkflowComplete
            {
                Task_ID = "TASK10001",
                select = false,
                customer = "Environment Canada",
                agreement = "T20-1516",
                site = "Address 1",
                JobType = "Energize",
                Expected_dates = "",
                ActualDates = "",
                problem_exist = false,
                Report = ""
            });

            return model;
        }

    }
}