using System;
using System.Collections.Generic;

namespace CustomerCRUD.Models
{
    public partial class CustomersDatum
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }        
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
