//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SAL.EFLib
{
    public partial class SiteVisitAssignment
    {
        public int row_id { get; set; }
        public Nullable<int> SiteVisitID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<bool> isLead { get; set; }
        public bool isDelete { get; set; }
        public Nullable<System.DateTime> dt_created { get; set; }
        public Nullable<int> created_UID { get; set; }
        public Nullable<System.DateTime> dt_last_updated { get; set; }
        public Nullable<int> last_updated_UID { get; set; }
        public Nullable<System.Guid> RowGuid { get; set; }
    }
    
}
