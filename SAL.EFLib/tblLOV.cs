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
    public partial class tblLOV
    {
        public int row_id { get; set; }
        public string category_code { get; set; }
        public string LOV_code { get; set; }
        public short sequence_num { get; set; }
        public string value { get; set; }
        public string alt_value { get; set; }
        public string select_flg1 { get; set; }
        public string select_flg2 { get; set; }
        public string select_flg3 { get; set; }
        public string par_LOV_code { get; set; }
        public string workflow_flg { get; set; }
        public string Webform_flg { get; set; }
        public string status_flg { get; set; }
        public System.DateTime dt_created { get; set; }
        public string created_by { get; set; }
        public System.DateTime dt_last_updated { get; set; }
        public string last_updated_by { get; set; }
        public short modification_num { get; set; }
        public Nullable<System.Guid> RowGuid { get; set; }
    }
    
}
