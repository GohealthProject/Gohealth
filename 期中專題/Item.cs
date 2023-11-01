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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ReportDetails = new HashSet<ReportDetail>();
            this.ReportTests = new HashSet<ReportTest>();
            this.ReservedSubs = new HashSet<ReservedSub>();
            this.subProjectBridges = new HashSet<subProjectBridge>();
        }
    
        public int itemID { get; set; }
        public string itemName { get; set; }
        public string itemComment { get; set; }
        public Nullable<int> itemPrice { get; set; }
        public Nullable<int> projectID { get; set; }
        public string itemUnit { get; set; }
        public Nullable<int> itemRangeMin { get; set; }
        public Nullable<int> itemRangeMax { get; set; }
        public Nullable<int> Mmin { get; set; }
        public Nullable<int> Mmax { get; set; }
        public Nullable<int> Fmin { get; set; }
        public Nullable<int> Fmax { get; set; }
        public string itemRange { get; set; }
    
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportDetail> ReportDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportTest> ReportTests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservedSub> ReservedSubs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subProjectBridge> subProjectBridges { get; set; }
    }
}
