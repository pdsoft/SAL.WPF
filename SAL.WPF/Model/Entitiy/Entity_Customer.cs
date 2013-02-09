using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAL.Model
{
    #region customer
    public class Site
    {
        public int Sys_ID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int numEqipment { get; set; }
        public string LastVisit { get; set; }
        public string LastReport { get; set; }
    }

    public class Agreement
    {
        public int Sys_ID { get; set; }
        public string AgreementNum { get; set; }
        public string DateSigned { get; set; }
        public string DateEffective { get; set; }
        public string DateExpiry { get; set; }
        public string Site { get; set; }
    }

    public class Contact
    {
        public int Sys_ID { get; set; }
        public string Name { get; set; }
        public bool Primary { get; set; }
        public string ContactType { get; set; }
        public string Title { get; set; }
        //public string Address { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        // public string Site { get; set; }
    }

    public class CustomerModel
    {
        // private Person[] _people;

        public IList<Site> Sites = new List<Site>();

        public IList<Agreement> Agreements = new List<Agreement>();

        public IList<Contact> Contacts = new List<Contact>();

        //------------------------------
        public void AddSite(Site obj)
        {
            this.Sites.Add(obj);
        }

        //------------------------------
        public void AddAgreement(Agreement obj)
        {
            this.Agreements.Add(obj);
        }

        //------------------------------
        public void AddContact(Contact obj)
        {
            this.Contacts.Add(obj);
        }
    }
    #endregion

}