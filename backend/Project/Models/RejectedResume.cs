using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class RejectedResume
    {
        public int Id { get; set; }
        public int Resumeid { get; set; }
        public string Companyid { get; set; }
        public string Candidatename { get; set; }
        public string Gender { get; set; }
        public string Skill { get; set; }
        public string Contactno { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Highestqualification { get; set; }
        public string Previouscompany { get; set; }
        public int? Approved { get; set; }
        public DateTime RejectedAt { get; set; }
    }
}
