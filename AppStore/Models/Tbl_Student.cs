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
    
    public partial class Tbl_Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Student()
        {
            this.Tbl_Project = new HashSet<Tbl_Project>();
        }
    
        public int SID { get; set; }
        public string Sname { get; set; }
        public string Stid { get; set; }
        
        public Nullable<int> Sbatch { get; set; }
        public string SEmail { get; set; }
        public string Sphone { get; set; }
        public string SuserName { get; set; }
        public string Spassword { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Project> Tbl_Project { get; set; }
    }
}
