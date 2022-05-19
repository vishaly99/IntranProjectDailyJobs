﻿using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string CompanyUsername { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set; }
        public string Type { get; set; }
        public int? Status { get; set; }
        public int? Points { get; set; }
        public string Website { get; set; }
        public string Linkdin { get; set; }
        public string Glassdoor { get; set; }
        public string Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsTest { get; set; }
        public int? InsBy { get; set; }
        public DateTime? InsDt { get; set; }
        public int? UpdBy { get; set; }
        public DateTime? UpdDt { get; set; }
        public int? DelBy { get; set; }
        public DateTime? DetDt { get; set; }
    }
}
