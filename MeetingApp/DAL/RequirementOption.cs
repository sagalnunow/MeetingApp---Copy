//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeetingApp.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequirementOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RequirementOption()
        {
            this.MeetingEmployees = new HashSet<MeetingEmployee>();
        }
    
        public int Id { get; set; }
        public Nullable<bool> IsRequired { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetingEmployee> MeetingEmployees { get; set; }
    }
}
