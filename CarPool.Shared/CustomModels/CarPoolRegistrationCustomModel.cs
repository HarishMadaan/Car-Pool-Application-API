using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.Shared.CustomModels
{
    public class CarPoolRegistrationCustomModel
    {

        public int Id { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string MemberName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public Nullable<System.DateTime> PoolDate { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public Nullable<double> Charges { get; set; }
        public Nullable<int> SeatsAvailable { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }

    }
}
