//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 期中專題
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlanRef
    {
        public int planbridgeId { get; set; }
        public int planID { get; set; }
        public Nullable<int> projectID { get; set; }
    
        public virtual Plan Plan { get; set; }
        public virtual Project Project { get; set; }
    }
}
