//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tracker.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentResponse
    {
        public int questionId { get; set; }
        public int studentId { get; set; }
        public string response { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual Student Student { get; set; }
    }
}