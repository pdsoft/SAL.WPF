using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAL.Model
{

    #region Site
    public class Equipment
    {
        public string Sys_ID { get; set; }
        public string AssetID { get; set; }
        public string FedFrom { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string LastVisit { get; set; }
        public string ProblemExist { get; set; }
    }

    public class Visit
    {
        public string Sys_ID { get; set; }
        public string VisitBy { get; set; }
        public string ExpectDate { get; set; }
        public string ActualDate { get; set; }
        public string Status { get; set; }
    }

    public class SiteContact
    {
        public string Sys_ID { get; set; }
        public string Name { get; set; }
        public string ContactType { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
    }

    public class Attachment
    {
        public string Sys_ID { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Logged_by { get; set; }
        public string ShortDesc { get; set; }
    }

    public class SiteModel
    {
        // private Person[] _people;

        public IList<Equipment> Equipments = new List<Equipment>();

        public IList<Visit> Visits = new List<Visit>();

        public IList<Attachment> Attachments = new List<Attachment>();

        public IList<SiteContact> Contacts = new List<SiteContact>();

        //------------------------------
        public void AddEquipment(Equipment obj)
        {
            this.Equipments.Add(obj);
        }

        //------------------------------
        public void AddVisit(Visit obj)
        {
            this.Visits.Add(obj);
        }

        //------------------------------
        public void AddAttachment(Attachment obj)
        {
            this.Attachments.Add(obj);
        }

        //------------------------------
        public void AddContact(SiteContact obj)
        {
            this.Contacts.Add(obj);
        }
    }
    #endregion

}