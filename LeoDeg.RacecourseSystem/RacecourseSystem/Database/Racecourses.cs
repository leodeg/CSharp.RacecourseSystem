//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RacecourseSystem.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Racecourses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Nullable<int> HorseAmount { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
