//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRenting_v2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Driver_License
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver_License()
        {
            this.Client_Licenses = new HashSet<Client_Licenses>();
        }
    
        public int ID_License { get; set; }
        public string DriverID { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public string HairColor { get; set; }
        public string EyesColor { get; set; }
        public double Height { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client_Licenses> Client_Licenses { get; set; }
    }
}
