using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Resume
    {
        public int Id { get; set; }
        public string ResumeId { get; set; }
        public string CompanyUsername { get; set; }
        public string Candidatename { get; set; }
        public string Gender { get; set; }
        public string Skill { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime? Dob { get; set; }
        public string Highestqulification { get; set; }
        public string Previouscompany { get; set; }
        public int? Approved { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsTest { get; set; }
        public int? InsBy { get; set; }
        public DateTime? InsDt { get; set; }
        public int? UpdBy { get; set; }
        public DateTime? UpdDt { get; set; }
        public int? DelBy { get; set; }
        public DateTime? DetDt { get; set; }
        public string Upload { get; set; }
        public string Type { get; set; }
    }
}
