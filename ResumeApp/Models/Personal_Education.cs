//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResumeApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personal_Education
    {
        public string Institute { get; set; }
        public string Location { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CandidateId { get; set; }
        public int id { get; set; }
    
        public virtual Personal_Info Personal_Info { get; set; }
    }
}
