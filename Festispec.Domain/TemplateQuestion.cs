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
    
    public partial class TemplateQuestion
    {
        public int Template_Id { get; set; }
        public int Question_Id { get; set; }
    
        public virtual Template Template { get; set; }
        public virtual Question Question { get; set; }
    }
}
