using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Shared.CustomModels
{
    public class CarPoolAssociationCustomModel
    {
        public int AssociationId { get; set; }
        public Nullable<int> CarPoolId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> IsApproved { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DDate { get; set; }

        public string MemberName { get; set; }

    }
}
