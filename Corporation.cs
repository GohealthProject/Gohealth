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
    
    public partial class Corporation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Corporation()
        {
            this.Members = new HashSet<Member>();
        }
    
        public int taxID { get; set; }
        public string corporation1 { get; set; }
        public Nullable<double> discount { get; set; }
        public int contactnumber { get; set; }
        public string address { get; set; }
        public string middleman { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
