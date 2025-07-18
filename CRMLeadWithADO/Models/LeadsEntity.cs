﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMLeadWithADO.Models
{
    public class LeadsEntity
    {
        [Key]
        [DisplayName("Lead Id")]
        public int Id { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime LeadDate { get; set; }

        public string? Name { get; set; }

        [DisplayName("Email Address")]
        public string? EmailAddress { get; set; }

        [DisplayName("Contact Number")]
        public string Mobile { get; set; }

        [DisplayName("Lead Source")]
        public string LeadSource { get; set; }

        [DisplayName("Lead Status")]
        public string LeadStatus { get; set; }
        
        [DisplayName("Follow Up Date")]
        [DataType(DataType.Date)]
        public DateTime? NextFollowUpDate { get; set; }
    }
}
