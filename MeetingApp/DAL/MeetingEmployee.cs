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
    
    public partial class MeetingEmployee
    {
        public int Id { get; set; }
        public Nullable<int> Employee_Id { get; set; }
        public Nullable<int> Meeting_Id { get; set; }
        public Nullable<int> RequirementOption_Id { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual RequirementOption RequirementOption { get; set; }
    }
}
