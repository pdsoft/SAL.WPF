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
    public partial class tblLOV_Category
    {
        public int row_id { get; set; }
        public string category { get; set; }
        public string code { get; set; }
        public string desc { get; set; }
        public string add_flg { get; set; }
        public string edit_flg { get; set; }
        public System.DateTime dt_created { get; set; }
        public string created_by { get; set; }
        public System.DateTime dt_last_updated { get; set; }
        public string last_updated_by { get; set; }
        public short modification_num { get; set; }
        public string display_flg { get; set; }
        public string delete_flg { get; set; }
        public Nullable<System.Guid> RowGuid { get; set; }
    }
    
}
