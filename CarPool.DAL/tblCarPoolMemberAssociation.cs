//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarPool.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCarPoolMemberAssociation
    {
        public int AssociationId { get; set; }
        public Nullable<int> CarPoolId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DDate { get; set; }
        public Nullable<int> IsApproved { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual tblCarPoolRegistration tblCarPoolRegistration { get; set; }
        public virtual tblMember tblMember { get; set; }
    }
}