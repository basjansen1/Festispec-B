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
    
    public partial class Planning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Planning()
        {
            this.Questions = new HashSet<InspectionQuestion>();
        }
    
        public int Inspection_Id { get; set; }
        public int Inspector_Id { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan TimeFrom { get; set; }
        public System.TimeSpan TimeTo { get; set; }
        public Nullable<System.TimeSpan> Hours { get; set; }
    
        public virtual Inspection Inspection { get; set; }
        public virtual Inspector Inspector { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InspectionQuestion> Questions { get; set; }
    }
}
