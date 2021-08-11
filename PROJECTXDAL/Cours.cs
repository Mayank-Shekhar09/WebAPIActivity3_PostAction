//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJECTXDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cours()
        {
            this.BatchCourseFacultyMappings = new HashSet<BatchCourseFacultyMapping>();
            this.FacultyCourseMappings = new HashSet<FacultyCourseMapping>();
            this.DeliveryModels = new HashSet<DeliveryModel>();
        }
    
        public string CourseId { get; set; }
        public string CourseTitle { get; set; }
        public Nullable<int> CourseDuration { get; set; }
        public string CourseMode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BatchCourseFacultyMapping> BatchCourseFacultyMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacultyCourseMapping> FacultyCourseMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryModel> DeliveryModels { get; set; }
    }
}