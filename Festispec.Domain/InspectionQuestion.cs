//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Festispec.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class InspectionQuestion : Question
    {
        public string Answer { get; set; }
        public int Planning_Inspection_Id { get; set; }
        public int Planning_Inspector_Id { get; set; }
        public System.DateTime Planning_Date { get; set; }
    
        public virtual Planning Planning { get; set; }
    }
}
