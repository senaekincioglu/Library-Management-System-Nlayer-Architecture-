//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management_System_DAL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Movement = new HashSet<Movement>();
        }
    
        public byte Id { get; set; }
        public string Employees { get; set; }
    
        public virtual ICollection<Movement> Movement { get; set; }
    }
}