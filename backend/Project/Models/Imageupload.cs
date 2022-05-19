using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Imageupload
    {
        public int Id { get; set; }
        public string Imagepath { get; set; }
        public DateTime? InsertedOn { get; set; }
    }
}
