//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentPortal.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Training
    {
        public int TID { get; set; }
        public int StudId { get; set; }
        public string Technology { get; set; }
        public string Organization { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string TypeOfTraining { get; set; }
        public string ProjectLink { get; set; }
        public string Link { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
