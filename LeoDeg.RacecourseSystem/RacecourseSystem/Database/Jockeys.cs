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
    
    public partial class Jockeys
    {
        public int Id { get; set; }
        public string License { get; set; }
        public string Rank { get; set; }
        public string AdditionalInfo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public string Country { get; set; }
    }
}
