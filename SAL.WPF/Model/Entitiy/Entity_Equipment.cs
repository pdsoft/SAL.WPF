using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAL.Model
{

    #region Site
    public class AttributeValue
    {
        public string Sys_ID { get; set; }
        public string AttributeType { get; set; }
        public string AttributeName { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }

    public class Problem
    {
        public string Sys_ID { get; set; }
        public string SiteVisit { get; set; }
        public string ProblemType { get; set; }
        public string ProblemDesc { get; set; }
        public string ProblemSeverity { get; set; }
        public string ProblemImage { get; set; }
        public string Recommendation { get; set; }
        public string WorkLog { get; set; }
        public string DateFound { get; set; }
        public string DateFixed { get; set; }
    }

    public class CustomerInput
    {
        public string Sys_ID { get; set; }
        public string Type { get; set; }
        public string InputBy { get; set; }
        public string Description { get; set; }
        public string AttachmentLink { get; set; }
    }

    public class ApplicationSafety
    {
        public string Sys_ID { get; set; }
        public string Type { get; set; }
        public string Notice { get; set; }
        public string Doc_link { get; set; }
    }

    public class EquipmentModel
    {
        // private Person[] _people;

        public IList<AttributeValue> AttributeValues = new List<AttributeValue>();

        public IList<Problem> Problems = new List<Problem>();

        public IList<CustomerInput> CustomerInputs = new List<CustomerInput>();

        public IList<ApplicationSafety> ApplicationSafetys = new List<ApplicationSafety>(); 

        //------------------------------
        public void AddAttributeValue(AttributeValue obj)
        {
            this.AttributeValues.Add(obj);
        }

        //------------------------------
        public void AddProblem(Problem obj)
        {
            this.Problems.Add(obj);
        }

        //------------------------------
        public void AddCustomerInput(CustomerInput obj)
        {
            this.CustomerInputs.Add(obj);
        }

        //------------------------------
        public void AddApplicationSafety(ApplicationSafety obj)
        {
            this.ApplicationSafetys.Add(obj);
        }
    }
    #endregion

}