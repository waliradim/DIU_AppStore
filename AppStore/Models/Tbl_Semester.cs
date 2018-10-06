//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Semester
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Semester()
        {
            this.Tbl_Project = new HashSet<Tbl_Project>();
            this.Tbl_AssignCourse = new HashSet<Tbl_AssignCourse>();
        }
    
        public int SemesterID { get; set; }
        [Required(ErrorMessage = "Please Insert Semester Name")] 
        [Display(Name = "Semester Name")] 
        [StringLength(45, ErrorMessage = "Maximum 45 character minimum 3", MinimumLength = 3)] 
        [DataType(DataType.Text)]

        public string SemesterName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Project> Tbl_Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AssignCourse> Tbl_AssignCourse { get; set; }
    }
}
