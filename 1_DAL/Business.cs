//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Business
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Business()
        {
            this.Timelines = new HashSet<Timeline>();
        }
    
        public int businessID { get; set; }
        public string businessName { get; set; }
        public string businessOwnerID { get; set; }
        public string businessPhoneNo { get; set; }
        public string businessAddress { get; set; }
        public string businessCity { get; set; }
        public Nullable<bool> businessSpace { get; set; }
        public Nullable<int> noOfRegisters { get; set; }
    
        public virtual BusinessOwner BusinessOwner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeline> Timelines { get; set; }
    }
}
